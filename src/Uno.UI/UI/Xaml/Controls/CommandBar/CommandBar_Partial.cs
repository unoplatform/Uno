using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DirectUI;
using Uno.Disposables;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using static Microsoft.UI.Xaml.Controls._Tracing;

namespace Windows.UI.Xaml.Controls
{
	partial class CommandBar
	{
		private enum OverflowInitialFocusItem
		{
			None,
			FirstItem,
			LastItem,
		}

		CommandBarElementCollection m_tpPrimaryCommands;
		CommandBarElementCollection m_tpSecondaryCommands;
		CommandBarElementCollection m_tpDynamicPrimaryCommands;
		CommandBarElementCollection m_tpDynamicSecondaryCommands;
		//ObservableCollection<ICommandBarElement> m_tpWrappedPrimaryCommands;
		//ObservableCollection<ICommandBarElement> m_tpWrappedSecondaryCommands;

		// Primary commands in the transition to move or restore the primary commands
		// to overflow or primary commands
		TrackerCollection<ICommandBarElement> m_tpPrimaryCommandsInTransition;
		TrackerCollection<ICommandBarElement> m_tpPrimaryCommandsInPreviousTransition;


		SerialDisposable m_unloadedEventHandler = new SerialDisposable();
		SerialDisposable m_primaryCommandsChangedEventHandler = new SerialDisposable();
		SerialDisposable m_secondaryCommandsChangedEventHandler = new SerialDisposable();
		SerialDisposable m_secondaryItemsControlLoadedEventHandler = new SerialDisposable();
		SerialDisposable m_contentRootSizeChangedEventHandler = new SerialDisposable();
		SerialDisposable m_overflowContentSizeChangedEventHandler = new SerialDisposable();
		SerialDisposable m_overflowPresenterItemsPresenterKeyDownEventHandler = new SerialDisposable();

		SerialDisposable m_accessKeyInvokedEventHandler = new SerialDisposable();
		SerialDisposable m_overflowPopupOpenedEventHandler = new SerialDisposable();

		// Template parts.
		FrameworkElement m_tpContentControl;
		FrameworkElement m_tpOverflowContentRoot;
		Popup m_tpOverflowPopup;
		ItemsPresenter m_tpOverflowPresenterItemsPresenter;
		FrameworkElement m_tpWindowedPopupPadding;

		double m_overflowContentMinWidth = 0;
		double m_overflowContentTouchMinWidth = 0;
		double m_overflowContentMaxWidth = 480;

		// Restorable primary command minimum width from overflow to the primary command collection
		double m_restorablePrimaryCommandMinWidth = 0;

		bool m_skipProcessTabStopOverride = false;
		// DirectUI::InputDeviceType m_inputDeviceTypeUsedToOpen = DirectUI::InputDeviceType::Touch;


		bool m_hasAlreadyFiredOverflowChangingEvent = false;
		bool m_hasAppBarSeparatorInOverflow = false;
		bool m_isDynamicOverflowEnabled = true;
		int m_SecondaryCommandStartIndex = 0;

		OverflowInitialFocusItem m_overflowInitialFocusItem = OverflowInitialFocusItem.None;

		AppBarSeparator m_tpAppBarSeparatorInOverflow;

		// Whenever there is a change in the primary/secondary commands or a size change, we take note
		// of the focused command and we make sure we restore focus during the next layout pass.
		ICommandBarElement m_focusedElementPriorToCollectionOrSizeChange;
		FocusState m_focusStatePriorToCollectionOrSizeChange;

		double m_lastAvailableWidth = 0;

		public CommandBar()
		{
			PrepareState();
			DefaultStyleKey = typeof(CommandBar);
		}

		~CommandBar()
		{
			if (m_tpPrimaryCommands is { })
			{
				m_primaryCommandsChangedEventHandler.Disposable = null;
			}

			if (m_tpSecondaryCommands is { })
			{
				m_secondaryCommandsChangedEventHandler.Disposable = null;
			}

			if (m_tpSecondaryItemsControlPart is { })
			{
				m_secondaryItemsControlLoadedEventHandler.Disposable = null;
			}
		}

