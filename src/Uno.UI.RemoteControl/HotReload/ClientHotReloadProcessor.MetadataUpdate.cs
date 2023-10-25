﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.Helpers;
using Uno.UI.RemoteControl.HotReload.Messages;
using Uno.UI.RemoteControl.HotReload.MetadataUpdater;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.RemoteControl.HotReload;

partial class ClientHotReloadProcessor : IRemoteControlProcessor
{
	private static int _isReloading;

	private bool _linkerEnabled;
	private HotReloadAgent _agent;
	private ElementUpdateAgent? _elementAgent;
	private static ClientHotReloadProcessor? _instance;
	private readonly TaskCompletionSource<bool> _hotReloadWorkloadSpaceLoaded = new();

	private ElementUpdateAgent ElementAgent
	{
		get
		{
			_elementAgent ??= new ElementUpdateAgent(s =>
				{
					if (this.Log().IsEnabled(LogLevel.Trace))
					{
						this.Log().Trace(s);
					}
				});

			return _elementAgent;
		}
	}

	private void WorkspaceLoadResult(HotReloadWorkspaceLoadResult hotReloadWorkspaceLoadResult)
		=> _hotReloadWorkloadSpaceLoaded.SetResult(hotReloadWorkspaceLoadResult.WorkspaceInitialized);

	/// <summary>
	/// Waits for the server's hot reload workspace to be loaded
	/// </summary>
	/// <param name="ct"></param>
	/// <returns></returns>
	public Task<bool> WaitForWorkspaceLoaded(CancellationToken ct)
		=> _hotReloadWorkloadSpaceLoaded.Task;

	[MemberNotNull(nameof(_agent))]
	partial void InitializeMetadataUpdater()
	{
		_instance = this;

		_linkerEnabled = string.Equals(Environment.GetEnvironmentVariable("UNO_BOOTSTRAP_LINKER_ENABLED"), "true", StringComparison.OrdinalIgnoreCase);

		if (_linkerEnabled)
		{
			var message = "The application was compiled with the IL linker enabled, hot reload is disabled. " +
						"See WasmShellILLinkerEnabled for more details.";

			Console.WriteLine($"[ERROR] {message}");
		}

		_agent = new HotReloadAgent(s =>
		{
			if (this.Log().IsEnabled(LogLevel.Trace))
			{
				this.Log().Trace(s);
			}
		});
	}

	private bool MetadataUpdatesEnabled
	{
		get
		{
			var unoRuntimeIdentifier = GetMSBuildProperty("UnoRuntimeIdentifier");
			var targetFramework = GetMSBuildProperty("TargetFramework");
			var buildingInsideVisualStudio = GetMSBuildProperty("BuildingInsideVisualStudio");

			return
				buildingInsideVisualStudio.Equals("true", StringComparison.OrdinalIgnoreCase)
				&& (
					// As of VS 17.8, when the debugger is not attached, mobile targets can use
					// DevServer's hotreload workspace, as visual studio does not enable it on its own.
					(!Debugger.IsAttached
						&& (targetFramework.Contains("-android") || targetFramework.Contains("-ios"))));
		}
	}

	private string[] GetMetadataUpdateCapabilities()
	{
		if (Type.GetType(HotReloadAgent.MetadataUpdaterType) is { } type)
		{
			if (type.GetMethod("GetCapabilities", BindingFlags.Static | BindingFlags.NonPublic) is { } getCapabilities)
			{
				if (getCapabilities.Invoke(null, Array.Empty<string>()) is string caps)
				{
					if (this.Log().IsEnabled(LogLevel.Trace))
					{
						this.Log().Trace($"Metadata Updates runtime capabilities: {caps}");
					}

					return caps.Split(' ');
				}
				else
				{
					if (this.Log().IsEnabled(LogLevel.Warning))
					{
						this.Log().Trace($"Runtime does not support Hot Reload (Invalid returned type for {HotReloadAgent.MetadataUpdaterType}.GetCapabilities())");
					}
				}
			}
			else
			{
				if (this.Log().IsEnabled(LogLevel.Warning))
				{
					this.Log().Trace($"Runtime does not support Hot Reload (Unable to find method {HotReloadAgent.MetadataUpdaterType}.GetCapabilities())");
				}
			}
		}
		else
		{
			if (this.Log().IsEnabled(LogLevel.Warning))
			{
				this.Log().Trace($"Runtime does not support Hot Reload (Unable to find type {HotReloadAgent.MetadataUpdaterType})");
			}
		}
		return Array.Empty<string>();
	}

