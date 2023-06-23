#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Controls
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class ItemsStackPanel : global::Windows.UI.Xaml.Controls.Panel
	{
		// Skipping already declared property Orientation
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Xaml.Controls.ItemsUpdatingScrollMode ItemsUpdatingScrollMode
		{
			get
			{
				throw new global::System.NotImplementedException("The member ItemsUpdatingScrollMode ItemsStackPanel.ItemsUpdatingScrollMode is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ItemsUpdatingScrollMode%20ItemsStackPanel.ItemsUpdatingScrollMode");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ItemsStackPanel", "ItemsUpdatingScrollMode ItemsStackPanel.ItemsUpdatingScrollMode");
			}
		}
		#endif
		// Skipping already declared property GroupPadding
		// Skipping already declared property GroupHeaderPlacement
		#if false || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  double CacheLength
		{
			get
			{
				return (double)this.GetValue(CacheLengthProperty);
			}
			set
			{
				this.SetValue(CacheLengthProperty, value);
			}
		}
		#endif
		#if false || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  int FirstCacheIndex
		{
			get
			{
				throw new global::System.NotImplementedException("The member int ItemsStackPanel.FirstCacheIndex is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=int%20ItemsStackPanel.FirstCacheIndex");
			}
		}
		#endif
		#if false || false || IS_UNIT_TESTS || false || false || false || false
		[global::Uno.NotImplemented("IS_UNIT_TESTS")]
		public  int FirstVisibleIndex
		{
			get
			{
				throw new global::System.NotImplementedException("The member int ItemsStackPanel.FirstVisibleIndex is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=int%20ItemsStackPanel.FirstVisibleIndex");
			}
		}
		#endif
		#if false || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  int LastCacheIndex
		{
			get
			{
				throw new global::System.NotImplementedException("The member int ItemsStackPanel.LastCacheIndex is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=int%20ItemsStackPanel.LastCacheIndex");
			}
		}
		#endif
		#if false || false || IS_UNIT_TESTS || false || false || false || false
		[global::Uno.NotImplemented("IS_UNIT_TESTS")]
		public  int LastVisibleIndex
		{
			get
			{
				throw new global::System.NotImplementedException("The member int ItemsStackPanel.LastVisibleIndex is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=int%20ItemsStackPanel.LastVisibleIndex");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Xaml.Controls.PanelScrollingDirection ScrollingDirection
		{
			get
			{
				throw new global::System.NotImplementedException("The member PanelScrollingDirection ItemsStackPanel.ScrollingDirection is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=PanelScrollingDirection%20ItemsStackPanel.ScrollingDirection");
			}
		}
		#endif
		// Skipping already declared property AreStickyGroupHeadersEnabled
		#if false || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.UI.Xaml.DependencyProperty CacheLengthProperty { get; } = 
		Windows.UI.Xaml.DependencyProperty.Register(
			nameof(CacheLength), typeof(double), 
			typeof(global::Windows.UI.Xaml.Controls.ItemsStackPanel), 
			new Windows.UI.Xaml.FrameworkPropertyMetadata(global::Uno.UI.Helpers.Boxes.DoubleBoxes.Zero));
		#endif
		// Skipping already declared property GroupHeaderPlacementProperty
		// Skipping already declared property GroupPaddingProperty
		// Skipping already declared property OrientationProperty
		// Skipping already declared property AreStickyGroupHeadersEnabledProperty
		// Skipping already declared method Windows.UI.Xaml.Controls.ItemsStackPanel.ItemsStackPanel()
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.ItemsStackPanel()
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.GroupPadding.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.GroupPadding.set
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.Orientation.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.Orientation.set
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.FirstCacheIndex.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.FirstVisibleIndex.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.LastVisibleIndex.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.LastCacheIndex.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.ScrollingDirection.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.GroupHeaderPlacement.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.GroupHeaderPlacement.set
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.ItemsUpdatingScrollMode.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.ItemsUpdatingScrollMode.set
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.CacheLength.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.CacheLength.set
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.AreStickyGroupHeadersEnabled.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.AreStickyGroupHeadersEnabled.set
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.AreStickyGroupHeadersEnabledProperty.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.GroupPaddingProperty.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.OrientationProperty.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.GroupHeaderPlacementProperty.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ItemsStackPanel.CacheLengthProperty.get
	}
}
