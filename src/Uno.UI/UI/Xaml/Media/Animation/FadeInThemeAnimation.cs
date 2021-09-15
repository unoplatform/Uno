﻿using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Uno.UI;

namespace Windows.UI.Xaml.Media.Animation
{
	public partial class FadeInThemeAnimation : DoubleAnimation, ITimeline
	{
		public FadeInThemeAnimation()
		{
			this.SetValue(
				DurationProperty,
				new Duration(FeatureConfiguration.ThemeAnimation.DefaultThemeAnimationDuration),
				DependencyPropertyValuePrecedences.DefaultValue);

			this.SetValue(
				Storyboard.TargetPropertyProperty,
				"Opacity",
				DependencyPropertyValuePrecedences.DefaultValue);

			this.SetValue(
				ToProperty,
				(double?)1d,
				DependencyPropertyValuePrecedences.DefaultValue);
		}

		public static DependencyProperty TargetNameProperty { get; } = DependencyProperty.Register(
#pragma warning disable Uno0002_Internal // String dependency properties (in *most* cases) shouldn't have null default value.
			"TargetName", typeof(string), typeof(FadeInThemeAnimation), new FrameworkPropertyMetadata(null)); // TODO: What the default value should be? null or string.Empty?
#pragma warning restore Uno0002_Internal // String dependency properties (in *most* cases) shouldn't have null default value.

		public string TargetName
		{
			get => (string)GetValue(TargetNameProperty);
			set => SetValue(TargetNameProperty, value);
		}

		private protected override void InitTarget()
		{
			var target = NameScope.GetNameScope(this)?.FindName(TargetName);
			if (target is DependencyObject depObj)
			{
				Storyboard.SetTarget(this, depObj);
			}
		}
	}
}
