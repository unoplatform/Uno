#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class PropertyMetadata 
	{
		// Skipping already declared property CreateDefaultValueCallback
		// Skipping already declared property DefaultValue
		// Skipping already declared method Windows.UI.Xaml.PropertyMetadata.PropertyMetadata(object)
		// Forced skipping of method Windows.UI.Xaml.PropertyMetadata.PropertyMetadata(object)
		// Skipping already declared method Windows.UI.Xaml.PropertyMetadata.PropertyMetadata(object, Windows.UI.Xaml.PropertyChangedCallback)
		// Forced skipping of method Windows.UI.Xaml.PropertyMetadata.PropertyMetadata(object, Windows.UI.Xaml.PropertyChangedCallback)
		// Forced skipping of method Windows.UI.Xaml.PropertyMetadata.DefaultValue.get
		// Forced skipping of method Windows.UI.Xaml.PropertyMetadata.CreateDefaultValueCallback.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.UI.Xaml.PropertyMetadata Create( object defaultValue)
		{
			throw new global::System.NotImplementedException("The member PropertyMetadata PropertyMetadata.Create(object defaultValue) is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.UI.Xaml.PropertyMetadata Create( object defaultValue,  global::Windows.UI.Xaml.PropertyChangedCallback propertyChangedCallback)
		{
			throw new global::System.NotImplementedException("The member PropertyMetadata PropertyMetadata.Create(object defaultValue, PropertyChangedCallback propertyChangedCallback) is not implemented in Uno.");
		}
		#endif
		// Skipping already declared method Windows.UI.Xaml.PropertyMetadata.Create(Windows.UI.Xaml.CreateDefaultValueCallback)
		// Skipping already declared method Windows.UI.Xaml.PropertyMetadata.Create(Windows.UI.Xaml.CreateDefaultValueCallback, Windows.UI.Xaml.PropertyChangedCallback)
	}
}
