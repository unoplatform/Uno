﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.Xaml;
using Uno.UI.Xaml.Input;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media;

#if XAMARIN_IOS
using View = UIKit.UIView;
#elif XAMARIN_ANDROID
using View = Android.Views.View;
#else
using View = Windows.UI.Xaml.UIElement;
#endif

namespace Windows.UI.Xaml.Controls.Primitives
{
	public partial class FlyoutBase : DependencyObject
	{
		public event EventHandler<object> Opened;
		public event EventHandler<object> Closed;
		public event EventHandler<object> Opening;
		public event TypedEventHandler<FlyoutBase, FlyoutBaseClosingEventArgs> Closing;

		internal bool m_isPositionedAtPoint;

		protected internal Popup _popup;
		private bool _isLightDismissEnabled = true;
		private readonly SerialDisposable _sizeChangedDisposable = new SerialDisposable();

		private bool m_hasPlacementOverride;
		private FlyoutPlacementMode m_placementOverride;

		private bool m_isTargetPositionSet;
		private Point m_targetPoint;

		internal bool IsTargetPositionSet => m_isTargetPositionSet;

		private bool m_isPositionedForDateTimePicker;

		[NotImplemented]
		private InputDeviceType m_inputDeviceTypeUsedToOpen;

		internal FlyoutPlacementMode EffectivePlacement => m_hasPlacementOverride ? m_placementOverride : Placement;

		protected FlyoutBase()
		{
		}

		private void EnsurePopupCreated()
		{
			if (_popup == null)
			{
				ResourceResolver.ApplyResource(this, LightDismissOverlayBackgroundProperty, "FlyoutLightDismissOverlayBackground", isThemeResourceExtension: true, isHotReloadSupported: true);

				var child = CreatePresenter();
				_popup = new Popup()
				{
					Child = child,
					IsLightDismissEnabled = _isLightDismissEnabled,
					AssociatedFlyout = this,
				};

				SynchronizePropertyToPopup(Popup.TemplatedParentProperty, TemplatedParent);

				_popup.Opened += OnPopupOpened;
				_popup.Closed += OnPopupClosed;

				_popup.BindToEquivalentProperty(this, nameof(LightDismissOverlayMode));
				_popup.BindToEquivalentProperty(this, nameof(LightDismissOverlayBackground));

				InitializePopupPanel();

				SynchronizePropertyToPopup(Popup.DataContextProperty, DataContext);
				SynchronizePropertyToPopup(Popup.AllowFocusOnInteractionProperty, AllowFocusOnInteraction);
				SynchronizePropertyToPopup(Popup.AllowFocusWhenDisabledProperty, AllowFocusWhenDisabled);
			}
		}

		/// <summary>
		/// Controls the appeareance of <see cref="MenuFlyout"/>, when true the native popups and appearance
		/// is used, otherwise the UWP appeareance is used. The default value is provided by <see cref="FeatureConfiguration.Style.UseUWPDefaultStyles"/>.
		/// </summary>
		public bool UseNativePopup { get; set; } = !FeatureConfiguration.Style.UseUWPDefaultStyles;

		protected virtual void InitializePopupPanel()
		{
			InitializePopupPanelPartial();
		}

		private protected bool IsLightDismissOverlayEnabled
		{
			get => _isLightDismissEnabled;
			set
			{
				_isLightDismissEnabled = value;

				if (_popup != null)
				{
					_popup.IsLightDismissEnabled = value;
				}
			}
		}

		partial void InitializePopupPanelPartial();

		private void OnPopupOpened(object sender, object e)
		{
			if (_popup.Child is FrameworkElement child)
			{
				SizeChangedEventHandler handler = (_, __) => SetPopupPositionPartial(Target, PopupPositionInTarget);

				child.SizeChanged += handler;

				_sizeChangedDisposable.Disposable = Disposable
					.Create(() => child.SizeChanged -= handler);
			}
		}

