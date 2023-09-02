﻿using Android.Graphics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Rect = Windows.Foundation.Rect;

namespace Microsoft.UI.Xaml.Media;

public partial class RevealBrush : XamlCompositionBrushBase
{
	protected override Paint GetPaintInner(Rect destinationRect)
	{
		var color = this.IsDependencyPropertySet(FallbackColorProperty) ?
			GetColorWithOpacity(FallbackColor) :
			GetColorWithOpacity(Color);
		return new Paint() { Color = color, AntiAlias = true };
	}
}
