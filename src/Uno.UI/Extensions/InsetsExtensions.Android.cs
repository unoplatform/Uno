﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.UI.Xaml;

namespace Uno.UI.Extensions
{
	internal static class InsetsExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Thickness ToThickness(this Android.Graphics.Insets insets)
			=> new Thickness(insets.Left, insets.Top, insets.Right, insets.Bottom);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Thickness ToThickness(this AndroidX.Core.Graphics.Insets insets)
			=> new Thickness(insets.Left, insets.Top, insets.Right, insets.Bottom);
	}
}
