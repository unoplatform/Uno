#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Notifications
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class BadgeUpdateManagerForUser 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.System.User User
		{
			get
			{
				throw new global::System.NotImplementedException("The member User BadgeUpdateManagerForUser.User is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=User%20BadgeUpdateManagerForUser.User");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Notifications.BadgeUpdater CreateBadgeUpdaterForApplication()
		{
			throw new global::System.NotImplementedException("The member BadgeUpdater BadgeUpdateManagerForUser.CreateBadgeUpdaterForApplication() is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=BadgeUpdater%20BadgeUpdateManagerForUser.CreateBadgeUpdaterForApplication%28%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Notifications.BadgeUpdater CreateBadgeUpdaterForApplication( string applicationId)
		{
			throw new global::System.NotImplementedException("The member BadgeUpdater BadgeUpdateManagerForUser.CreateBadgeUpdaterForApplication(string applicationId) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=BadgeUpdater%20BadgeUpdateManagerForUser.CreateBadgeUpdaterForApplication%28string%20applicationId%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Notifications.BadgeUpdater CreateBadgeUpdaterForSecondaryTile( string tileId)
		{
			throw new global::System.NotImplementedException("The member BadgeUpdater BadgeUpdateManagerForUser.CreateBadgeUpdaterForSecondaryTile(string tileId) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=BadgeUpdater%20BadgeUpdateManagerForUser.CreateBadgeUpdaterForSecondaryTile%28string%20tileId%29");
		}
		#endif
		// Forced skipping of method Windows.UI.Notifications.BadgeUpdateManagerForUser.User.get
	}
}
