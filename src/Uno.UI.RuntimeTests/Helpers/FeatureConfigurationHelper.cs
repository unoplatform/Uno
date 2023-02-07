﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.Disposables;
using Windows.UI.Xaml;

namespace Uno.UI.RuntimeTests.Helpers
{
	public static class FeatureConfigurationHelper
	{
		/// <summary>
		/// Enable <see cref="FrameworkTemplate"/> pooling (Uno only) for the duration of a single test.
		/// </summary>
		public static IDisposable UseTemplatePooling()
		{
#if NETFX_CORE
			return null;
#else
			var originallyEnabled = FrameworkTemplatePool.IsPoolingEnabled;
			FrameworkTemplatePool.IsPoolingEnabled = true;
			return Disposable.Create(() => FrameworkTemplatePool.IsPoolingEnabled = originallyEnabled);
#endif
		}

		public static IDisposable UseListViewAnimations()
		{
#if __ANDROID__
			var originalSetting = FeatureConfiguration.NativeListViewBase.RemoveItemAnimator;
			FeatureConfiguration.NativeListViewBase.RemoveItemAnimator = false;
			return Disposable.Create(() => FeatureConfiguration.NativeListViewBase.RemoveItemAnimator = originalSetting);
#else
			return null;
#endif
		}

		/// <summary>
		/// On Android, ensure that native popups are used for the duration of the test. On other platforms this is a no-op.
		/// </summary>
		public static IDisposable UseNativePopups()
		{
#if !__ANDROID__
			return null;
#else
			Assert.IsFalse(FeatureConfiguration.Popup.UseNativePopup);
			FeatureConfiguration.Popup.UseNativePopup = true;
			return Disposable.Create(() => FeatureConfiguration.Popup.UseNativePopup = false);
#endif
		}
	}
}