		public bool IsOpen
		{
			get => (bool)GetValue(IsOpenProperty);
			private set => SetValue(IsOpenProperty, value);
		}
		public static DependencyProperty IsOpenProperty { get; } =
			DependencyProperty.Register(
				nameof(IsOpen), typeof(bool),
				typeof(FlyoutBase),
				new FrameworkPropertyMetadata(default(bool)));

		#region Placement

		/// <summary>
		/// Preferred placement of the flyout.
		/// </summary>
		/// <remarks>
		/// If there's not enough place, the following logic will be used:
		/// https://docs.microsoft.com/en-us/previous-versions/windows/apps/dn308515(v=win.10)#placing-a-flyout
		/// </remarks>
		public FlyoutPlacementMode Placement
		{
			get { return (FlyoutPlacementMode)GetValue(PlacementProperty); }
			set { SetValue(PlacementProperty, value); }
		}

		public static DependencyProperty PlacementProperty { get; } =
			DependencyProperty.Register(
				"Placement",
				typeof(FlyoutPlacementMode),
				typeof(FlyoutBase),
				new FrameworkPropertyMetadata(default(FlyoutPlacementMode))
			);

		#endregion

		public LightDismissOverlayMode LightDismissOverlayMode
		{
			get
			{
				return (LightDismissOverlayMode)this.GetValue(LightDismissOverlayModeProperty);
			}
			set
			{
				this.SetValue(LightDismissOverlayModeProperty, value);
			}
		}

		public static DependencyProperty LightDismissOverlayModeProperty { get; } =
		Windows.UI.Xaml.DependencyProperty.Register(
			"LightDismissOverlayMode", typeof(LightDismissOverlayMode),
			typeof(FlyoutBase),
			new FrameworkPropertyMetadata(default(LightDismissOverlayMode)));


		/// <summary>
		/// Sets the light-dismiss colour, if the overlay is enabled. The external API for modifying this is to override the PopupLightDismissOverlayBackground, etc, static resource values.
		/// </summary>
		internal Brush LightDismissOverlayBackground
		{
			get { return (Brush)GetValue(LightDismissOverlayBackgroundProperty); }
			set { SetValue(LightDismissOverlayBackgroundProperty, value); }
		}

		internal static DependencyProperty LightDismissOverlayBackgroundProperty { get; } =
			DependencyProperty.Register("LightDismissOverlayBackground", typeof(Brush), typeof(FlyoutBase), new FrameworkPropertyMetadata(null));

		/// <summary>
		/// Gets or sets whether a disabled control can receive focus.
		/// </summary>
		public bool AllowFocusWhenDisabled
		{
			get => GetAllowFocusWhenDisabledValue();
			set => SetAllowFocusWhenDisabledValue(value);
		}

		/// <summary>
		/// Identifies the AllowFocusWhenDisabled  dependency property.
		/// </summary>
		[GeneratedDependencyProperty(DefaultValue = false, Options = FrameworkPropertyMetadataOptions.Inherits, ChangedCallback = true)]
		public static DependencyProperty AllowFocusWhenDisabledProperty { get; } = CreateAllowFocusWhenDisabledProperty();

		private void OnAllowFocusWhenDisabledChanged(bool oldValue, bool newValue) =>
			SynchronizePropertyToPopup(Popup.AllowFocusWhenDisabledProperty, AllowFocusWhenDisabled);

		/// <summary>
		/// Gets or sets a value that indicates whether the element automatically gets focus when the user interacts with it.
		/// </summary>
		public bool AllowFocusOnInteraction
		{
			get => GetAllowFocusOnInteractionValue();
			set => SetAllowFocusOnInteractionValue(value);
		}

		/// <summary>
		/// Identifies for the AllowFocusOnInteraction dependency property.
		/// </summary>
		[GeneratedDependencyProperty(DefaultValue = true, Options = FrameworkPropertyMetadataOptions.Inherits, ChangedCallback = true)]
		public static DependencyProperty AllowFocusOnInteractionProperty { get; } = CreateAllowFocusOnInteractionProperty();

