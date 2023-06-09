﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Uno.Extensions;
using Uno.Helpers;
using Windows.ApplicationModel;

namespace Windows.Storage
{
	partial class StorageFile
	{
		private static async Task<StorageFile> GetFileFromApplicationUri(CancellationToken ct, Uri uri)
		{
			if (uri.Scheme != "ms-appx")
			{
				// ms-appdata is handled by the caller.
				throw new InvalidOperationException("Uri is not using the ms-appx or ms-appdata scheme");
			}

			var path = Uri.UnescapeDataString(uri.PathAndQuery).TrimStart(new char[] { '/' });

			var resourcePathname = global::System.IO.Path.Combine(Package.Current.InstalledPath, uri.Host, path);

			if (resourcePathname != null)
			{
				return await StorageFile.GetFileFromPathAsync(resourcePathname);
			}
			else
			{
				throw new FileNotFoundException($"The file [{path}] cannot be found  in the package directory");
			}
		}
	}
}
