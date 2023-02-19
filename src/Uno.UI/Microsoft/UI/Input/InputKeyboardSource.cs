﻿#if HAS_UNO_WINUI

namespace Microsoft.UI.Input
{
	public partial class InputKeyboardSource
	{
		public static Windows.UI.Core.CoreVirtualKeyStates GetKeyStateForCurrentThread(Windows.System.VirtualKey virtualKey)
			=> Xaml.Window.Current.CoreWindow.GetKeyState(virtualKey);
	}
}
#endif