		private void OnAllowFocusOnInteractionChanged(bool oldValue, bool newValue) =>
			SynchronizePropertyToPopup(Popup.AllowFocusOnInteractionProperty, AllowFocusOnInteraction);

		public FrameworkElement Target { get; private set; }

		/// <summary>
		/// Defines an optional position of the popup in the <see cref="Target"/> element.
		/// </summary>
		internal Point? PopupPositionInTarget => m_isPositionedAtPoint ? m_targetPoint : default(Point?);

		public void Hide()
		{
			Hide(canCancel: true);
		}

		internal void Hide(bool canCancel)
		{
			if (!IsOpen)
			{
				return;
			}

			if (canCancel)
			{
				bool cancel = false;
				OnClosing(ref cancel);
				if (cancel)
				{
					return;
				}
			}

			Close();
			IsOpen = false;
			OnClosed();
			Closed?.Invoke(this, EventArgs.Empty);
		}

		public void ShowAt(FrameworkElement placementTarget)
		{
			ShowAtCore(placementTarget, null);
		}

		public void ShowAt(DependencyObject placementTarget, FlyoutShowOptions showOptions)
		{
			if (placementTarget is FrameworkElement fe)
			{
				ShowAtCore(fe, showOptions);
			}
		}

		private protected virtual void ShowAtCore(FrameworkElement placementTarget, FlyoutShowOptions showOptions)
		{
			EnsurePopupCreated();

			m_hasPlacementOverride = false;

			if (IsOpen)
			{
				if (placementTarget == Target)
				{
					return;
				}
				else
				{
					// Close at previous placement target before opening at new one (without raising Closing)
					Hide(canCancel: false);
				}
			}

			Target = placementTarget;

			if (showOptions != null)
			{
				if (showOptions.Position is { } positionValue)
				{
					m_isPositionedAtPoint = true;

					if (placementTarget != null)
					{
						// Uno TODO: Calling TransformToVisual(null) on an element within the main visual tree will include the status bar height, which we don't
						// want because the status bar is otherwise excluded from layout calculations. We get the transform relative to the managed root view instead.
						UIElement reference =
#if __ANDROID__
							Window.Current.Content;
#else
							null;
#endif

						var transformToRoot = placementTarget.TransformToVisual(reference);
						positionValue = transformToRoot.TransformPoint(positionValue);
					}

					if (double.IsNaN(positionValue.X) || double.IsNaN(positionValue.Y))
					{
						throw new ArgumentException("Invalid flyout position");
					}

					// UNO TODO: clamp position within contentRect

					SetTargetPosition(positionValue);
				}

				if (showOptions.Placement != FlyoutPlacementMode.Auto)
				{
					m_hasPlacementOverride = true;
					m_placementOverride = showOptions.Placement;
				}
			}

			OnOpening();
			Opening?.Invoke(this, EventArgs.Empty);
			Open();
			IsOpen = true;

			// **************************************************************************************
			// UNO-FIX: Defer the raising of the Opened event to ensure everything is well
			// initialized before opening it.
			// **************************************************************************************
			Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
			// **************************************************************************************
			{
				if (IsOpen)
				{
					OnOpened();
					Opened?.Invoke(this, EventArgs.Empty);
				}
			});
		}

		private void SetTargetPosition(Point targetPoint)
		{
			m_isTargetPositionSet = true;
			m_targetPoint = targetPoint;
		}

		private void ApplyTargetPosition()
		{
			if (m_isTargetPositionSet && _popup != null)
			{
				_popup.HorizontalOffset = m_targetPoint.X;
				_popup.VerticalOffset = m_targetPoint.Y;
			}
		}

		private protected virtual void OnOpening() { }

		internal virtual void OnClosing(ref bool cancel)
		{

			var closing = new FlyoutBaseClosingEventArgs();
			Closing?.Invoke(this, closing);
			cancel = closing.Cancel;
		}

