// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// ApplicationBarService.h, ApplicationBarService.cpp, ApplicationBarService_Partial.cpp

#nullable enable

using System;
using System.Collections.Generic;
using Uno.Disposables;
using Uno.UI.Xaml.Input;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using static Microsoft.UI.Xaml.Controls._Tracing;

namespace Windows.UI.Xaml.Controls
{
	//TODO Uno: This is just a stub of the MUX class.
	internal partial class ApplicationBarService
	{
		public ApplicationBarService()
		{
			m_pRootVisualWeakReference = new WeakReference<UIElement?>(null);
			m_pEdgeGesture = null;
			m_pPreviousFocusedElementWeakRef = new WeakReference<DependencyObject?>(null);
			m_isOverlayVisible = false;

			m_shouldTopGetFocus = true;
			m_suspendLightDismissLayerState = false;
			m_focusReturnState = FocusState.Unfocused;
			m_appBarsLoading = 0;


			m_bounds = null;

			m_unloadingAppbars = new Dictionary<FrameworkElement, SerialDisposable>();

			Initialize();
		}

		internal TabStopProcessingResult ProcessTabStopOverride(
			DependencyObject? focusedElement,
			DependencyObject? candidateTabStopElement,
			bool isBackward)
		{
			return new TabStopProcessingResult();
		}

		~ApplicationBarService()
		{
			m_pPreviousFocusedElementWeakRef.SetTarget(null);
			CleanupOpenEventHooks();

			if (m_overlayClosingCompletedHandler is { })
			{
				MUX_ASSERT(m_overlayClosingStoryboard is { });
				m_overlayClosingCompletedHandler.Disposable = null;
			}
		}

