﻿using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Windows.Foundation;
using Microsoft.UI.Windowing.Native;
using Windows.UI.ViewManagement;
using MUXWindowId = Microsoft.UI.WindowId;

namespace Microsoft.UI.Windowing;

#if HAS_UNO_WINUI
public
#else
internal
#endif
partial class AppWindow
{
	private static readonly ConcurrentDictionary<MUXWindowId, AppWindow> _windowIdMap = new();
	private static ulong _windowIdIterator;

	private INativeAppWindow _nativeAppWindow;

	private AppWindowPresenter _presenter;
	private string _titleCache; // only use this until the _nativeAppWindow is set

	internal AppWindow()
	{
		Id = new(Interlocked.Increment(ref _windowIdIterator));

		_windowIdMap[Id] = this;
		ApplicationView.GetOrCreateForWindowId(Id);
	}

	public event TypedEventHandler<AppWindow, AppWindowChangedEventArgs> Changed;

	public string Title
	{
		get => _nativeAppWindow is not null ? _nativeAppWindow.Title : _titleCache;
		set
		{
			if (_nativeAppWindow is not null)
			{
				_nativeAppWindow.Title = value;
			}

			_titleCache = value;
		}
	}

#if __IOS__
	internal UIKit.UIScreen Screen => _nativeAppWindow.Screen;
#elif __MACOS__
	internal AppKit.NSScreen Screen => _nativeAppWindow.Screen;
#endif

	internal void SetNativeWindow(INativeAppWindow nativeAppWindow)
	{
		if (nativeAppWindow is null)
		{
			throw new ArgumentNullException(nameof(nativeAppWindow));
		}

		_nativeAppWindow = nativeAppWindow;

		if (string.IsNullOrWhiteSpace(_nativeAppWindow.Title) && !string.IsNullOrWhiteSpace(_titleCache))
		{
			_nativeAppWindow.Title = _titleCache;
		}
		else
		{
			_titleCache = _nativeAppWindow.Title;
		}

		SetPresenter(AppWindowPresenterKind.Default);
	}

	public event TypedEventHandler<AppWindow, AppWindowClosingEventArgs> Closing;

	internal static MUXWindowId MainWindowId { get; } = new(1);

	public MUXWindowId Id { get; }

	public AppWindowPresenter Presenter => _presenter;

	public static AppWindow GetFromWindowId(MUXWindowId windowId)
	{
		if (!_windowIdMap.TryGetValue(windowId, out var appWindow))
		{
			throw new InvalidOperationException("Window not found");
		}

		return appWindow;
	}

	internal static bool TryGetFromWindowId(MUXWindowId windowId, [NotNullWhen(true)] out AppWindow appWindow)
		=> _windowIdMap.TryGetValue(windowId, out appWindow);

	public void SetPresenter(AppWindowPresenter appWindowPresenter)
	{
		if (_presenter == appWindowPresenter)
		{
			return;
		}

		if (_presenter is not null)
		{
			_presenter.SetOwner(null);
		}

		appWindowPresenter.SetOwner(this);
		_presenter = appWindowPresenter;
		_nativeAppWindow.SetPresenter(_presenter);
		Changed?.Invoke(this, new AppWindowChangedEventArgs() { DidPresenterChange = true });
	}

	public void SetPresenter(AppWindowPresenterKind appWindowPresenterKind)
	{
		switch (appWindowPresenterKind)
		{
			case AppWindowPresenterKind.CompactOverlay:
				throw new NotSupportedException("CompactOverlay presenter is not yet supported for non-Windows targets.");
			case AppWindowPresenterKind.FullScreen:
				SetPresenter(FullScreenPresenter.Create());
				break;
			case AppWindowPresenterKind.Overlapped:
			case AppWindowPresenterKind.Default:
				SetPresenter(OverlappedPresenter.Create());
				break;
			default:
				throw new InvalidOperationException("Invalid presenter kind");
		}
	}

	internal void RaiseClosing(AppWindowClosingEventArgs args) => Closing?.Invoke(this, args);
}
