﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elfie.Serialization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Uno.Disposables;
using Uno.Extensions;
using Uno.UI.RemoteControl.HotReload;
using Uno.UI.RemoteControl.HotReload.Messages;
using Uno.UI.RemoteControl.Messaging.HotReload;
using Uno.UI.RemoteControl.Messaging.IdeChannel;

[assembly: Uno.UI.RemoteControl.Host.ServerProcessorAttribute(typeof(Uno.UI.RemoteControl.Host.HotReload.ServerHotReloadProcessor))]

namespace Uno.UI.RemoteControl.Host.HotReload
{
	partial class ServerHotReloadProcessor : IServerProcessor, IDisposable
	{
		private readonly IRemoteControlServer _remoteControlServer;

		public ServerHotReloadProcessor(IRemoteControlServer remoteControlServer)
		{
			_remoteControlServer = remoteControlServer;
		}

		public string Scope => WellKnownScopes.HotReload;

		public async Task ProcessFrame(Frame frame)
		{
			switch (frame.Name)
			{
				case ConfigureServer.Name:
					ProcessConfigureServer(frame.GetContent<ConfigureServer>());
					break;
				case XamlLoadError.Name:
					ProcessXamlLoadError(frame.GetContent<XamlLoadError>());
					break;
				case UpdateFile.Name:
					await ProcessUpdateFile(frame.GetContent<UpdateFile>());
					break;
			}
		}

		/// <inheritdoc />
		public async Task ProcessIdeMessage(IdeMessage message, CancellationToken ct)
		{
			switch (message)
			{
				case HotReloadRequestedIdeMessage hrRequested:
					// Note: For now the IDE will notify the ProcessingFiles only in case of force hot reload request sent by client!
					await Notify(HotReloadEvent.ProcessingFiles, HotReloadEventSource.IDE);
					if (_pendingHotReloadRequestToIde.TryGetValue(hrRequested.RequestId, out var request))
					{
						request.TrySetResult(hrRequested.Result);
					}
					break;

				case HotReloadEventIdeMessage evt:
					await Notify(evt.Event, HotReloadEventSource.IDE);
					break;
			}
		}

		#region Hot-relaod state
		private HotReloadState _globalState; // This actually contains only the initializing stat (i.e. Disabled, Initializing, Idle). Processing state is _current != null.
		private HotReloadServerOperation? _current; // I.e. head of the operation chain list

		public enum HotReloadEventSource
		{
			IDE,
			DevServer
		}

		private async ValueTask EnsureHotReloadStarted()
		{
			if (_current is null)
			{
				await StartHotReload(null);
			}
		}

		private async ValueTask<HotReloadServerOperation> StartHotReload(ImmutableHashSet<string>? filesPaths)
		{
			var previous = _current;
			HotReloadServerOperation? current, @new;
			while (true)
			{
				@new = new HotReloadServerOperation(this, previous, filesPaths);
				current = Interlocked.CompareExchange(ref _current, @new, previous);
				if (current == previous)
				{
					break;
				}
				else
				{
					previous = current;
				}
			}

			// Notify the start of new hot-reload operation
			await SendUpdate();

			return @new;
		}

		private async ValueTask<HotReloadServerOperation> StartOrContinueHotReload(ImmutableHashSet<string>? filesPaths = null)
			=> _current is { } current && (filesPaths is null || current.TryMerge(filesPaths))
				? current
				: await StartHotReload(filesPaths);

		private ValueTask AbortHotReload()
			=> _current?.Complete(HotReloadServerResult.Aborted) ?? SendUpdate();

		private async ValueTask Notify(HotReloadEvent evt, HotReloadEventSource source = HotReloadEventSource.DevServer)
		{
			switch (evt)
			{
				// Global state events
				case HotReloadEvent.Disabled:
					_globalState = HotReloadState.Disabled;
					await AbortHotReload();
					break;

				case HotReloadEvent.Initializing:
					_globalState = HotReloadState.Initializing;
					await SendUpdate();
					break;

				case HotReloadEvent.Ready:
					_globalState = HotReloadState.Ready;
					await SendUpdate();
					break;

				// Pending hot-reload events
				case HotReloadEvent.ProcessingFiles:
					await EnsureHotReloadStarted();
					break;

				case HotReloadEvent.Completed:
					await (await StartOrContinueHotReload()).DeferComplete(HotReloadServerResult.Success);
					break;

				case HotReloadEvent.NoChanges:
					await (await StartOrContinueHotReload()).Complete(HotReloadServerResult.NoChanges);
					break;
				case HotReloadEvent.Failed:
					await (await StartOrContinueHotReload()).Complete(HotReloadServerResult.Failed);
					break;

				case HotReloadEvent.RudeEdit:
					await (await StartOrContinueHotReload()).Complete(HotReloadServerResult.RudeEdit);
					break;
			}
		}

