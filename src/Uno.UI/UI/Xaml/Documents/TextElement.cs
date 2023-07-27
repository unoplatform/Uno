﻿#if IS_UNIT_TESTS
#pragma warning disable CS0067
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.DataBinding;
using Uno.Disposables;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media;
using Windows.UI.Text;
using Uno.UI;
using Uno.UI.Xaml;
using Uno.UI.Xaml.Media;

#if __ANDROID__
using View = Android.Views.View;
using Font = Android.Graphics.Typeface;
using Android.Graphics;
#elif __IOS__
using View = UIKit.UIView;
using Color = UIKit.UIColor;
using Font = UIKit.UIFont;
#elif __MACOS__
using View = Windows.UI.Xaml.UIElement;
using Color = Windows.UI.Color;
#else
using Color = System.Drawing.Color;
#endif

#if __WASM__
using BaseClass = Windows.UI.Xaml.UIElement;
#else
using BaseClass = Windows.UI.Xaml.DependencyObject;
#endif

namespace Windows.UI.Xaml.Documents
{
	public abstract partial class TextElement : BaseClass, IThemeChangeAware
	{
#if !__WASM__
		public TextElement()
		{
			SetDefaultForeground(ForegroundProperty);
			InitializeBinder();
		}
#endif

		#region FontFamily Dependency Property
		public FontFamily FontFamily
		{
			get { return (FontFamily)this.GetValue(FontFamilyProperty); }
			set { this.SetValue(FontFamilyProperty, value); }
		}

		public static DependencyProperty FontFamilyProperty { get; } =
			DependencyProperty.Register(
				"FontFamily",
				typeof(FontFamily),
				typeof(TextElement),
				new FrameworkPropertyMetadata(
					defaultValue: FontFamily.Default,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((TextElement)s).OnFontFamilyChanged()
				)
			);

		protected virtual void OnFontFamilyChanged()
		{
			OnFontFamilyChangedPartial();
		}

		partial void OnFontFamilyChangedPartial();
		#endregion

		#region FontStyle Dependency Property

		public FontStyle FontStyle
		{
			get { return (FontStyle)this.GetValue(FontStyleProperty); }
			set { this.SetValue(FontStyleProperty, value); }
		}

		public static DependencyProperty FontStyleProperty { get; } =
			DependencyProperty.Register(
				"FontStyle",
				typeof(FontStyle),
				typeof(TextElement),
				new FrameworkPropertyMetadata(
					defaultValue: Windows.UI.Text.FontStyle.Normal,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((TextElement)s).OnFontStyleChanged()
				)
			);

		protected virtual void OnFontStyleChanged()
		{
			OnFontStyleChangedPartial();
		}

		partial void OnFontStyleChangedPartial();

		#endregion

		#region FontSize Dependency Property

		public double FontSize
		{
			get { return (double)this.GetValue(FontSizeProperty); }
			set { this.SetValue(FontSizeProperty, value); }
		}

		public static DependencyProperty FontSizeProperty { get; } =
			DependencyProperty.Register(
				"FontSize",
				typeof(double),
				typeof(TextElement),
				new FrameworkPropertyMetadata(
					defaultValue: 14.0,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((TextElement)s).OnFontSizeChanged()
				)
			);

		protected virtual void OnFontSizeChanged()
		{
			OnFontSizeChangedPartial();
		}

		partial void OnFontSizeChangedPartial();

		#endregion

		#region Foreground Dependency Property

		public Brush Foreground
		{
			get { return (Brush)this.GetValue(ForegroundProperty); }
			set
			{
				if (value != null && !(value is SolidColorBrush))
				{
					throw new InvalidOperationException("Specified brush is not a SolidColorBrush");
				}

				this.SetValue(ForegroundProperty, value);
			}
		}

		public static DependencyProperty ForegroundProperty { get; } =
			DependencyProperty.Register(
				"Foreground",
				typeof(Brush),
				typeof(TextElement),
				new FrameworkPropertyMetadata(
					defaultValue: SolidColorBrushHelper.Black,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((TextElement)s).OnForegroundChanged()
				)
			);

		protected virtual void OnForegroundChanged()
		{
			OnForegroundChangedPartial();
		}

		partial void OnForegroundChangedPartial();

		#endregion

		#region FontWeight Dependency Property

		public FontWeight FontWeight
		{
			get { return (FontWeight)this.GetValue(FontWeightProperty); }
			set { this.SetValue(FontWeightProperty, value); }
		}

