// <auto-generated>
#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Controls
{
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
#endif
	public partial class MapControl : global::Microsoft.UI.Xaml.Controls.Control
	{
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public double ZoomLevel
		{
			get
			{
				return (double)this.GetValue(ZoomLevelProperty);
			}
			set
			{
				this.SetValue(ZoomLevelProperty, value);
			}
		}
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string MapServiceToken
		{
			get
			{
				return (string)this.GetValue(MapServiceTokenProperty);
			}
			set
			{
				this.SetValue(MapServiceTokenProperty, value);
			}
		}
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public global::System.Collections.Generic.IList<global::Microsoft.UI.Xaml.Controls.MapLayer> Layers
		{
			get
			{
				return (global::System.Collections.Generic.IList<global::Microsoft.UI.Xaml.Controls.MapLayer>)this.GetValue(LayersProperty);
			}
			set
			{
				this.SetValue(LayersProperty, value);
			}
		}
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public bool InteractiveControlsVisible
		{
			get
			{
				return (bool)this.GetValue(InteractiveControlsVisibleProperty);
			}
			set
			{
				this.SetValue(InteractiveControlsVisibleProperty, value);
			}
		}
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public global::Windows.Devices.Geolocation.Geopoint Center
		{
			get
			{
				return (global::Windows.Devices.Geolocation.Geopoint)this.GetValue(CenterProperty);
			}
			set
			{
				this.SetValue(CenterProperty, value);
			}
		}
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty CenterProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(Center), typeof(global::Windows.Devices.Geolocation.Geopoint),
			typeof(global::Microsoft.UI.Xaml.Controls.MapControl),
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(global::Windows.Devices.Geolocation.Geopoint)));
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty InteractiveControlsVisibleProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(InteractiveControlsVisible), typeof(bool),
			typeof(global::Microsoft.UI.Xaml.Controls.MapControl),
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(bool)));
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty LayersProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(Layers), typeof(global::System.Collections.Generic.IList<global::Microsoft.UI.Xaml.Controls.MapLayer>),
			typeof(global::Microsoft.UI.Xaml.Controls.MapControl),
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(global::System.Collections.Generic.IList<global::Microsoft.UI.Xaml.Controls.MapLayer>)));
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty MapServiceTokenProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(MapServiceToken), typeof(string),
			typeof(global::Microsoft.UI.Xaml.Controls.MapControl),
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(string)));
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty ZoomLevelProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(ZoomLevel), typeof(double),
			typeof(global::Microsoft.UI.Xaml.Controls.MapControl),
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(double)));
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public MapControl() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.MapControl", "MapControl.MapControl()");
		}
#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.MapControl()
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.MapServiceToken.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.MapServiceToken.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.Center.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.Center.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.Layers.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.Layers.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.ZoomLevel.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.ZoomLevel.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.InteractiveControlsVisible.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.InteractiveControlsVisible.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.MapElementClick.add
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.MapElementClick.remove
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.MapServiceErrorOccurred.add
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.MapServiceErrorOccurred.remove
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.LayersProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.MapServiceTokenProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.CenterProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.ZoomLevelProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.MapControl.InteractiveControlsVisibleProperty.get
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Xaml.Controls.MapControl, global::Microsoft.UI.Xaml.Controls.MapElementClickEventArgs> MapElementClick
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.MapControl", "event TypedEventHandler<MapControl, MapElementClickEventArgs> MapControl.MapElementClick");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.MapControl", "event TypedEventHandler<MapControl, MapElementClickEventArgs> MapControl.MapElementClick");
			}
		}
#endif
#if __ANDROID__ || __IOS__ || __TVOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Xaml.Controls.MapControl, global::Microsoft.UI.Xaml.Controls.MapControlMapServiceErrorOccurredEventArgs> MapServiceErrorOccurred
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.MapControl", "event TypedEventHandler<MapControl, MapControlMapServiceErrorOccurredEventArgs> MapControl.MapServiceErrorOccurred");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__TVOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.MapControl", "event TypedEventHandler<MapControl, MapControlMapServiceErrorOccurredEventArgs> MapControl.MapServiceErrorOccurred");
			}
		}
#endif
	}
}
