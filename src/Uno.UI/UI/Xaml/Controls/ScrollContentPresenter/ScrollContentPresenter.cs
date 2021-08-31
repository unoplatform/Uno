#nullable enable

using Uno.Extensions;
using Uno.Logging;
using Uno.UI.DataBinding;
using Windows.UI.Xaml.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using Uno.Disposables;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.Foundation;
#if XAMARIN_ANDROID
using View = Android.Views.View;
using Font = Android.Graphics.Typeface;
#elif XAMARIN_IOS_UNIFIED
using UIKit;
using View = UIKit.UIView;
using Color = UIKit.UIColor;
using Font = UIKit.UIFont;
#elif __MACOS__
using AppKit;
using View = AppKit.NSView;
using Color = AppKit.NSColor;
using Font = AppKit.NSFont;
#else
using View = Windows.UI.Xaml.UIElement;
#endif

namespace Windows.UI.Xaml.Controls
{
	public partial class ScrollContentPresenter : ContentPresenter, ILayoutConstraints
	{
		#region ScrollOwner
		private ManagedWeakReference _scroller;

		public object? ScrollOwner
		{
			get => _scroller.Target;
			set
			{
				if (value is null)
				{
					throw new NullReferenceException("ScrollOwner cannot be null");
				}

				var oldScroller = default(object?);
				if (_scroller is { } oldScrollerRef)
				{
					oldScroller = oldScrollerRef.Target;
					if (value == oldScroller)
					{
						return;
					}

					WeakReferencePool.ReturnWeakReference(this, oldScrollerRef);
				}

				_scroller = WeakReferencePool.RentWeakReference(this, value);

				if (value is ScrollViewer newScroller)
				{
					OnScrollerChanged(oldScroller as ScrollViewer, newScroller);
				}
			}
		}

		partial void OnScrollerChanged(ScrollViewer? oldValue, ScrollViewer newValue);

		internal ScrollViewer? Scroller => ScrollOwner as ScrollViewer;
		#endregion

#if __WASM__
		bool _forceChangeToCurrentView;

		bool IScrollContentPresenter.ForceChangeToCurrentView
		{
			get => _forceChangeToCurrentView;
			set => _forceChangeToCurrentView = value;
		}
#endif

		public ScrollContentPresenter()
		{
			// On Skia, the Scrolling is managed by the ScrollContentPresenter (as UWP), which is flagged as IsScrollPort.
			// Note: We should still add support for the zoom factor ... which is not yet supported on Skia.
			// Note 2: This has direct consequences in UIElement.GetTransform and VisualTreeHelper.SearchDownForTopMostElementAt
			UIElement.RegisterAsScrollPort(this);

			this.RegisterParentChangedCallback(this, OnParentChanged);

			InitializePartial();
		}

		partial void InitializePartial();

		private void OnParentChanged(object instance, object key, DependencyObjectParentChangedEventArgs args)
		{
			// Set Content to null when we are removed from TemplatedParent. Otherwise Content.RemoveFromSuperview() may
			// be called when it is attached to a different view.
			if (args.NewParent == null)
			{
				Content = null;
			}
		}

		bool ILayoutConstraints.IsWidthConstrained(View requester)
		{
			if (requester != null && CanHorizontallyScroll)
			{
				return false;
			}

			return this.IsWidthConstrainedSimple() ?? (Parent as ILayoutConstraints)?.IsWidthConstrained(this) ?? false;
		}

		bool ILayoutConstraints.IsHeightConstrained(View requester)
		{
			if (requester != null && CanVerticallyScroll)
			{
				return false;
			}

			return this.IsHeightConstrainedSimple() ?? (Parent as ILayoutConstraints)?.IsHeightConstrained(this) ?? false;
		}

		public double ExtentHeight
		{
			get
			{
				if (Content is FrameworkElement fe)
				{
					var explicitHeight = fe.Height;
					if (!explicitHeight.IsNaN())
					{
						return explicitHeight;
					}
					var canUseActualHeightAsExtent =
						ActualHeight > 0 &&
						fe.VerticalAlignment == VerticalAlignment.Stretch;

					return canUseActualHeightAsExtent ? fe.ActualHeight : fe.DesiredSize.Height;
				}

				return 0d;
			}
		}

		public double ExtentWidth
		{
			get
			{
				if (Content is FrameworkElement fe)
				{
					var explicitWidth = fe.Width;
					if (!explicitWidth.IsNaN())
					{
						return explicitWidth;
					}

					var canUseActualWidthAsExtent =
						ActualWidth > 0 &&
						fe.HorizontalAlignment == HorizontalAlignment.Stretch;

					return canUseActualWidthAsExtent ? fe.ActualWidth : fe.DesiredSize.Width;
				}

				return 0d;
			}
		}

		public double ViewportHeight => DesiredSize.Height;

		public double ViewportWidth => DesiredSize.Width;

		public void SetVerticalOffset(double offset)
			=> Set(verticalOffset: offset);

		public void SetHorizontalOffset(double offset)
			=> Set(horizontalOffset: offset);

#if UNO_HAS_MANAGED_SCROLL_PRESENTER || __WASM__
		protected override Size MeasureOverride(Size size)
		{
			if (Content is UIElement child)
			{
				var slotSize = size;

#if __WASM__
				if (CanVerticallyScroll || _forceChangeToCurrentView)
				{
					slotSize.Height = double.PositiveInfinity;
				}
				if (CanHorizontallyScroll || _forceChangeToCurrentView)
				{
					slotSize.Width = double.PositiveInfinity;
				}
#else
				if (CanVerticallyScroll)
				{
					slotSize.Height = double.PositiveInfinity;
				}
				if (CanHorizontallyScroll)
				{
					slotSize.Width = double.PositiveInfinity;
				}
#endif

				child.Measure(slotSize);

				var desired = child.DesiredSize;

				// Give opportunity to the the content to define the viewport size itself
				(child as ICustomScrollInfo)?.ApplyViewport(ref desired);

				return new Size(
					Math.Min(size.Width, desired.Width),
					Math.Min(size.Height, desired.Height)
				);
			}

			return new Size(0, 0);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			if (Content is UIElement child)
			{
				Rect childRect = default;

				var desiredSize = child.DesiredSize;

				childRect.Width = Math.Max(finalSize.Width, desiredSize.Width);
				childRect.Height = Math.Max(finalSize.Height, desiredSize.Height);

				child.Arrange(childRect);

				// Give opportunity to the the content to define the viewport size itself
				(child as ICustomScrollInfo)?.ApplyViewport(ref finalSize);
			}

			return finalSize;
		}

		internal override bool IsViewHit()
			=> true;

#elif __IOS__ // Note: No __ANDROID__, the ICustomScrollInfo support is made directly in the NativeScrollContentPresenter
		protected override Size MeasureOverride(Size size)
		{
			var result = base.MeasureOverride(size);

			(RealContent as ICustomScrollInfo).ApplyViewport(ref result);

			return result;
		}

		/// <inheritdoc />
		protected override Size ArrangeOverride(Size finalSize)
		{
			var result = base.ArrangeOverride(finalSize);

			(RealContent as ICustomScrollInfo).ApplyViewport(ref result);

			return result;
		}
#endif
	}
}
