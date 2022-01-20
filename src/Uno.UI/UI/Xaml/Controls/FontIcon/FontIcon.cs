﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Uno;
using Windows.UI.Text;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls
{
	public partial class FontIcon : IconElement
	{
		private readonly TextBlock _textBlock;

		public FontIcon()
		{
			_textBlock = new TextBlock();

			AddIconElementView(_textBlock);

			Loaded += FontIcon_Loaded;
		}

		private void FontIcon_Loaded(object sender, RoutedEventArgs e)
		{
			SynchronizeProperties();
		}

		private void SynchronizeProperties()
		{
			_textBlock.Text = Glyph;
			_textBlock.FontSize = FontSize;
			_textBlock.FontStyle = FontStyle;
			_textBlock.FontFamily = FontFamily;
			_textBlock.Foreground = Foreground;

			_textBlock.VerticalAlignment = VerticalAlignment.Center;
			_textBlock.HorizontalAlignment = HorizontalAlignment.Center;
			_textBlock.TextAlignment = Windows.UI.Xaml.TextAlignment.Center;
		}

		#region Glyph

		public string Glyph
		{
			get => (string)GetValue(GlyphProperty);
			set => SetValue(GlyphProperty, value);
		}

		public static DependencyProperty GlyphProperty { get; } =
			DependencyProperty.Register(
				nameof(Glyph),
				typeof(string),
				typeof(FontIcon),
				new FrameworkPropertyMetadata(
					string.Empty,
					(s, e) => ((FontIcon)s).OnGlyphChanged((string)e.NewValue)));

		private void OnGlyphChanged(string newValue)
		{
			if (_textBlock != null)
			{
				_textBlock.Text = newValue;
			}
		}

		#endregion

		#region FontFamily

		public FontFamily FontFamily
		{
			get { return (FontFamily)this.GetValue(FontFamilyProperty); }
			set { this.SetValue(FontFamilyProperty, value); }
		}

		public static DependencyProperty FontFamilyProperty { get; } =
			DependencyProperty.Register(
				name: nameof(FontFamily),
				propertyType: typeof(FontFamily),
				ownerType: typeof(FontIcon),
				typeMetadata: new FrameworkPropertyMetadata(
					defaultValue: new FontFamily(Uno.UI.FeatureConfiguration.Font.SymbolsFont),
					propertyChangedCallback: (s, e) => ((FontIcon)s).OnFontFamilyChanged((FontFamily)e.NewValue)
				)
		);

		private void OnFontFamilyChanged(FontFamily newValue)
		{
			if (_textBlock != null)
			{
				_textBlock.FontFamily = newValue;
			}
		}

		#endregion

		#region FontStyle

		public FontStyle FontStyle
		{
			get { return (FontStyle)GetValue(FontStyleProperty); }
			set { SetValue(FontStyleProperty, value); }
		}

		public static DependencyProperty FontStyleProperty { get; } =
			DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(FontIcon), new FrameworkPropertyMetadata(FontStyle.Normal,
				(s, e) => ((FontIcon)s).OnFontStyleChanged((FontStyle)e.NewValue)));

		private void OnFontStyleChanged(FontStyle newValue)
		{
			if (_textBlock != null)
			{
				_textBlock.FontStyle = newValue;
			}
		}

		#endregion

		#region FontSize

		public double FontSize
		{
			get => (double)GetValue(FontSizeProperty);
			set => SetValue(FontSizeProperty, value);
		}

		public static DependencyProperty FontSizeProperty { get; } =
			DependencyProperty.Register(
				nameof(FontSize),
				typeof(double),
				typeof(FontIcon),
				new FrameworkPropertyMetadata(
					20.0,
					(s, e) => ((FontIcon)s).OnFontSizeChanged((double)e.NewValue)));

		private void OnFontSizeChanged(double newValue)
		{
			if (_textBlock != null)
			{
				_textBlock.FontSize = newValue;
			}
		}

		#endregion

		#region FontWeight

		public FontWeight FontWeight
		{
			get => (FontWeight)GetValue(FontWeightProperty);
			set => SetValue(FontWeightProperty, value);
		}

		public static DependencyProperty FontWeightProperty { get; } =
			DependencyProperty.Register(
				nameof(FontWeight),
				typeof(FontWeight),
				typeof(FontIcon),
				new FrameworkPropertyMetadata(
					new FontWeight(400),
					(s, e) => ((FontIcon)s).OnFontWeightChanged((FontWeight)e.NewValue)));

		private void OnFontWeightChanged(FontWeight newValue)
		{
			if (_textBlock != null)
			{
				_textBlock.FontWeight = newValue;
			}
		}

		#endregion

		#region IsTextScaleFactorEnabled

		[NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public bool IsTextScaleFactorEnabled
		{
			get => (bool)this.GetValue(IsTextScaleFactorEnabledProperty);
			set => SetValue(IsTextScaleFactorEnabledProperty, value);
		}

		[NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static DependencyProperty IsTextScaleFactorEnabledProperty { get; } =
			DependencyProperty.Register(
				nameof(IsTextScaleFactorEnabled),
				typeof(bool),
				typeof(FontIcon),
				new FrameworkPropertyMetadata(true));

		#endregion

		protected override void OnForegroundChanged(DependencyPropertyChangedEventArgs e)
		{
			var solidColorBrush = e.NewValue as SolidColorBrush;
			if (solidColorBrush != null && _textBlock != null)
			{
				_textBlock.Foreground = solidColorBrush;
			}
		}
	}
}