		private async ValueTask SendUpdate(HotReloadServerOperation? completing = null)
		{
			var state = _globalState;
			var operations = ImmutableList<HotReloadServerOperationData>.Empty;

			if (state is not HotReloadState.Disabled && (_current ?? completing) is { } current)
			{
				var infos = ImmutableList.CreateBuilder<HotReloadServerOperationData>();
				var foundCompleting = completing is null;
				LoadInfos(current);
				if (!foundCompleting)
				{
					LoadInfos(completing);
				}

				operations = infos.ToImmutable();

				void LoadInfos(HotReloadServerOperation? operation)
				{
					while (operation is not null)
					{
						if (operation.Result is null)
						{
							state = HotReloadState.Processing;
						}

						foundCompleting |= operation == completing;
						infos.Add(new(operation.Id, operation.StartTime, operation.FilePaths, operation.CompletionTime, operation.Result));
						operation = operation.Previous!;
					}
				}
			}

			await _remoteControlServer.SendFrame(new HotReloadStatusMessage(state, operations));
		}

		/// <summary>
		/// A hot-reload operation that is in progress.
		/// </summary>
		private class HotReloadServerOperation
		{
			public readonly static int DefaultAutoRetryIfNoChangesAttempts = 3;

			public readonly static TimeSpan DefaultAutoRetryIfNoChangesDelay = TimeSpan.FromMilliseconds(500);

			// Delay to wait without any update to consider operation was aborted.
			private static readonly TimeSpan _timeoutDelay = TimeSpan.FromSeconds(30);

			private static readonly ImmutableHashSet<string> _empty = ImmutableHashSet<string>.Empty.WithComparer(_pathsComparer);
			private static long _count;

			private readonly ServerHotReloadProcessor _owner;
			private readonly HotReloadServerOperation? _previous;
			private readonly Timer _timeout;

			private ImmutableHashSet<string> _filePaths;
			private int /* HotReloadResult */ _result = -1;
			private CancellationTokenSource? _deferredCompletion;

			// In VS we forcefully request to VS to hot-reload application, but in some cases the changes are not detected by VS and it returns a NoChanges result.
			// In such cases we can retry the hot-reload request to VS to let it process the file updates.
			private int _noChangesRetry;
			private TimeSpan _noChangesRetryDelay = DefaultAutoRetryIfNoChangesDelay;

			public long Id { get; } = Interlocked.Increment(ref _count);

			public DateTimeOffset StartTime { get; } = DateTimeOffset.Now;

			public DateTimeOffset? CompletionTime { get; private set; }

			public HotReloadServerOperation? Previous => _previous;

			public ImmutableHashSet<string> FilePaths => _filePaths;

			public HotReloadServerResult? Result => _result is -1 ? null : (HotReloadServerResult)_result;

			/// <param name="previous">The previous hot-reload operation which has to be considered as aborted when this new one completes.</param>
			public HotReloadServerOperation(ServerHotReloadProcessor owner, HotReloadServerOperation? previous, ImmutableHashSet<string>? filePaths = null)
			{
				_owner = owner;
				_previous = previous;
				_filePaths = filePaths ?? _empty;

				_timeout = new Timer(
					static that => _ = ((HotReloadServerOperation)that!).Complete(HotReloadServerResult.Aborted),
					this,
					_timeoutDelay,
					Timeout.InfiniteTimeSpan);
			}

