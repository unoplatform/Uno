#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Phone.Notification.Management
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class EmailFolderInfo 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string DisplayName
		{
			get
			{
				throw new global::System.NotImplementedException("The member string EmailFolderInfo.DisplayName is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=string%20EmailFolderInfo.DisplayName");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool IsNotificationEnabled
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool EmailFolderInfo.IsNotificationEnabled is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20EmailFolderInfo.IsNotificationEnabled");
			}
		}
		#endif
		// Forced skipping of method Windows.Phone.Notification.Management.EmailFolderInfo.DisplayName.get
		// Forced skipping of method Windows.Phone.Notification.Management.EmailFolderInfo.IsNotificationEnabled.get
	}
}
