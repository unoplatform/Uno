#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Media
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	public delegate void RateChangedRoutedEventHandler(object sender, global::Windows.UI.Xaml.Media.RateChangedRoutedEventArgs e);
	#endif
}