			/// <summary>
			/// Attempts to update the <see cref="FilePaths"/> if we determine that the provided paths are corresponding to this operation.
			/// </summary>
			/// <returns>
			/// True if this operation should be considered as valid for the given file paths (and has been merged with original paths),
			/// false if the given paths does not belong to this operation.
			/// </returns>
			public bool TryMerge(ImmutableHashSet<string> filePaths)
			{
				if (_result is not -1)
				{
					return false;
				}

				var original = _filePaths;
				while (true)
				{
					ImmutableHashSet<string> updated;
					if (original.IsEmpty)
					{
						updated = filePaths;
					}
					else if (original.Any(filePaths.Contains))
					{
						updated = original.Union(filePaths);
					}
					else
					{
						return false;
					}

					var current = Interlocked.CompareExchange(ref _filePaths, updated, original);
					if (current == original)
					{
						_timeout.Change(_timeoutDelay, Timeout.InfiniteTimeSpan);
						return true;
					}
					else
					{
						original = current;
					}
				}
			}

			/// <summary>
			/// Configure a simple auto-retry strategy if no changes are detected.
			/// </summary>
			public void EnableAutoRetryIfNoChanges(int? attempts, TimeSpan? delay)
			{
				_noChangesRetry = attempts ?? DefaultAutoRetryIfNoChangesAttempts;
				_noChangesRetryDelay = delay ?? DefaultAutoRetryIfNoChangesDelay;
			}

			/// <summary>
			/// As errors might get a bit after the complete from the IDE, we can defer the completion of the operation.
			/// </summary>
			public async ValueTask DeferComplete(HotReloadServerResult result, Exception? exception = null)
			{
				Debug.Assert(result != HotReloadServerResult.InternalError || exception is not null); // For internal error we should always provide an exception!

				if (Interlocked.CompareExchange(ref _deferredCompletion, new CancellationTokenSource(), null) is null)
				{
					_timeout.Change(_timeoutDelay, Timeout.InfiniteTimeSpan);
					await Task.Delay(TimeSpan.FromSeconds(1), _deferredCompletion.Token);
					if (!_deferredCompletion.IsCancellationRequested)
					{
						await Complete(result, exception);
					}
				}
			}

			public ValueTask Complete(HotReloadServerResult result, Exception? exception = null)
				=> Complete(result, exception, isFromNext: false);

			private async ValueTask Complete(HotReloadServerResult result, Exception? exception, bool isFromNext)
			{
				if (_result is -1
					&& result is HotReloadServerResult.NoChanges
					&& Interlocked.Decrement(ref _noChangesRetry) >= 0)
				{
					if (_noChangesRetryDelay is { TotalMilliseconds: > 0 })
					{
						await Task.Delay(_noChangesRetryDelay);
					}

					if (await _owner.RequestHotReloadToIde(Id))
					{
						return;
					}
				}

				Debug.Assert(result != HotReloadServerResult.InternalError || exception is not null); // For internal error we should always provide an exception!

				// Remove this from current
				Interlocked.CompareExchange(ref _owner._current, null, this);
				_deferredCompletion?.Cancel(false); // No matter if already completed

				// Check if not already disposed
				if (Interlocked.CompareExchange(ref _result, (int)result, -1) is not -1)
				{
					return; // Already completed
				}

				CompletionTime = DateTimeOffset.Now;
				await _timeout.DisposeAsync();

				// Consider previous hot-reload operation(s) as aborted (this is actually a chain list)
				if (_previous is not null)
				{
					await _previous.Complete(
						HotReloadServerResult.Aborted,
						new TimeoutException("An more recent hot-reload operation has completed."),
						isFromNext: true);
				}

				if (!isFromNext) // Only the head of the list should request update
				{
					await _owner.SendUpdate(this);
				}
			}
		}
		#endregion

		#region XamlLoadError
		private void ProcessXamlLoadError(XamlLoadError xamlLoadError)
		{
			if (this.Log().IsEnabled(LogLevel.Error))
			{
				this.Log().LogError(
					$"The XAML file failed to load [{xamlLoadError.FilePath}]\n" +
					$"{xamlLoadError.ExceptionType}: {xamlLoadError.Message}\n" +
					$"{xamlLoadError.StackTrace}");
			}
		}
		#endregion

		#region ConfigureServer
		private void ProcessConfigureServer(ConfigureServer configureServer)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug($"Base project path: {configureServer.ProjectPath}");
			}

