﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// ApplicationBarService.h, ApplicationBarService.cpp, ApplicationBarService_Partial.cpp

#nullable enable

using Uno.UI.Xaml.Input;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Controls
{
	//TODO Uno: This is just a stub of the MUX class.
	internal class ApplicationBarService
	{
		internal static TabStopProcessingResult ProcessTabStopOverride(
			DependencyObject? focusedElement,
			DependencyObject? candidateTabStopElement,
			bool isBackward)
		{
			return new TabStopProcessingResult();
		}
	}
}
