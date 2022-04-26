﻿using System;
using System.Collections.Generic;
using System.Text;
using Uno.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls
{
	public partial class RelativePanel
	{

		#region BackgroundSizing DepedencyProperty
		[GeneratedDependencyProperty(DefaultValue = default(BackgroundSizing), ChangedCallback = true)]
		public static DependencyProperty BackgroundSizingProperty { get; } = CreateBackgroundSizingProperty();

		public BackgroundSizing BackgroundSizing
		{
			get => GetBackgroundSizingValue();
			set => SetBackgroundSizingValue(value);
		}

		private void OnBackgroundSizingChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnBackgroundSizingChangedInnerPanel(e);
		}
		#endregion

		#region BorderBrush DependencyProperty

		public Brush BorderBrush
		{
			get => GetBorderBrushValue();
			set => SetBorderBrushValue(value);
		}

		private static Brush GetBorderBrushDefaultValue() => SolidColorBrushHelper.Transparent;

		[GeneratedDependencyProperty(ChangedCallbackName = nameof(OnBorderBrushPropertyChanged), Options = FrameworkPropertyMetadataOptions.ValueInheritsDataContext)]
		public static DependencyProperty BorderBrushProperty { get; } = CreateBorderBrushProperty();

		private void OnBorderBrushPropertyChanged(Brush oldValue, Brush newValue)
		{
			BorderBrushInternal = newValue;
			OnBorderBrushChanged(oldValue, newValue);
		}

		#endregion

		#region BorderThickness DependencyProperty

		public Thickness BorderThickness
		{
			get => GetBorderThicknessValue();
			set => SetBorderThicknessValue(value);
		}

		private static Thickness GetBorderThicknessDefaultValue() => Thickness.Empty;

		[GeneratedDependencyProperty(ChangedCallbackName = nameof(OnBorderThicknessPropertyChanged))]
		public static DependencyProperty BorderThicknessProperty { get; } = CreateBorderThicknessProperty();

		private void OnBorderThicknessPropertyChanged(Thickness oldValue, Thickness newValue)
		{
			BorderThicknessInternal = newValue;
			OnBorderThicknessChanged(oldValue, newValue);
		}

		#endregion

		#region Padding DependencyProperty

		public Thickness Padding
		{
			get => GetPaddingValue();
			set => SetPaddingValue(value);
		}

		private static Thickness GetPaddingDefaultValue() => Thickness.Empty;

		[GeneratedDependencyProperty(ChangedCallbackName = nameof(OnPaddingPropertyChanged))]
		public static DependencyProperty PaddingProperty { get; } = CreatePaddingProperty();

		private void OnPaddingPropertyChanged(Thickness oldValue, Thickness newValue)
		{
			PaddingInternal = newValue;
			OnPaddingChanged(oldValue, newValue);
		}

		#endregion

		#region CornerRadius DependencyProperty

		public CornerRadius CornerRadius
		{
			get => GetCornerRadiusValue();
			set => SetCornerRadiusValue(value);
		}

		private static CornerRadius GetCornerRadiusDefaultValue() => CornerRadius.None;

		[GeneratedDependencyProperty(ChangedCallbackName = nameof(OnCornerRadiusPropertyChanged))]
		public static DependencyProperty CornerRadiusProperty { get; } = CreateCornerRadiusProperty();

		private void OnCornerRadiusPropertyChanged(CornerRadius oldValue, CornerRadius newValue)
		{
			CornerRadiusInternal = newValue;
			OnCornerRadiusChanged(oldValue, newValue);
		}

		#endregion

		#region Panel Alignment relationships

		public static bool GetAlignBottomWithPanel(UIElement view)
		{
			return (bool)view.GetValue(AlignBottomWithPanelProperty);
		}

		public static void SetAlignBottomWithPanel(UIElement view, bool value)
		{
			view.SetValue(AlignBottomWithPanelProperty, value);
		}

		public static DependencyProperty AlignBottomWithPanelProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignBottomWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: false, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static bool GetAlignLeftWithPanel(UIElement view)
		{
			return (bool)view.GetValue(AlignLeftWithPanelProperty);
		}

		public static void SetAlignLeftWithPanel(UIElement view, bool value)
		{
			view.SetValue(AlignLeftWithPanelProperty, value);
		}

		public static DependencyProperty AlignLeftWithPanelProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignLeftWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: false, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static bool GetAlignRightWithPanel(UIElement view)
		{
			return (bool)view.GetValue(AlignRightWithPanelProperty);
		}

		public static void SetAlignRightWithPanel(UIElement view, bool value)
		{
			view.SetValue(AlignRightWithPanelProperty, value);
		}

		public static DependencyProperty AlignRightWithPanelProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignRightWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: false, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static bool GetAlignTopWithPanel(UIElement view)
		{
			return (bool)view.GetValue(AlignTopWithPanelProperty);
		}

		public static void SetAlignTopWithPanel(UIElement view, bool value)
		{
			view.SetValue(AlignTopWithPanelProperty, value);
		}

		public static DependencyProperty AlignTopWithPanelProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignTopWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: false, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static bool GetAlignHorizontalCenterWithPanel(UIElement view)
		{
			return (bool)view.GetValue(AlignHorizontalCenterWithPanelProperty);
		}

		public static void SetAlignHorizontalCenterWithPanel(UIElement view, bool value)
		{
			view.SetValue(AlignHorizontalCenterWithPanelProperty, value);
		}

		public static DependencyProperty AlignHorizontalCenterWithPanelProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignHorizontalCenterWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: false, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static bool GetAlignVerticalCenterWithPanel(UIElement view)
		{
			return (bool)view.GetValue(AlignVerticalCenterWithPanelProperty);
		}

		public static void SetAlignVerticalCenterWithPanel(UIElement view, bool value)
		{
			view.SetValue(AlignVerticalCenterWithPanelProperty, value);
		}

		public static DependencyProperty AlignVerticalCenterWithPanelProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignVerticalCenterWithPanel", typeof(bool), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: false, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));
		#endregion

		#region Sibling Alignment relationships

		public static object GetAlignBottomWith(UIElement view)
		{
			return (object)view.GetValue(AlignBottomWithProperty);
		}

		public static void SetAlignBottomWith(UIElement view, object value)
		{
			view.SetValue(AlignBottomWithProperty, value);
		}

		public static DependencyProperty AlignBottomWithProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignBottomWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static object GetAlignLeftWith(UIElement view)
		{
			return (object)view.GetValue(AlignLeftWithProperty);
		}

		public static void SetAlignLeftWith(UIElement view, object value)
		{
			view.SetValue(AlignLeftWithProperty, value);
		}

		public static DependencyProperty AlignLeftWithProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignLeftWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static object GetAlignRightWith(UIElement view)
		{
			return (object)view.GetValue(AlignRightWithProperty);
		}

		public static void SetAlignRightWith(UIElement view, object value)
		{
			view.SetValue(AlignRightWithProperty, value);
		}

		public static DependencyProperty AlignRightWithProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignRightWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static object GetAlignTopWith(UIElement view)
		{
			return (object)view.GetValue(AlignTopWithProperty);
		}

		public static void SetAlignTopWith(UIElement view, object value)
		{
			view.SetValue(AlignTopWithProperty, value);
		}

		public static DependencyProperty AlignTopWithProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignTopWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static object GetAlignHorizontalCenterWith(UIElement view)
		{
			return (object)view.GetValue(AlignHorizontalCenterWithProperty);
		}

		public static void SetAlignHorizontalCenterWith(UIElement view, object value)
		{
			view.SetValue(AlignHorizontalCenterWithProperty, value);
		}

		public static DependencyProperty AlignHorizontalCenterWithProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignHorizontalCenterWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static object GetAlignVerticalCenterWith(UIElement view)
		{
			return (object)view.GetValue(AlignVerticalCenterWithProperty);
		}

		public static void SetAlignVerticalCenterWith(UIElement view, object value)
		{
			view.SetValue(AlignVerticalCenterWithProperty, value);
		}

		public static DependencyProperty AlignVerticalCenterWithProperty { get ; } =
			DependencyProperty.RegisterAttached("AlignVerticalCenterWith", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		#endregion

		#region Sibling Positional relationships

		public static object GetAbove(UIElement view)
		{
			return (object)view.GetValue(AboveProperty);
		}

		public static void SetAbove(UIElement view, object value)
		{
			view.SetValue(AboveProperty, value);
		}

		public static DependencyProperty AboveProperty { get ; } =
			DependencyProperty.RegisterAttached("Above", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static object GetBelow(UIElement view)
		{
			return (object)view.GetValue(BelowProperty);
		}

		public static void SetBelow(UIElement view, object value)
		{
			view.SetValue(BelowProperty, value);
		}

		public static DependencyProperty BelowProperty { get ; } =
			DependencyProperty.RegisterAttached("Below", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static object GetLeftOf(UIElement view)
		{
			return (object)view.GetValue(LeftOfProperty);
		}

		public static void SetLeftOf(UIElement view, object value)
		{
			view.SetValue(LeftOfProperty, value);
		}

		public static DependencyProperty LeftOfProperty { get ; } =
			DependencyProperty.RegisterAttached("LeftOf", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		public static object GetRightOf(UIElement view)
		{
			return (object)view.GetValue(RightOfProperty);
		}

		public static void SetRightOf(UIElement view, object value)
		{
			view.SetValue(RightOfProperty, value);
		}

		public static DependencyProperty RightOfProperty { get ; } =
			DependencyProperty.RegisterAttached("RightOf", typeof(object), typeof(RelativePanel), new FrameworkPropertyMetadata(defaultValue: null, propertyChangedCallback: (s, e) => OnPositioningChanged(s)));

		#endregion

		private static void OnPositioningChanged(object s)
		{
			var element = s as FrameworkElement;

			if (element == null)
			{
				return;
			}

			element.InvalidateArrange();
		}
	}
}
