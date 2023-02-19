#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.ApplicationModel.AppExtensions
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class AppExtensionPackageInstalledEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string AppExtensionName
		{
			get
			{
				throw new global::System.NotImplementedException("The member string AppExtensionPackageInstalledEventArgs.AppExtensionName is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=string%20AppExtensionPackageInstalledEventArgs.AppExtensionName");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.Collections.Generic.IReadOnlyList<global::Windows.ApplicationModel.AppExtensions.AppExtension> Extensions
		{
			get
			{
				throw new global::System.NotImplementedException("The member IReadOnlyList<AppExtension> AppExtensionPackageInstalledEventArgs.Extensions is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IReadOnlyList%3CAppExtension%3E%20AppExtensionPackageInstalledEventArgs.Extensions");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Package Package
		{
			get
			{
				throw new global::System.NotImplementedException("The member Package AppExtensionPackageInstalledEventArgs.Package is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Package%20AppExtensionPackageInstalledEventArgs.Package");
			}
		}
		#endif
		// Forced skipping of method Windows.ApplicationModel.AppExtensions.AppExtensionPackageInstalledEventArgs.AppExtensionName.get
		// Forced skipping of method Windows.ApplicationModel.AppExtensions.AppExtensionPackageInstalledEventArgs.Package.get
		// Forced skipping of method Windows.ApplicationModel.AppExtensions.AppExtensionPackageInstalledEventArgs.Extensions.get
	}
}
