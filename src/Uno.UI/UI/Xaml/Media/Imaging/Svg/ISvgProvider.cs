﻿#nullable enable

using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Microsoft.UI.Xaml;

#if __SKIA__
using SkiaSharp;
#endif

namespace Uno.UI.Xaml.Media.Imaging.Svg;

/// <summary>
/// This interface is used internally by Uno Platform
/// to allow the installation of SVG Addin.
/// Avoid using this interface directly, as its signature
/// may change.
/// </summary>
public interface ISvgProvider
{
	UIElement GetCanvas();

	bool IsParsed { get; }

	Size SourceSize { get; }

	event EventHandler? SourceLoaded;

	Task<bool> TryLoadSvgDataAsync(byte[] imageData);

#if __SKIA__
	SKPicture? TryGetLoadedDataAsPictureAsync();
#endif

	void Unload();
}
