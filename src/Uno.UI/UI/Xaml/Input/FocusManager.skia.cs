#nullable disable

#if __SKIA__
namespace Windows.UI.Xaml.Input
{
	public partial class FocusManager
	{
		private static void FocusNative(UIElement? control)
		{
			//TODO Uno: Use platform-specific focus functionality.
		}
	}
}
#endif