		protected override void PrepareState()
		{
			base.PrepareState();

			CommandBarElementCollection spCollection_Primary;

			spCollection_Primary = new CommandBarElementCollection();
			spCollection_Primary.Init(this, notifyCollectionChanging: false);
			m_tpPrimaryCommands = spCollection_Primary;

			CommandBarElementCollection spCollection_Secondary;

			spCollection_Secondary = new CommandBarElementCollection();
			spCollection_Secondary.Init(this, notifyCollectionChanging: false);
			m_tpSecondaryCommands = spCollection_Secondary;

			// Set the value for our collection properties so that they are in the
			// effective value map and get processed during EnterImpl.
			PrimaryCommands = m_tpPrimaryCommands;
			SecondaryCommands = m_tpSecondaryCommands;

			Unloaded += OnUnloaded;

			m_tpPrimaryCommands.VectorChanged += OnPrimaryCommandsChanged;
			m_primaryCommandsChangedEventHandler.Disposable = Disposable.Create(() => m_tpPrimaryCommands.VectorChanged -= OnPrimaryCommandsChanged);

			m_tpSecondaryCommands.VectorChanged += OnSecondaryCommandsChanged;
			m_secondaryCommandsChangedEventHandler.Disposable = Disposable.Create(() => m_tpSecondaryCommands.VectorChanged -= OnSecondaryCommandsChanged);

			m_tpDynamicPrimaryCommands = new CommandBarElementCollection();
			m_tpDynamicPrimaryCommands.Init(this, notifyCollectionChanging: false);

			m_tpDynamicSecondaryCommands = new CommandBarElementCollection();
			m_tpDynamicSecondaryCommands.Init(this, notifyCollectionChanging: false);

			m_tpPrimaryCommandsInPreviousTransition = new TrackerCollection<ICommandBarElement>();
			m_tpPrimaryCommandsInTransition = new TrackerCollection<ICommandBarElement>();

			m_tpAppBarSeparatorInOverflow = new AppBarSeparator();

		}

		private void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
		{
			if (args.Property == CommandBarDefaultLabelPositionProperty)
			{
				PropagateDefaultLabelPosition();
				UpdateVisualState();
			}
			else if (args.Property == IsDynamicOverflowEnabledProperty)
			{
				if (m_isDynamicOverflowEnabled != (bool)args.NewValue)
				{
					m_isDynamicOverflowEnabled = (bool)args.NewValue;

					ResetDynamicCommands();
					InvalidateMeasure();
					UpdateVisualState();
				}
			}
			else if (args.Property == ClosedDisplayModeProperty
				|| args.Property == CommandBarOverflowButtonVisibilityProperty)
			{
				UpdateTemplateSettings();
			}
			else if (args.Property == VisibilityProperty)
			{
				ResetCommandBarElementFocus();
			}
		}

