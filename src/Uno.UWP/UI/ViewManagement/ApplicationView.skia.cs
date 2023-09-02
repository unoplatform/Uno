﻿#nullable enable
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno.Foundation.Extensibility;
using Windows.Foundation;

namespace Windows.UI.ViewManagement
{
	partial class ApplicationView
	{
		private readonly IApplicationViewExtension _applicationViewExtension;
		private Size _preferredMinSize;
		private string _title = "";

		public ApplicationView()
		{
			_applicationViewExtension = ApiExtensibility.CreateInstance<IApplicationViewExtension>(this);
		}

		public string Title
		{
			get => _title;
			set
			{
				_title = value;
				OnPropertyChanged();
			}
		}

		internal Size PreferredMinSize
		{
			get => _preferredMinSize;
			set
			{
				_preferredMinSize = value;
				OnPropertyChanged();
			}
		}

		internal PropertyChangedEventHandler? PropertyChanged;

		public bool TryEnterFullScreenMode() => _applicationViewExtension.TryEnterFullScreenMode();

		public void ExitFullScreenMode() => _applicationViewExtension.ExitFullScreenMode();

		public bool TryResizeView(Size value)
		{
			if (value.Width < _preferredMinSize.Width || value.Height < _preferredMinSize.Height)
			{
				return false;
			}
			return _applicationViewExtension.TryResizeView(value);
		}

		public void SetPreferredMinSize(Size minSize) => PreferredMinSize = minSize;

		private void OnPropertyChanged([CallerMemberName] string? name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}

	internal interface IApplicationViewExtension
	{
		bool TryEnterFullScreenMode();

		void ExitFullScreenMode();

		bool TryResizeView(Size size);
	}
}
