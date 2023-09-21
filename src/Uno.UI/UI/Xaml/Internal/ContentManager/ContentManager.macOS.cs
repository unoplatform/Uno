﻿#nullable enable

using System;
using AppKit;
using CoreGraphics;
using Uno.UI.Xaml.Core;
using WinUICoreServices = Uno.UI.Xaml.Core.CoreServices;

namespace Uno.UI.Xaml.Controls;

partial class ContentManager
{
	partial void SetupCoreWindowRootVisualPlatform(RootVisual rootVisual)
	{
		if (WinUICoreServices.Instance.ContentRootCoordinator.CoreWindowContentRoot is { } contentRoot)
		{
			contentRoot.SetHost(this); // Enables input manager
		}
		else
		{
			throw new InvalidOperationException("The content root was not initialized.");
		}

		NativeWindowWrapper.Instance.MainController.View = rootVisual;
		rootVisual.Frame = NativeWindowWrapper.Instance.NativeWindow.Frame;
		rootVisual.AutoresizingMask = NSViewResizingMask.WidthSizable | NSViewResizingMask.HeightSizable;
		var windowSize = NativeWindowWrapper.Instance.GetWindowSize();
		// This is required to get the mouse move while not pressed!
		var options = NSTrackingAreaOptions.MouseEnteredAndExited
			| NSTrackingAreaOptions.MouseMoved
			| NSTrackingAreaOptions.ActiveInKeyWindow
			| NSTrackingAreaOptions.EnabledDuringMouseDrag // We want enter/leave events even if the button is pressed
			| NSTrackingAreaOptions.InVisibleRect; // Automagicaly syncs the bounds rect
		var trackingArea = new NSTrackingArea(new CGRect(0, 0, windowSize.Width, windowSize.Height), options, rootVisual, null);

		rootVisual.AddTrackingArea(trackingArea);
	}
}
