﻿#nullable enable

using System;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Controls;

internal partial class NativeWindowFactory
{
	public static INativeWindowWrapper? CreateWindow(Windows.UI.Xaml.Window window, XamlRoot xamlRoot)
	{
		if (window is null)
		{
			throw new ArgumentNullException(nameof(window));
		}

		if (xamlRoot is null)
		{
			throw new ArgumentNullException(nameof(xamlRoot));
		}

		return CreateWindowPlatform(window, xamlRoot);
	}

#if !__SKIA__
	private static INativeWindowWrapper? CreateWindowPlatform(Windows.UI.Xaml.Window window, XamlRoot xamlRoot) => null;
#endif
}
