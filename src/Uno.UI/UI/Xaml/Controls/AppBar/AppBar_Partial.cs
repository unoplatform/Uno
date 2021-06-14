using System;
using System.Collections.Generic;
using System.Text;
using DirectUI;
using Uno.Disposables;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls
{
	public partial class AppBar : ContentControl
	{

		private const string TEXT_HUB_SEE_MORE = nameof(TEXT_HUB_SEE_MORE);
		private const string TEXT_HUB_SEE_LESS = nameof(TEXT_HUB_SEE_LESS);
		private const string UIA_MORE_BUTTON = nameof(UIA_MORE_BUTTON);
		private const string UIA_LESS_BUTTON = nameof(UIA_LESS_BUTTON);

		protected Grid m_tpLayoutRoot;
		protected FrameworkElement m_tpContentRoot;
		protected ButtonBase m_tpExpandButton;
		protected VisualStateGroup m_tpDisplayModesStateGroup;

		double m_compactHeight;
		double m_minimalHeight;

		AppBarMode m_Mode;

		// Focus state to be applied on loaded.
		FocusState m_onLoadFocusState;

		// Owner, if this AppBar is owned by a Page using TopAppBar/BottomAppBar.
		WeakReference<Page> m_wpOwner;

		SerialDisposable m_loadedEventHandler = new SerialDisposable();
		SerialDisposable m_unloadedEventHandler = new SerialDisposable();
		SerialDisposable m_layoutUpdatedEventHandler = new SerialDisposable();
		SerialDisposable m_sizeChangedEventHandler = new SerialDisposable();
		SerialDisposable m_contentRootSizeChangedEventHandler = new SerialDisposable();
		SerialDisposable m_windowSizeChangedEventHandler = new SerialDisposable();
		SerialDisposable m_expandButtonClickEventHandler = new SerialDisposable();
		SerialDisposable m_displayModeStateChangedEventHandler = new SerialDisposable();

		UIElement m_layoutTransitionElement;
		UIElement m_overlayLayoutTransitionElement;

		UIElement m_parentElementForLTEs;
		FrameworkElement m_overlayElement;
		SerialDisposable m_overlayElementPointerPressedEventHandler = new SerialDisposable();

		WeakReference<DependencyObject> m_savedFocusedElementWeakRef;
		FocusState m_savedFocusState;

		bool m_isInOverlayState;
		bool m_isChangingOpenedState;
		bool m_hasUpdatedTemplateSettings;

		// We refresh this value in the OnSizeChanged() & OnContentSizeChanged() handlers.
		double m_contentHeight;

		bool m_isOverlayVisible;
		Storyboard m_overlayOpeningStoryboard;
		Storyboard m_overlayClosingStoryboard;

		public AppBar()
		{
			m_Mode = AppBarMode.Inline;
			m_onLoadFocusState = FocusState.Unfocused;
			m_savedFocusState = FocusState.Unfocused;
			m_isInOverlayState = false;
			m_isChangingOpenedState = false;
			m_hasUpdatedTemplateSettings = false;
			m_compactHeight = 0d;
			m_minimalHeight = 0d;
			m_contentHeight = 0d;
			m_isOverlayVisible = false;

			PrepareState();
			DefaultStyleKey = typeof(AppBar);
		}

		~AppBar()
		{
			if (Window.Current is { } window)
			{
				m_windowSizeChangedEventHandler.Disposable = null;
			}

			// UNO TODO
			// Make sure we're not still registered for back button events when no longer
			// in the tree.
			//IFC_RETURN(BackButtonIntegration_UnregisterListener(this));
		}

		protected virtual void PrepareState()
		{
			Loaded += OnLoaded;
			Unloaded += OnUnloaded;
			SizeChanged += OnSizeChanged;

			m_windowSizeChangedEventHandler.Disposable = Window.Current.RegisterSizeChangedEvent(OnWindowSizeChanged);

			TemplateSettings = new AppBarTemplateSettings(this);
		}

		// Note that we need to wait for OnLoaded event to set focus.
		// When we get the on opened event children of AppBar will not be populated
		// yet which will prevent them from getting focus.
		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			LayoutUpdated += OnLayoutUpdated;

			var isOpen = IsOpen;
			if (isOpen)
			{
				OnIsOpenChanged(true);
			}

			//UNO TODO

			//if (m_Mode != AppBarMode_Inline)
			//{
			//	ctl::ComPtr<IApplicationBarService> applicationBarService;
			//	IFC_RETURN(DXamlCore::GetCurrent()->GetApplicationBarService(applicationBarService));

			//	if (m_Mode == AppBarMode_Floating)
			//	{
			//		IFC_RETURN(applicationBarService->RegisterApplicationBar(this, m_Mode));
			//	}

			//	// Focus the AppBar only if this is a Threshold app and if the AppBar that is being loaded is already open.
			//	isOpen = FALSE;
			//	IFC_RETURN(get_IsOpen(&isOpen));

			//	if (isOpen)
			//	{
			//		auto focusState = (m_onLoadFocusState != xaml::FocusState_Unfocused ? m_onLoadFocusState : xaml::FocusState_Programmatic);
			//		IFC_RETURN(applicationBarService->FocusApplicationBar(this, focusState));
			//	}

			//	// Reset the saved focus state
			//	m_onLoadFocusState = xaml::FocusState_Unfocused;
			//}

			UpdateVisualState();
		}

		private void OnUnloaded(object sender, RoutedEventArgs e)
		{
			LayoutUpdated -= OnLayoutUpdated;

			if (m_isInOverlayState)
			{
				TeardownOverlayState();
			}

			// UNO TODO
			/*
			if (m_Mode == AppBarMode_Floating)
			{
				ctl::ComPtr<IApplicationBarService> applicationBarService;
				IFC_RETURN(DXamlCore::GetCurrent()->GetApplicationBarService(applicationBarService));
				IFC_RETURN(applicationBarService->UnregisterApplicationBar(this));
			}

			// Make sure we're not still registered for back button events when no longer
			// in the tree.
			IFC_RETURN(BackButtonIntegration_UnregisterListener(this));
			*/
		}
		private void OnLayoutUpdated(object sender, object e)
		{
			if (m_layoutTransitionElement is { })
			{
				PositionLTEs();
			}
		}

		private void OnSizeChanged(object sender, SizeChangedEventArgs args)
		{
			RefreshContentHeight();
			UpdateTemplateSettings();

			if (GetOwner() is { } pageOwner)
			{
				// UNO TODO
				//pageOwner.AppBarClosedSizeChanged();
			}
		}

		private void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
		{
			if (args.Property == IsOpenProperty)
			{
				var isOpen = (bool)args.NewValue;
				OnIsOpenChanged(isOpen);

				UpdateVisualState();
			}
			else if (args.Property == IsStickyProperty)
			{
				OnIsStickyChanged();
			}
			else if (args.Property == ClosedDisplayModeProperty)
			{
				// UNO TODO
				/*
				if (m_Mode != AppBarMode.Inline)
				{
					ctl::ComPtr<IApplicationBarService> applicationBarService;
					IFC_RETURN(DXamlCore::GetCurrent()->GetApplicationBarService(applicationBarService));

					IFC_RETURN(applicationBarService->HandleApplicationBarClosedDisplayModeChange(this, m_Mode));
				}*/

				InvalidateMeasure();
				UpdateVisualState();
			}
			else if (args.Property == LightDismissOverlayModeProperty)
			{
				ReevaluateIsOverlayVisible();
			}
			else if (args.Property == IsEnabledProperty)
			{
				UpdateVisualState();
			}
		}

		protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
		{
			if (GetOwner() is { } pageOwner)
			{
				// UNO TODO
				//pageOwner.AppBarClosedSizeChanged();
			}
		}

		protected override void OnApplyTemplate()
		{
			if (m_tpContentRoot is { })
			{
				m_contentRootSizeChangedEventHandler.Disposable = null;
			}

			if (m_tpExpandButton is { })
			{
				m_expandButtonClickEventHandler.Disposable = null;
			}

			if (m_tpDisplayModesStateGroup is { })
			{
				m_displayModeStateChangedEventHandler.Disposable = null;
			}

			// Clear our previous template parts.
			m_tpLayoutRoot = null;
			m_tpContentRoot = null;
			m_tpExpandButton = null;
			m_tpDisplayModesStateGroup = null;

			base.OnApplyTemplate();

			GetTemplatePart("LayoutRoot", out m_tpLayoutRoot);
			GetTemplatePart("ContentRoot", out m_tpContentRoot);

			if (m_tpContentRoot is { })
			{
				m_tpContentRoot.SizeChanged += OnContentRootSizeChanged;
				m_contentRootSizeChangedEventHandler.Disposable = Disposable.Create(() => m_tpContentRoot.SizeChanged -= OnContentRootSizeChanged);
			}

			GetTemplatePart("ExpandButton", out m_tpExpandButton);

			if (m_tpExpandButton == null)
			{
				// The previous CommandBar template used "MoreButton" for this template part's name,
				// so now we're stuck with it, as much as I'd like to converge them..
				GetTemplatePart("MoreButton", out m_tpExpandButton);
			}

			if (m_tpExpandButton is { })
			{
				m_tpExpandButton.Click += OnExpandButtonClick;
				m_expandButtonClickEventHandler.Disposable = Disposable.Create(() => m_tpExpandButton.Click -= OnExpandButtonClick);

				var resourceLoader = ResourceLoader.GetForCurrentView();

				var toolTip = new ToolTip();
				toolTip.Content = DXamlCore.GetCurrent().GetLocalizedResourceString(TEXT_HUB_SEE_MORE);

				ToolTipService.SetToolTip(m_tpExpandButton, toolTip);

				var automationName = AutomationProperties.GetName((Button)m_tpExpandButton);
				if (automationName == null)
				{
					automationName = DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString(UIA_MORE_BUTTON);
					AutomationProperties.SetName((Button)m_tpExpandButton, automationName);
				}
			}

			// Query compact & minimal height from resource dictionary.
			{
				var resources = Resources;

				if (resources.TryGetValue("AppBarThemeCompactHeight", out var oCompactHeight)
					&& oCompactHeight is double compactHeight)
				{
					m_compactHeight = compactHeight;
				}

				if (resources.TryGetValue("AppBarThemeMinimalHeight", out var oMinimalHeight)
				&& oMinimalHeight is double minimalHeight)
				{
					m_minimalHeight = minimalHeight;
				}
			}

			// Lookup the animations to use for the window overlay.
			if (m_tpLayoutRoot is { })
			{
				var gridResources = m_tpLayoutRoot.Resources;

				if (gridResources.TryGetValue("OverlayOpeningAnimation", out var oWindowOverlayOpeningStoryboard)
					&& oWindowOverlayOpeningStoryboard is Storyboard windowOverlayOpeningStoryboard)
				{
					m_overlayOpeningStoryboard = windowOverlayOpeningStoryboard;
				}

				if (gridResources.TryGetValue("OverlayClosingAnimation", out var oWindowOverlayClosingStoryboard)
					&& oWindowOverlayClosingStoryboard is Storyboard windowOverlayClosingStoryboard)
				{
					m_overlayClosingStoryboard = windowOverlayClosingStoryboard;
				}
			}

			ReevaluateIsOverlayVisible();
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			var size = base.MeasureOverride(availableSize);

			if (m_Mode == AppBarMode.Top || m_Mode == AppBarMode.Bottom)
			{
				// regardless of what we desire, settings of alignment or fixed size content, we will always take up full width
				size.Width = availableSize.Width;
			}

			// Make sure our returned height matches the configured state.
			var closedDisplayMode = ClosedDisplayMode;

			size.Height = closedDisplayMode switch
			{
				AppBarClosedDisplayMode.Compact => m_compactHeight,
				AppBarClosedDisplayMode.Minimal => m_minimalHeight,
				_ => 0d,
			};

			return size;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			var layoutRootDesiredSize = new Size();
			if (m_tpLayoutRoot is { })
			{
				layoutRootDesiredSize = m_tpLayoutRoot.DesiredSize;
			}
			else
			{
				layoutRootDesiredSize = finalSize;
			}

			var baseSize = base.ArrangeOverride(new Size(finalSize.Width, layoutRootDesiredSize.Height));

			baseSize.Height = finalSize.Height;

			return baseSize;
		}

		protected virtual void OnOpening(object e)
		{
			TryQueryDisplayModesStatesGroup();

			if (m_Mode == AppBarMode.Inline)
			{
				// If we're in a popup that is light-dismissable, then we don't want to set up
				// a light-dismiss layer - the popup will have its own light-dismiss layer,
				// and it can interfere with ours.
				var popupAncestor = FindFirstParent<Popup>();
				if (popupAncestor == null || (popupAncestor.IsLightDismissEnabled || popupAncestor.IsSubMenu))
				{
					if (!m_isInOverlayState)
					{
						if (IsInLiveTree)
						{
							// Setup our LTEs and light-dismiss layer.
							SetupOverlayState();

							if (m_isOverlayVisible)
							{
								PlayOverlayOpeningAnimation();
							}
						}
					}
				}

				var isSticky = IsSticky;
				if (!isSticky)
				{
					SetFocusOnAppBar();
				}
			}
			else
			{
				// Pre-Threshold AppBars were hidden and would get added to the tree upon opening which
				// would invoke their loaded handlers to set focus.
				// In threshold, hidden appbars are always in the tree, so we have to simulate the same
				// behavior by focusing the appbar whenever it opens.
				var closedDisplayMode = ClosedDisplayMode;
				if (closedDisplayMode == AppBarClosedDisplayMode.Hidden)
				{
					// UNO TODO
					//ctl::ComPtr<IApplicationBarService> applicationBarService;
					//IFC_RETURN(DXamlCore::GetCurrent()->GetApplicationBarService(applicationBarService));

					// Determine the focus state

					// UNO TODO
					//var focusState = m_onLoadFocusState != FocusState.Unfocused ? m_onLoadFocusState : FocusState.Programmatic;
					//IFC_RETURN(applicationBarService->FocusApplicationBar(this, focusState));

					// Reset the saved focus state
					m_onLoadFocusState = FocusState.Unfocused;
				}
			}

			if (m_tpExpandButton is { })
			{
				// Set a tooltip with "See Less" for the expand button.
				var toolTip = new ToolTip();
				toolTip.Content = DXamlCore.GetCurrent().GetLocalizedResourceString(TEXT_HUB_SEE_LESS);

				ToolTipService.SetToolTip(m_tpExpandButton, toolTip);

				AutomationProperties.SetName(m_tpExpandButton, DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString(UIA_LESS_BUTTON));
			}

			ElementSoundPlayer.RequestInteractionSoundForElement(ElementSoundKind.Show, this);

			Opening?.Invoke(this, e);
		}


		protected virtual void OnOpened(object e)
		{
			Opening?.Invoke(this, e);

			// UNO TODO
			//if (DXamlCore::GetCurrent()->GetHandle()->BackButtonSupported())
			//{
			//	IFC_RETURN(BackButtonIntegration_RegisterListener(this));
			//}

		}

		protected virtual void OnClosing(object e)
		{
			if (m_Mode == AppBarMode.Inline)
			{
				// Only restore focus if this AppBar isn't in a flyout - if it is,
				// then focus will be restored when the flyout closes.
				// We'll interfere with that if we restore focus before that time.
				var popupAncestor = FindFirstParent<Popup>();
				if (popupAncestor == null || !(popupAncestor.PopupPanel is FlyoutBasePopupPanel))
				{
					RestoreSavedFocus();
				}

				if (m_isOverlayVisible && m_isInOverlayState)
				{
					PlayOverlayClosingAnimation();
				}
			}

			if (m_tpExpandButton is { })
			{
				// Set a tooltip with "See More" for the expand button.
				var tooltipText = DXamlCore.GetCurrent().GetLocalizedResourceString(TEXT_HUB_SEE_MORE);
				var tooltip = new ToolTip();
				tooltip.Content = tooltipText;

				ToolTipService.SetToolTip(m_tpExpandButton, tooltip);

				// Update the localized accessibility name for expand button with the more app bar button.
				AutomationProperties.SetName(m_tpExpandButton, DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString(UIA_MORE_BUTTON);
			}

			// Request a play hide sound for closed
			ElementSoundPlayer.RequestInteractionSoundForElement(ElementSoundKind.Hide, this);

			// Raise the event
			Closing?.Invoke(this, e);
		}

		protected virtual void OnClosed(object e)
		{
			if (m_Mode == AppBarMode.Inline && m_isInOverlayState)
			{
				TeardownOverlayState();
			}

			// Raise the event
			Closed?.Invoke(this, e);

			// UNO TODO
			//IFC_RETURN(BackButtonIntegration_UnregisterListener(this));

		}


		// UNO TODO: After Focus
		//AppBar::ProcessTabStopOverride(
		//_In_opt_ DependencyObject* pFocusedElement,
		//_In_opt_ DependencyObject* pCandidateTabStopElement,

		//const bool isBackward,

		//const bool /*didCycleFocusAtRootVisualScope*/,
		//_Outptr_ DependencyObject** ppNewTabStop,
		//_Out_ BOOLEAN* pIsTabStopOverridden
	 //   )
		//{
		//	*ppNewTabStop = nullptr;
		//	*pIsTabStopOverridden = FALSE;

		//	// The ApplicationBarService manages focus for non-inline appbars.
		//	if (m_Mode == AppBarMode_Inline)
		//	{
		//		BOOLEAN isOpen = FALSE;
		//		IFC_RETURN(get_IsOpen(&isOpen));

		//		BOOLEAN isSticky = FALSE;
		//		IFC_RETURN(get_IsSticky(&isSticky));

		//		// We don't override tab-stop behavior for closed or sticky appbars.
		//		if (!isOpen || isSticky)
		//		{
		//			return S_OK;
		//		}

		//	BOOLEAN isAncestorOfFocusedElement = FALSE;
		//	IFC_RETURN(IsAncestorOf(pFocusedElement, &isAncestorOfFocusedElement));

		//		BOOLEAN isAncestorOfCandidateElement = FALSE;
		//	IFC_RETURN(IsAncestorOf(pCandidateTabStopElement, &isAncestorOfCandidateElement));

		//		// If the element losing focus is a child of the appbar and the element
		//		// we're losing focus to is not, then we override tab-stop to keep the
		//		// focus within the appbar.
		//		if (isAncestorOfFocusedElement && !isAncestorOfCandidateElement)
		//		{
		//			xref_ptr<CDependencyObject> newTabStop;

		//	IFC_RETURN(isBackward?
		//		FocusManager_GetLastFocusableElement(GetHandle(), newTabStop.ReleaseAndGetAddressOf()) :

		//				FocusManager_GetFirstFocusableElement(GetHandle(), newTabStop.ReleaseAndGetAddressOf())
		//				);

		//			// Check to see if we overrode the tab stop candidate.
		//			if (newTabStop)
		//			{
		//				IFC_RETURN(DXamlCore::GetCurrent()->GetPeer(newTabStop, ppNewTabStop));

		//				* pIsTabStopOverridden = TRUE;
		//}
		//		}
		//	}

		//	return S_OK;
		//}

		
		private void OnContentRootSizeChanged(object sender, SizeChangedEventArgs args)
		{
			RefreshContentHeight(out var didChange);

			if (didChange)
			{
				UpdateTemplateSettings();
			}
		}

		private void OnWindowSizeChanged(object sender, Core.WindowSizeChangedEventArgs e)
		{
			if (m_Mode == AppBarMode.Inline)
			{
				TryDismissInlineAppBar();
			}
		}

		// floating appbars are managed through vsm. System appbars (as set by page) use
		// transitions that are triggered by layout to load, unload and move around.
		private protected override void ChangeVisualState(bool useTransitions)
		{
			base.ChangeVisualState(useTransitions);

			bool ignored = false;
			bool isEnabled = false;
			bool isOpen = false;

			var closedDisplayMode = AppBarClosedDisplayMode.Hidden;
			bool shouldOpenUp = false;

			isEnabled = IsEnabled;
			isOpen = IsOpen;
			closedDisplayMode = ClosedDisplayMode;

			// We only need to check this if we're going to an opened state.
			if (isOpen)
			{
				GetShouldOpenUp(out shouldOpenUp);
			}

			// CommonStates
			GoToState(useTransitions, isEnabled ? "Normal" : "Disabled", out ignored);

			// FloatingStates
			if (m_Mode == AppBarMode.Floating)
			{
				GoToState(useTransitions, isOpen ? "FloatingVisible" : "FloatingHidden", out ignored);
			}

			// DockPositions
			switch (m_Mode)
			{
				case AppBarMode.Top:
					GoToState(useTransitions, "Top", out ignored);
					break;

				case AppBarMode.Bottom:
					GoToState(useTransitions, "Bottom", out ignored);
					break;

				default:
					GoToState(useTransitions, "Undocked", out ignored);
					break;
			}

			// DisplayModeStates
			var displayMode = closedDisplayMode switch
			{
				AppBarClosedDisplayMode.Compact => "Compact",
				AppBarClosedDisplayMode.Minimal => "Minimal",
				_ => "Hidden",
			};

			var placement = shouldOpenUp ? "Up" : "Down";
			var openState = string.Empty;

			if (isOpen)
			{
				openState = "Open";
			} else
			{
				openState = "Closed";
				placement = string.Empty;
			}
			
			GoToState(useTransitions, $"{displayMode}{openState}{placement}", out ignored);
		}

		protected override void OnPointerPressed(PointerRoutedEventArgs e)
		{
			base.OnPointerPressed(e);

			var isOpen = IsOpen;
			if (isOpen)
			{
				var isSticky = IsSticky;

				if (!isSticky)
				{
					// If the app bar is in a modal-like state, then don't propagate pointer
					// events.
					e.Handled = true;
				}
			}
			else
			{
				var closedDisplayMode = ClosedDisplayMode;
				if (closedDisplayMode == AppBarClosedDisplayMode.Minimal)
				{
					IsOpen = true;
					e.Handled = true;
				}
			}
		}

		protected override void OnRightTapped(RightTappedRoutedEventArgs e)
		{
			base.OnRightTapped(e);

			if (m_Mode != AppBarMode.Inline)
			{
				var pointerDeviceType = e.PointerDeviceType;
				if (pointerDeviceType != Devices.Input.PointerDeviceType.Mouse)
				{
					return;
				}

				var isOpen = IsOpen;
				var isHandled = e.Handled;

				if (isOpen && !isHandled)
				{
					// UNO TODO
					//ctl::ComPtr<IApplicationBarService> applicationBarService;
					//IFC_RETURN(DXamlCore::GetCurrent()->GetApplicationBarService(applicationBarService));

					//applicationBarService->SetFocusReturnState(xaml::FocusState_Pointer);
					//IFC_RETURN(applicationBarService->ToggleApplicationBars());

					//applicationBarService->ResetFocusReturnState();
					e.Handled = true;
				}
			}
		}

		private void OnIsStickyChanged()
		{
			if (m_Mode != AppBarMode.Inline)
			{
				// UNO TODO
				//ctl::ComPtr<IApplicationBarService> applicationBarService;
				//IFC_RETURN(DXamlCore::GetCurrent()->GetApplicationBarService(applicationBarService));
				//IFC_RETURN(applicationBarService->UpdateDismissLayer());
			}

			if (m_overlayElement is { })
			{
				var isSticky = IsSticky;
				m_overlayElement.IsHitTestVisible = !isSticky;
			}
		}

		private void OnIsOpenChanged(bool isOpen)
		{
			// If the AppBar is not live, then wait until it's loaded before
			// responding to changes to opened state and firing our Opening/Opened events.
			if (!IsInLiveTree)
			{
				return;
			}

			if (m_Mode != AppBarMode.Inline)
			{
				// UNO TODO
				//ctl::ComPtr<IApplicationBarService> applicationBarService;
				//IFC_RETURN(DXamlCore::GetCurrent()->GetApplicationBarService(applicationBarService));

				//BOOLEAN hasFocus = FALSE;
				//IFC_RETURN(HasFocus(&hasFocus));

				//if (isOpen)
				//{
				//	IFC_RETURN(applicationBarService->SaveCurrentFocusedElement(this));
				//	IFC_RETURN(applicationBarService->OpenApplicationBar(this, m_Mode));

				//	// If the AppBar does not already have focus (i.e. it was opened programmatically),
				//	// then focus the AppBar.
				//	if (!hasFocus)
				//	{
				//		IFC_RETURN(applicationBarService->FocusApplicationBar(this, xaml::FocusState_Programmatic));
				//	}
				//}
				//else
				//{
				//	IFC_RETURN(applicationBarService->CloseApplicationBar(this, m_Mode));

				//	// Only restore the focus to the saved element if we have the focus just before closing.
				//	// For CommandBar, we also check if the Overflow has focus in the override method "HasFocus"
				//	if (hasFocus)
				//	{
				//		IFC_RETURN(applicationBarService->FocusSavedElement(this));
				//	}
				//}

				//IFC_RETURN(applicationBarService->UpdateDismissLayer());
			}

			// Flag that we're transitions between opened & closed states.
			m_isChangingOpenedState = true;

			// Fire our Opening/Closing events.  If we're a legacy app or a badly
			// re-templated app, then fire the Opened/Closed events as well.
			{
				var routedEventArgs = new RoutedEventArgs(this);

				if (isOpen)
				{
					OnOpening(routedEventArgs);
				}
				else
				{
					OnClosing(routedEventArgs);
				}

				// We only query the display modes visual state group for post-WinBlue AppBars
				// so in cases where we don't have it (either via re-templating or legacy apps)
				// fire the Opening/Closing & Opened/Closed events immediately.
				// For WinBlue apps, firing the Opening/Closing events as well doesn't
				// matter because Blue apps wouldn't have had access to them.
				// For post-WinBlue AppBars, we fire the Opening/Closing & Opened/Closed
				// events based on our display mode state transitions.
				if (m_tpDisplayModesStateGroup == null)
				{
					if (isOpen)
					{
						OnOpened(routedEventArgs);
					}
					else
					{
						OnClosed(routedEventArgs);
					}
				}
			}
		}

		private void OnIsOpenChangedForAutomation(DependencyPropertyChangedEventArgs args)
		{
			var isOpen = (bool)args.NewValue;
			bool bAutomationListener = false;

			if (isOpen)
			{
				AutomationPeer.RaiseEventIfListener(this, AutomationEvents.MenuOpened);
			} else
			{
				AutomationPeer.RaiseEventIfListener(this, AutomationEvents.MenuClosed);
			}

			// Raise ToggleState Property change event for Automation clients if they are listening for property changed events.
			bAutomationListener = AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged);
			if (bAutomationListener)
			{
				var automationPeer = GetAutomationPeer();
				if (automationPeer is AppBarAutomationPeer applicationBarAutomationPeer)
				{
					applicationBarAutomationPeer.RaiseToggleStatePropertyChangedEvent(args.OldValue, args.NewValue);
					applicationBarAutomationPeer.RaiseExpandCollapseAutomationEvent(isOpen);
				}

			}
		}

		protected override AutomationPeer OnCreateAutomationPeer()
		{
			AutomationPeer ppAutomationPeer = null;

			AppBarAutomationPeer spAutomationPeer;
			spAutomationPeer = new AppBarAutomationPeer(this);
			ppAutomationPeer = spAutomationPeer;

			return ppAutomationPeer;
		}

		protected override void OnKeyDown(KeyRoutedEventArgs args)
		{
			base.OnKeyDown(args);

			bool isHandled = false;
			isHandled = args.Handled;

			if (isHandled)
			{
				return;
			}

			var key = args.Key;
			if (key == System.VirtualKey.Escape)
			{
				bool isAnyAppBarClosed = false;

				if (m_Mode == AppBarMode.Inline)
				{
					TryDismissInlineAppBar(out isAnyAppBarClosed);
				}
				else
				{
					// UNO TODO
					//BOOLEAN isSticky = FALSE;
					//IFC_RETURN(get_IsSticky(&isSticky));

					//// If we have focus and the app bar is not sticky close all light-dismiss app bars on ESC
					//ctl::ComPtr<IApplicationBarService> applicationBarService;
					//IFC_RETURN(DXamlCore::GetCurrent()->GetApplicationBarService(applicationBarService));

					//BOOLEAN hasFocus = FALSE;
					//IFC_RETURN(HasFocus(&hasFocus));
					//if (hasFocus)
					//{
					//	IFC_RETURN(applicationBarService->CloseAllNonStickyAppBars(&isAnyAppBarClosed));

					//	if (isSticky)
					//	{
					//		// If the appbar is sticky restore focus to the saved element without closing the appbar
					//		applicationBarService->SetFocusReturnState(xaml::FocusState_Keyboard);
					//		IFC_RETURN(applicationBarService->FocusSavedElement(this));
					//		applicationBarService->ResetFocusReturnState();
					//	}
					//}
				}

				args.Handled = isAnyAppBarClosed;
			}
		}

		public void SetOwner(Page pOwner)
		{
			m_wpOwner.SetTarget(pOwner);
		}

		public Page GetOwner()
		{
			if (m_wpOwner != null
				&& m_wpOwner.TryGetTarget(out var pageOwner)
				&& pageOwner is { })
			{
				return pageOwner;
			}

			return null;
		}

		protected virtual bool ContainsElement(DependencyObject pElement)
		{
			bool isAncestorOfElement = false;

			// For AppBar, ContainsElement is equivalent to IsAncestorOf.
			// However, ContainsElement is a virtual method, and CommandBar's
			// implementation of it also checks the overflow popup separately from
			// IsAncestorOf since the popup isn't part of the same visual tree.
			isAncestorOfElement = this.IsAncestorOf(pElement);

			return isAncestorOfElement;
		}

		protected bool IsExpandButton(UIElement element)
		{
			return m_tpExpandButton is { } && element == m_tpExpandButton;
		}

		private void OnExpandButtonClick(object sender, RoutedEventArgs e)
		{
			bool bIsOpen = false;
			bIsOpen = IsOpen;
			IsOpen = !bIsOpen;
		}

		private OnDisplayModesStateChanged(object sender, VisualStateChangedEventArgs pArgs)
		{
			// We only fire the opened/closed events if we're changing our opened state (either
			// from open to closed or closed to open).  We don't fire the event if we changed
			// between 2 opened states or 2 closed states such as might happen when changing
			// closed display mode.
			if (m_isChangingOpenedState)
			{
				// Create the event args we'll use for our Opened/Closed events.
				var routedEventArgs = new RoutedEventArgs(this);

				var isOpen = IsOpen;

				if (isOpen)
				{
					OnOpened(routedEventArgs);
				}
				else
				{
					OnClosed(routedEventArgs);
				}

				m_isChangingOpenedState = false;
			}
		}

		private void UpdateTemplateSettings()
		{
			//
			// AppBar/CommandBar TemplateSettings and how they're used.
			//
			// The template settings are core to acheiving the desired experience
			// for AppBar/CommandBar at least to how it relates to the various
			// ClosedDisplayModes.
			//
			// This comment block will describe how the code uses TemplateSettings
			// to achieve the desired bar interation experience which is controlled
			// via the ClosedDisplayMode property.
			//
			// Anatomy of the bar component of an AppBar/CommandBar:
			//
			//  !==================================================!
			//  !                  Clip Rectangle                  !
			//  !                                                  !
			//  ! |----------------------------------------------| !
			//  ! |                                              | !
			//  ! |                 Content Root                 | !
			//  ! |                                              | !
			//  !=|==============================================|=!
			//    |::::::::::::::::::::::::::::::::::::::::::::::|
			//    |::::::::::::::::::::::::::::::::::::::::::::::|
			//    |----------------------------------------------|
			//
			// * The region covered in '::' is clipped away.
			//
			// ** The diagram shows the clip rect wider than the content, but
			//    that is just done to make it more readable.  In reality, they
			//    are the same width.
			//
			// When we measure and arrange an AppBar/CommandBar, the size we return
			// as our desired sized (in the case of measure) and the final size
			// (in the case of arrange) depends on the closed display mode.  We
			// measure our sub-tree normally but we modify the returned height to
			// make it match our closed display mode.
			//
			// This causes the control to get arranged such that the top portion
			// of the content root that is within our closed display mode height
			// will be visible, while the rest that is below will get covered up
			// by other content.  It's similar to if we had a negative margin on
			// the bottom.
			//
			// The clip rectangle is then used to make sure this bottom portion does
			// not get rendered; so we are left with just the top portion representing
			// our closed display mode.
			//
			// This is where the template settings start to play a part.  We need
			// to make sure to translate the clip rectangle up by a value that is equal
			// to the difference between the content's height and our closed display
			// mode height.  Since we want to translate up, we have to make that value
			// negative, which results in this equation:
			//
			//      VerticalDelta = ClosedDisplayMode_Height - ContentHeight
			//
			// This value is calculated for each of our supported ClosedDisplayModes
			// and is then used in our template & VSM to create the Closed/OpenUp/OpenDown
			// experiences.
			//
			// We apply it in the following ways to achieve our various states:
			//
			//     Closed:
			//      - Clip Rectangle translated by VerticalDelta (essentially translated up).
			//      - Content Root not translated.
			//
			//     OpenUp:
			//      - Clip Rectangle translated by VerticalDelta (essentially translated up).
			//      - Content Root translated by VerticalDelta (essentially translated up).
			//
			//     OpenDown:
			//      - Clip Rectangle not translated.
			//      - Content Root not translated.
			//

			var templateSettings = TemplateSettings;

			var actualWidth = ActualWidth;

			var contentHeight = m_contentHeight;

			templateSettings.ClipRect = new Rect(0, 0, actualWidth, contentHeight);
		}

		protected void GetTemplatePart<T>(string name, out T element) where T : class
		{
			element = GetTemplateChild(name) as T;
		}


		internal override void OnLayoutUpdated()
		{
			if (m_layoutTransitionElement is { })
			{
				PositionLTEs();
			}
		}
	}
}
