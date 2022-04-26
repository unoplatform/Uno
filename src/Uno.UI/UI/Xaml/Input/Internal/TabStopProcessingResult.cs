﻿#nullable enable

using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Input
{
	internal struct TabStopProcessingResult
	{
		public DependencyObject? NewTabStop { get; set; }

		public bool IsOverriden { get; set; }
	}
}
