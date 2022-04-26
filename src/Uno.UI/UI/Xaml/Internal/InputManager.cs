﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// InputManager.h, InputManager.cpp

#nullable enable

using Uno.UI.Xaml.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Core
{
	internal class InputManager
	{
		private ContentRoot _contentRoot;

		public InputManager(ContentRoot contentRoot)
		{
			_contentRoot = contentRoot;
		}

		//TODO Uno: Set along with user input - this needs to be adjusted soon
		internal InputDeviceType LastInputDeviceType { get; set; } = InputDeviceType.None;

		internal FocusInputDeviceKind LastFocusInputDeviceKind { get; set; }

		internal bool ShouldRequestFocusSound()
		{
			//TODO Uno: Implement
			return false;
		}

		internal void NotifyFocusChanged(DependencyObject? focusedElement, bool bringIntoView, bool animateIfBringIntoView)
		{
			//TODO Uno: Implement
		}

		internal bool LastInputWasNonFocusNavigationKeyFromSIP()
		{
			//TODO Uno: Implement
			return false;
		}
	}
}