		protected override void OnApplyTemplate()
		{
			if (m_tpSecondaryItemsControlPart is { })
			{
				m_secondaryItemsControlLoadedEventHandler.Disposable = null;
			}

			if (m_tpOverflowContentRoot is { })
			{
				m_overflowContentSizeChangedEventHandler.Disposable = null;
			}

			if (m_tpOverflowPresenterItemsPresenter is { })
			{
				m_overflowPresenterItemsPresenterKeyDownEventHandler.Disposable = null;
			}

			// Clear our previous template parts.
			m_tpContentControl = null;
			m_tpOverflowContentRoot = null;
			m_tpOverflowPopup = null;
			m_tpOverflowPresenterItemsPresenter = null;
			m_tpWindowedPopupPadding = null;

			base.OnApplyTemplate();

			if (m_tpSecondaryItemsControlPart is { })
			{
				m_tpSecondaryItemsControlPart.Loaded += OnSecondaryItemsControlLoaded;
				m_secondaryItemsControlLoadedEventHandler.Disposable = Disposable.Create(() => m_tpSecondaryItemsControlPart.Loaded -= OnSecondaryItemsControlLoaded);
			}

			// Apply a shadow
			//IFC_RETURN(ApplyElevationEffect(m_tpSecondaryItemsControlPart.AsOrNull<IUIElement>().Get()));

			GetTemplatePart<FrameworkElement>("ContentControl", out var contentControl);
			GetTemplatePart<FrameworkElement>("OverflowContentRoot", out var overflowContentRoot);
			GetTemplatePart<Popup>("OverflowPopup", out var overflowPopup);
			GetTemplatePart<FrameworkElement>("WindowedPopupPadding", out var windowedPopupPadding);

			m_tpContentControl = contentControl;

			m_tpOverflowContentRoot = overflowContentRoot;
			if (m_tpOverflowContentRoot is { })
			{
				m_tpOverflowContentRoot.SizeChanged += OnOverflowContentRootSizeChanged;
				m_overflowContentSizeChangedEventHandler.Disposable = Disposable.Create(() => m_tpOverflowContentRoot.SizeChanged -= OnOverflowContentRootSizeChanged);
			}

			m_tpOverflowPopup = overflowPopup;
			if (m_tpOverflowPopup is { })
			{
				m_tpOverflowPopup.IsSubMenu = true;
			}

			m_tpWindowedPopupPadding = windowedPopupPadding;

			// Query overflow menu min/max width from resource dictionary.
			var resources = Resources;

			if (resources.TryGetValue("CommandBarOverflowMinWidth", out var oOverflowContentMinWidth)
				&& oOverflowContentMinWidth is double overflowContentMinWidth)
			{
				m_overflowContentMinWidth = overflowContentMinWidth;
			}

			if (resources.TryGetValue("CommandBarOverflowTouchMinWidth", out var oOverflowContentTouchMinWidth)
				&& oOverflowContentTouchMinWidth is double overflowContentTouchMinWidth)
			{
				m_overflowContentTouchMinWidth = overflowContentTouchMinWidth;
			}

			if (resources.TryGetValue("CommandBarOverflowMaxWidth", out var oOverflowContentMaxWidth)
				&& oOverflowContentMaxWidth is double overflowContentMaxWidth)
			{
				m_overflowContentMaxWidth = overflowContentMaxWidth;
			}

			// We set CommandBarTemplateSettings.OverflowContentMaxWidth immediately, rather than waiting for the CommandBar to open before setting it.
			// If we don't initialize it here, it will default to 0, meaning the overflow will stay at size 0,0 and will never fire the SizeChanged event.
			// The SizeChanged event is what triggers the call to UpdateTemplateSettings after the CommandBar opens.
			if (CommandBarTemplateSettings is { } templateSettings)
			{
				templateSettings.OverflowContentMaxWidth = m_overflowContentMaxWidth;
			}

			ConfigureItemsControls();

			var isOpen = IsOpen;

			// Put the primary commands into compact mode if not open.
			if (!isOpen)
			{
				SetCompactMode(true);
			}

			// Inform the secondary AppBarButtons whether or not any secondary AppBarToggleButtons exist.
			SetOverflowStyleParams();

			PropagateDefaultLabelPosition();

			var secondaryItemCount = m_tpDynamicSecondaryCommands.Count;
			for (int i = 0; i < secondaryItemCount; ++i)
			{
				SetOverflowStyleAndInputModeOnSecondaryCommand(i, true);
			}

			//Enabling Keytips and AccessKeys in CommandBar secondary commands
			if (m_tpExpandButton is { } && m_tpSecondaryItemsControlPart is { })
			{
				var isAKScope = m_tpExpandButton.IsAccessKeyScope;

				if (isAKScope)
				{
					m_tpSecondaryItemsControlPart.AccessKeyScopeOwner = m_tpExpandButton;

					AccessKeyInvoked += OnAccessKeyInvoked;
					m_accessKeyInvokedEventHandler.Disposable = Disposable.Create(() => AccessKeyInvoked -= OnAccessKeyInvoked);
				}
			}

			UpdateVisualState();
		}

		private void OnAccessKeyInvoked(UIElement sender, AccessKeyInvokedEventArgs args)
		{
			throw new NotImplementedException();
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			if (m_isDynamicOverflowEnabled)
			{
				return MeasureOverrideForDynamicOverflow(availableSize);
			}
			else
			{
				return base.MeasureOverride(availableSize);
			}
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			var size = base.ArrangeOverride(finalSize);

			// We need to wait until the measure pass is done and the new command containers
			// are generated before we restore focus. Note that the measure pass will measure
			// both the CommandBar and the secondary commands' popup. The latter is why we
			// can't call RestoreCommandBarElementFocus at the end of CommandBar::MeasureOverride.
			RestoreCommandBarElementFocus();

			return size;
		}

