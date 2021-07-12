
#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls
{
	// Service class that provides the system implementation for managing
	// many app bars and the edgy event.
	partial class ApplicationBarService : IApplicationBarService
	{
		WeakReference<UIElement?> m_pRootVisualWeakReference;
		List<WeakReference<AppBar>> m_ApplicationBars = new List<WeakReference<AppBar>>();

		// Edge Gesture Completed registration token
		SerialDisposable m_EdgeGestureCompletedEventToken = new SerialDisposable();

		// Pointer pressed event tokens
		SerialDisposable m_DismissPressedEventToken = new SerialDisposable();
		SerialDisposable m_DismissPointerReleasedEventToken = new SerialDisposable();
		SerialDisposable m_DismissLayerRightTapToken = new SerialDisposable();

		// Keyboard event token
		SerialDisposable? m_KeyPressedEventToken = new SerialDisposable();

		// activation token
		SerialDisposable m_activationToken = new SerialDisposable();

		// Reference to current EdgeGesture object
		EdgeGesture? m_pEdgeGesture;

		// the host of the dismiss layer and the wrappers
		Popup? m_tpPopupHost;
		Grid? m_tpDismissLayer;

		// AppBarLightDismiss element which implment Invoke accessibility pattern (a child of m_tpDismissLayer with the same size)
		Grid? m_tpAccDismissLayer;
		// wrappers that will host the appbars. We need wrappers in order to be able to apply transitions
		Border? m_tpTopBarHost;
		Border? m_tpBottomBarHost;
		EdgeUIThemeTransition? m_tpBottomHostTransition;

		// transparent brush, used to toggle on and off the hittesting behavior of the grid
		SolidColorBrush? m_tpTransparentBrush;
		// map of unloading appbars. Needed to be able to unhook the unloaded event after we received it.
		Dictionary<FrameworkElement, SerialDisposable> m_unloadingAppbars;
		// cache the previous bounds that we used as our visual viewport
		Rect? m_bounds;
		// Holds a weak reference to the most recent element focused on the main content before any appbar
		// got opened.
		WeakReference<DependencyObject?> m_pPreviousFocusedElementWeakRef;
		// After dismissing an appbar or pressing ESC on a sticky appbar focus returns to the previously focused element before appbar is
		// opened. We determine the focus state when returning the focus to the previously focus element on manner dismissing and hold this state
		// at this variable.
		FocusState m_focusReturnState;
		// The only case where top app bar should not get focus as soon as it opens is the case where
		// bottom app bar will get opened at the same time. This BOOLEAN should be false in that case. Otherwise
		// it should always be true.
		bool m_shouldTopGetFocus;
		// Light dismiss layer and the popup host preserve their current state when this flag is set.
		bool m_suspendLightDismissLayerState;
		// Focus appbars after all appbars which are loading have loaded so we can determine which appbar should receive focus.
		int m_appBarsLoading;

		private const int s_OpeningDurationMs = 467;
		private const int s_ClosingDurationMs = 167;
		bool m_isOverlayVisible;
		Storyboard? m_overlayOpeningStoryboard;
		Storyboard? m_overlayClosingStoryboard;
		SerialDisposable m_overlayClosingCompletedHandler = new SerialDisposable();
	}

	internal enum AppBarTabPriority
	{
		Top,
		Bottom,
	};
}
