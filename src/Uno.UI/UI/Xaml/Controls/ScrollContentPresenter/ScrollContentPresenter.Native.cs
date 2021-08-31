#if __IOS__ || __ANDROID__
#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls
{
	// This file contains **support** of NativeScrollContentPresenter by the ScrollContentPresenter that is being put in template of the ScrollViewer.
	// Basically it's just a decorator which implements the same SCP contract as the UWP one, and forwards all info it native counterpart.

	partial class ScrollContentPresenter
	{
		private IScrollContentPresenter? _native;

		/// <inheritdoc />
		protected override void OnContentChanged(object oldValue, object newValue)
		{
			if (newValue is IScrollContentPresenter nativeScp)
			{
				_native = nativeScp;
			}
			else if (Scroller?.TemplatedParent is ListViewBase lv
				&& lv.NativePanel is {} nativeList)
			{
				// If the owner is a ListView which supports virtualization we override the content to a 
				_native = new ListViewBaseScrollContentPresenter(nativeList);
			}
			else
			{
				_native = new NativeScrollContentPresenter(this);
			}

			base.OnContentChanged(oldValue, newValue);
		}

		/// <inheritdoc />
		protected override Size MeasureOverride(Size size)
		{
			_native.Measure(size);

			return base.MeasureOverride(size);
		}

		/// <inheritdoc />
		protected override Size ArrangeOverride(Size finalSize)
		{
			_native.Arrange(finalSize);

			return base.ArrangeOverride(finalSize);
		}

		private object? RealContent => _native?.Content;

		internal ScrollBarVisibility NativeHorizontalScrollBarVisibility
		{
			get => _native?.HorizontalScrollBarVisibility ?? default;
			set
			{
				if (_native != null)
				{
					_native.HorizontalScrollBarVisibility = value;
				}
			}
		}

		internal ScrollBarVisibility NativeVerticalScrollBarVisibility
		{
			get => _native?.VerticalScrollBarVisibility ?? default;
			set
			{
				if (_native != null)
				{
					_native.VerticalScrollBarVisibility = value;
				}
			}
		}

		public bool CanHorizontallyScroll
		{
			get => _native?.CanHorizontallyScroll ?? false;
			set
			{
				if (_native != null)
				{
					_native.CanHorizontallyScroll = value;
				}
			}
		}

		public bool CanVerticallyScroll
		{
			get => _native?.CanVerticallyScroll ?? false;
			set
			{
				if (_native != null)
				{
					_native.CanVerticallyScroll = value;
				}
			}
		}

		internal bool Set(
			double? horizontalOffset = null,
			double? verticalOffset = null,
			float? zoomFactor = null,
			bool disableAnimation = true,
			bool isIntermediate = false)
			=> _native?.Set(horizontalOffset, verticalOffset, zoomFactor, disableAnimation, isIntermediate) ?? false;
	}
}
#endif
