#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Data.Pdf
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class PdfDocument 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool IsPasswordProtected
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool PdfDocument.IsPasswordProtected is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20PdfDocument.IsPasswordProtected");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  uint PageCount
		{
			get
			{
				throw new global::System.NotImplementedException("The member uint PdfDocument.PageCount is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=uint%20PdfDocument.PageCount");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Data.Pdf.PdfPage GetPage( uint pageIndex)
		{
			throw new global::System.NotImplementedException("The member PdfPage PdfDocument.GetPage(uint pageIndex) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=PdfPage%20PdfDocument.GetPage%28uint%20pageIndex%29");
		}
		#endif
		// Forced skipping of method Windows.Data.Pdf.PdfDocument.PageCount.get
		// Forced skipping of method Windows.Data.Pdf.PdfDocument.IsPasswordProtected.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.Foundation.IAsyncOperation<global::Windows.Data.Pdf.PdfDocument> LoadFromFileAsync( global::Windows.Storage.IStorageFile file)
		{
			throw new global::System.NotImplementedException("The member IAsyncOperation<PdfDocument> PdfDocument.LoadFromFileAsync(IStorageFile file) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IAsyncOperation%3CPdfDocument%3E%20PdfDocument.LoadFromFileAsync%28IStorageFile%20file%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.Foundation.IAsyncOperation<global::Windows.Data.Pdf.PdfDocument> LoadFromFileAsync( global::Windows.Storage.IStorageFile file,  string password)
		{
			throw new global::System.NotImplementedException("The member IAsyncOperation<PdfDocument> PdfDocument.LoadFromFileAsync(IStorageFile file, string password) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IAsyncOperation%3CPdfDocument%3E%20PdfDocument.LoadFromFileAsync%28IStorageFile%20file%2C%20string%20password%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.Foundation.IAsyncOperation<global::Windows.Data.Pdf.PdfDocument> LoadFromStreamAsync( global::Windows.Storage.Streams.IRandomAccessStream inputStream)
		{
			throw new global::System.NotImplementedException("The member IAsyncOperation<PdfDocument> PdfDocument.LoadFromStreamAsync(IRandomAccessStream inputStream) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IAsyncOperation%3CPdfDocument%3E%20PdfDocument.LoadFromStreamAsync%28IRandomAccessStream%20inputStream%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.Foundation.IAsyncOperation<global::Windows.Data.Pdf.PdfDocument> LoadFromStreamAsync( global::Windows.Storage.Streams.IRandomAccessStream inputStream,  string password)
		{
			throw new global::System.NotImplementedException("The member IAsyncOperation<PdfDocument> PdfDocument.LoadFromStreamAsync(IRandomAccessStream inputStream, string password) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IAsyncOperation%3CPdfDocument%3E%20PdfDocument.LoadFromStreamAsync%28IRandomAccessStream%20inputStream%2C%20string%20password%29");
		}
		#endif
	}
}
