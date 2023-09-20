﻿#if HAS_UNO_WINUI
#nullable enable

using Windows.UI.ViewManagement;

namespace Windows.UI.Xaml;

public sealed partial class Window
{
	public Window() : this(false)
	{
	}

	public global::Microsoft.UI.Dispatching.DispatcherQueue DispatcherQueue { get; } = global::Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();

#if !__IOS__ // This can be added when iOS uses SceneDelegate #8341.
	/// <summary>
	/// Gets or sets a string used for the window title.
	/// </summary>
	public string Title
	{
		get => ApplicationView.GetForCurrentView().Title;
		set => ApplicationView.GetForCurrentView().Title = value;
	}
#endif
}
#endif
