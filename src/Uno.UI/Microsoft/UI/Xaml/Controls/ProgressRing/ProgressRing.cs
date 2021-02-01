﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Uno.Extensions;
using Uno.Foundation.Extensibility;
using Uno.Logging;
using Uno.UI;

#nullable enable

namespace Microsoft.UI.Xaml.Controls
{
	public partial class ProgressRing : Control
	{
		private const string ActiveStateName = "Active";
		private const string DeterminateActiveStateName = "DeterminateActive";
		private const string InactiveStateName = "Inactive";
		private const string LottiePlayerName = "LottiePlayer";
		private const string LayoutRootName = "LayoutRoot";
		private readonly ILottieVisualSourceProvider? _lottieProvider;


		private AnimatedVisualPlayer? _player;
		private Panel? _layoutRoot;
		private double _oldValue = 0d;
		private Uri? _currentSourceUri = null;

		public static DependencyProperty IsActiveProperty { get; } = DependencyProperty.Register(
			nameof(IsActive), typeof(bool), typeof(ProgressRing), new FrameworkPropertyMetadata(true, OnIsActivePropertyChanged));

		public bool IsActive
		{
			get => (bool)GetValue(IsActiveProperty);
			set => SetValue(IsActiveProperty, value);
		}

		public static DependencyProperty IsIndeterminateProperty { get; } = DependencyProperty.Register(
			nameof(IsIndeterminate), typeof(bool), typeof(ProgressRing), new FrameworkPropertyMetadata(true, OnIsIndeterminatePropertyChanged));


		public bool IsIndeterminate
		{
			get => (bool)GetValue(IsIndeterminateProperty);
			set => SetValue(IsIndeterminateProperty, value);
		}

		public double Value
		{
			get { return (double)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		public static DependencyProperty ValueProperty { get; } = DependencyProperty.Register(
			nameof(Value), typeof(double), typeof(ProgressRing), new FrameworkPropertyMetadata(0d, (s, e) => (s as ProgressRing)?.OnValuePropertyChanged(e)));

		public double Maximum
		{
			get { return (double)GetValue(MaximumProperty); }
			set { SetValue(MaximumProperty, value); }
		}

		public static DependencyProperty MaximumProperty { get; } = DependencyProperty.Register(
			nameof(Maximum), typeof(double), typeof(ProgressRing), new FrameworkPropertyMetadata(100d, (s, e) => (s as ProgressRing)?.OnMaximumPropertyChanged(e)));

		public double Minimum
		{
			get { return (double)GetValue(MinimumProperty); }
			set { SetValue(MinimumProperty, value); }
		}

		public static DependencyProperty MinimumProperty { get; } = DependencyProperty.Register(
			nameof(Minimum), typeof(double), typeof(ProgressRing), new FrameworkPropertyMetadata(0d, (s, e) => (s as ProgressRing)?.OnMinimumPropertyChanged(e)));

		public ProgressRing()
		{
			DefaultStyleKey = typeof(ProgressRing);

			ApiExtensibility.CreateInstance(this, out _lottieProvider);

			if (_lottieProvider == null)
			{
				this.Log().Error($"{nameof(ProgressRing)} control needs the Uno.UI.Lottie package to run properly.");
			}

			RegisterPropertyChangedCallback(ForegroundProperty, OnForegroundPropertyChanged);
			RegisterPropertyChangedCallback(BackgroundProperty, OnBackgroundPropertyChanged);
		}

		protected override AutomationPeer OnCreateAutomationPeer() => new ProgressRingAutomationPeer(progressRing: this);

		protected override void OnApplyTemplate()
		{
			_player = GetTemplateChild(LottiePlayerName) as Windows.UI.Xaml.Controls.AnimatedVisualPlayer;
			_layoutRoot = GetTemplateChild(LayoutRootName) as Panel;

			SetAnimatedVisualPlayerSource();

			UpdateLottieProgress();
			ChangeVisualState();

			OnForegroundPropertyChanged(this, ForegroundProperty);
			OnBackgroundPropertyChanged(this, BackgroundProperty);
		}

		private static void OnIsIndeterminatePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			(dependencyObject as ProgressRing)?.ChangeVisualState();
		}

		private void OnForegroundPropertyChanged(DependencyObject sender, DependencyProperty dp)
		{
			if (_player?.Source is IThemableAnimatedVisualSource source
				&& Brush.TryGetColorWithOpacity(Foreground, out var foreground))
			{
				source.SetColorThemeProperty("Foreground", foreground);
			}
		}

		private void OnBackgroundPropertyChanged(DependencyObject sender, DependencyProperty dp)
		{
			if (_player?.Source is IThemableAnimatedVisualSource source
				&& Brush.TryGetColorWithOpacity(Background, out var background))
			{
				source.SetColorThemeProperty("Background", background);
			}
		}

		private static void OnIsActivePropertyChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
		{
			(dependencyobject as ProgressRing)?.ChangeVisualState();
		}

		private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			CoerceValue();

			if (!IsIndeterminate)
			{
				UpdateLottieProgress();
			}
		}

