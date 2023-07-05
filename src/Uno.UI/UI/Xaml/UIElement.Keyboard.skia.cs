#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.DataBinding;
using Uno.UI.Extensions;
using Windows.UI.Core;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Uno.UI;

namespace Windows.UI.Xaml
{
	partial class UIElement
	{
		private class KeyboardManager
		{
			public KeyboardManager()
			{
				Window.Current.CoreWindow.NativeKeyDownReceived += InitiateKeyDownBubblingFlow;
				Window.Current.CoreWindow.NativeKeyUpReceived += InitiateKeyUpBubblingFlow;
			}

			private void InitiateKeyDownBubblingFlow(CoreWindow sender, KeyEventArgs args)
			{
				var originalSource = FocusManager.GetFocusedElement() as UIElement ?? Window.Current.Content;

				originalSource.RaiseEvent(
					KeyDownEvent,
					new KeyRoutedEventArgs(originalSource, args.VirtualKey, args.KeyStatus)
					{
						CanBubbleNatively = false
					}
				);

				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().Trace(
						$"CoreWindow_KeyDown(vk: {args.VirtualKey}, " +
						$"IsExtendedKey: {args.KeyStatus.IsExtendedKey}, " +
						$"IsKeyReleased: {args.KeyStatus.IsKeyReleased}, " +
						$"IsMenuKeyDown: {args.KeyStatus.IsMenuKeyDown}, " +
						$"RepeatCount: {args.KeyStatus.RepeatCount}, " +
						$"ScanCode: {args.KeyStatus.ScanCode})"
					);
				}
			}

			private void InitiateKeyUpBubblingFlow(CoreWindow sender, KeyEventArgs args)
			{
				var originalSource = FocusManager.GetFocusedElement() as UIElement ?? Window.Current.Content;

				originalSource.RaiseEvent(
					KeyUpEvent,
					new KeyRoutedEventArgs(originalSource, args.VirtualKey, args.KeyStatus)
					{
						CanBubbleNatively = false
					}
				);

				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().Trace(
						$"CoreWindow_KeyUp(vk: {args.VirtualKey}, " +
						$"IsExtendedKey: {args.KeyStatus.IsExtendedKey}, " +
						$"IsKeyReleased: {args.KeyStatus.IsKeyReleased}, " +
						$"IsMenuKeyDown: {args.KeyStatus.IsMenuKeyDown}, " +
						$"RepeatCount: {args.KeyStatus.RepeatCount}, " +
						$"ScanCode: {args.KeyStatus.ScanCode})"
					);
				}
			}
		}

		// TODO Should be per CoreWindow
		private static KeyboardManager _keyboardManager;

		partial void InitializeKeyboard()
		{
			if (_keyboardManager == null)
			{
				_keyboardManager = new KeyboardManager();
			}
		}
	}
}