		private protected virtual void OnClosed()
		{

			m_isTargetPositionSet = false;
		}

		private protected virtual void OnOpened() { }

		protected virtual Control CreatePresenter() => null;

		private void OnPopupClosed(object sender, object e)
		{
			Hide(canCancel: false);
			_sizeChangedDisposable.Disposable = null;
		}

		protected internal virtual void Close()
		{
			if (_popup != null)
			{
				_popup.IsOpen = false;
			}
		}

		protected internal virtual void Open()
		{
			EnsurePopupCreated();

			SetPopupPositionPartial(Target, PopupPositionInTarget);
			ApplyTargetPosition();

			_popup.IsOpen = true;
		}

		partial void SetPopupPositionPartial(UIElement placementTarget, Point? positionInTarget);

		partial void OnDataContextChangedPartial(DependencyPropertyChangedEventArgs e) =>
			SynchronizePropertyToPopup(Popup.DataContextProperty, DataContext);

		private void SynchronizePropertyToPopup(DependencyProperty property, object value)
		{
			// This is present to force properties to be propagated to the popup of the flyout
			// since it is not directly a child in the visual tree of the flyout.
			_popup?.SetValue(property, value, precedence: DependencyPropertyValuePrecedences.Local);
		}

		partial void OnTemplatedParentChangedPartial(DependencyPropertyChangedEventArgs e) =>
			SynchronizePropertyToPopup(Popup.TemplatedParentProperty, TemplatedParent);

		public static FlyoutBase GetAttachedFlyout(FrameworkElement element)
		{
			return (FlyoutBase)element.GetValue(AttachedFlyoutProperty);
		}

		public static void SetAttachedFlyout(FrameworkElement element, FlyoutBase value)
		{
			element.SetValue(AttachedFlyoutProperty, value);
		}

		public static void ShowAttachedFlyout(FrameworkElement flyoutOwner)
		{
			var flyout = GetAttachedFlyout(flyoutOwner);
			flyout?.ShowAt(flyoutOwner);
		}

		internal static Rect CalculateAvailableWindowRect(bool isMenuFlyout, Popup popup, object placementTarget, bool hasTargetPosition, Point positionPoint, bool isFull)
		{
			// UNO TODO: UWP also uses values coming from the input pane and app bars, if any.
			// Make sure of migrate to XamlRoot: https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.xamlroot
			return ApplicationView.GetForCurrentView().VisibleBounds;
		}

		internal void SetPresenterStyle(
			Control pPresenter,
			Style pStyle)
		{
			Debug.Assert(pPresenter != null);

			if (pStyle != null)
			{
				pPresenter.Style = pStyle;
			}
			else
			{
				pPresenter.ClearValue(Control.StyleProperty);
			}
		}

		internal Control GetPresenter() => _popup?.Child as Control;

