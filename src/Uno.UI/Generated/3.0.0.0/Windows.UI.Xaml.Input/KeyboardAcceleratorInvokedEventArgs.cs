#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Input
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class KeyboardAcceleratorInvokedEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool Handled
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool KeyboardAcceleratorInvokedEventArgs.Handled is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20KeyboardAcceleratorInvokedEventArgs.Handled");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.KeyboardAcceleratorInvokedEventArgs", "bool KeyboardAcceleratorInvokedEventArgs.Handled");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Xaml.DependencyObject Element
		{
			get
			{
				throw new global::System.NotImplementedException("The member DependencyObject KeyboardAcceleratorInvokedEventArgs.Element is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=DependencyObject%20KeyboardAcceleratorInvokedEventArgs.Element");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Xaml.Input.KeyboardAccelerator KeyboardAccelerator
		{
			get
			{
				throw new global::System.NotImplementedException("The member KeyboardAccelerator KeyboardAcceleratorInvokedEventArgs.KeyboardAccelerator is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=KeyboardAccelerator%20KeyboardAcceleratorInvokedEventArgs.KeyboardAccelerator");
			}
		}
		#endif
		// Forced skipping of method Windows.UI.Xaml.Input.KeyboardAcceleratorInvokedEventArgs.Handled.get
		// Forced skipping of method Windows.UI.Xaml.Input.KeyboardAcceleratorInvokedEventArgs.Handled.set
		// Forced skipping of method Windows.UI.Xaml.Input.KeyboardAcceleratorInvokedEventArgs.Element.get
		// Forced skipping of method Windows.UI.Xaml.Input.KeyboardAcceleratorInvokedEventArgs.KeyboardAccelerator.get
	}
}
