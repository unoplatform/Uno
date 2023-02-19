﻿using System;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Java.Interop;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Microsoft.Identity.Client;
using Uno.UI.ViewManagement;
using Uno.AuthenticationBroker;
using System.IO;
using System.Threading;
using Android.OS;

namespace SamplesApp.Droid
{
	[Activity(
#if DEBUG // Disabled because of https://github.com/xamarin/xamarin-android/issues/6463                                                                                
			Exported = true,
#endif
			MainLauncher = true,
			ConfigurationChanges = global::Uno.UI.ActivityHelper.AllConfigChanges,
			WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden
		)]
	[IntentFilter(
		new[] {
			Android.Content.Intent.ActionView
		},
		Categories = new[] {
			Android.Content.Intent.CategoryDefault,
			Android.Content.Intent.CategoryBrowsable
		},
		DataScheme = "uno-samples-test")]
	public class MainActivity : Windows.UI.Xaml.ApplicationActivity
	{
		private bool _onCreateEventInvoked = false;
		private HandlerThread _pixelCopyHandlerThread;

		public MainActivity()
		{
			ApplicationViewHelper.GetBaseActivityEvents().Create += OnCreateEvent;
		}

		private void OnCreateEvent(Android.OS.Bundle savedInstanceState)
		{
			_onCreateEventInvoked = true;
		}

		protected override void OnStart()
		{
			if (!_onCreateEventInvoked)
			{
				throw new InvalidOperationException($"Invalid startup sequence to initialize BaseActivityEvents");
			}

			base.OnStart();
		}

		[Export("RunTest")]
		public string RunTest(string metadataName) => App.RunTest(metadataName);

		[Export("IsTestDone")]
		public bool IsTestDone(string testId) => App.IsTestDone(testId);

		[Export("GetDisplayScreenScaling")]
		public string GetDisplayScreenScaling(string displayId) => App.GetDisplayScreenScaling(displayId);

		/// <summary>
		/// Returns a base64 encoded PNG file
		/// </summary>
		[Export("GetScreenshot")]
		public string GetScreenshot(string displayId)
		{
			var rootView = Windows.UI.Xaml.Window.Current.MainContent as View;

			var bitmap = Android.Graphics.Bitmap.CreateBitmap(rootView.Width, rootView.Height, Android.Graphics.Bitmap.Config.Argb8888);
			var locationOfViewInWindow = new int[2];
			rootView.GetLocationInWindow(locationOfViewInWindow);

			var xCoordinate = locationOfViewInWindow[0];
			var yCoordinate = locationOfViewInWindow[1];

			var scope = new Android.Graphics.Rect(
				xCoordinate,
				yCoordinate,
				xCoordinate + rootView.Width,
				yCoordinate + rootView.Height
			);

			if (_pixelCopyHandlerThread == null)
			{
				_pixelCopyHandlerThread = new Android.OS.HandlerThread("ScreenshotHelper");
				_pixelCopyHandlerThread.Start();
			}

			var listener = new PixelCopyListener();

			// PixelCopy.Request returns the actual rendering of the screen location
			// for the app, incliing OpenGL content.
			PixelCopy.Request(Window, scope, bitmap, listener, new Android.OS.Handler(_pixelCopyHandlerThread.Looper));

			listener.WaitOne();

			using var memoryStream = new MemoryStream();
			bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 100, memoryStream);

			return Convert.ToBase64String(memoryStream.ToArray());
		}

		[Export("SetFullScreenMode")]
		public void SetFullScreenMode(bool fullscreen)
		{
			// workaround for #2747: force the app into fullscreen
			// to prevent status bar from reappearing when popup are shown.
			var activity = Uno.UI.ContextHelper.Current as Activity;
			if (fullscreen)
			{
				activity.Window.AddFlags(WindowManagerFlags.Fullscreen);
			}
			else
			{
				activity.Window.ClearFlags(WindowManagerFlags.Fullscreen);
			}
		}
		protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
		}

		class PixelCopyListener : Java.Lang.Object, PixelCopy.IOnPixelCopyFinishedListener
		{
			private ManualResetEvent _event = new ManualResetEvent(false);

			public void WaitOne()
			{
				_event.WaitOne();
			}

			public void OnPixelCopyFinished(int copyResult)
			{
				_event.Set();
			}
		}
	}


	[Activity(Exported = true)]
	[IntentFilter(
		new[] {
			Android.Content.Intent.ActionView
		},
		Categories = new[] {
			Android.Content.Intent.CategoryDefault,
			Android.Content.Intent.CategoryBrowsable
		},
		DataScheme = "msauth")]
	public class MsalActivity : BrowserTabActivity
	{
	}


	[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
	[IntentFilter(
	new[] { Android.Content.Intent.ActionView },
	Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
	DataScheme = "wab")]
	public class WebAuthenticationBrokerActivity : WebAuthenticationBrokerActivityBase
	{
	}

}

