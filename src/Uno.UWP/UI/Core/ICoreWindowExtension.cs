using System;
using System.Linq;
using Windows.Devices.Input;
using Windows.Foundation;

namespace Windows.UI.Core;

internal interface ICoreWindowExtension
{
#if UNO_SUPPORTS_NATIVEHOST
	bool IsNativeElement(object content);

	void AttachNativeElement(object owner, object content);

	void DetachNativeElement(object owner, object content);

	void ArrangeNativeElement(object owner, object content, Rect arrangeRect, Rect? clipRect);

	Size MeasureNativeElement(object owner, object content, Size childMeasuredSize, Size availableSize);

	object CreateSampleComponent(string text); // useful for internal testing

	bool IsNativeElementAttached(object owner, object nativeElement);

	void ChangeNativeElementVisiblity(object owner, object content, bool visible);

	void ChangeNativeElementOpacity(object owner, object content, double opacity);
#endif
}
