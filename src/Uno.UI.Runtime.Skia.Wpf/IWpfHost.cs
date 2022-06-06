#nullable enable

using Windows.Devices.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using WpfCanvas = System.Windows.Controls.Canvas;

namespace Uno.UI.Runtime.Skia.Wpf
{
	internal interface IWpfHost
	{
		XamlRoot? XamlRoot { get; }

		WpfCanvas? NativeOverlayLayer { get;}

		void ReleasePointerCapture(Pointer pointer);
		
		void SetPointerCapture(Pointer pointer);
	}
}
