﻿namespace Windows.UI.Xaml.Controls;

public partial class Canvas
{
	static partial void OnZIndexChangedPartial(UIElement element, double? zindex)
	{
		element.Visual.ZIndex = (int)zindex;
	}
}
