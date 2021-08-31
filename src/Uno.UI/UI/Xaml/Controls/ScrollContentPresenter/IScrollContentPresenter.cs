#if !UNO_HAS_MANAGED_SCROLL_PRESENTER
using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls
{
	/// <summary>
	/// An interface consumed by <see cref="ScrollViewer"/>, which may contain either a <see cref="ScrollContentPresenter"/> (the
	/// normal case) or a <see cref="ListViewBaseScrollContentPresenter"/> (special case to handle usage within the template of 
	/// <see cref="ListViewBase"/>)
	/// </summary>
	internal partial interface IScrollContentPresenter
	{
		ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }
		ScrollBarVisibility VerticalScrollBarVisibility { get; set; }

		bool CanHorizontallyScroll { get; set; }
		bool CanVerticallyScroll { get; set; }

		/// <summary>
		/// The distance the content has been scrolled horizontally.
		/// </summary>
		double HorizontalOffset { get; }

		/// <summary>
		/// The distance the content has been scrolled vertically.
		/// </summary>
		double VerticalOffset { get; }

		/// <summary>
		/// The absolute dimensions of the content (or an estimate), for presenters where this is not simply equal to the Content element's size.
		/// </summary>
		Size? CustomContentExtent { get; }

		object Content { get; set; }

		void OnMinZoomFactorChanged(float newValue);
		void OnMaxZoomFactorChanged(float newValue);

		Rect MakeVisible(UIElement visual, Rect rectangle);

		/// <summary>
		/// Sets the scrolling state of that SCP
		/// </summary>
		/// <param name="horizontalOffset">The optional horizontal offset, `null` means the SCP should remain at the same horizontal location.</param>
		/// <param name="verticalOffset">The optional vertical offset, `null` means the SCP should remain at the same vertical location.</param>
		/// <param name="zoomFactor">The optional zoom factor, `null` means the SCP should remain at the same zoom level.</param>
		/// <param name="disableAnimation">Indicates if the change to the provided value should be animated or not.</param>
		/// <param name="isIntermediate">
		/// Indicates that the provided values are not final and the SCP should expect another scroll request soon
		/// (cf. <see cref="ScrollViewerViewChangedEventArgs.IsIntermediate"/>).
		/// </param>
		/// <returns>`true` if the offsets has been applied as-is, `false` if offsets has been clamped.</returns>
		bool Set(
			double? horizontalOffset = null,
			double? verticalOffset = null,
			float? zoomFactor = null,
			bool disableAnimation = true,
			bool isIntermediate = false);
	}
}
#endif
