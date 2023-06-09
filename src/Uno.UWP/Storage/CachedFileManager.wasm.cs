﻿using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Uno.Foundation;
using Uno.Storage.Internal;
using Windows.Storage.Provider;

#if NET7_0_OR_GREATER
using NativeMethods = __Windows.Storage.Pickers.FileSavePicker.NativeMethods;
#endif

namespace Windows.Storage
{
	public static partial class CachedFileManager
	{
		private static async Task<FileUpdateStatus> CompleteUpdatesTaskAsync(IStorageFile file, CancellationToken token)
		{
			if (file is StorageFile storageFile && storageFile.Provider == StorageProviders.WasmDownloadPicker)
			{
				var stream = await file.OpenStreamForReadAsync();
				byte[] data;

				using (var reader = new BinaryReader(stream))
				{
					data = reader.ReadBytes((int)stream.Length);
				}

				var gch = GCHandle.Alloc(data, GCHandleType.Pinned);
				var pinnedData = gch.AddrOfPinnedObject();

				try
				{
#if NET7_0_OR_GREATER
					NativeMethods.SaveAs(file.Name, pinnedData, data.Length);
#else
					WebAssemblyRuntime.InvokeJS($"Windows.Storage.Pickers.FileSavePicker.SaveAs('{file.Name}', {pinnedData}, {data.Length})");
#endif
				}
				finally
				{
					gch.Free();
				}
			}

			return FileUpdateStatus.Complete;
		}
	}
}
