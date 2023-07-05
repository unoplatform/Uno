#nullable disable

using Windows.System;
using Uno;

namespace Windows.UI.Xaml.Controls
{
	partial class Control
	{

		[NotImplemented] // Method for WinUI code compatibility. Not implemented yet
		private protected void GetKeyboardModifiers(out VirtualKeyModifiers virtualKeyModifiers)
		{
			virtualKeyModifiers = VirtualKeyModifiers.None;
		}
	}
}
