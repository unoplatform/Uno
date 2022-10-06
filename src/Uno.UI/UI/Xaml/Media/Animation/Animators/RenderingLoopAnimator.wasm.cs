﻿using System;
using System.Diagnostics;
using System.Threading;
using Uno.Foundation;
using Uno.Foundation.Interop;
using Uno.Foundation.Logging;

namespace Windows.UI.Xaml.Media.Animation
{
	internal abstract class RenderingLoopAnimator<T> : CPUBoundAnimator<T>, IJSObject where T : struct
	{
		protected RenderingLoopAnimator(T from, T to)
			: base(from, to)
		{
			Handle = JSObjectHandle.Create(this, Metadata.Instance);
		}

		public JSObjectHandle Handle { get; }

		protected override void EnableFrameReporting()
		{
			if (Handle.IsAlive)
			{
				WebAssemblyRuntime.InvokeJSWithInterop($"{this}.EnableFrameReporting();");
			}
			else if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("Cannot EnableFrameReporting as Handle is no longer alive.");
			}
		}

		protected override void DisableFrameReporting()
		{
			if (Handle.IsAlive)
			{
				WebAssemblyRuntime.InvokeJSWithInterop($"{this}.DisableFrameReporting();");
			}
			else if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("Cannot DisableFrameReporting as Handle is no longer alive.");
			}
		}

		protected override void SetStartFrameDelay(long delayMs)
		{
			if (Handle.IsAlive)
			{
				WebAssemblyRuntime.InvokeJSWithInterop($"{this}.SetStartFrameDelay({delayMs});");
			}
			else if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("Cannot SetStartFrameDelay as Handle is no longer alive.");
			}
		}

		protected override void SetAnimationFramesInterval()
		{
			if (Handle.IsAlive)
			{
				WebAssemblyRuntime.InvokeJSWithInterop($"{this}.SetAnimationFramesInterval();");
			}
			else if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("Cannot SetAnimationFramesInterval as Handle is no longer alive.");
			}
		}

		private void OnFrame() => OnFrame(null, null);

		/// <inheritdoc />
		public override void Dispose()
		{
			// WARNING: If the Dispose is invoked by the GC, it has most probably already disposed the Handle,
			//			which means that we have already lost ability to dispose/stop the native object!

			base.Dispose();
			Handle.Dispose();

			GC.SuppressFinalize(this);
		}

		~RenderingLoopAnimator()
		{
			Dispose();
		}

		private class Metadata : IJSObjectMetadata
		{
			public static Metadata Instance { get; } = new Metadata();

			private Metadata() { }

			/// <inheritdoc />
			public long CreateNativeInstance(IntPtr managedHandle)
			{
				var id = RenderingLoopAnimatorMetadataIdProvider.Next();
				WebAssemblyRuntime.InvokeJS($"Windows.UI.Xaml.Media.Animation.RenderingLoopAnimator.createInstance(\"{managedHandle}\", \"{id}\")");

				return id;
			}

			/// <inheritdoc />
			public string GetNativeInstance(IntPtr managedHandle, long jsHandle)
				=> $"Windows.UI.Xaml.Media.Animation.RenderingLoopAnimator.getInstance(\"{jsHandle}\")";

			/// <inheritdoc />
			public void DestroyNativeInstance(IntPtr managedHandle, long jsHandle)
				=> WebAssemblyRuntime.InvokeJS($"Windows.UI.Xaml.Media.Animation.RenderingLoopAnimator.destroyInstance(\"{jsHandle}\")");

			/// <inheritdoc />
			public object InvokeManaged(object instance, string method, string parameters)
			{
				switch (method)
				{
					case "OnFrame":
						((RenderingLoopAnimator<T>)instance).OnFrame();
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(method));
				}

				return null;
			}
		}
	}
}
