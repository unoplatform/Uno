#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Controls
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class ContainerContentChangingEventArgs 
	{
		// Skipping already declared property Handled
		// Skipping already declared property InRecycleQueue
		// Skipping already declared property Item
		// Skipping already declared property ItemContainer
		// Skipping already declared property ItemIndex
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  uint Phase
		{
			get
			{
				throw new global::System.NotImplementedException("The member uint ContainerContentChangingEventArgs.Phase is not implemented in Uno.");
			}
		}
		#endif
		// Skipping already declared method Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs.ContainerContentChangingEventArgs()
		// Forced skipping of method Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs.ContainerContentChangingEventArgs()
		// Forced skipping of method Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs.ItemContainer.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs.InRecycleQueue.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs.ItemIndex.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs.Item.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs.Phase.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs.Handled.get
		// Forced skipping of method Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs.Handled.set
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void RegisterUpdateCallback( global::Windows.Foundation.TypedEventHandler<global::Windows.UI.Xaml.Controls.ListViewBase, global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs> callback)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs", "void ContainerContentChangingEventArgs.RegisterUpdateCallback(TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> callback)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void RegisterUpdateCallback( uint callbackPhase,  global::Windows.Foundation.TypedEventHandler<global::Windows.UI.Xaml.Controls.ListViewBase, global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs> callback)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs", "void ContainerContentChangingEventArgs.RegisterUpdateCallback(uint callbackPhase, TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> callback)");
		}
		#endif
	}
}
