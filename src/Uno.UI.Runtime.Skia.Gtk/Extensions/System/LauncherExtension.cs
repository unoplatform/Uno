﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Uno.Extensions;
using Uno.Extensions.System;
using Uno.UI.Runtime.Skia.Gtk.Extensions.System.LauncherHelpers;
using Windows.System;
using Uno.Foundation.Logging;

namespace Uno.UI.Runtime.Skia.Gtk.Extensions.System
{
	internal class LauncherExtension : ILauncherExtension
	{
		public LauncherExtension(object owner)
		{
		}

		public Task<bool> LaunchUriAsync(Uri uri)
		{
			var processStartInfo = new ProcessStartInfo(uri.OriginalString)
			{
				UseShellExecute = true,
				Verb = "open"
			};

			var process = new Process()
			{
				StartInfo = processStartInfo
			};

			return Task.FromResult(process.Start());
		}

		public Task<LaunchQuerySupportStatus> QueryUriSupportAsync(Uri uri, LaunchQuerySupportType launchQuerySupportType)
		{
			return Task.Run(() =>
			{
				bool? canOpenUri = null;

				try
				{
					// Easiest way:
					canOpenUri = CheckXdgSettings(uri);
				}
				catch (Exception exception)
				{
					// Failure here does not affect the the query.
					if (typeof(LauncherExtension).Log().IsEnabled(LogLevel.Error))
					{
						typeof(LauncherExtension).Log().Error($"Failed to invoke xdg-settings", exception);
					}
				}

				// Guaranteed to work on all Linux Gtk platforms.
				canOpenUri ??= CheckMimeTypeAssociations(uri);

				return canOpenUri.Value ?
					LaunchQuerySupportStatus.Available : LaunchQuerySupportStatus.NotSupported;
			});
		}

		private bool CheckXdgSettings(Uri uri)
		{
			var process = new Process()
			{
				StartInfo = new ProcessStartInfo()
				{
					FileName = "xdg-settings",
					Arguments = $"get default-url-scheme-handler {uri.Scheme}",
					RedirectStandardOutput = true
				}
			};
			process.Start();
			var response = process.StandardOutput.ReadToEnd().Trim();
			return !string.IsNullOrEmpty(response);
		}

		private bool CheckMimeTypeAssociations(Uri uri)
		{
			var list = new MimeAppsList();
			var mimeType = $"x-scheme-handler/{uri.Scheme}";
			return list.Supports(mimeType);
		}
	}
}