		private void OnMaximumPropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			CoerceMinimum();
			CoerceValue();

			if (!IsIndeterminate)
			{
				UpdateLottieProgress();
			}
		}
		private void OnMinimumPropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			CoerceMaximum();
			CoerceValue();

			if (!IsIndeterminate)
			{
				UpdateLottieProgress();
			}
		}

		private void SetAnimatedVisualPlayerSource()
		{
			if (_lottieProvider != null && _player != null)
			{
				var isIndeterminate = IsIndeterminate;
				if (isIndeterminate && _currentSourceUri != FeatureConfiguration.ProgressRing.ProgressRingAsset)
				{
					_currentSourceUri = FeatureConfiguration.ProgressRing.ProgressRingAsset;
					var animatedVisualSource = _lottieProvider.CreateTheamableFromLottieAsset(_currentSourceUri);
					_player.Source = animatedVisualSource;
				}
				else if (!isIndeterminate && _currentSourceUri != FeatureConfiguration.ProgressRing.DeterminateProgressRingAsset)
				{
					_currentSourceUri = FeatureConfiguration.ProgressRing.DeterminateProgressRingAsset;
					var animatedVisualSource = _lottieProvider.CreateTheamableFromLottieAsset(_currentSourceUri);
					_player.Source = animatedVisualSource;
				}
				
			}
			else if (_player != null && _layoutRoot != null)
			{
				// If we have a _player, it means we're having a ControlTemplate relying
				// on it.  In this case, the Uno.UI.Lottie reference is required for the
				// rendering of the ProgressRing.

				var txt = new TextBlock
				{
					Text = "⚠️ Uno.UI.Lottie missing ⚠️",
					Foreground = SolidColorBrushHelper.Red
				};

				_layoutRoot.Children.Add(txt);
			}
		}

		private void ChangeVisualState()
		{
			if (IsActive)
			{
				if (IsIndeterminate)
				{
					// Support for older templates
					VisualStateManager.GoToState(this, ActiveStateName, true);
					SetAnimatedVisualPlayerSource();
					var _ = _player?.PlayAsync(0, 1, true);
				}
				else
				{
					VisualStateManager.GoToState(this, DeterminateActiveStateName, true);
					SetAnimatedVisualPlayerSource();
					UpdateLottieProgress();
				}
			}
			else
			{
				VisualStateManager.GoToState(this, InactiveStateName, true);
				_player?.Stop();
			}
		}

		private void UpdateLottieProgress()
		{
			if (_player == null)
			{
				return;
			}

			var value = Value;
			var min = Minimum;
			var range = Maximum - min;
			var fromProgress = (_oldValue - min) / range;
			var toProgress = (value - min) / range;

			if (fromProgress < toProgress)
			{
				var _ = _player.PlayAsync(fromProgress, toProgress, false);
			}
			else
			{
				_player.SetProgress(toProgress);
			}

			_oldValue = value;
		}

		private void CoerceMinimum()
		{
			var max = Maximum;
			if (Minimum > max)
			{
				Minimum = max;
			}
		}

		private void CoerceMaximum()
		{
			var min = Minimum;
			if (Maximum < min)
			{
				Maximum = min;
			}
		}

		private void CoerceValue()
		{
			var value = Value;
			if (!double.IsNaN(value) && !IsInBounds(value))
			{
				var max = Maximum;
				if (value > max)
				{
					Value = max;
				}
				else
				{
					Value = Minimum;
				}
			}
		}
		private bool IsInBounds(double value)
		{
			return (value >= Minimum && value <= Maximum);
		}
	}
}