		internal Rect UpdateTargetPosition(Rect availableWindowRect, Size presenterSize, Rect presenterRect)
		{
			double horizontalOffset = 0.0;
			double verticalOffset = 0.0;
			double maxWidth = double.NaN;
			double maxHeight = double.NaN;
			FrameworkElement spPopupAsFE;
			FlowDirection flowDirection = FlowDirection.LeftToRight;
			//FlowDirection targetFlowDirection = FlowDirection.LeftToRight;
			bool isMenuFlyout = this is MenuFlyout;
			bool preferTopPlacement = false;

			Debug.Assert(_popup != null);
			Debug.Assert(m_isTargetPositionSet);

			horizontalOffset = m_targetPoint.X;
			verticalOffset = m_targetPoint.Y;

			FlyoutPlacementMode placementMode = EffectivePlacement;

			// We want to preserve existing MenuFlyout behavior - it will continue to ignore the Placement property.
			// We also don't want to adjust anything if we've been positioned for a DatePicker or TimePicker -
			// in those cases, we've already been put at exactly the position we want to be at.
			if (!isMenuFlyout && !m_isPositionedForDateTimePicker)
			{
				switch (placementMode)
				{
					case FlyoutPlacementMode.Top:
						horizontalOffset -= presenterSize.Width / 2;
						verticalOffset -= presenterSize.Height;
						break;
					case FlyoutPlacementMode.Bottom:
						horizontalOffset -= presenterSize.Width / 2;
						break;
					case FlyoutPlacementMode.Left:
						horizontalOffset -= presenterSize.Width;
						verticalOffset -= presenterSize.Height / 2;
						break;
					case FlyoutPlacementMode.Right:
						verticalOffset -= presenterSize.Height / 2;
						break;
					case FlyoutPlacementMode.TopEdgeAlignedLeft:
					case FlyoutPlacementMode.RightEdgeAlignedBottom:
						verticalOffset -= presenterSize.Height;
						break;
					case FlyoutPlacementMode.TopEdgeAlignedRight:
					case FlyoutPlacementMode.LeftEdgeAlignedBottom:
						horizontalOffset -= presenterSize.Width;
						verticalOffset -= presenterSize.Height;
						break;
					case FlyoutPlacementMode.BottomEdgeAlignedLeft:
					case FlyoutPlacementMode.RightEdgeAlignedTop:
						// Nothing changes in this case - we want the point to be the top-left corner of the flyout,
						// which it already is.
						break;
					case FlyoutPlacementMode.BottomEdgeAlignedRight:
					case FlyoutPlacementMode.LeftEdgeAlignedTop:
						horizontalOffset -= presenterSize.Width;
						break;
				}
			}

			preferTopPlacement = (m_inputDeviceTypeUsedToOpen == InputDeviceType.Touch) && isMenuFlyout;
			//bool useHandednessPlacement = (m_inputDeviceTypeUsedToOpen == DirectUI.InputDeviceType.Pen) && isMenuFlyout;
			//var useHandednessPlacement = false; // Uno TODO

			if (preferTopPlacement)
			{
				verticalOffset -= presenterSize.Height;
			}

			// Uno TODO: support ExclusionRect
			//// If the desired placement of the flyout is inside the exclusion area, we'll shift it in the direction of the placement direction
			//// so that it no longer is inside that area.
			//if (!RectUtil.AreDisjoint(m_exclusionRect, { (float)(horizontalOffset), (float)(verticalOffset), presenterSize.Width, presenterSize.Height }))
			//{
			//	FlyoutBase.MajorPlacementMode majorPlacementMode = preferTopPlacement
			//		? FlyoutBase.MajorPlacementMode.Top
			//		: GetMajorPlacementFromPlacement(placementMode);

			//	switch (majorPlacementMode)
			//	{
			//		case FlyoutBase.MajorPlacementMode.Top:
			//			verticalOffset = m_exclusionRect.Y - presenterSize.Height;
			//			break;
			//		case FlyoutBase.MajorPlacementMode.Bottom:
			//			verticalOffset = m_exclusionRect.Y + m_exclusionRect.Height;
			//			break;
			//		case FlyoutBase.MajorPlacementMode.Left:
			//			horizontalOffset = m_exclusionRect.X - presenterSize.Width;
			//			break;
			//		case FlyoutBase.MajorPlacementMode.Right:
			//			horizontalOffset = m_exclusionRect.X + m_exclusionRect.Width;
			//			break;
			//	}
			//}

			spPopupAsFE = _popup;
			//flowDirection = (spPopupAsFE.FlowDirection);
			//if (m_isPositionedAtPoint)
			//{
			//	targetFlowDirection = (m_tpPlacementTarget.FlowDirection);
			//	Debug.Assert(flowDirection == targetFlowDirection);
			//}

			//bool isRTL = (flowDirection == xaml.FlowDirection_RightToLeft);
			//bool shiftLeftForRightHandedness = useHandednessPlacement && (IsRightHandedHandedness() != isRTL);
			//if (shiftLeftForRightHandedness)
			//{
			//	if (!isRTL)
			//	{
			//		horizontalOffset -= presenterSize.Width;
			//	}
			//	else
			//	{
			//		horizontalOffset += presenterSize.Width;
			//	}
			//}

			// Get the current presenter max width/height
			maxWidth = (GetPresenter() as Control).MaxWidth;
			maxHeight = (GetPresenter() as Control).MaxHeight;

			// Uno TODO: windowed popup mode
			//// Set the target position to the out of Xaml window if it is a windowed Popup.
			//// Set the target position to the inner Xaml window position if it isn't.
			//if (IsWindowedPopup())
			//{
			//	wf.Point targetPoint = { (FLOAT)(horizontalOffset), (FLOAT)(verticalOffset) };
			//	wf.Rect availableMonitorRect = default;

			//	// Calculate the available monitor bounds to set the target position within the monitor bounds
			//	(DXamlCore.GetCurrent().CalculateAvailableMonitorRect(m_tpPopup as Popup, targetPoint, &availableMonitorRect));

			//	// Set the max width and height with the available monitor bounds
			//	(m_tpPresenter as Control.put_MaxWidth(
			//		double.IsNaN(maxWidth) ? availableMonitorRect.Width : Math.Min(maxWidth, availableMonitorRect.Width)));
			//	(m_tpPresenter as Control.put_MaxHeight(
			//		double.IsNaN(maxHeight) ? availableMonitorRect.Height : Math.Min(maxHeight, availableMonitorRect.Height)));

			//	// Adjust the target position if the current target is out of the monitor bounds
			//	if (flowDirection == FlowDirection.LeftToRight)
			//	{
			//		if (targetPoint.X + presenterSize.Width > (availableMonitorRect.X + availableMonitorRect.Width))
			//		{
			//			// Update the target horizontal position if the target is out of the available monitor.
			//			// If the presenter width is greater than the current target left point from the screen,
			//			// the menu target left position is set to the begin of the screen position.
			//			horizontalOffset -= Math.Min(
			//				presenterSize.Width,
			//				Math.Max(0, targetPoint.X - availableMonitorRect.X));
			//		}
			//	}
			//	else
			//	{
			//		if (targetPoint.X - availableMonitorRect.X < presenterSize.Width)
			//		{
			//			// Update the target horizontal position if the target is outside the available monitor
			//			// if the presenter width is greater than the current target right point from the screen,
			//			// the menu target left position is set to the end of the screen position.
			//			horizontalOffset += Math.Min(
			//				presenterSize.Width,
			//				Math.Max(0, availableMonitorRect.Width - targetPoint.X + availableMonitorRect.X));
			//		}
			//	}

			//	// If we couldn't actually fit to the left, flip back to show right.
			//	if (shiftLeftForRightHandedness)
			//	{
			//		if (!isRTL && targetPoint.X < availableMonitorRect.X)
			//		{
			//			horizontalOffset += presenterSize.Width;
			//			targetPoint.X += presenterSize.Width;
			//		}
			//		else if (isRTL && targetPoint.X + presenterSize.Width >= availableMonitorRect.Width)
			//		{
			//			horizontalOffset -= presenterSize.Width;
			//			targetPoint.X -= presenterSize.Width;
			//		}
			//	}

			//	if (preferTopPlacement && targetPoint.Y < availableMonitorRect.Y)
			//	{
			//		verticalOffset += presenterSize.Height;
			//		targetPoint.Y += presenterSize.Height;

			//		// Nudge down if necessary to avoid the exclusion rect
			//		if (!RectUtil.AreDisjoint(m_exclusionRect, { (float)(horizontalOffset), (float)(verticalOffset), presenterSize.Width, presenterSize.Height }))
   //         {
			//			verticalOffset = m_exclusionRect.Y + m_exclusionRect.Height;
			//		}
			//	}

			//	if (targetPoint.Y + presenterSize.Height > (availableMonitorRect.Y + availableMonitorRect.Height))
			//	{
			//		// Update the target vertical position if the target is out of the available monitor.
			//		// If the presenter height is greater than the current target top point from the screen,
			//		// the menu target top position is set to the begin of the screen position.
			//		if (verticalOffset > 0)
			//		{
			//			verticalOffset = verticalOffset - Math.Min(
			//				presenterSize.Height,
			//				Math.Max(0, targetPoint.Y - availableMonitorRect.Y));
			//		}
			//		else // if it spans two monitors, make it start at the second.
			//		{
			//			verticalOffset = 0;
			//		}
			//	}
			//	(m_tpPopup.HorizontalOffset = horizontalOffset);
			//	(m_tpPopup.VerticalOffset = verticalOffset);
			//}
			//else
			{
				// Uno TODO: currently the Flyout layout calculations are done from the popup panel's ArrangeOverride(), which is too late to be setting MaxWidth/MaxHeight.
				//// Set the max width and height with the available windows bounds
				//(m_tpPresenter as Control.put_MaxWidth(
				//	double.IsNaN(maxWidth) ? availableWindowRect.Width : Math.Min(maxWidth, availableWindowRect.Width)));
				//(m_tpPresenter as Control.put_MaxHeight(
				//	double.IsNaN(maxHeight) ? availableWindowRect.Height : Math.Min(maxHeight, availableWindowRect.Height)));

				if (flowDirection == FlowDirection.LeftToRight)
				{
					// Adjust the target position if the current target is out of the Xaml window bounds
					if (horizontalOffset + presenterSize.Width > availableWindowRect.X + availableWindowRect.Width)
					{
						if (m_isPositionedAtPoint)
						{
							// Update the target horizontal position if the target is out of the available rect
							horizontalOffset -= Math.Min(presenterSize.Width, horizontalOffset);
						}
						else
						{
							// Used for date and time picker flyouts
							horizontalOffset = availableWindowRect.X + availableWindowRect.Width - presenterSize.Width;
							horizontalOffset = Math.Max(availableWindowRect.X, horizontalOffset);
						}
					}
				}
				else
				{
					// Adjust the target position if the current target is out of the Xaml window bounds
					if (horizontalOffset - presenterSize.Width < availableWindowRect.X)
					{
						if (m_isPositionedAtPoint)
						{
							// Update the target horizontal position if the target is out of the available rect
							horizontalOffset += Math.Min(presenterSize.Width, (availableWindowRect.Width + availableWindowRect.X - horizontalOffset));
						}
						else
						{
							// Used for date and time picker flyouts
							horizontalOffset = presenterSize.Width + availableWindowRect.X;
							horizontalOffset = Math.Min(availableWindowRect.Width + availableWindowRect.X, horizontalOffset);
						}
					}
				}

				//// If we couldn't actually fit to the left, flip back to show right.
				//if (shiftLeftForRightHandedness)
				//{
				//	if (!isRTL && horizontalOffset < availableWindowRect.X)
				//	{
				//		horizontalOffset += presenterSize.Width;
				//	}
				//	else if (isRTL && horizontalOffset + presenterSize.Width >= availableWindowRect.Width)
				//	{
				//		horizontalOffset -= presenterSize.Width;
				//	}
				//}

				// If opening up would cause the flyout to get clipped, we fall back to opening down:
				if (preferTopPlacement && verticalOffset < availableWindowRect.Y)
				{
					verticalOffset += presenterSize.Height;

					//// Nudge down if necessary to avoid the exclusion rect
					//if (!RectUtil.AreDisjoint(m_exclusionRect, { (float)(horizontalOffset), (float)(verticalOffset), presenterSize.Width, presenterSize.Height }))
     //       {
					//	verticalOffset = m_exclusionRect.Y + m_exclusionRect.Height;
					//}
				}

				if (verticalOffset + presenterSize.Height > availableWindowRect.Y + availableWindowRect.Height)
				{
					// Update the target vertical position if the target is out of the available rect
					if (m_isPositionedAtPoint)
					{
						verticalOffset -= Math.Min(presenterSize.Height, verticalOffset);
					}
					else
					{
						verticalOffset = availableWindowRect.Y + availableWindowRect.Height - presenterSize.Height;
					}
				}

				verticalOffset = Math.Max(availableWindowRect.Y, verticalOffset);
				// Uno TODO: scrap PlacementPopupPanel and rely on setting Popup.HOffset/VOffset
				//m_tpPopup.HorizontalOffset = horizontalOffset;
				//m_tpPopup.VerticalOffset = verticalOffset;
			}

			double leftMostEdge = (flowDirection == FlowDirection.LeftToRight) ? horizontalOffset : horizontalOffset - presenterSize.Width;

			presenterRect.X = leftMostEdge;
			presenterRect.Y = verticalOffset;
			presenterRect.Width = presenterSize.Width;
			presenterRect.Height = presenterSize.Height;

			return presenterRect;
		}

