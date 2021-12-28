﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uno.Extensions;
using Uno;
using Uno.Foundation.Logging;
using Uno.Collections;
using Windows.Foundation;

using View = Android.Views.View;
using Font = Android.Graphics.Typeface;
using System.Linq.Expressions;
using Uno.UI;

namespace Windows.UI.Xaml.Controls
{
	abstract partial class Layouter
	{
		public static void SetMeasuredDimensions(View view, int width, int height)
		{
			LayouterHelper.SetMeasuredDimensions(view, new object[] { width, height });
		}

		protected Size MeasureChildOverride(View view, Size slotSize)
		{
			var widthSpec = ViewHelper.SpecFromLogicalSize(slotSize.Width);
			var heightSpec = ViewHelper.SpecFromLogicalSize(slotSize.Height);

			if (double.IsPositiveInfinity(slotSize.Width) || double.IsPositiveInfinity(slotSize.Height))
			{
				// Bypass Android cache, to ensure the Child's Measure() is actually invoked.
				view.ForceLayout();

				// This could occur when one of the dimension is _Infinite_: Android will cache the
				// value, which is not something we want. Specially when the container is a <StackPanel>.

				// Issue: https://github.com/unoplatform/uno/issues/2879
			}

			if (view.IsLayoutRequested && view.Parent is View parent && !parent.IsLayoutRequested)
			{
				// If a view has requested layout but its Parent hasn't, then the tree is in a broken state, because RequestLayout() calls
				// cannot bubble up from below the view, and remeasures cannot bubble down from above the parent. This can arise, eg, when
				// ForceLayout() is used. To fix this state, call RequestLayout() on the parent. Since MeasureChildOverride() is called
				// from the top down, we should be able to assume that the tree above the parent is already in a good state.
				parent.RequestLayout();
			}

			MeasureChild(view, widthSpec, heightSpec);

			var ret = Uno.UI.Controls.BindableView.GetNativeMeasuredDimensionsFast(view)
				.PhysicalToLogicalPixels();

			return ret.AtMost(slotSize);
		}

		protected abstract void MeasureChild(View view, int widthSpec, int heightSpec);

		protected void ArrangeChildOverride(View view, Rect frame)
		{
			LogArrange(view, frame);

			var elt = view as UIElement;
			var physicalFrame = frame.LogicalToPhysicalPixels();

			try
			{
				elt?.SetFramePriorArrange(frame, physicalFrame);

				view.Layout(
					(int)physicalFrame.Left,
					(int)physicalFrame.Top,
					(int)physicalFrame.Right,
					(int)physicalFrame.Bottom
				);
			}
			finally
			{
				elt?.ResetFramePostArrange();
			}
		}
	}

	internal static partial class LayouterExtensions
	{
		public static IEnumerable<View> GetChildren(this Layouter layouter)
		{
			return (layouter.Panel as Android.Views.ViewGroup).GetChildren();
		}
	}
}
