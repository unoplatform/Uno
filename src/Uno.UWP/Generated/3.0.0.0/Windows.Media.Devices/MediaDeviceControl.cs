#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Media.Devices
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class MediaDeviceControl 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Media.Devices.MediaDeviceControlCapabilities Capabilities
		{
			get
			{
				throw new global::System.NotImplementedException("The member MediaDeviceControlCapabilities MediaDeviceControl.Capabilities is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=MediaDeviceControlCapabilities%20MediaDeviceControl.Capabilities");
			}
		}
		#endif
		// Forced skipping of method Windows.Media.Devices.MediaDeviceControl.Capabilities.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool TryGetValue(out double value)
		{
			throw new global::System.NotImplementedException("The member bool MediaDeviceControl.TryGetValue(out double value) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20MediaDeviceControl.TryGetValue%28out%20double%20value%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool TrySetValue( double value)
		{
			throw new global::System.NotImplementedException("The member bool MediaDeviceControl.TrySetValue(double value) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20MediaDeviceControl.TrySetValue%28double%20value%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool TryGetAuto(out bool value)
		{
			throw new global::System.NotImplementedException("The member bool MediaDeviceControl.TryGetAuto(out bool value) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20MediaDeviceControl.TryGetAuto%28out%20bool%20value%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool TrySetAuto( bool value)
		{
			throw new global::System.NotImplementedException("The member bool MediaDeviceControl.TrySetAuto(bool value) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20MediaDeviceControl.TrySetAuto%28bool%20value%29");
		}
		#endif
	}
}
