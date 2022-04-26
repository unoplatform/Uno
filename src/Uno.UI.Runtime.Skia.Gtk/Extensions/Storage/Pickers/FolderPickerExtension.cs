﻿#nullable enable

using Gtk;
using System;
using System.Threading;
using System.Threading.Tasks;
using Uno.UI.Runtime.Skia;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Uno.Extensions.Storage.Pickers
{
	internal class FolderPickerExtension : IFolderPickerExtension
	{
		private readonly FolderPicker _picker;

		public FolderPickerExtension(FolderPicker owner)
		{
			_picker = owner ?? throw new ArgumentNullException(nameof(owner));
		}

		public async Task<StorageFolder?> PickSingleFolderAsync(CancellationToken token)
		{
			string commitText = "Select Folder";
			if (!string.IsNullOrWhiteSpace(_picker.CommitButtonText))
			{
				commitText = _picker.CommitButtonText;
			}

			FileChooserDialog dialog = new FileChooserDialog(
				"Select Folder",
				GtkHost.Window,
				FileChooserAction.SelectFolder,
				"Cancel", ResponseType.Cancel,
				commitText, ResponseType.Accept);

			dialog.SelectMultiple = false;

			if (!_picker.FileTypeFilter.Contains("*"))
			{
				throw new ArgumentNullException();
			}

			dialog.SetCurrentFolder(PickerHelpers.GetInitialDirectory(_picker.SuggestedStartLocation));

			StorageFolder folder = null;
			if (dialog.Run() == (int)ResponseType.Accept)
			{
				folder = await StorageFolder.GetFolderFromPathAsync(dialog.Filename);
			}

			dialog.Destroy();
			return folder;
		}
	}
}
