﻿#nullable disable

using Windows.Devices.Input;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Input;

internal interface IPointerExtension
{
	void ReleasePointerCapture(PointerIdentifier pointer, XamlRoot xamlRoot);

	void SetPointerCapture(PointerIdentifier pointer, XamlRoot xamlRoot);
}