		// sets up our appbar hosting solution using a grid (that is sized to the visible size of the window)
		// and two borders. Those borders are the wrappers that host the appbars.
		// We use hosts so that we can apply transitions without stomping over user values.
		private void Initialize()
		{
			Popup spPopup;
			Grid spGrid;
			AppBarLightDismiss spAccDismissLayer;
			Border spTopHost;
			Border spBottomHost;
			EdgeUIThemeTransition spTopHostChildTransition;
			EdgeUIThemeTransition spBottomHostChildTransition;
			EdgeUIThemeTransition spBottomHostTransition;
			SolidColorBrush spTransparentBrush;
			TransitionCollection spTransitionCollection;
			Transition spTransition;

			IList<UIElement>? pChildren = null;
			Color transparentColor = new Color();
			PointerEventHandler? pDismissLayerPointerPressedHandler = null;
			PointerEventHandler? pDismissLayerPointerReleasedHandler = null;
			Window? pCurrentWindow = null;
			WindowActivatedEventHandler? pWindowActivatedHandler = null;
			RightTappedEventHandler? pDismissLayerRightTappedHandler = null;

			var bounds = new Rect();

			spAccDismissLayer = new AppBarLightDismiss();
			spGrid = new Grid();
			spPopup = new Popup();
			spTopHost = new Border();
			spBottomHost = new Border();
			spTopHostChildTransition = new EdgeUIThemeTransition();
			spBottomHostChildTransition = new EdgeUIThemeTransition();
			spBottomHostTransition = new EdgeUIThemeTransition();

			pCurrentWindow = Window.Current;

			//UNO TODO: ?
			//IFC(spPopup->put_IsApplicationBarService(TRUE));

			m_tpPopupHost = spPopup;
			m_tpDismissLayer = spGrid;
			m_tpAccDismissLayer = spAccDismissLayer;

			m_tpTopBarHost = spTopHost;
			m_tpBottomBarHost = spBottomHost;
			m_tpBottomHostTransition = spBottomHostTransition;

			//UNO TODO: Implement EdgeUIThemeTransition
			//m_tpBottomHostTransition.SetToOnlyReactToTickAndUseIHMTiming(-1);

			// our popup will host the grid
			m_tpPopupHost.Child = m_tpDismissLayer;
			pChildren = m_tpDismissLayer.Children;

			// initialize the dismiss layer to valid bounds
			bounds = Window.Current.Bounds;
			m_tpDismissLayer.Width = bounds.Width;
			m_tpDismissLayer.Height = bounds.Height;

			// the grid acts as the light dismiss layer, so it needs atleast a transparent color
			// we will be toggling the brush in order to turn on or off the shield
			spTransparentBrush = new SolidColorBrush();
			transparentColor.A = 0;
			transparentColor.B = 255;
			transparentColor.G = 255;
			transparentColor.R = 255;
			m_tpTransparentBrush = spTransparentBrush;
			m_tpTransparentBrush.Color = transparentColor;

			// hookup pointer presses to the dismiss layer. This way we can
			// act as a true dismiss layer
			m_tpDismissLayer.PointerPressed += OnDismissLayerPressed;
			m_DismissPressedEventToken.Disposable = Disposable.Create(() => m_tpDismissLayer.PointerPressed -= OnDismissLayerPressed);

			// Also hookup pointer up event so we can catch and handle it. Unless we do this, controls beneath the dismiss layer
			// will get unmatched events (they will receive pointer up but not down). We do not want this.
			m_tpDismissLayer.PointerReleased += OnDismissLayerPointerReleased;
			m_DismissPointerReleasedEventToken.Disposable = Disposable.Create(() => m_tpDismissLayer.PointerReleased -= OnDismissLayerPointerReleased);

			// Hook up right tapped event to the dismiss layer so we can toggle the appbars instead of
			// just dismissing the non-sticky ones when it gets right tapped
			m_tpDismissLayer.RightTapped += OnDismissLayerRightTapped;
			m_DismissLayerRightTapToken.Disposable = Disposable.Create(() => m_tpDismissLayer.RightTapped -= OnDismissLayerRightTapped);

			// our dismiss layer will host in total two appbar hosts.
			// in order to easily manage the appear and disappear transitions, we'll put a transition on the
			// appbars through the childtransitions of the hosts.
			//
			// For the movement of the bottom bar though, we cannot use a transition on the bottom bar directly, since
			// it is not moving relative to its parent. It is the border (host) that is moving, so it is the one that
			// needs the transition.
			spTopHostChildTransition.Edge = EdgeTransitionLocation.Top;
			spBottomHostChildTransition.Edge = EdgeTransitionLocation.Bottom;

			// setup alignments such that the bottombar is always at the bottom of the visible area
			m_tpTopBarHost.VerticalAlignment = VerticalAlignment.Top;
			m_tpTopBarHost.HorizontalAlignment = HorizontalAlignment.Stretch;
			m_tpBottomBarHost.VerticalAlignment = VerticalAlignment.Bottom;
			m_tpBottomBarHost.HorizontalAlignment = HorizontalAlignment.Stretch;
			m_tpAccDismissLayer.VerticalAlignment = VerticalAlignment.Stretch;
			m_tpAccDismissLayer.HorizontalAlignment = HorizontalAlignment.Stretch;

			// m_tpAccDismissLayer needs to be the last child (UpdateDismissLayer() work on that assumption)
			pChildren.Add(m_tpTopBarHost);
			pChildren.Add(m_tpBottomBarHost);
			pChildren.Add(m_tpAccDismissLayer);

			// start without shield on
			UpdateDismissLayer();

			// start probably with the popup closed
			EvaluatePopupState();

			if (pCurrentWindow is { })
			{
				pCurrentWindow.Activated += OnWindowActivated;
				m_activationToken.Disposable = Disposable.Create(() => pCurrentWindow.Activated -= OnWindowActivated);
			}

			// Add this to the list of objects not in the peer table.
			//DXamlCore::GetCurrent()->AddToReferenceTrackingList(this);
		}

		private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void OnDismissLayerRightTapped(object sender, RightTappedRoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void OnDismissLayerPointerReleased(object sender, PointerRoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void OnDismissLayerPressed(object sender, PointerRoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
