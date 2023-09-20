﻿#nullable enable

using System;
using System.Collections.Generic;
using Gtk;
using Uno.Foundation.Logging;
using Uno.UI.Xaml.Controls;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Core.Preview;
using Windows.UI.Xaml;
using WinUIApplication = Windows.UI.Xaml.Application;

namespace Uno.UI.Runtime.Skia.Gtk.UI.Controls;

internal class GtkWindowWrapper : INativeWindowWrapper
{
	private bool _wasShown;
	private readonly UnoGtkWindow _gtkWindow;
	private List<PendingWindowStateChangedInfo>? _pendingWindowStateChanged = new();

	public GtkWindowWrapper(UnoGtkWindow wpfWindow)
	{
		_gtkWindow = wpfWindow ?? throw new ArgumentNullException(nameof(wpfWindow));
		_gtkWindow.Shown += OnWindowShown;
		_gtkWindow.Host.SizeChanged += OnHostSizeChanged;
		_gtkWindow.DeleteEvent += WindowClosing;
		_gtkWindow.WindowStateEvent += OnWindowStateChanged;
	}

	public void Show() => _gtkWindow.ShowAll();

	private void OnWindowShown(object? sender, EventArgs e)
	{
		_wasShown = true;
		ReplayPendingWindowStateChanges();
	}

	public UnoGtkWindow NativeWindow => _gtkWindow;

	public bool Visible => _gtkWindow.IsVisible;

	public event EventHandler<CoreWindowActivationState>? ActivationChanged;
	public event EventHandler<bool>? VisibilityChanged;
	public event EventHandler? Closed;
	public event EventHandler<Size>? SizeChanged;

	public void Activate() => _gtkWindow.Activate();

	private void WindowClosing(object sender, DeleteEventArgs args)
	{
		var manager = SystemNavigationManagerPreview.GetForCurrentView();
		if (!manager.HasConfirmedClose)
		{
			if (!manager.RequestAppClose())
			{
				// App closing was prevented, handle event
				args.RetVal = true;
				return;
			}
		}

		// Closing should continue, perform suspension.
		WinUIApplication.Current.RaiseSuspending();

		// All prerequisites passed, can safely close.
		args.RetVal = false;
		Main.Quit();
	}

	private void OnHostSizeChanged(object? sender, Windows.Foundation.Size e)
	{
		SizeChanged?.Invoke(this, e);
	}

	private void OnWindowStateChanged(object o, WindowStateEventArgs args)
	{
		var newState = args.Event.NewWindowState;
		var changedMask = args.Event.ChangedMask;

		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"OnWindowStateChanged: {newState}/{changedMask}");
		}

		if (_wasShown)
		{
			ProcessWindowStateChanged(newState, changedMask);
		}
		else
		{
			// Store state changes to replay once the application has been
			// initalized completely (initialization can be delayed if the render
			// surface is automatically detected).
			_pendingWindowStateChanged?.Add(new(newState, changedMask));
		}
	}

	private void ReplayPendingWindowStateChanges()
	{
		if (_pendingWindowStateChanged is not null)
		{
			foreach (var state in _pendingWindowStateChanged)
			{
				ProcessWindowStateChanged(state.newState, state.changedMask);
			}

			_pendingWindowStateChanged = null;
		}
	}

	private void ProcessWindowStateChanged(Gdk.WindowState newState, Gdk.WindowState changedMask)
	{
		var winUIApplication = WinUIApplication.Current;

		var isVisible =
			!(newState.HasFlag(Gdk.WindowState.Withdrawn) ||
			newState.HasFlag(Gdk.WindowState.Iconified));

		var isVisibleChanged =
			changedMask.HasFlag(Gdk.WindowState.Withdrawn) ||
			changedMask.HasFlag(Gdk.WindowState.Iconified);

		var focused = newState.HasFlag(Gdk.WindowState.Focused);
		var focusChanged = changedMask.HasFlag(Gdk.WindowState.Focused);

		if (!focused && focusChanged)
		{
			ActivationChanged?.Invoke(this, Windows.UI.Core.CoreWindowActivationState.Deactivated);
		}

		if (isVisibleChanged)
		{
			if (isVisible)
			{
				winUIApplication?.RaiseLeavingBackground(() => VisibilityChanged?.Invoke(this, true));
			}
			else
			{
				VisibilityChanged?.Invoke(this, false);
				winUIApplication?.RaiseEnteredBackground(null);
			}
		}

		if (focused && focusChanged)
		{
			ActivationChanged?.Invoke(this, Windows.UI.Core.CoreWindowActivationState.CodeActivated);
		}
	}
}
