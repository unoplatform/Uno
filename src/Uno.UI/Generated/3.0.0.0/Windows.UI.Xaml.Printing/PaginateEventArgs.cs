#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Printing
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class PaginateEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  int CurrentPreviewPageNumber
		{
			get
			{
				throw new global::System.NotImplementedException("The member int PaginateEventArgs.CurrentPreviewPageNumber is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=int%20PaginateEventArgs.CurrentPreviewPageNumber");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Graphics.Printing.PrintTaskOptions PrintTaskOptions
		{
			get
			{
				throw new global::System.NotImplementedException("The member PrintTaskOptions PaginateEventArgs.PrintTaskOptions is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=PrintTaskOptions%20PaginateEventArgs.PrintTaskOptions");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public PaginateEventArgs() 
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Printing.PaginateEventArgs", "PaginateEventArgs.PaginateEventArgs()");
		}
		#endif
		// Forced skipping of method Windows.UI.Xaml.Printing.PaginateEventArgs.PaginateEventArgs()
		// Forced skipping of method Windows.UI.Xaml.Printing.PaginateEventArgs.PrintTaskOptions.get
		// Forced skipping of method Windows.UI.Xaml.Printing.PaginateEventArgs.CurrentPreviewPageNumber.get
	}
}
