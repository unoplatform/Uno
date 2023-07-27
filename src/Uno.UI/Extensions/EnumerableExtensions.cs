﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uno.Extensions;
using Windows.UI.Xaml.Controls;

#if __ANDROID__
using _View = Android.Views.View;
#elif __IOS__
using _View = UIKit.UIView;
using UIKit;
#elif __MACOS__
using _View = AppKit.NSView;
#else
using _View = Windows.UI.Xaml.UIElement;
#endif

namespace Uno.UI.Extensions
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Projects the specified collection to an array.
		/// </summary>
		public static List<TResult> SelectToList<TResult>(this UIElementCollection source, Func<_View, TResult> selector)
		{
			var output = new List<TResult>(source.Count);

			foreach (var item in source)
			{
				output.Add(selector(item));
			}

			return output;
		}
	}
}