		internal static PreferredJustification GetJustificationFromPlacementMode(FlyoutPlacementMode placement)
		{
			switch (placement)
			{
				case FlyoutPlacementMode.Full:
				case FlyoutPlacementMode.Top:
				case FlyoutPlacementMode.Bottom:
				case FlyoutPlacementMode.Left:
				case FlyoutPlacementMode.Right:
					return PreferredJustification.Center;
				case FlyoutPlacementMode.TopEdgeAlignedLeft:
				case FlyoutPlacementMode.BottomEdgeAlignedLeft:
					return PreferredJustification.Left;
				case FlyoutPlacementMode.TopEdgeAlignedRight:
				case FlyoutPlacementMode.BottomEdgeAlignedRight:
					return PreferredJustification.Right;
				case FlyoutPlacementMode.LeftEdgeAlignedTop:
				case FlyoutPlacementMode.RightEdgeAlignedTop:
					return PreferredJustification.Top;
				case FlyoutPlacementMode.LeftEdgeAlignedBottom:
				case FlyoutPlacementMode.RightEdgeAlignedBottom:
					return PreferredJustification.Bottom;
				default:
					if (typeof(FlyoutBase).Log().IsEnabled(LogLevel.Error))
					{
						typeof(FlyoutBase).Log().LogError("Unsupported FlyoutPlacementMode");
					}
					return PreferredJustification.Center;
			}
		}

