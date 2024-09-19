﻿using System.Diagnostics;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.UI;
using Windows.Foundation;

#if __ANDROID__
using Android.Views;
using View = Android.Views.View;
#elif __IOS__
using CoreGraphics;
using View = UIKit.UIView;
#elif __MACOS__
using AppKit;
using CoreGraphics;
using View = AppKit.NSView;
#else
using View = Microsoft.UI.Xaml.UIElement;
#endif

namespace Microsoft.UI.Xaml;

internal static partial class MobileLayoutingHelpers
{
	public static Size MeasureElement(View view, Size availableSize)
	{
#if __CROSSRUNTIME__ || IS_UNIT_TESTS
		view.Measure(availableSize);
		return view.DesiredSize;
#else
		if (view is UIElement viewAsUIElement)
		{
			viewAsUIElement.Measure(availableSize);
			return viewAsUIElement.DesiredSize;
		}

		var isDirty = LayoutInformation.GetMeasureDirtyPath(view);
		var previousSize = LayoutInformation.GetAvailableSize(view);
		if (!isDirty && previousSize == availableSize)
		{
			return LayoutInformation.GetDesiredSize(view);
		}

		LayoutInformation.SetMeasureDirtyPath(view, false);

#if __ANDROID__
		// Calling the native Measure method may not always trigger OnMeasure
		// We should do RequestLayout()
		view.RequestLayout();
#endif

		if (view is ILayouterElement layouterElement)
		{
			var desiredSizeFromLayouterElement = layouterElement.Measure(availableSize);
			LayoutInformation.SetDesiredSize(view, desiredSizeFromLayouterElement);
			LayoutInformation.SetAvailableSize(view, availableSize);
			return desiredSizeFromLayouterElement;
		}

#if __ANDROID__
		var physical = availableSize.LogicalToPhysicalPixels();
		var widthSpec = ViewHelper.SpecFromLogicalSize(availableSize.Width);
		var heightSpec = ViewHelper.SpecFromLogicalSize(availableSize.Height);
		view.Measure(widthSpec, heightSpec);
		var desiredSize = Uno.UI.Controls.BindableView.GetNativeMeasuredDimensionsFast(view).PhysicalToLogicalPixels();
		LayoutInformation.SetDesiredSize(view, desiredSize);
		LayoutInformation.SetAvailableSize(view, availableSize);

		view.InvalidateArrangeOnNativeOnly();

		if (view is ViewGroup viewGroup)
		{
			foreach (var child in viewGroup.GetChildren())
			{
				if (child is UIElement childAsUIElement)
				{
					if (childAsUIElement.IsMeasureDirtyOrMeasureDirtyPath)
					{
						MeasureElement(child, desiredSize);
					}
				}
				else
				{
					// Both view and child are native-only. So, skip native measure on the child.
					// The "view" (i.e, the parent) is responsible for measuring its child
					// If the child contains a managed element, we get back to measuring it via FrameworkElement.OnMeasure
				}
			}
		}

		return desiredSize;
#elif __IOS__ || __MACOS__
		var physical = availableSize.LogicalToPhysicalPixels();

#if __IOS__
		var desiredSize = view.SizeThatFits(physical).PhysicalToLogicalPixels();
#else
		CGSize desiredSize = view switch
		{
			NSControl nsControl => nsControl.SizeThatFits(physical),
			IHasSizeThatFits hasSizeThatFits => hasSizeThatFits.SizeThatFits(physical),
			_ => view.FittingSize,
		};
		desiredSize = desiredSize.PhysicalToLogicalPixels();
#endif

		LayoutInformation.SetDesiredSize(view, desiredSize);
		LayoutInformation.SetAvailableSize(view, availableSize);
		foreach (var child in view.Subviews)
		{
			MeasureElement(child, desiredSize);
		}

		return desiredSize;
#else
#error Unrecognized platform
#endif
#endif
	}

	public static void ArrangeElement(View view, Rect finalRect)
	{
#if __CROSSRUNTIME__ || IS_UNIT_TESTS
		view.Arrange(finalRect);
#else
		if (view is UIElement viewAsUIElement)
		{
			viewAsUIElement.Arrange(finalRect);
			return;
		}

		var isDirty = LayoutInformation.GetArrangeDirtyPath(view);
		var previousRect = LayoutInformation.GetLayoutSlot(view);
		if (!isDirty && previousRect == finalRect)
		{
			return;
		}

		if (previousRect != finalRect)
		{
			LayoutInformation.SetLayoutSlot(view, finalRect);
		}

		if (isDirty)
		{
			LayoutInformation.SetArrangeDirtyPath(view, false);
		}

		if (view is ILayouterElement layouterElement)
		{
			layouterElement.Arrange(finalRect);
		}
		else
		{
			var physicalRect = ViewHelper.LogicalToPhysicalPixels(finalRect);
#if __ANDROID__
			view.Layout((int)physicalRect.Left, (int)physicalRect.Top, (int)physicalRect.Right, (int)physicalRect.Bottom);
			if (view is ViewGroup viewGroup)
			{
				foreach (var child in viewGroup.GetChildren())
				{
					if (child is UIElement childAsUIElement)
					{
						if (childAsUIElement.IsArrangeDirtyOrArrangeDirtyPath)
						{
							ArrangeElement(child, finalRect);
						}
					}
					else
					{
						// Both view and child are native-only. So, skip native layout on the child.
						// The "view" (i.e, the parent) is responsible for layouting its child
						// If the child contains a managed element, we get back to arranging it via FrameworkElement.OnLayoutCore
					}
				}
			}
#elif __IOS__ || __MACOS__
			view.Frame = physicalRect;
#endif
		}

		if (view is IFrameworkElement_EffectiveViewport evp)
		{
			evp.OnLayoutUpdated();
		}
#endif
	}

#if __ANDROID__ || __IOS__ || __MACOS__
	private static void InvalidateArrangeOnNativeOnly(this View view)
	{
		Debug.Assert(view is not UIElement);
		LayoutInformation.SetArrangeDirtyPath(view, true);
		var parent = view.Parent;
		if (parent is UIElement uiElement)
		{
			uiElement.InvalidateArrangeDirtyPath();
		}
		else if (parent is View parentView)
		{
			InvalidateArrangeOnNativeOnly(parentView);
		}
	}
#endif
}
