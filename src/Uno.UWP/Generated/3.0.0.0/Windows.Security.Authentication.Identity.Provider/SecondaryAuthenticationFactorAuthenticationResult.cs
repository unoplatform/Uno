#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Security.Authentication.Identity.Provider
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class SecondaryAuthenticationFactorAuthenticationResult 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Security.Authentication.Identity.Provider.SecondaryAuthenticationFactorAuthentication Authentication
		{
			get
			{
				throw new global::System.NotImplementedException("The member SecondaryAuthenticationFactorAuthentication SecondaryAuthenticationFactorAuthenticationResult.Authentication is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=SecondaryAuthenticationFactorAuthentication%20SecondaryAuthenticationFactorAuthenticationResult.Authentication");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Security.Authentication.Identity.Provider.SecondaryAuthenticationFactorAuthenticationStatus Status
		{
			get
			{
				throw new global::System.NotImplementedException("The member SecondaryAuthenticationFactorAuthenticationStatus SecondaryAuthenticationFactorAuthenticationResult.Status is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=SecondaryAuthenticationFactorAuthenticationStatus%20SecondaryAuthenticationFactorAuthenticationResult.Status");
			}
		}
		#endif
		// Forced skipping of method Windows.Security.Authentication.Identity.Provider.SecondaryAuthenticationFactorAuthenticationResult.Status.get
		// Forced skipping of method Windows.Security.Authentication.Identity.Provider.SecondaryAuthenticationFactorAuthenticationResult.Authentication.get
	}
}