	private void AssemblyReload(AssemblyDeltaReload assemblyDeltaReload)
	{
		try
		{
			if (Debugger.IsAttached)
			{
				if (this.Log().IsEnabled(LogLevel.Error))
				{
					this.Log().Error($"Hot Reload is not supported when the debugger is attached.");
				}

				return;
			}

			if (assemblyDeltaReload.IsValid())
			{
				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().Trace($"Applying IL Delta after {assemblyDeltaReload.FilePath}, Guid:{assemblyDeltaReload.ModuleId}");
				}

				var changedTypesStreams = new MemoryStream(Convert.FromBase64String(assemblyDeltaReload.UpdatedTypes));
				var changedTypesReader = new BinaryReader(changedTypesStreams);

				var delta = new UpdateDelta()
				{
					MetadataDelta = Convert.FromBase64String(assemblyDeltaReload.MetadataDelta),
					ILDelta = Convert.FromBase64String(assemblyDeltaReload.ILDelta),
					PdbBytes = Convert.FromBase64String(assemblyDeltaReload.PdbDelta),
					ModuleId = Guid.Parse(assemblyDeltaReload.ModuleId),
					UpdatedTypes = ReadIntArray(changedTypesReader)
				};

				_agent.ApplyDeltas(new[] { delta });

				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().Trace($"Done applying IL Delta for {assemblyDeltaReload.FilePath}, Guid:{assemblyDeltaReload.ModuleId}");
				}
			}
			else
			{
				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().Trace($"Failed to apply IL Delta for {assemblyDeltaReload.FilePath} ({assemblyDeltaReload})");
				}
			}
		}
		catch (Exception e)
		{
			if (this.Log().IsEnabled(LogLevel.Error))
			{
				this.Log().Error($"An exception occurred when applying IL Delta for {assemblyDeltaReload.FilePath} ({assemblyDeltaReload.ModuleId})", e);
			}
		}
	}

	static int[] ReadIntArray(BinaryReader binaryReader)
	{
		var numValues = binaryReader.ReadInt32();
		if (numValues == 0)
		{
			return Array.Empty<int>();
		}

		var values = new int[numValues];

		for (var i = 0; i < numValues; i++)
		{
			values[i] = binaryReader.ReadInt32();
		}

		return values;
	}

	private static async Task<bool> ShouldReload()
	{
		if (Interlocked.CompareExchange(ref _isReloading, 1, 0) == 1)
		{
			return false;
		}
		try
		{
			await TypeMappings.WaitForMappingsToResume();
		}
		finally
		{
			Interlocked.Exchange(ref _isReloading, 0);
		}
		return true;
	}

	private static async Task ReloadWithUpdatedTypes(Type[] updatedTypes)
	{
		if (!await ShouldReload())
		{
			return;
		}

		try
		{
			UpdateGlobalResources(updatedTypes);

			var handlerActions = _instance?.ElementAgent?.ElementHandlerActions;

			// Action: BeforeVisualTreeUpdate
			// This is called before the visual tree is updated
			_ = handlerActions?.Do(h => h.Value.BeforeVisualTreeUpdate(updatedTypes)).ToArray();

			var capturedStates = new Dictionary<string, Dictionary<string, object>>();

			var isCapturingState = true;
			var treeIterator = EnumerateHotReloadInstances(
					Window.Current.Content,
					async (fe, key) =>
					{
						// Get the original type of the element, in case it's been replaced
						var liveType = fe.GetType();
						var originalType = liveType.GetOriginalType() ?? fe.GetType();

						// Get the handler for the type specified
						// Since we're only interested in handlers for specific element types
						// we exclude those registered for "object". Handlers that want to run
						// for all element types should register for FrameworkElement instead
						var handler = (from h in handlerActions
									   where (originalType == h.Key ||
											originalType.IsSubclassOf(h.Key)) &&
											h.Key != typeof(object)
									   select h.Value).FirstOrDefault();

						// Get the replacement type, or null if not replaced
						var mappedType = originalType.GetMappedType();

						if (handler is not null)
						{
							if (!capturedStates.TryGetValue(key, out var dict))
							{
								dict = new();
							}
							if (isCapturingState)
							{
								handler.CaptureState(fe, dict, updatedTypes);
								if (dict.Any())
								{
									capturedStates[key] = dict;
								}
							}
							else
							{
								await handler.RestoreState(fe, dict, updatedTypes);
							}
						}

						if (updatedTypes.Contains(liveType))
						{
							// This may happen if one of the nested types has been hot reloaded, but not the type itself.
							// For instance, a DataTemplate in a resource dictionary may mark the type as updated in `updatedTypes`
							// but it will not be considered as a new type even if "CreateNewOnMetadataUpdate" was set.

							return (fe, null, liveType);
						}
						else
						{
							return (handler is not null || mappedType is not null) ? (fe, handler, mappedType) : default;
						}
					},
					parentKey: default);

			// Forced iteration to capture all state before doing ui update
			var instancesToUpdate = await treeIterator.ToArrayAsync();

			// Iterate through the visual tree and either invoke ElementUpdate, 
			// or replace the element with a new one
			foreach (var (element, elementHandler, elementMappedType) in instancesToUpdate)
			{
				// Action: ElementUpdate
				// This is invoked for each existing element that is in the tree that needs to be replaced
				elementHandler?.ElementUpdate(element, updatedTypes);

				if (elementMappedType is not null)
				{
					if (_log.IsEnabled(LogLevel.Trace))
					{
						_log.Error($"Updating element [{element}] to [{elementMappedType}]");
					}

					ReplaceViewInstance(element, elementMappedType, elementHandler);
				}
			}

			isCapturingState = false;
			// Forced iteration again to restore all state after doing ui update
			_ = await treeIterator.ToArrayAsync();

			// Action: AfterVisualTreeUpdate
			_ = handlerActions?.Do(h => h.Value.AfterVisualTreeUpdate(updatedTypes)).ToArray();
		}
		catch (Exception ex)
		{
			if (_log.IsEnabled(LogLevel.Error))
			{
				_log.Error($"Error doing UI Update - {ex.Message}", ex);
			}
			throw;
		}
	}

	/// <summary>
	/// Updates App-level resources (from app.xaml) using the provided updated types list.
	/// </summary>
	private static void UpdateGlobalResources(Type[] updatedTypes)
	{
		var globalResourceTypes = updatedTypes
			.Where(t => t?.FullName != null && (
				t.FullName.EndsWith("GlobalStaticResources", StringComparison.OrdinalIgnoreCase)
				|| t.FullName[..^2].EndsWith("GlobalStaticResources", StringComparison.OrdinalIgnoreCase)))
			.ToArray();

		if (globalResourceTypes.Length != 0)
		{
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.Debug($"Updating app resources");
			}

			MethodInfo? GetInitMethod(Type type, string name)
			{
				if (type.GetMethod(
					name,
					BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, Array.Empty<Type>()) is { } initializeMethod)
				{
					return initializeMethod;
				}
				else
				{
					if (_log.IsEnabled(LogLevel.Debug))
					{
						_log.Debug($"{name} method not found on {type}");
					}

					return null;
				}
			}

			// First, register all dictionaries
			foreach (var globalResourceType in globalResourceTypes)
			{
				// Follow the initialization sequence implemented by
				// App.InitializeComponent (Initialize then RegisterResourceDictionariesBySourceLocal).

				if (GetInitMethod(globalResourceType, "Initialize") is { } initializeMethod)
				{
					if (_log.IsEnabled(LogLevel.Trace))
					{
						_log.Debug($"Initializing resources for {globalResourceType}");
					}

					// Invoke initializers so default types and other resources get updated.
					initializeMethod.Invoke(null, null);
				}

				if (GetInitMethod(globalResourceType, "RegisterResourceDictionariesBySourceLocal") is { } registerResourceDictionariesBySourceLocalMethod)
				{
					if (_log.IsEnabled(LogLevel.Trace))
					{
						_log.Debug($"Initializing resources sources for {globalResourceType}");
					}

					// Invoke initializers so default types and other resources get updated.
					registerResourceDictionariesBySourceLocalMethod.Invoke(null, null);
				}
			}


			// Then find over updated types to find the ones that are implementing IXamlResourceDictionaryProvider
			List<Uri> updatedDictionaries = new();

			foreach (var updatedType in updatedTypes)
			{
				if (updatedType.GetInterfaces().Contains(typeof(IXamlResourceDictionaryProvider)))
				{
					if (_log.IsEnabled(LogLevel.Trace))
					{
						_log.Debug($"Updating resources for {updatedType}");
					}

					// This assumes that we're using an explicit implementation of IXamlResourceDictionaryProvider, which
					// provides an instance property that returns the new dictionary.
					var staticDictionaryProperty = updatedType
						.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

					if (staticDictionaryProperty?.GetMethod is { } getMethod)
					{
						if (getMethod.Invoke(null, null) is IXamlResourceDictionaryProvider provider
							&& provider.GetResourceDictionary() is { Source: not null } dictionary)
						{
							updatedDictionaries.Add(dictionary.Source);
						}
					}
				}
			}

			// Traverse the current app's tree to replace dictionaries matching the source property
			// with the updated ones.
			UpdateResourceDictionaries(updatedDictionaries, Application.Current.Resources);

			// Force the app reevaluate global resources changes
			Application.Current.UpdateResourceBindingsForHotReload();
		}
	}

	/// <summary>
	/// Refreshes ResourceDictionary instances that have been detected as updated
	/// </summary>
	/// <param name="updatedDictionaries"></param>
	/// <param name="root"></param>
	private static void UpdateResourceDictionaries(List<Uri> updatedDictionaries, ResourceDictionary root)
	{
		var dictionariesToRefresh = root
			.MergedDictionaries
			.Where(merged => updatedDictionaries.Any(d => d == merged.Source))
			.ToArray();

		foreach (var merged in dictionariesToRefresh)
		{
			root.RefreshMergedDictionary(merged);
		}
	}

	private static void ReplaceViewInstance(UIElement instance, Type replacementType, ElementUpdateAgent.ElementUpdateHandlerActions? handler = default, Type[]? updatedTypes = default)
	{
		if (replacementType.GetConstructor(Array.Empty<Type>()) is { } creator)
		{
			if (_log.IsEnabled(LogLevel.Trace))
			{
				_log.Trace($"Creating instance of type {replacementType}");
			}

			var newInstance = Activator.CreateInstance(replacementType);
			var instanceFE = instance as FrameworkElement;
			var newInstanceFE = newInstance as FrameworkElement;
			if (instanceFE is not null &&
				newInstanceFE is not null)
			{
				handler?.BeforeElementReplaced(instanceFE, newInstanceFE, updatedTypes);
			}
			switch (instance)
			{
#if __IOS__
				case UserControl userControl:
					if (newInstance is UIKit.UIView newUIViewContent)
					{
						SwapViews(userControl, newUIViewContent);
					}
					break;
#endif
				case ContentControl content:
					if (newInstance is ContentControl newContent)
					{
						SwapViews(content, newContent);
					}
					break;
			}

			if (instanceFE is not null &&
				newInstanceFE is not null)
			{
				handler?.AfterElementReplaced(instanceFE, newInstanceFE, updatedTypes);
			}
		}
		else
		{
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.LogDebug($"Type [{instance.GetType()}] has no parameterless constructor, skipping reload");
			}
		}
	}

	public static void UpdateApplication(Type[] types)
	{
		foreach (var t in types)
		{
			if (t.GetCustomAttribute<System.Runtime.CompilerServices.MetadataUpdateOriginalTypeAttribute>() is { } update)
			{
				TypeMappings.RegisterMapping(t, update.OriginalType);
			}
		}

		if (_log.IsEnabled(LogLevel.Trace))
		{
			_log.Trace($"UpdateApplication (changed types: {string.Join(", ", types.Select(s => s.ToString()))})");
		}

		_ = Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(
			Windows.UI.Core.CoreDispatcherPriority.Normal,
			async () => await ReloadWithUpdatedTypes(types));
	}
}

public static class AsyncEnumerableExtensions
{
	public async static Task<T[]> ToArrayAsync<T>(this IAsyncEnumerable<T> enumerable)
	{
		var list = new List<T>();
		await foreach (var item in enumerable)
		{
			list.Add(item);
		}
		return list.ToArray();
	}
}