		public static DependencyProperty FontWeightProperty { get; } =
			DependencyProperty.Register(
				"FontWeight",
				typeof(FontWeight),
				typeof(TextElement),
				new FrameworkPropertyMetadata(
					defaultValue: FontWeights.Normal,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((TextElement)s).OnFontWeightChanged()
				)
			);

		protected virtual void OnFontWeightChanged()
		{
			OnFontWeightChangedPartial();
		}

		partial void OnFontWeightChangedPartial();

		#endregion

		#region CharacterSpacing Dependency Property

		public int CharacterSpacing
		{
			get => (int)GetValue(CharacterSpacingProperty);
			set => SetValue(CharacterSpacingProperty, value);
		}

		public static DependencyProperty CharacterSpacingProperty { get; } =
			DependencyProperty.Register(
				"CharacterSpacing",
				typeof(int),
				typeof(TextElement),
				new FrameworkPropertyMetadata(
					defaultValue: 0,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((TextElement)s).OnCharacterSpacingChanged()
				)
			);

		protected virtual void OnCharacterSpacingChanged()
		{
			OnCharacterSpacingChangedPartial();
		}

		partial void OnCharacterSpacingChangedPartial();

		#endregion

		#region TextDecorations

		public TextDecorations TextDecorations
		{
			get { return (TextDecorations)GetValue(TextDecorationsProperty); }
			set { SetValue(TextDecorationsProperty, value); }
		}

		public static DependencyProperty TextDecorationsProperty { get; } =
			DependencyProperty.Register(
				nameof(TextDecorations),
				typeof(TextDecorations),
				typeof(TextElement),
				new FrameworkPropertyMetadata(
					defaultValue: TextDecorations.None,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((TextElement)s).OnTextDecorationsChanged()
				)
			);

		protected virtual void OnTextDecorationsChanged()
		{
			OnTextDecorationsChangedPartial();
		}

		partial void OnTextDecorationsChangedPartial();

		#endregion

		#region BaseLineAlignment Dependency Property

		public BaseLineAlignment BaseLineAlignment
		{
			get => (BaseLineAlignment)GetValue(BaseLineAlignmentProperty);
			set => SetValue(BaseLineAlignmentProperty, value);
		}

		public static DependencyProperty BaseLineAlignmentProperty { get; } =
			DependencyProperty.Register(
				"BaseLineAlignment",
				typeof(BaseLineAlignment),
				typeof(TextElement),
				new FrameworkPropertyMetadata(
					defaultValue: BaseLineAlignment.Baseline,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) => ((TextElement)s).OnBaseLineAlignmentChanged()
				)
			);

		protected virtual void OnBaseLineAlignmentChanged()
		{
			OnBaseLineAlignmentChangedPartial();
		}

		partial void OnBaseLineAlignmentChangedPartial();

		#endregion

		#region AllowFocusOnInteraction Dependency Property

		/// <summary>
		/// Identifies for the AllowFocusOnInteraction dependency property.
		/// </summary>
		[GeneratedDependencyProperty(DefaultValue = true, Options = FrameworkPropertyMetadataOptions.Inherits)]
		public static DependencyProperty AllowFocusOnInteractionProperty { get; } = CreateAllowFocusOnInteractionProperty();

		/// <summary>
		/// Gets or sets a value that indicates whether the element automatically gets focus when the user interacts with it.
		/// </summary>
		public bool AllowFocusOnInteraction
		{
			get => GetAllowFocusOnInteractionValue();
			set => SetAllowFocusOnInteractionValue(value);
		}

		#endregion

		private string _name;

		public string Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					_name = value;
					OnNameChangedPartial(value);
				}
			}
		}

		partial void OnNameChangedPartial(string newValue);

		/// <summary>
		/// Retrieves the parent RichTextBox/CRichTextBlock/TextBlock.
		/// </summary>
		/// <returns>FrameworkElement or <see langword="null"/>.</returns>
		internal FrameworkElement GetContainingFrameworkElement()
		{
			var parent = this.GetParent();

			while (
				parent != null &&
				!(parent is RichTextBlock) &&
				!(parent is TextBlock))
			{
				parent = parent.GetParent();
			}

			return parent as FrameworkElement;
		}

		public void OnThemeChanged() => SetDefaultForeground(ForegroundProperty);

#if !__WASM__
		private void SetDefaultForeground(DependencyProperty foregroundProperty)
		{
			this.SetValue(foregroundProperty, DefaultBrushes.TextForegroundBrush, DependencyPropertyValuePrecedences.DefaultValue);
			((IDependencyObjectStoreProvider)this).Store.SetLastUsedTheme(Application.Current?.RequestedThemeForResources);
		}
#endif
	}
}
