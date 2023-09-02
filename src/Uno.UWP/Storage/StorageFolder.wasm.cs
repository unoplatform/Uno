﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using Uno.Foundation;
using Uno.Foundation.Interop;
using Uno.Extensions;
using System.Threading.Tasks;
using Uno.Foundation.Logging;

namespace Windows.Storage
{
	partial class StorageFolder
	{
		private static TaskCompletionSource<bool> _storageInitialized = new TaskCompletionSource<bool>();

		internal void MakePersistent()
			=> MakePersistent(this);

		private static async Task TryInitializeStorage()
		{
			if (typeof(StorageFolder).Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
			{
				typeof(StorageFolder).Log().Debug("Waiting for emscripten storage initialization");
			}

			await _storageInitialized.Task;

			if (typeof(StorageFolder).Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
			{
				typeof(StorageFolder).Log().Debug("Emscripten storage initialized");
			}
		}

		internal static void MakePersistent(params StorageFolder[] folders)
		{
			var parms = new StorageFolderMakePersistentParams()
			{
				Paths = folders.SelectToArray(f => f.Path),
				Paths_Length = folders.Length
			};

			TSInteropMarshaller.InvokeJS("UnoStatic_Windows_Storage_StorageFolder:makePersistent", parms);
		}

		[TSInteropMessage]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		private struct StorageFolderMakePersistentParams
		{
			public int Paths_Length;

			[MarshalAs(UnmanagedType.LPArray, ArraySubType = TSInteropMarshaller.LPUTF8Str)]
			public string[] Paths;
		}

		[JSExport]
		internal static void DispatchStorageInitialized()
		{
			if (typeof(StorageFolder).Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
			{
				typeof(StorageFolder).Log().Debug("Dispatch emscripten storage initialized");
			}

			_storageInitialized.TrySetResult(true);
		}
	}
}
