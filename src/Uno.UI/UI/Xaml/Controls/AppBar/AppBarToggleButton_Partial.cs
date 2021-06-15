using System;
using System.Collections.Generic;
using System.Text;
using Uno.Disposables;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls
{
	public partial class AppBarToggleButton : ToggleButton, ICommandBarElement, ICommandBarElement2, ICommandBarElement3, ICommandBarOverflowElement, ICommandBarLabeledElement
	{
		// LabelOnRightStyle doesn't work in AppBarButton/AppBarToggleButton Reveal Style.
		// Animate the width to NaN if width is not overrided and right-aligned labels and no LabelOnRightStyle. 
		Storyboard m_widthAdjustmentsForLabelOnRightStyleStoryboard;

		CommandBarDefaultLabelPosition m_defaultLabelPosition;
		// UNO TODO
		//DirectUI::InputDeviceType m_inputDeviceTypeUsedToOpenOverflow;

		TextBlock m_tpKeyboardAcceleratorTextLabel;

		// We won't actually set the label-on-right style unless we've applied the template,
		// because we won't have the label-on-right style from the template until we do.
		bool m_isTemplateApplied;


		// We need to adjust our visual state to account for CommandBarElements that use Icons.
		bool m_isWithIcons;

		// We need to adjust our visual state to account for CommandBarElements that have keyboard accelerator text.
		bool m_isWithKeyboardAcceleratorText = false;
		double m_maxKeyboardAcceleratorTextWidth = 0;

		// If we have a keyboard accelerator attached to us and the app has not set a tool tip on us,
		// then we'll create our own tool tip.  We'll use this flag to indicate that we can unset or
		// overwrite that tool tip as needed if the keyboard accelerator is removed or the button
		// moves into the overflow section of the app bar or command bar.
		bool m_ownsToolTip;

		public AppBarToggleButton()
		{
			//m_inputDeviceTypeUsedToOpenOverflow(DirectUI::InputDeviceType::None)
			m_isTemplateApplied = false;
			m_isWithIcons = false;
			m_ownsToolTip = true;

			RegisterPropertyChangedCallback(CommandProperty, OnCommandChanged);
			DefaultStyleKey = typeof(AppBarToggleButton);
		}

		

		public AppBarToggleButtonTemplateSettings TemplateSettings { get; } = new AppBarToggleButtonTemplateSettings();


		internal void SetOverflowStyleParams(bool hasIcons, bool hasKeyboardAcceleratorText)
		{
			bool updateState = false;

			if (m_isWithIcons != hasIcons)
			{
				m_isWithIcons = hasIcons;
				updateState = true;
			}
			if (m_isWithKeyboardAcceleratorText != hasKeyboardAcceleratorText)
			{
				m_isWithKeyboardAcceleratorText = hasKeyboardAcceleratorText;
				updateState = true;
			}
			if (updateState)
			{
				UpdateVisualState();
			}
		}

		void ICommandBarLabeledElement.SetDefaultLabelPosition(CommandBarDefaultLabelPosition defaultLabelPosition)
		{
			if (m_defaultLabelPosition != defaultLabelPosition)
			{
				m_defaultLabelPosition = defaultLabelPosition;
				UpdateInternalStyles();
				UpdateVisualState();
			}
		}

		bool ICommandBarLabeledElement.GetHasBottomLabel()
		{
			CommandBarDefaultLabelPosition effectiveLabelPosition = GetEffectiveLabelPosition();
			var label = Label;

			return effectiveLabelPosition == CommandBarDefaultLabelPosition.Bottom
				&& label != null;
		}

		internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
		{
			AppBarButtonHelpers.OnPropertyChanged<AppBarToggleButton>(this, args);
		}

		protected override void OnApplyTemplate()
		{
			AppBarButtonHelpers.OnBeforeApplyTemplate<AppBarToggleButton>(this);
			base.OnApplyTemplate();
			AppBarButtonHelpers.OnApplyTemplate<AppBarToggleButton>(this);
		}

		protected override void OnPointerEntered(PointerRoutedEventArgs args)
		{
			base.OnPointerEntered(args);
			AppBarButtonHelpers.CloseSubMenusOnPointerEntered<AppBarToggleButton>(this, null);
		}

		// Sets the visual state to "Compact" or "FullSize" based on the value
		// of our IsCompact property.
		private protected override void ChangeVisualState(bool useTransitions)
		{
			bool useOverflowStyle = false;

			base.ChangeVisualState(useTransitions);
			useOverflowStyle = UseOverflowStyle;

			if (useOverflowStyle)
			{
				if (m_isWithIcons)
				{
					GoToState(useTransitions, "OverflowWithMenuIcons");
				}
				else
				{
					GoToState(useTransitions, "Overflow");
				}

				{
					bool isEnabled = false;
					bool isPressed = false;
					bool isPointerOver = false;
					bool isChecked;

					isEnabled = IsEnabled;
					isPressed = IsPressed;
					isPointerOver = IsPointerOver;
					isChecked = IsChecked ?? false;

					if (isChecked)
					{
						if (isPressed)
						{
							GoToState(useTransitions, "OverflowCheckedPressed");
						}
						else if (isPointerOver)
						{
							GoToState(useTransitions, "OverflowCheckedPointerOver");
						}
						else if (isEnabled)
						{
							GoToState(useTransitions, "OverflowChecked");
						}
					}
					else
					{
						if (isPressed)
						{
							GoToState(useTransitions, "OverflowPressed");
						}
						else if (isPointerOver)
						{
							GoToState(useTransitions, "OverflowPointerOver");
						}
						else if (isEnabled)
						{
							GoToState(useTransitions, "OverflowNormal");
						}
					}
				}
			}

			AppBarButtonHelpers.ChangeCommonVisualStates<AppBarToggleButton>(this, useTransitions);
		}


		// Create AppBarToggleButtonAutomationPeer to represent the AppBarToggleButton.
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new AppBarToggleButtonAutomationPeer(this);
		}

		protected override void OnToggle()
		{
			CommandBar.OnCommandExecutionStatic(this);
			base.OnToggle();
		}

		protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
		{
			base.OnVisibilityChanged(oldValue, newValue);
			CommandBar.OnCommandBarElementVisibilityChanged(this);
		}

		private void OnCommandChanged(DependencyObject sender, DependencyProperty dp)
		{
			AppBarButtonHelpers.OnCommandChanged();
		}

		private CommandBarDefaultLabelPosition GetEffectiveLabelPosition()
		{
			CommandBarLabelPosition labelPosition;
			labelPosition = LabelPosition;

			return labelPosition == CommandBarLabelPosition.Collapsed ? CommandBarDefaultLabelPosition.Collapsed : m_defaultLabelPosition;
		}

		private void UpdateInternalStyles()
		{
			// If the template isn't applied yet, we'll early-out,
			// because we won't have the style to apply from the
			// template yet.
			if (m_isTemplateApplied == null)
			{
				return;
			}

			CommandBarDefaultLabelPosition effectiveLabelPosition;
			bool useOverflowStyle;

			effectiveLabelPosition = GetEffectiveLabelPosition();
			useOverflowStyle = UseOverflowStyle;

			bool shouldHaveLabelOnRightStyleSet = effectiveLabelPosition == CommandBarDefaultLabelPosition.Right && !useOverflowStyle;

			// Apply/UnApply auto width animation if needed
			// only play auto width animation when the width is not overrided by local/animation setting
			// and when LabelOnRightStyle is not set. LabelOnRightStyle take high priority than animation.
			if (shouldHaveLabelOnRightStyleSet
				&& !this.IsDependencyPropertyLocallySet(WidthProperty))
			{
				// Apply our width adjustments using a storyboard so that we don't stomp over template or user
				// provided values.  When we stop the storyboard, it will restore the previous values.
				if (m_widthAdjustmentsForLabelOnRightStyleStoryboard == null)
				{
					var storyboard = CreateStoryboardForWidthAdjustmentsForLabelOnRightStyle();
					m_widthAdjustmentsForLabelOnRightStyleStoryboard = storyboard;
				}

				StartAnimationForWidthAdjustments();
			}
			else if (!shouldHaveLabelOnRightStyleSet && m_widthAdjustmentsForLabelOnRightStyleStoryboard is { })
			{
				StopAnimationForWidthAdjustments();
			}

			AppBarButtonHelpers.UpdateToolTip<AppBarToggleButton>(this);
		}

		private Storyboard CreateStoryboardForWidthAdjustmentsForLabelOnRightStyle()
		{
			var storyboardLocal = new Storyboard();

			var objectAnimation = new ObjectAnimationUsingKeyFrames();

			Storyboard.SetTarget(objectAnimation, this);
			Storyboard.SetTargetProperty(objectAnimation, "Width");

			var discreteObjectKeyFrame = new DiscreteObjectKeyFrame();

			var keyTime = KeyTime.FromTimeSpan(TimeSpan.Zero);

			discreteObjectKeyFrame.KeyTime = keyTime;
			discreteObjectKeyFrame.Value = double.NaN;

			objectAnimation.KeyFrames.Add(discreteObjectKeyFrame);
			storyboardLocal.Children.Add(objectAnimation);

			return storyboardLocal;
		}

		private void StartAnimationForWidthAdjustments()
		{
			if (m_widthAdjustmentsForLabelOnRightStyleStoryboard is { })
			{
				StopAnimationForWidthAdjustments();
				m_widthAdjustmentsForLabelOnRightStyleStoryboard.Begin();
				m_widthAdjustmentsForLabelOnRightStyleStoryboard.SkipToFill();
			}
		}

		private void StopAnimationForWidthAdjustments()
		{
			if (m_widthAdjustmentsForLabelOnRightStyleStoryboard is { })
			{
				ClockState currentState;
				currentState = m_widthAdjustmentsForLabelOnRightStyleStoryboard.GetCurrentState();
				if (currentState == ClockState.Active
					|| currentState == ClockState.Filling)
				{
					m_widthAdjustmentsForLabelOnRightStyleStoryboard.Stop();
				}
			}
		}

	}
}