		internal static MajorPlacementMode GetMajorPlacementFromPlacement(FlyoutPlacementMode placement)
		{
			switch (placement)
			{
				case FlyoutPlacementMode.Full:
					return MajorPlacementMode.Full;
				case FlyoutPlacementMode.Top:
				case FlyoutPlacementMode.TopEdgeAlignedLeft:
				case FlyoutPlacementMode.TopEdgeAlignedRight:
					return MajorPlacementMode.Top;
				case FlyoutPlacementMode.Bottom:
				case FlyoutPlacementMode.BottomEdgeAlignedLeft:
				case FlyoutPlacementMode.BottomEdgeAlignedRight:
					return MajorPlacementMode.Bottom;
				case FlyoutPlacementMode.Left:
				case FlyoutPlacementMode.LeftEdgeAlignedTop:
				case FlyoutPlacementMode.LeftEdgeAlignedBottom:
					return MajorPlacementMode.Left;
				case FlyoutPlacementMode.Right:
				case FlyoutPlacementMode.RightEdgeAlignedTop:
				case FlyoutPlacementMode.RightEdgeAlignedBottom:
					return MajorPlacementMode.Right;
				default:
					if (typeof(FlyoutBase).Log().IsEnabled(LogLevel.Error))
					{
						typeof(FlyoutBase).Log().LogError("Unsupported FlyoutPlacementMode");
					}
					return MajorPlacementMode.Full;
			}
		}
	}
}
