#nullable enable

using System;
using Uno.Foundation;
using Uno.Foundation.Extensibility;
using Windows.Foundation;

namespace Windows.UI.Core
{
	public partial class CoreWindow
	{
		private ICoreWindowExtension _coreWindowExtension = default!; // Init in partial ctor.

		public event TypedEventHandler<CoreWindow, KeyEventArgs>? KeyDown;
		public event TypedEventHandler<CoreWindow, KeyEventArgs>? KeyUp;

		partial void InitializePartial()
		{
			_coreWindowExtension = ApiExtensibility.CreateInstance<ICoreWindowExtension>(this);
		}

		internal event TypedEventHandler<CoreWindow, KeyEventArgs>? NativeKeyDownReceived;
		internal event TypedEventHandler<CoreWindow, KeyEventArgs>? NativeKeyUpReceived;

		internal bool IsNativeElement(object content)
			=> _coreWindowExtension.IsNativeElement(content);

		internal void AttachNativeElement(object owner, object content)
			=> _coreWindowExtension.AttachNativeElement(owner, content);

		internal void DetachNativeElement(object owner, object content)
			=> _coreWindowExtension.DetachNativeElement(owner, content);

		internal void ArrangeNativeElement(object owner, object content, Rect arrangeRect, Rect? clipRect)
			=> _coreWindowExtension.ArrangeNativeElement(owner, content, arrangeRect, clipRect);

		internal Size MeasureNativeElement(object owner, object content, Size childMeasuredSize, Size availableSize)
			=> _coreWindowExtension.MeasureNativeElement(owner, content, childMeasuredSize, availableSize);

		internal void ChangeNativeElementVisiblity(object owner, object content, bool visible)
			=> _coreWindowExtension.ChangeNativeElementVisiblity(owner, content, visible);

		internal void ChangeNativeElementOpacity(object owner, object content, double opacity)
			=> _coreWindowExtension.ChangeNativeElementOpacity(owner, content, opacity);

		internal object? CreateSampleComponent(string text) => _coreWindowExtension.CreateSampleComponent(text);

		internal bool IsNativeElementAttached(object owner, object nativeElement)
			=> _coreWindowExtension.IsNativeElementAttached(owner, nativeElement);

		internal void RaiseNativeKeyDownReceived(KeyEventArgs args)
		{
			NativeKeyDownReceived?.Invoke(this, args);
			KeyDown?.Invoke(this, args);
		}
		internal void RaiseNativeKeyUpReceived(KeyEventArgs args)
		{
			NativeKeyUpReceived?.Invoke(this, args);
			KeyUp?.Invoke(this, args);
		}
	}
}
