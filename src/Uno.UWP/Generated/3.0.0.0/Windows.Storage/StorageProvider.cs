#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Storage
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class StorageProvider 
	{
		// Skipping already declared property DisplayName
		// Skipping already declared property Id
		// Forced skipping of method Windows.Storage.StorageProvider.Id.get
		// Forced skipping of method Windows.Storage.StorageProvider.DisplayName.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Foundation.IAsyncOperation<bool> IsPropertySupportedForPartialFileAsync( string propertyCanonicalName)
		{
			throw new global::System.NotImplementedException("The member IAsyncOperation<bool> StorageProvider.IsPropertySupportedForPartialFileAsync(string propertyCanonicalName) is not implemented in Uno.");
		}
		#endif
	}
}
