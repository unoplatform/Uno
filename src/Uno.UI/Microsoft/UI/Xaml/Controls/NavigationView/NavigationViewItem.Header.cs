﻿// MUX reference NavigationViewItem.h, commit 574e5ed

using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.Disposables;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class NavigationViewItem
	{
		internal SerialDisposable EventRevoker { get; } = new SerialDisposable();

		internal ItemsRepeater GetRepeater() => m_repeater;

		private readonly SerialDisposable m_splitViewIsPaneOpenChangedRevoker = new SerialDisposable();
		private readonly SerialDisposable m_splitViewDisplayModeChangedRevoker = new SerialDisposable();
		private readonly SerialDisposable m_splitViewCompactPaneLengthChangedRevoker = new SerialDisposable();

		private readonly SerialDisposable m_presenterPointerPressedRevoker = new SerialDisposable();
		private readonly SerialDisposable m_presenterPointerEnteredRevoker = new SerialDisposable();
		private readonly SerialDisposable m_presenterPointerMovedRevoker = new SerialDisposable();
		private readonly SerialDisposable m_presenterPointerReleasedRevoker = new SerialDisposable();
		private readonly SerialDisposable m_presenterPointerExitedRevoker = new SerialDisposable();
		private readonly SerialDisposable m_presenterPointerCanceledRevoker = new SerialDisposable();
		private readonly SerialDisposable m_presenterPointerCaptureLostRevoker = new SerialDisposable();

		private readonly SerialDisposable m_repeaterElementPreparedRevoker = new SerialDisposable();
		private readonly SerialDisposable m_repeaterElementClearingRevoker = new SerialDisposable();
		private readonly SerialDisposable m_itemsSourceViewCollectionChangedRevoker = new SerialDisposable();

		private readonly SerialDisposable m_flyoutClosingRevoker = new SerialDisposable();
		private readonly SerialDisposable m_isEnabledChangedRevoker = new SerialDisposable();

		private ToolTip m_toolTip;
		private NavigationViewItemHelper<NavigationViewItem> backing_m_helper;
		private NavigationViewItemHelper<NavigationViewItem> m_helper => backing_m_helper ??= new NavigationViewItemHelper<NavigationViewItem>(this);

		private NavigationViewItemPresenter m_navigationViewItemPresenter;
		private object m_suggestedToolTipContent;
		private ItemsRepeater m_repeater;
		private Grid m_flyoutContentGrid;
		private Grid m_rootGrid;

		private bool m_isClosedCompact;

		private bool m_appliedTemplate;
		private bool m_hasKeyboardFocus;

		// Visual state tracking
		private Pointer m_capturedPointer;
		private uint m_trackedPointerId;
		private bool m_isPressed;
		private bool m_isPointerOver;

		private bool m_isRepeaterParentedToFlyout;
	}
}
