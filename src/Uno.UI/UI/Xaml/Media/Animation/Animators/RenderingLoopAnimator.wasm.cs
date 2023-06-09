﻿using System;
using System.Diagnostics;
using System.Threading;
using Uno.Foundation;
using Uno.Foundation.Interop;
using Uno.Foundation.Logging;

#if NET7_0_OR_GREATER
using NativeMethods = __Windows.UI.Xaml.Media.Animation.RenderingLoopAnimator.NativeMethods;
#endif

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
#if NET7_0_OR_GREATER
				NativeMethods.EnableFrameReporting(Handle.JSHandle);
#else
				WebAssemblyRuntime.InvokeJSWithInterop($"{this}.EnableFrameReporting();");
#endif
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
#if NET7_0_OR_GREATER
				NativeMethods.DisableFrameReporting(Handle.JSHandle);
#else
				WebAssemblyRuntime.InvokeJSWithInterop($"{this}.DisableFrameReporting();");
#endif
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
#if NET7_0_OR_GREATER
				NativeMethods.SetStartFrameDelay(Handle.JSHandle, delayMs);
#else
				WebAssemblyRuntime.InvokeJSWithInterop($"{this}.SetStartFrameDelay({delayMs});");
#endif
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
#if NET7_0_OR_GREATER
				NativeMethods.SetAnimationFramesInterval(Handle.JSHandle);
#else
				WebAssemblyRuntime.InvokeJSWithInterop($"{this}.SetAnimationFramesInterval();");
#endif
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

#if NET7_0_OR_GREATER
				NativeMethods.CreateInstance(managedHandle, id);
#else
				WebAssemblyRuntime.InvokeJS($"Windows.UI.Xaml.Media.Animation.RenderingLoopAnimator.createInstance({managedHandle}, {id})");
#endif

				return id;
			}

			/// <inheritdoc />
			public string GetNativeInstance(IntPtr managedHandle, long jsHandle)
				=> $"Windows.UI.Xaml.Media.Animation.RenderingLoopAnimator.getInstance(\"{jsHandle}\")";

			/// <inheritdoc />
			public void DestroyNativeInstance(IntPtr managedHandle, long jsHandle)
				=>
#if NET7_0_OR_GREATER
					NativeMethods.DestroyInstance(jsHandle);
#else
					WebAssemblyRuntime.InvokeJS($"Windows.UI.Xaml.Media.Animation.RenderingLoopAnimator.destroyInstance({jsHandle})");
#endif

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
