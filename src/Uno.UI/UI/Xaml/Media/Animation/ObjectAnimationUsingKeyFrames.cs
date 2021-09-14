using Uno.Diagnostics.Eventing;
using Uno.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.Disposables;
using System.Text;
using Windows.UI.Xaml.Markup;
using Windows.UI.Core;
using System.Threading.Tasks;

namespace Windows.UI.Xaml.Media.Animation
{
	[ContentProperty(Name = "KeyFrames")]
	public sealed partial class ObjectAnimationUsingKeyFrames : Timeline, ITimeline
	{
		private readonly static IEventProvider _trace = Tracing.Get(TraceProvider.Id);
		private EventActivity _traceActivity;

		public static class TraceProvider
		{
			public readonly static Guid Id = Guid.Parse("{9EBBD06A-ADA3-464F-93C6-C850AB62A41D}");

			public const int Start = 1;
			public const int Stop = 2;
			public const int Pause = 3;
			public const int Resume = 4;
		}

		private KeyFrameScheduler<object>? _frameScheduler;
		
		//private Stopwatch _watch = new Stopwatch();
		//private TimeSpan _elapsedTime;
		
		private int _replayCount;

		public ObjectAnimationUsingKeyFrames()
		{
			KeyFrames = new ObjectKeyFrameCollection(owner: this, isAutoPropertyInheritanceEnabled: false);
		}

		#region KeyFrames DependencyProperty

		public ObjectKeyFrameCollection KeyFrames
		{
			get => (ObjectKeyFrameCollection)GetValue(KeyFramesProperty);
			internal set => SetValue(KeyFramesProperty, value);
		}

		/// <remarks>
		/// This property is not exposed as a DP in UWP, but it is required
		/// to be one for the DataContext/TemplatedParent to flow properly.
		/// </remarks>
		internal static DependencyProperty KeyFramesProperty { get; } =
			DependencyProperty.Register(
				name: "KeyFrames", 
				propertyType: typeof(ObjectKeyFrameCollection), 
				ownerType: typeof(ObjectAnimationUsingKeyFrames), 
				typeMetadata: new FrameworkPropertyMetadata(
					defaultValue: null
				)
			);

		#endregion

		internal override TimeSpan GetCalculatedDuration()
		{
			var duration = Duration;
			if (duration != Duration.Automatic)
			{
				return base.GetCalculatedDuration();
			}

			if (KeyFrames.Any())
			{
				var lastKeyTime = KeyFrames.Max(kf => kf.KeyTime);
				return lastKeyTime.TimeSpan;
			}

			return base.GetCalculatedDuration();
		}

		void ITimeline.Begin()
		{
			if (_trace.IsEnabled)
			{
				_traceActivity = _trace.WriteEventActivity(
					TraceProvider.Start,
					EventOpcode.Start,
					payload: GetTraceProperties()
				);
			}

			Reset();
			_replayCount = 1;

			State = TimelineState.Active;

			_frameScheduler = new KeyFrameScheduler<object>(
				BeginTime,
				Duration.HasTimeSpan ? Duration.TimeSpan : default(TimeSpan?),
				default,
				KeyFrames,
				OnFrame,
				OnFramesEnd);
			_frameScheduler.Start();
		}

		void ITimeline.Stop()
		{
			if (_trace.IsEnabled)
			{
				_traceActivity = _trace.WriteEventActivity(
					TraceProvider.Stop,
					EventOpcode.Stop,
					payload: GetTraceProperties()
				);
			}

			_frameScheduler?.Stop();

			Reset();
			ClearValue();
		}

		void ITimeline.Resume()
		{
			if (State != TimelineState.Paused)
			{
				return;
			}

			if (_trace.IsEnabled)
			{
				_traceActivity = _trace.WriteEventActivity(
					TraceProvider.Resume,
					EventOpcode.Send,
					payload: GetTraceProperties()
				);
			}

			State = TimelineState.Active;
			_frameScheduler!.Resume();
		}

