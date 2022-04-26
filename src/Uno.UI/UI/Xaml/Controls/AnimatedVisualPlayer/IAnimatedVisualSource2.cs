﻿using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls
{
	public interface IAnimatedVisualSource2 : IAnimatedVisualSource
    {
		public IReadOnlyDictionary<string, double> Markers { get; }

		void SetColorProperty(string propertyName, Color value);
	}
}
