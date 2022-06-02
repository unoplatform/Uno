using Gtk;

namespace Uno.UI.Runtime.Skia
{
	internal interface IRenderSurface
	{
		Widget Widget { get; }

		void TakeScreenshot(string filePath);

		void InvalidateRender();
	}
}