		void ITimeline.Pause()
		{
			if (State != TimelineState.Active)
			{
				return;
			}

			if (_trace.IsEnabled)
			{
				_traceActivity = _trace.WriteEventActivity(
					TraceProvider.Pause,
					EventOpcode.Send,
					payload: GetTraceProperties()
				);
			}

			State = TimelineState.Paused;
			_frameScheduler?.Pause();
		}

		void ITimeline.Seek(TimeSpan offset)
		{
			_frameScheduler?.Seek(offset);
		}

		void ITimeline.SeekAlignedToLastTick(TimeSpan offset)
		{
			// Same as Seek
			((ITimeline)this).Seek(offset);
		}

		void ITimeline.SkipToFill()
		{
			// Set value to last keytime and set state to filling
			_frameScheduler?.Dispose();
			_frameScheduler = null;

			var fillFrame = KeyFrames.OrderBy(k => k.KeyTime.TimeSpan).Last();

			SetValue(fillFrame.Value);
			State = TimelineState.Stopped;

		}

		void ITimeline.Deactivate()
		{
			Reset();
		}

		/// <summary>
		/// Brings the Timeline to its initial state
		/// </summary>
		private void Reset()
		{
			State = TimelineState.Stopped;
			_frameScheduler?.Dispose();
			_frameScheduler = null;
		}

		private IDisposable? OnFrame(object currentValue, IKeyFrame<object> frame, TimeSpan duration)
		{
			SetValue(frame.Value);
			return null;
		}

		private void OnFramesEnd(KeyFrameScheduler<object>.EndReason endReason)
		{
			if (endReason != KeyFrameScheduler<object>.EndReason.EndOfFrames)
			{
				return;
			}

			if (NeedsRepeat())
			{
				Replay();
				return;
			}

			if (FillBehavior == FillBehavior.HoldEnd)//Two types of fill behaviors : HoldEnd - Keep displaying the last frame
			{
				Fill();
			}
			else// Stop - Put back the initial state
			{
				Reset();
				ClearValue();
			}

			OnCompleted();
		}

		/// <summary>
		/// Fills the animation: the final frame is shown and left visible
		/// </summary>
		private void Fill()
		{
			var lastTime = KeyFrames.Max(k => k.KeyTime.TimeSpan);
			var lastKeyFrame = KeyFrames.First(k => k.KeyTime.TimeSpan.Equals(lastTime));

			State = TimelineState.Filling;
			_frameScheduler?.Dispose();
			_frameScheduler = null;
			SetValue(lastKeyFrame.Value);
		}

		/// <summary>
		/// Replays the Timeline
		/// </summary>
		private void Replay()
		{
			ClearValue();
			_replayCount++;

			_frameScheduler?.Dispose();
			_frameScheduler = new KeyFrameScheduler<object>(
				BeginTime,
				Duration.HasTimeSpan ? Duration.TimeSpan : default(TimeSpan?),
				default,
				KeyFrames,
				OnFrame,
				OnFramesEnd);
			_frameScheduler.Start();
		}

		/// <summary>
		/// Checks if the Timeline will repeat.
		/// </summary>
		/// <returns><c>true</c>, Repeat needed, <c>false</c> otherwise.</returns>
		private bool NeedsRepeat()
		{
			var totalTime = _watch.Elapsed;

			//3 types of repeat behavors,
			return (RepeatBehavior.Type == RepeatBehaviorType.Forever) // Forever: Will always repeat the TimeLine
				|| (RepeatBehavior.HasCount && RepeatBehavior.Count > _replayCount) // Count: Will repeat the TimeLine x times
				|| (RepeatBehavior.HasDuration && RepeatBehavior.Duration - totalTime > TimeSpan.Zero); // Duration: Will repeat the TimeLine for a given duration
		}

		/// <summary>
		/// Destroys the animation
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (_frameScheduler != null)
			{
				_frameScheduler.Dispose();
				_frameScheduler = null;
			}
		}
	}
}
