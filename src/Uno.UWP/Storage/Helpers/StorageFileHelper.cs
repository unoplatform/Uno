﻿#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Uno;

namespace Windows.Storage.Helpers;

internal partial class StorageFileHelper
{
	/// <summary>
	/// Determines if an asset or resource exists within the application package
	/// </summary>
	/// <param name="fileName">relative file path</param>
	/// <returns>A task that will complete with a result of true if the file exists, otherwise with a result of false.</returns>
	public static async Task<bool> ExistsInPackage(string fileName) => await FileExistsInPackage(fileName);

#if IS_UNIT_TESTS || __NETSTD_REFERENCE__
	private static Task<bool> FileExistsInPackage(string fileName)
		=> throw new NotImplementedException();
#endif

#if __SKIA__ || WINDOWS || WINAPPSDK || WINDOWS_UWP || WINUI
	private static Task<bool> FileExistsInPackage(string fileName)
	{
		var executingPath = Assembly.GetExecutingAssembly().Location;
		if (!string.IsNullOrEmpty(executingPath))
		{
			var path = Path.GetDirectoryName(executingPath);
			if (!string.IsNullOrEmpty(path))
			{
				var fullPath = Path.Combine(path, fileName);
				return Task.FromResult(File.Exists(fullPath));
			}
		}

		return Task.FromResult(false);
	}
#endif
}