			if (InitializeMetadataUpdater(configureServer))
			{
				this.Log().LogDebug($"Metadata updater initialized");
			}
			else
			{
				// We are relying on IDE, we won't have any other hot-reload initialization steps.
				_ = Notify(HotReloadEvent.Ready);
				this.Log().LogDebug("Metadata updater **NOT** initialized.");
			}
		}
		#endregion

		#region UpdateFile
		private readonly ConcurrentDictionary<long, TaskCompletionSource<Result>> _pendingHotReloadRequestToIde = new();

		private async Task ProcessUpdateFile(UpdateFile message)
		{
			var hotReload = await StartHotReload(ImmutableHashSet<string>.Empty.Add(Path.GetFullPath(message.FilePath)));

			try
			{
				var (result, error) = message switch
				{
					{ FilePath: null or { Length: 0 } } => (FileUpdateResult.BadRequest, "Invalid request (file path is empty)"),
					{ OldText: not null, NewText: not null } => await DoUpdate(message.OldText, message.NewText),
					{ OldText: null, NewText: not null } => await DoWrite(message.NewText),
					{ NewText: null, IsCreateDeleteAllowed: true } => await DoDelete(),
					_ => (FileUpdateResult.BadRequest, "Invalid request")
				};
				if ((int)result < 300 && !message.IsForceHotReloadDisabled)
				{
					hotReload.EnableAutoRetryIfNoChanges(message.ForceHotReloadAttempts, message.ForceHotReloadDelay);
					await RequestHotReloadToIde(hotReload.Id);
				}

				await _remoteControlServer.SendFrame(new UpdateFileResponse(message.RequestId, message.FilePath ?? "", result, error, hotReload.Id));
			}
			catch (Exception ex)
			{
				await hotReload.Complete(HotReloadServerResult.InternalError, ex);
				await _remoteControlServer.SendFrame(new UpdateFileResponse(message.RequestId, message.FilePath ?? "", FileUpdateResult.Failed, ex.Message));
			}

			async ValueTask<(FileUpdateResult, string?)> DoUpdate(string oldText, string newText)
			{
				if (!File.Exists(message.FilePath))
				{
					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().LogDebug($"Requested file '{message.FilePath}' does not exists [{message.RequestId}].");
					}

					return (FileUpdateResult.FileNotFound, $"Requested file '{message.FilePath}' does not exists.");
				}

				var originalContent = await File.ReadAllTextAsync(message.FilePath);
				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().LogTrace($"Original content: {originalContent} [{message.RequestId}].");
				}

				var updatedContent = originalContent.Replace(oldText, newText);
				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().LogTrace($"Updated content: {updatedContent} [{message.RequestId}].");
				}

				if (updatedContent == originalContent)
				{
					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().LogDebug($"No changes detected in {message.FilePath} [{message.RequestId}].");
					}

					return (FileUpdateResult.NoChanges, null);
				}

				var effectiveUpdate = WaitForFileUpdated();
				await File.WriteAllTextAsync(message.FilePath, updatedContent);
				await effectiveUpdate;

				return (FileUpdateResult.Success, null);
			}

			async ValueTask<(FileUpdateResult, string?)> DoWrite(string newText)
			{
				if (!message.IsCreateDeleteAllowed && !File.Exists(message.FilePath))
				{
					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().LogDebug($"Requested file '{message.FilePath}' does not exists [{message.RequestId}].");
					}

					return (FileUpdateResult.FileNotFound, $"Requested file '{message.FilePath}' does not exists.");
				}

				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().LogTrace($"Write content: {newText} [{message.RequestId}].");
				}

				var effectiveUpdate = WaitForFileUpdated();
				await File.WriteAllTextAsync(message.FilePath, newText);
				await effectiveUpdate;

				return (FileUpdateResult.Success, null);
			}

			async ValueTask<(FileUpdateResult, string?)> DoDelete()
			{
				if (!File.Exists(message.FilePath))
				{
					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().LogDebug($"Requested file '{message.FilePath}' does not exists [{message.RequestId}].");
					}

					return (FileUpdateResult.FileNotFound, $"Requested file '{message.FilePath}' does not exists.");
				}

				var effectiveUpdate = WaitForFileUpdated();
				File.Delete(message.FilePath);
				await effectiveUpdate;

				return (FileUpdateResult.Success, null);
			}

			async Task WaitForFileUpdated()
			{
				var file = new FileInfo(message.FilePath);
				var dir = file.Directory;
				while (dir is { Exists: false })
				{
					dir = dir.Parent;
				}

				if (dir is null)
				{
					return;
				}

				var tcs = new TaskCompletionSource();
				using var watcher = new FileSystemWatcher(dir.FullName);
				watcher.Changed += async (snd, e) =>
				{
					if (e.FullPath.Equals(file.FullName, StringComparison.OrdinalIgnoreCase))
					{
						if ((message.ForceHotReloadDelay ?? HotReloadServerOperation.DefaultAutoRetryIfNoChangesDelay) is { TotalMilliseconds: > 0 } delay)
						{
							await Task.Delay(delay);
						}

						tcs.TrySetResult();
					}
				};
				watcher.EnableRaisingEvents = true;

				if (await Task.WhenAny(tcs.Task, Task.Delay(TimeSpan.FromSeconds(2))) != tcs.Task
					&& this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().LogDebug($"File update event not received for '{message.FilePath}', continuing anyway [{message.RequestId}].");
				}
			}
		}

		private async Task<bool> RequestHotReloadToIde(long sequenceId)
		{
			var hrRequest = new ForceHotReloadIdeMessage(sequenceId);
			var hrRequested = new TaskCompletionSource<Result>();

			try
			{
				using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
				await using var ctReg = cts.Token.Register(() => hrRequested.TrySetCanceled());

				_pendingHotReloadRequestToIde.TryAdd(hrRequest.CorrelationId, hrRequested);
				await _remoteControlServer.SendMessageToIDEAsync(hrRequest);

				return await hrRequested.Task is { IsSuccess: true };
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				_pendingHotReloadRequestToIde.TryRemove(hrRequest.CorrelationId, out _);
			}
		}
		#endregion

		public void Dispose()
		{
			_solutionWatcherEventsDisposable?.Dispose();
			if (_solutionWatchers != null)
			{
				foreach (var watcher in _solutionWatchers)
				{
					watcher.Dispose();
				}
			}

			_hotReloadService?.EndSession();
		}

		#region Helpers
		private static IObservable<Task<ImmutableHashSet<string>>> To2StepsObservable(FileSystemWatcher[] watchers, Predicate<string> filter)
			=> Observable.Create<Task<ImmutableHashSet<string>>>(o =>
			{
				// Create an observable instead of using the FromEventPattern which
				// does not register to events properly.
				// Renames are required for the WriteTemporary->DeleteOriginal->RenameToOriginal that
				// Visual Studio uses to save files.

				var gate = new object();
				var buffer = default((ImmutableHashSet<string>.Builder items, TaskCompletionSource<ImmutableHashSet<string>> task)?);
				var bufferTimer = new Timer(CloseBuffer);

				void changed(object s, FileSystemEventArgs args) => OnNext(args.FullPath);
				void renamed(object s, RenamedEventArgs args) => OnNext(args.FullPath);

				foreach (var watcher in watchers)
				{
					watcher.Changed += changed;
					watcher.Created += changed;
					watcher.Renamed += renamed;
				}

				void OnNext(string file)
				{
					if (!filter(file))
					{
						return;
					}

					lock (gate)
					{
						if (buffer is null)
						{
							buffer = (ImmutableHashSet.CreateBuilder<string>(_pathsComparer), new());
							o.OnNext(buffer.Value.task.Task);
						}

						buffer.Value.items.Add(file);
						bufferTimer.Change(250, Timeout.Infinite); // Wait for 250 ms without any file change
					}
				}

				void CloseBuffer(object? state)
				{
					(ImmutableHashSet<string>.Builder items, TaskCompletionSource<ImmutableHashSet<string>> task) completingBuffer;
					if (buffer is null)
					{
						Debug.Fail("Should not happen.");
						return;
					}

					lock (gate)
					{
						completingBuffer = buffer.Value;
						buffer = default;
					}

					completingBuffer.task.SetResult(completingBuffer.items.ToImmutable());
				}

				return Disposable.Create(() =>
				{
					foreach (var watcher in watchers)
					{
						watcher.Changed -= changed;
						watcher.Created -= changed;
						watcher.Renamed -= renamed;
					}

					bufferTimer.Dispose();
				});
			});
		#endregion
	}
}
