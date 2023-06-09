#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Media
{
	#if __ANDROID__ || __IOS__ || NET461 || false || false || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__NETSTD_REFERENCE__", "__MACOS__")]
	#endif
	public  partial class LineGeometry : global::Windows.UI.Xaml.Media.Geometry
	{
		#if __ANDROID__ || __IOS__ || NET461 || false || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Foundation.Point StartPoint
		{
			get
			{
				return (global::Windows.Foundation.Point)this.GetValue(StartPointProperty);
			}
			set
			{
				this.SetValue(StartPointProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || false || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Foundation.Point EndPoint
		{
			get
			{
				return (global::Windows.Foundation.Point)this.GetValue(EndPointProperty);
			}
			set
			{
				this.SetValue(EndPointProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || false || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.UI.Xaml.DependencyProperty EndPointProperty { get; } = 
		Windows.UI.Xaml.DependencyProperty.Register(
			nameof(EndPoint), typeof(global::Windows.Foundation.Point), 
			typeof(global::Windows.UI.Xaml.Media.LineGeometry), 
			new Windows.UI.Xaml.FrameworkPropertyMetadata(default(global::Windows.Foundation.Point)));
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || false || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.UI.Xaml.DependencyProperty StartPointProperty { get; } = 
		Windows.UI.Xaml.DependencyProperty.Register(
			nameof(StartPoint), typeof(global::Windows.Foundation.Point), 
			typeof(global::Windows.UI.Xaml.Media.LineGeometry), 
			new Windows.UI.Xaml.FrameworkPropertyMetadata(default(global::Windows.Foundation.Point)));
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || false || false || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__NETSTD_REFERENCE__", "__MACOS__")]
		public LineGeometry() 
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.LineGeometry", "LineGeometry.LineGeometry()");
		}
		#endif
		// Forced skipping of method Windows.UI.Xaml.Media.LineGeometry.LineGeometry()
		// Forced skipping of method Windows.UI.Xaml.Media.LineGeometry.StartPoint.get
		// Forced skipping of method Windows.UI.Xaml.Media.LineGeometry.StartPoint.set
		// Forced skipping of method Windows.UI.Xaml.Media.LineGeometry.EndPoint.get
		// Forced skipping of method Windows.UI.Xaml.Media.LineGeometry.EndPoint.set
		// Forced skipping of method Windows.UI.Xaml.Media.LineGeometry.StartPointProperty.get
		// Forced skipping of method Windows.UI.Xaml.Media.LineGeometry.EndPointProperty.get
	}
}