		private Size MeasureOverrideForDynamicOverflow(Size availableSize)
		{
			var contentRootDesiredSize = new Size();
			var availablePrimarySize = new Size();

			MUX_ASSERT(m_isDynamicOverflowEnabled);

			var measureSize = base.MeasureOverride(availableSize);

			if (m_tpPrimaryItemsControlPart is { } && m_tpContentRoot is { })
			{

			}
		}

		private void OnOverflowContentRootSizeChanged(object sender, SizeChangedEventArgs args)
		{
			throw new NotImplementedException();
		}

		private void OnPrimaryCommandsChanged(IObservableVector<ICommandBarElement> sender, IVectorChangedEventArgs pArgs)
		{
			ResetDynamicCommands();

			var isOpen = IsOpen;

			var shouldBeCompact = !isOpen;

			var change = pArgs.CollectionChange;
			var changeIndex = pArgs.Index;

			if (change == CollectionChange.ItemInserted ||
				change == CollectionChange.ItemChanged)
			{
				var element = m_tpDynamicPrimaryCommands[(int)changeIndex];
				element.IsCompact = shouldBeCompact;
				PropagateDefaultLabelPositionToElement(element);
			}
			else if (change == CollectionChange.Reset)
			{
				SetCompactMode(shouldBeCompact);

				var itemCount = m_tpDynamicPrimaryCommands.Count;
				for (int i = 0; i < itemCount; ++i)
				{
					var element = m_tpDynamicPrimaryCommands[i];
					PropagateDefaultLabelPositionToElement(element);
				}
			}

			InvalidateMeasure();

			UpdateVisualState();
		}

		// Used to *set* overflow style state on items that are entering
		// the secondary items vector.
		private void OnSecondaryCommandsChanged(IObservableVector<ICommandBarElement> sender, IVectorChangedEventArgs pArgs)
		{
			ResetDynamicCommands();;

			var change = pArgs.CollectionChange;
			var changeIndex = pArgs.Index;

			SetOverflowStyleParams();

			if (change == CollectionChange.ItemInserted ||
				change == CollectionChange.ItemChanged)
			{
				var element = m_tpDynamicSecondaryCommands[(int)changeIndex];
				PropagateDefaultLabelPositionToElement(element);
				SetOverflowStyleAndInputModeOnSecondaryCommand(changeIndex, true));
				PropagateDefaultLabelPositionToElement(element);
			}
			else if (change == CollectionChange.Reset)
			{
				var itemCount = m_tpDynamicSecondaryCommands.Count;

				for (int i = 0; i < itemCount; ++i)
				{
					var element = m_tpDynamicSecondaryCommands[i]
					SetOverflowStyleAndInputModeOnSecondaryCommand(i, true);
					PropagateDefaultLabelPositionToElement(element);
				}
			}

			InvalidateMeasure();
			UpdateVisualState();
			UpdateTemplateSettings();
		}

		private void OnUnloaded(object sender, RoutedEventArgs e)
		{
			// Make sure our popup is closed.
			if (m_tpOverflowPopup is { })
			{
				m_tpOverflowPopup.IsOpen = false;
			}

			var isOpen = IsOpen;
			if (!isOpen)
			{
				SetCompactMode(true);
			}
		}

		private void SetCompactMode(bool isCompact)
		{
			if (m_tpDynamicPrimaryCommands is { }
				|| m_tpDynamicSecondaryCommands is { })
			{
				return;
			}

			var primaryItemsCount = m_tpDynamicPrimaryCommands.Count;

			for (int i = 0; i < primaryItemsCount; ++i)
			{
				var element = m_tpDynamicPrimaryCommands[i];
				element.IsCompact = isCompact;
			}
		}

		internal void NotifyElementVectorChanging(CommandBarElementCollection pElementCollection, CollectionChange change, int changeIndex)
		{

		}
	}
}
