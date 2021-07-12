// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// ApplicationBarService.h, ApplicationBarService.cpp, ApplicationBarService_Partial.cpp

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
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
	internal partial class ApplicationBarService : 
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
		public void RegisterApplicationBar(AppBar pApplicationBar, AppBarMode mode)
		{
			var pWeakApplicationBar = new WeakReference<AppBar>(pApplicationBar);
			var isOpen = false;
			Page spOwner;

			// this doesn't catch multiple registrations. However, since
			// we are only registering when added to the live tree, which means we are never double registered.
			m_ApplicationBars.Add(pWeakApplicationBar);

			spOwner = pApplicationBar.GetOwner();
			//UNO TODO
			//VisualTree* visualTree = VisualTree::GetForElementNoRef(spOwner->GetHandle());
			//if (visualTree)
			//{
			//	static_cast<CPopup*>(m_tpPopupHost.Cast<Popup>()->GetHandle())->SetAssociatedVisualTree(visualTree);
			//}

			AddApplicationBarToVisualTree(pApplicationBar, mode);

			if (mode == AppBarMode.Top)
			{
				m_tpTopBarHost?.ClearValue(Border.ChildTransitionsProperty);
			}
			else if (mode == AppBarMode.Bottom)
			{
				m_tpBottomBarHost?.ClearValue(Border.ChildTransitionsProperty);
				//UNO TODO
				//IFC(m_tpBottomBarHost->ClearValueByKnownIndex(KnownPropertyIndex::UIElement_Transitions));
			}

			isOpen = pApplicationBar.IsOpen;
			if (isOpen)
			{
				OpenApplicationBar(pApplicationBar, mode);
			}
		}

		public void UnregisterApplicationBar(AppBar pApplicationBar)
		{
			AppBar? pApplicationBarInRegistration = null;
			UIElement? spAppbarTopUIE = null;
			UIElement? spAppbarBottomUIE = null;
			AppBar? spAppbarTop = null;
			AppBar? spAppbarBottom = null;

			spAppbarTopUIE = m_tpTopBarHost?.Child;
			spAppbarBottomUIE = m_tpBottomBarHost?.Child;
			spAppbarTop = spAppbarTopUIE as AppBar;
			spAppbarBottom = spAppbarBottomUIE as AppBar;

			// close the appbar so that we run the correct logic around evaluating popup state
			if (spAppbarTop == pApplicationBar)
			{
				CloseApplicationBar(pApplicationBar, AppBarMode.Top);
				RemoveApplicationBarFromVisualTree(pApplicationBar, AppBarMode.Top);
			}
			if (spAppbarBottom == pApplicationBar)
			{
				CloseApplicationBar(pApplicationBar, AppBarMode.Bottom);
				RemoveApplicationBarFromVisualTree(pApplicationBar, AppBarMode.Bottom);
			}

			foreach (var it in m_ApplicationBars.ToList())
			{
				if (it.TryGetTarget(out pApplicationBarInRegistration)
					&& pApplicationBarInRegistration is { }
					&& pApplicationBarInRegistration == pApplicationBar)
				{
					m_ApplicationBars.Remove(it);
				}
				else
				{
					// pApplicationBarInRegistration should never be NULL in the apps as we know.
					MUX_ASSERT(pApplicationBarInRegistration != null);
				}
			}
		}

		public void GetTopAndBottomAppBars(out AppBar? ppTopAppBar, out AppBar? ppBottomAppBar)
		{
			GetTopAndBottomAppBars(openAppBarsOnly: false, out ppTopAppBar, out ppBottomAppBar, out _);
		}

		public void GetTopAndBottomOpenAppBars(out AppBar? ppTopAppBar, out AppBar? ppBottomAppBar, out bool pIsAnyLightDismiss)
		{
			GetTopAndBottomAppBars(openAppBarsOnly: true, out ppTopAppBar, out ppBottomAppBar, out pIsAnyLightDismiss);
		}

		private void GetTopAndBottomAppBars(bool openAppBarsOnly, out AppBar? ppTopAppBar, out AppBar? ppBottomAppBar, out bool pIsAnyLightDismiss)
		{
			UIElement? sbAppbarTopUIE;
			UIElement? spAppbarBottomUIE;
			AppBar? spAppbarTop;
		}

		public void ClearCaches()
		{
			m_ApplicationBars.Clear();

			m_DismissPressedEventToken.Disposable = null;
			m_DismissPointerReleasedEventToken.Disposable = null;
			m_DismissLayerRightTapToken.Disposable = null;
			m_activationToken.Disposable = null;

			//UNO TODO
			// Clear the popup host caches that is on the current window.
			// DxamlCore::RunMessageLoop() calls the ClearCaches() and set the current window as null(m_pWindow),
			// so the current window's caches must be cleared now.
			//if (m_tpPopupHost)
			//{
			//	m_tpPopupHost.ClearWindowCaches();
			//}
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

		
		
		public void OnBoundsChanged(bool inputPaneChange = false) => throw new NotImplementedException();
		public void OpenApplicationBar(AppBar pAppBar, AppBarMode mode) => throw new NotImplementedException();
		public void CloseApplicationBar(AppBar pAppBar, AppBarMode mode) => throw new NotImplementedException();
		public void HandleApplicationBarClosedDisplayModeChange(AppBar pAppBar, AppBarMode mode) => throw new NotImplementedException();
		public bool CloseAllNonStickyAppBars() => throw new NotImplementedException();
		public void UpdateDismissLayer() => throw new NotImplementedException();
		public void ToggleApplicationBars() => throw new NotImplementedException();
		public void SaveCurrentFocusedElement(AppBar pAppBar) => throw new NotImplementedException();
		public void FocusSavedElement(AppBar pApplicationBar) => throw new NotImplementedException();
		TabStopProcessingResult IApplicationBarService.ProcessTabStopOverride(DependencyObject? pFocusedElement, DependencyObject? pCandidateTabStopElement, bool isBackward) => throw new NotImplementedException();
		public void FocusApplicationBar(AppBar pAppBar, FocusState focusState) => throw new NotImplementedException();
		public void SetFocusReturnState(FocusState focusState) => throw new NotImplementedException();
		public void ResetFocusReturnState() => throw new NotImplementedException();
		public AppBarStatus GetAppBarStatus() => throw new NotImplementedException();
		public void ProcessToggleApplicationBarsFromMouseRightTapped() => throw new NotImplementedException();
		
		public DependencyObject? GetFirstFocusableElementFromAppBars(AppBar? pTopAppBar, AppBar? pBottomAppBar, AppBarTabPriority tabPriority, bool startFromEnd) => throw new NotImplementedException();
	}
}
