#nullable disable

#if WINDOWS_UWP
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Storage;

namespace Uno.UI.RuntimeTests.Tests.Windows_Storage
{
	[TestClass]
	public class Given_FileIO_Native : Given_FileIO_Native_Base
	{
		private StorageFolder? _rootFolder;

		protected override async Task<StorageFolder> GetRootFolderAsync()
		{
			var testFolderName = Guid.NewGuid().ToString();
			_rootFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(testFolderName);
			return _rootFolder;
		}

		protected override async Task CleanupRootFolderAsync()
		{
			if (_rootFolder != null)
			{
				await _rootFolder.DeleteAsync();
			}
		}
	}
}
#endif
