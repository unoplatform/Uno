﻿using System;
using System.Threading.Tasks;
#if __IOS__
using UIKit;
#else
using AppKit;
using Foundation;
#endif
using AppleUrl = global::Foundation.NSUrl;

namespace Windows.System
{
	public static partial class Launcher
	{
		public static Task<bool> LaunchUriPlatformAsync(Uri uri)
		{
			if (IsSpecialUri(uri) && CanHandleSpecialUri(uri))
			{
				return Task.FromResult(HandleSpecialUri(uri));
			}

			var appleUrl = new AppleUrl(uri.OriginalString);
#if __IOS__
			return Task.FromResult(UIApplication.SharedApplication.OpenUrl(
				appleUrl));
#else
			return Task.FromResult(NSWorkspace.SharedWorkspace.OpenUrl(
				appleUrl));
#endif
		}


		public static Task<LaunchQuerySupportStatus> QueryUriSupportPlatformAsync(
			Uri uri,
			LaunchQuerySupportType launchQuerySupportType)
		{
			bool canOpenUri;
			if (!IsSpecialUri(uri))
			{
#if __IOS__
				canOpenUri = UIApplication.SharedApplication.CanOpenUrl(
					new AppleUrl(uri.OriginalString));
#else
				canOpenUri = NSWorkspace.SharedWorkspace.UrlForApplication(new NSUrl(uri.AbsoluteUri)) != null;
#endif
			}
			else
			{
				canOpenUri = CanHandleSpecialUri(uri);
			}

			var supportStatus = canOpenUri ?
				LaunchQuerySupportStatus.Available : LaunchQuerySupportStatus.NotSupported;

			return Task.FromResult(supportStatus);
		}
	}
}
