#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Data.Json
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public static partial class JsonError 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.Data.Json.JsonErrorStatus GetJsonStatus( int hresult)
		{
			throw new global::System.NotImplementedException("The member JsonErrorStatus JsonError.GetJsonStatus(int hresult) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=JsonErrorStatus%20JsonError.GetJsonStatus%28int%20hresult%29");
		}
		#endif
	}
}
