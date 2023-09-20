﻿#nullable enable

using System;
using System.ComponentModel;
using System.IO;
using Uno.Foundation.Logging;
using Uno.UI.Runtime.Skia.Wpf.Hosting;
using Uno.UI.Xaml.Controls;
using Uno.UI.Xaml.Core;
using Windows.Foundation;
using Windows.UI.Core.Preview;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using WinUI = Windows.UI.Xaml;
using WinUIApplication = Windows.UI.Xaml.Application;
using WpfWindow = System.Windows.Window;

namespace Uno.UI.Runtime.Skia.Wpf.UI.Controls;

internal class UnoWpfWindow : WpfWindow
{
	private readonly WinUI.Window _winUIWindow;
	private IWpfWindowHost _host;

	public UnoWpfWindow(WinUI.Window winUIWindow, XamlRoot xamlRoot)
	{
		_winUIWindow = winUIWindow ?? throw new ArgumentNullException(nameof(winUIWindow));
		_winUIWindow.Showing += OnShowing;

		Windows.Foundation.Size preferredWindowSize = ApplicationView.PreferredLaunchViewSize;
		if (preferredWindowSize != Windows.Foundation.Size.Empty)
		{
			Width = (int)preferredWindowSize.Width;
			Height = (int)preferredWindowSize.Height;
		}

		Content = _host = new UnoWpfWindowHost(this, winUIWindow);
		WpfManager.XamlRootMap.Register(xamlRoot, _host);

		ApplicationView.GetForCurrentView().PropertyChanged += OnApplicationViewPropertyChanged;
	}

	internal void OnArrange(Size arrangeSize)
	{

	}

	//TODO:MZ: Call this?
	private void OnCoreWindowContentRootSet(object? sender, object e)
	{
		var contentRoot = CoreServices.Instance
				.ContentRootCoordinator
				.CoreWindowContentRoot;

		var xamlRoot = contentRoot?.GetOrCreateXamlRoot();

		if (xamlRoot is null)
		{
			throw new InvalidOperationException("XamlRoot was not properly initialized");
		}

		contentRoot!.SetHost(this);
		WpfManager.XamlRootMap.Register(xamlRoot, _host);

		CoreServices.Instance.ContentRootCoordinator.CoreWindowContentRootSet -= OnCoreWindowContentRootSet;
	}

	private void OnShowing(object? sender, EventArgs e) => Show();

	private void OnApplicationViewPropertyChanged(object? sender, PropertyChangedEventArgs e) => UpdateWindowPropertiesFromApplicationView();

	internal void UpdateWindowPropertiesFromApplicationView()
	{
		var appView = ApplicationView.GetForCurrentView();
		Title = appView.Title;
		MinWidth = appView.PreferredMinSize.Width;
		MinHeight = appView.PreferredMinSize.Height;
	}

	internal void UpdateWindowPropertiesFromPackage()
	{
		if (Windows.ApplicationModel.Package.Current.Logo is Uri uri)
		{
			var basePath = uri.OriginalString.Replace('\\', Path.DirectorySeparatorChar);
			var iconPath = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledPath, basePath);

			if (File.Exists(iconPath))
			{
				if (this.Log().IsEnabled(LogLevel.Information))
				{
					this.Log().Info($"Loading icon file [{iconPath}] from Package.appxmanifest file");
				}

				Icon = new System.Windows.Media.Imaging.BitmapImage(new Uri(iconPath));
			}
			else if (Windows.UI.Xaml.Media.Imaging.BitmapImage.GetScaledPath(basePath) is { } scaledPath && File.Exists(scaledPath))
			{
				if (this.Log().IsEnabled(LogLevel.Information))
				{
					this.Log().Info($"Loading icon file [{scaledPath}] scaled logo from Package.appxmanifest file");
				}

				Icon = new System.Windows.Media.Imaging.BitmapImage(new Uri(scaledPath));
			}
			else
			{
				if (this.Log().IsEnabled(LogLevel.Warning))
				{
					this.Log().Warn($"Unable to find icon file [{iconPath}] specified in the Package.appxmanifest file.");
				}
			}
		}

		if (string.IsNullOrEmpty(ApplicationView.GetForCurrentView().Title))
		{
			ApplicationView.GetForCurrentView().Title = Windows.ApplicationModel.Package.Current.DisplayName;
		}
	}
}
