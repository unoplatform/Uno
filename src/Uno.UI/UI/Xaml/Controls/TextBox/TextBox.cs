﻿#if NET461 || UNO_REFERENCE_API || __MACOS__
#pragma warning disable CS0067, CS649
#endif

using System;

using Uno.Extensions;
using Uno.UI.Common;
using Uno.UI.DataBinding;
using Uno.UI.Xaml.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Uno.Foundation.Logging;
using Uno.Disposables;
using Uno.UI.Xaml.Media;
using Windows.ApplicationModel.DataTransfer;

#if HAS_UNO_WINUI
using Microsoft.UI.Input;
using PointerDeviceType = Microsoft.UI.Input.PointerDeviceType;
#else
using PointerDeviceType = Windows.Devices.Input.PointerDeviceType;
#endif

namespace Windows.UI.Xaml.Controls
{
	public class TextBoxConstants
	{
		public const string HeaderContentPartName = "HeaderContentPresenter";
		public const string ContentElementPartName = "ContentElement";
		public const string PlaceHolderPartName = "PlaceholderTextContentPresenter";
		public const string DeleteButtonPartName = "DeleteButton";
		public const string ButtonVisibleStateName = "ButtonVisible";
		public const string ButtonCollapsedStateName = "ButtonCollapsed";
	}

	public partial class TextBox : Control, IFrameworkTemplatePoolAware
	{
		/// <summary>
		/// This is a workaround for the template pooling issue where we change IsChecked when the template is recycled.
		/// This prevents incorrect event raising but is not a "real" solution. Pooling could still cause issues.
		/// This workaround can be removed if pooling is removed. See https://github.com/unoplatform/uno/issues/12189
		/// </summary>
		private bool _suppressTextChanged;

#pragma warning disable CS0067, CS0649
		private IFrameworkElement _placeHolder;
		private ContentControl _contentElement;
		private WeakReference<Button> _deleteButton;

		private readonly SerialDisposable _selectionHighlightColorSubscription = new SerialDisposable();
		private readonly SerialDisposable _foregroundBrushSubscription = new SerialDisposable();
#pragma warning restore CS0067, CS0649

		private ContentPresenter _header;
		protected private bool _isButtonEnabled = true;
		protected private bool CanShowButton => !Text.IsNullOrEmpty() && FocusState != FocusState.Unfocused && !IsReadOnly && !AcceptsReturn && TextWrapping == TextWrapping.NoWrap;

		public event TextChangedEventHandler TextChanged;
		public event TypedEventHandler<TextBox, TextBoxTextChangingEventArgs> TextChanging;
		public event TypedEventHandler<TextBox, TextBoxBeforeTextChangingEventArgs> BeforeTextChanging;
		public event RoutedEventHandler SelectionChanged;

		/// <summary>
		/// Set when <see cref="TextChanged"/> event is being raised, to ensure modifications by handlers don't trigger an infinite loop.
		/// </summary>
		private bool _isInvokingTextChanged;
		/// <summary>
		/// Set when <see cref="TextChanging"/> event is being raised, to ensure modifications by handlers don't trigger an infinite loop.
		/// </summary>
		private bool _isInvokingTextChanging;
		/// <summary>
		/// Set when the <see cref="Text"/> property is being modified by user input.
		/// </summary>
		private bool _isInputModifyingText;
		/// <summary>
		/// Set when the <see cref="Text"/> property is being cleared via delete button.
		/// </summary>
		private bool _isInputClearingText;
		/// <summary>
		/// Set when <see cref="RaiseTextChanged"/> has been dispatched but not yet called.
		/// </summary>
		private bool _isTextChangedPending;
		/// <summary>
		/// True if Text has changed while the TextBox has had focus, false otherwise
		///
		/// This flag is checked to avoid pushing a value to a two-way binding if no edits have occurred, per UWP's behavior.
		/// </summary>
		private bool _hasTextChangedThisFocusSession;

		public TextBox()
		{
			this.RegisterParentChangedCallbackStrong(this, OnParentChanged);

			DefaultStyleKey = typeof(TextBox);
			SizeChanged += OnSizeChanged;

			Loaded += TextBox_Loaded;
			Unloaded += TextBox_Unloaded;
		}

		internal bool IsUserModifying => _isInputModifyingText || _isInputClearingText;

		private void TextBox_Loaded(object sender, RoutedEventArgs e)
		{
			// Brush subscriptions might have been removed during Unloaded
			if (_foregroundBrushSubscription.Disposable is null)
			{
				OnForegroundColorChanged(null, Foreground);
			}
			if (_selectionHighlightColorSubscription.Disposable is null)
			{
				OnSelectionHighlightColorChanged(SelectionHighlightColor);
			}
		}

		private void TextBox_Unloaded(object sender, RoutedEventArgs e)
		{
			_foregroundBrushSubscription.Disposable = null;
			_selectionHighlightColorSubscription.Disposable = null;
		}

		private void OnSizeChanged(object sender, SizeChangedEventArgs args)
		{
			UpdateButtonStates();
		}

		private void OnParentChanged(object instance, object key, DependencyObjectParentChangedEventArgs args) => UpdateFontPartial();

		private void InitializeProperties()
		{
			UpdatePlaceholderVisibility();
			UpdateButtonStates();
			OnInputScopeChanged(InputScope);
			OnMaxLengthChanged(MaxLength);
			OnAcceptsReturnChanged(AcceptsReturn);
			OnIsReadonlyChanged();
			OnForegroundColorChanged(null, Foreground);
			UpdateFontPartial();
			OnHeaderChanged();
			OnIsTextPredictionEnabledChanged(IsTextPredictionEnabled);
			OnSelectionHighlightColorChanged(SelectionHighlightColor);
			OnIsSpellCheckEnabledChanged(IsSpellCheckEnabled);
			OnTextAlignmentChanged(TextAlignment);
			OnTextWrappingChanged();
			OnFocusStateChanged((FocusState)FocusStateProperty.GetMetadata(GetType()).DefaultValue, FocusState, initial: true);
			OnVerticalContentAlignmentChanged(VerticalAlignment.Top, VerticalContentAlignment);
			OnTextCharacterCasingChanged(CharacterCasing);
			UpdateDescriptionVisibility(true);
			var buttonRef = _deleteButton?.GetTarget();

			if (buttonRef != null)
			{
				var thisRef = (this as IWeakReferenceProvider).WeakReference;
				buttonRef.Command = new DelegateCommand(() => (thisRef.Target as TextBox)?.DeleteButtonClick());
			}

			InitializePropertiesPartial();
		}

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			// Ensures we don't keep a reference to a textBoxView that exists in a previous template
			_textBoxView = null;

			_placeHolder = GetTemplateChild(TextBoxConstants.PlaceHolderPartName) as IFrameworkElement;
			_contentElement = GetTemplateChild(TextBoxConstants.ContentElementPartName) as ContentControl;
			_header = GetTemplateChild(TextBoxConstants.HeaderContentPartName) as ContentPresenter;

			if (_contentElement is ScrollViewer scrollViewer)
			{
#if __IOS__ || __MACOS__
				// We disable scrolling because the inner ITextBoxView provides its own scrolling
				scrollViewer.HorizontalScrollMode = ScrollMode.Disabled;
				scrollViewer.VerticalScrollMode = ScrollMode.Disabled;
				scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
				scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
#endif
			}

			if (GetTemplateChild(TextBoxConstants.DeleteButtonPartName) is Button button)
			{
				_deleteButton = new WeakReference<Button>(button);
			}

			UpdateTextBoxView();
			InitializeProperties();
			UpdateVisualState();
		}

		partial void InitializePropertiesPartial();

		#region Text DependencyProperty

		public string Text
		{
			get => (string)this.GetValue(TextProperty);
			set
			{
				if (value == null)
				{
#if HAS_UNO_WINUI
					value = string.Empty;
#else
					throw new ArgumentNullException();
#endif
				}

				this.SetValue(TextProperty, value);
			}
		}

		private static string GetFirstLine(string value)
		{
			for (int i = 0; i < value.Length; i++)
			{
				var c = value[i];
				if (c == '\r' || c == '\n')
				{
					return value.Substring(0, i);
				}
			}

			return value;
		}

		public static DependencyProperty TextProperty { get; } =
			DependencyProperty.Register(
				"Text",
				typeof(string),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					defaultValue: string.Empty,
					options: FrameworkPropertyMetadataOptions.None,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnTextChanged(e),
					coerceValueCallback: (d, v) => ((TextBox)d)?.CoerceText(v),
					defaultUpdateSourceTrigger: UpdateSourceTrigger.Explicit
				)
				{
					CoerceWhenUnchanged = false
				}
			);

		protected virtual void OnTextChanged(DependencyPropertyChangedEventArgs e)
		{
			_hasTextChangedThisFocusSession = true;

			RaiseTextChanging();

			if (!_isInputModifyingText)
			{
				_textBoxView?.SetTextNative(Text);
			}

			UpdatePlaceholderVisibility();

			UpdateButtonStates();

			if (!_isTextChangedPending)
			{
				_isTextChangedPending = true;
				_ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, RaiseTextChanged);
			}
		}

		private void RaiseTextChanging()
		{
			if (!_isInvokingTextChanging)
			{
#if !HAS_EXPENSIVE_TRYFINALLY // Try/finally incurs a very large performance hit in mono-wasm - https://github.com/dotnet/runtime/issues/50783
				try
#endif
				{
					_isInvokingTextChanging = true;
					TextChanging?.Invoke(this, new TextBoxTextChangingEventArgs());
				}
#if !HAS_EXPENSIVE_TRYFINALLY // Try/finally incurs a very large performance hit in mono-wasm - https://github.com/dotnet/runtime/issues/50783
				finally
#endif
				{
					_isInvokingTextChanging = false;
				}
			}
		}

		/// <summary>
		/// This is called asynchronously after the UI changes in line with WinUI.
		/// Note that no further native text box view text modification should
		/// be performed in this method to avoid potential race conditions
		/// (see #6289)
		/// </summary>
		private void RaiseTextChanged()
		{
			if (_isInvokingTextChanged)
			{
				return;
			}

#if !HAS_EXPENSIVE_TRYFINALLY // Try/finally incurs a very large performance hit in mono-wasm - https://github.com/dotnet/runtime/issues/50783
			try
#endif
			{
				_isInvokingTextChanged = true;
				_isTextChangedPending = false;
				if (!_suppressTextChanged) // This workaround can be removed if pooling is removed. See https://github.com/unoplatform/uno/issues/12189
				{
					TextChanged?.Invoke(this, new TextChangedEventArgs(this));
				}
			}
#if !HAS_EXPENSIVE_TRYFINALLY // Try/finally incurs a very large performance hit in mono-wasm - https://github.com/dotnet/runtime/issues/50783
			finally
#endif
			{
				_isInvokingTextChanged = false;
				_suppressTextChanged = false;
			}
		}

		private void UpdatePlaceholderVisibility()
		{
			if (_placeHolder != null)
			{
				_placeHolder.Visibility = Text.IsNullOrEmpty() ? Visibility.Visible : Visibility.Collapsed;
			}
		}

		private object CoerceText(object baseValue)
		{
			if (!(baseValue is string baseString))
			{
				return ""; //Pushing null to the binding resets the text. (Setting null to the Text property directly throws an exception.)
			}

			if (MaxLength > 0 && baseString.Length > MaxLength)
			{
				return DependencyProperty.UnsetValue;
			}

			if (!AcceptsReturn)
			{
				baseString = GetFirstLine(baseString);
			}

			var args = new TextBoxBeforeTextChangingEventArgs(baseString);
			BeforeTextChanging?.Invoke(this, args);
			if (args.Cancel)
			{
				return DependencyProperty.UnsetValue;
			}

			return baseString;
		}

		#endregion

		#region Description DependencyProperty

		public
#if __IOS__ || __MACOS__
		new
#endif
		object Description
		{
			get => this.GetValue(DescriptionProperty);
			set => this.SetValue(DescriptionProperty, value);
		}

		public static DependencyProperty DescriptionProperty { get; } =
			DependencyProperty.Register(
				nameof(Description),
				typeof(object),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					defaultValue: null,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.UpdateDescriptionVisibility(false)
				)
			);

		private void UpdateDescriptionVisibility(bool initialization)
		{
			if (initialization && Description == null)
			{
				// Avoid loading DescriptionPresenter element in template if not needed.
				return;
			}

			var descriptionPresenter = this.FindName("DescriptionPresenter") as ContentPresenter;
			if (descriptionPresenter != null)
			{
				descriptionPresenter.Visibility = Description != null ? Visibility.Visible : Visibility.Collapsed;
			}
		}
		#endregion

		protected override void OnFontSizeChanged(double oldValue, double newValue)
		{
			base.OnFontSizeChanged(oldValue, newValue);
			UpdateFontPartial();
		}

		protected override void OnFontFamilyChanged(FontFamily oldValue, FontFamily newValue)
		{
			base.OnFontFamilyChanged(oldValue, newValue);
			UpdateFontPartial();
		}

		protected override void OnFontStyleChanged(FontStyle oldValue, FontStyle newValue)
		{
			base.OnFontStyleChanged(oldValue, newValue);
			UpdateFontPartial();
		}

		protected override void OnFontWeightChanged(FontWeight oldValue, FontWeight newValue)
		{
			base.OnFontWeightChanged(oldValue, newValue);
			UpdateFontPartial();
		}

		partial void UpdateFontPartial();

		protected override void OnForegroundColorChanged(Brush oldValue, Brush newValue)
		{
			_foregroundBrushSubscription.Disposable = null;
			if (newValue is SolidColorBrush brush)
			{
				OnForegroundColorChangedPartial(brush);
				_foregroundBrushSubscription.Disposable =
					Brush.AssignAndObserveBrush(brush, c => OnForegroundColorChangedPartial(brush));
			}
		}

		partial void OnForegroundColorChangedPartial(Brush newValue);

		#region PlaceholderText DependencyProperty

		public string PlaceholderText
		{
			get => (string)this.GetValue(PlaceholderTextProperty);
			set => this.SetValue(PlaceholderTextProperty, value);
		}

		public static DependencyProperty PlaceholderTextProperty { get; } =
			DependencyProperty.Register(
				"PlaceholderText",
				typeof(string),
				typeof(TextBox),
				new FrameworkPropertyMetadata(defaultValue: string.Empty)
			);

		#endregion

		#region SelectionHighlightColor DependencyProperty

		/// <summary>
		/// Gets or sets the brush used to highlight the selected text.
		/// </summary>
		public SolidColorBrush SelectionHighlightColor
		{
			get => (SolidColorBrush)GetValue(SelectionHighlightColorProperty);
			set => SetValue(SelectionHighlightColorProperty, value);
		}

		/// <summary>
		/// Identifies the SelectionHighlightColor dependency property.
		/// </summary>
		public static DependencyProperty SelectionHighlightColorProperty { get; } =
			DependencyProperty.Register(
				nameof(SelectionHighlightColor),
				typeof(SolidColorBrush),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					DefaultBrushes.SelectionHighlightColor,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnSelectionHighlightColorChanged((SolidColorBrush)e.NewValue)));

		private void OnSelectionHighlightColorChanged(SolidColorBrush brush)
		{
			_selectionHighlightColorSubscription.Disposable = null;
			if (brush is not null)
			{
				OnSelectionHighlightColorChangedPartial(brush);
				_selectionHighlightColorSubscription.Disposable = Brush.AssignAndObserveBrush(brush, c => OnSelectionHighlightColorChangedPartial(brush));
			}
			else
			{
				OnSelectionHighlightColorChangedPartial(DefaultBrushes.SelectionHighlightColor);
			}
		}

		partial void OnSelectionHighlightColorChangedPartial(SolidColorBrush brush);

		#endregion

		#region PlaceholderForeground DependencyProperty

		/// <summary>
		/// Gets or sets a brush that describes the color of placeholder text.
		/// </summary>
		public Brush PlaceholderForeground
		{
			get => (Brush)GetValue(PlaceholderForegroundProperty);
			set => SetValue(PlaceholderForegroundProperty, value);
		}

		/// <summary>
		/// Identifies the PlaceholderForeground dependency property.
		/// </summary>
		public static DependencyProperty PlaceholderForegroundProperty { get; } =
			DependencyProperty.Register(
				nameof(PlaceholderForeground),
				typeof(Brush),
				typeof(TextBox),
				new FrameworkPropertyMetadata(default(Brush)));

		#endregion

		#region InputScope DependencyProperty

		public InputScope InputScope
		{
			get => (InputScope)this.GetValue(InputScopeProperty);
			set => this.SetValue(InputScopeProperty, value);
		}

		public static DependencyProperty InputScopeProperty { get; } =
			DependencyProperty.Register(
				"InputScope",
				typeof(InputScope),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					defaultValue: new InputScope()
					{
						Names =
						{
							new InputScopeName
							{
								NameValue = InputScopeNameValue.Default
							}
						}
					},
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnInputScopeChanged((InputScope)e.NewValue)
				)
			);

		private void OnInputScopeChanged(InputScope newValue) => OnInputScopeChangedPartial(newValue);
		partial void OnInputScopeChangedPartial(InputScope newValue);

		#endregion

		#region MaxLength DependencyProperty

		public int MaxLength
		{
			get => (int)this.GetValue(MaxLengthProperty);
			set => this.SetValue(MaxLengthProperty, value);
		}

		public static DependencyProperty MaxLengthProperty { get; } =
			DependencyProperty.Register(
				"MaxLength",
				typeof(int),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					defaultValue: 0,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnMaxLengthChanged((int)e.NewValue)
				)
			);

		private void OnMaxLengthChanged(int newValue) => OnMaxLengthChangedPartial(newValue);

		partial void OnMaxLengthChangedPartial(int newValue);

		#endregion

		#region AcceptsReturn DependencyProperty

		public bool AcceptsReturn
		{
			get => (bool)this.GetValue(AcceptsReturnProperty);
			set => this.SetValue(AcceptsReturnProperty, value);
		}

		public static DependencyProperty AcceptsReturnProperty { get; } =
			DependencyProperty.Register(
				"AcceptsReturn",
				typeof(bool),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					defaultValue: false,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnAcceptsReturnChanged((bool)e.NewValue)
				)
			);

		private void OnAcceptsReturnChanged(bool newValue)
		{
			if (!newValue)
			{
				var text = Text;
				var singleLineText = GetFirstLine(text);
				if (text != singleLineText)
				{
					Text = singleLineText;
				}
			}

			OnAcceptsReturnChangedPartial(newValue);
			UpdateButtonStates();
		}

		partial void OnAcceptsReturnChangedPartial(bool newValue);

		#endregion

		#region TextWrapping DependencyProperty
		public TextWrapping TextWrapping
		{
			get => (TextWrapping)this.GetValue(TextWrappingProperty);
			set => this.SetValue(TextWrappingProperty, value);
		}

		public static DependencyProperty TextWrappingProperty { get; } =
			DependencyProperty.Register(
				"TextWrapping",
				typeof(TextWrapping),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					defaultValue: TextWrapping.NoWrap,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnTextWrappingChanged())
				);

		private void OnTextWrappingChanged()
		{
			OnTextWrappingChangedPartial();
			UpdateButtonStates();
		}

		partial void OnTextWrappingChangedPartial();

		#endregion

#if __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[Uno.NotImplemented("__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
#endif
		public CharacterCasing CharacterCasing
		{
			get => (CharacterCasing)this.GetValue(CharacterCasingProperty);
			set => this.SetValue(CharacterCasingProperty, value);
		}

#if __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[Uno.NotImplemented("__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
#endif
		public static DependencyProperty CharacterCasingProperty { get; } =
			DependencyProperty.Register(
				nameof(CharacterCasing),
				typeof(CharacterCasing),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
						defaultValue: CharacterCasing.Normal,
						propertyChangedCallback: (s, e) => ((TextBox)s)?.OnTextCharacterCasingChanged((CharacterCasing)e.NewValue))
				);

		private void OnTextCharacterCasingChanged(CharacterCasing newValue)
		{
			OnTextCharacterCasingChangedPartial(newValue);
		}

		partial void OnTextCharacterCasingChangedPartial(CharacterCasing newValue);

		#region IsReadOnly DependencyProperty

		public bool IsReadOnly
		{
			get => (bool)GetValue(IsReadOnlyProperty);
			set => SetValue(IsReadOnlyProperty, value);
		}

		public static DependencyProperty IsReadOnlyProperty { get; } =
			DependencyProperty.Register(
				"IsReadOnly",
				typeof(bool),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					false,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnIsReadonlyChanged()
				)
			);

		private void OnIsReadonlyChanged()
		{
			OnIsReadonlyChangedPartial();
			UpdateButtonStates();
		}

		partial void OnIsReadonlyChangedPartial();

		#endregion

		#region Header DependencyProperties

		public object Header
		{
			get => (object)GetValue(HeaderProperty);
			set => SetValue(HeaderProperty, value);
		}

		public static DependencyProperty HeaderProperty { get; } =
			DependencyProperty.Register("Header",
				typeof(object),
				typeof(TextBox),
				new FrameworkPropertyMetadata(defaultValue: null,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnHeaderChanged()
				)
			);

		public DataTemplate HeaderTemplate
		{
			get => (DataTemplate)GetValue(HeaderTemplateProperty);
			set => SetValue(HeaderTemplateProperty, value);
		}

		public static DependencyProperty HeaderTemplateProperty { get; } =
			DependencyProperty.Register("HeaderTemplate",
				typeof(DataTemplate),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					defaultValue: null,
					options: FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnHeaderChanged()
				)
			);

		private void OnHeaderChanged()
		{
			var headerVisibility = (Header != null || HeaderTemplate != null) ? Visibility.Visible : Visibility.Collapsed;

			if (_header != null)
			{
				_header.Visibility = headerVisibility;
			}
		}

		#endregion

		#region IsSpellCheckEnabled DependencyProperty

		public bool IsSpellCheckEnabled
		{
			get => (bool)this.GetValue(IsSpellCheckEnabledProperty);
			set => this.SetValue(IsSpellCheckEnabledProperty, value);
		}

		public static DependencyProperty IsSpellCheckEnabledProperty { get; } =
			DependencyProperty.Register(
				"IsSpellCheckEnabled",
				typeof(bool),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					defaultValue: true,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnIsSpellCheckEnabledChanged((bool)e.NewValue)
				)
			);

		private void OnIsSpellCheckEnabledChanged(bool newValue) => OnIsSpellCheckEnabledChangedPartial(newValue);

		partial void OnIsSpellCheckEnabledChangedPartial(bool newValue);

		#endregion

		#region IsTextPredictionEnabled DependencyProperty

		[Uno.NotImplemented]
		public bool IsTextPredictionEnabled
		{
			get => (bool)this.GetValue(IsTextPredictionEnabledProperty);
			set => this.SetValue(IsTextPredictionEnabledProperty, value);
		}

		[Uno.NotImplemented]
		public static DependencyProperty IsTextPredictionEnabledProperty { get; } =
			DependencyProperty.Register(
				"IsTextPredictionEnabled",
				typeof(bool),
				typeof(TextBox),
				new FrameworkPropertyMetadata(
					defaultValue: true,
					propertyChangedCallback: (s, e) => ((TextBox)s)?.OnIsTextPredictionEnabledChanged((bool)e.NewValue)
				)
			);

		private void OnIsTextPredictionEnabledChanged(bool newValue) => OnIsTextPredictionEnabledChangedPartial(newValue);

		partial void OnIsTextPredictionEnabledChangedPartial(bool newValue);

		#endregion

		#region TextAlignment DependencyProperty

#if XAMARIN_ANDROID
		public new TextAlignment TextAlignment
#else
		public TextAlignment TextAlignment
#endif
		{
			get { return (TextAlignment)GetValue(TextAlignmentProperty); }
			set { SetValue(TextAlignmentProperty, value); }
		}

		public static DependencyProperty TextAlignmentProperty { get; } =
			DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(TextBox), new FrameworkPropertyMetadata(TextAlignment.Left, (s, e) => ((TextBox)s)?.OnTextAlignmentChanged((TextAlignment)e.NewValue)));


		private void OnTextAlignmentChanged(TextAlignment newValue) => OnTextAlignmentChangedPartial(newValue);

		partial void OnTextAlignmentChangedPartial(TextAlignment newValue);

		#endregion

		public string SelectedText
		{
			get => ((string)this.GetValue(TextProperty)).Substring(SelectionStart, SelectionLength);
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}

				var actual = (string)this.GetValue(TextProperty);
				actual = actual.Remove(SelectionStart, SelectionLength);
				actual = actual.Insert(SelectionStart, value);

				this.SetValue(TextProperty, actual);

				SelectionLength = value.Length;
			}
		}

		private protected override void OnIsTabStopChanged(bool oldValue, bool newValue)
		{
			base.OnIsTabStopChanged(oldValue, newValue);
			OnIsTabStopChangedPartial();
		}

		partial void OnIsTabStopChangedPartial();

		internal override void UpdateFocusState(FocusState focusState)
		{
			var oldValue = FocusState;
			base.UpdateFocusState(focusState);
			if (oldValue != focusState)
			{
				OnFocusStateChanged(oldValue, focusState, initial: false);
			}
		}

		private void OnFocusStateChanged(FocusState oldValue, FocusState newValue, bool initial)
		{
			OnFocusStateChangedPartial(newValue);

			if (!initial && newValue == FocusState.Unfocused && _hasTextChangedThisFocusSession)
			{
				// Manually update Source when losing focus because TextProperty's default UpdateSourceTrigger is Explicit
				var bindingExpression = GetBindingExpression(TextProperty);
				bindingExpression?.UpdateSource(Text);
			}

			UpdateButtonStates();

			if (oldValue == FocusState.Unfocused || newValue == FocusState.Unfocused)
			{
				_hasTextChangedThisFocusSession = false;
			}

			UpdateVisualState();
		}

		partial void OnFocusStateChangedPartial(FocusState focusState);

		protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
		{
			base.OnVisibilityChanged(oldValue, newValue);
			if (newValue == Visibility.Visible)
			{
				UpdateVisualState();
			}
			else
			{
				_isPointerOver = false;
			}
		}

		protected override void OnPointerEntered(PointerRoutedEventArgs e)
		{
			base.OnPointerEntered(e);
			_isPointerOver = true;
			UpdateVisualState();
		}

		protected override void OnPointerExited(PointerRoutedEventArgs e)
		{
			base.OnPointerExited(e);
			_isPointerOver = false;
			UpdateVisualState();
		}

		protected override void OnPointerCaptureLost(PointerRoutedEventArgs e)
		{
			base.OnPointerCaptureLost(e);
			_isPointerOver = false;
			UpdateVisualState();
		}

		protected override void OnPointerPressed(PointerRoutedEventArgs args)
		{
			base.OnPointerPressed(args);

			if (ShouldFocusOnPointerPressed(args)
				// UWP Captures pointer is not Touch
				&& CapturePointer(args.Pointer))
			{
				Focus(FocusState.Pointer);
			}

			args.Handled = true;
		}

		/// <inheritdoc />
		protected override void OnPointerReleased(PointerRoutedEventArgs args)
		{
			base.OnPointerReleased(args);

			if (!ShouldFocusOnPointerPressed(args))
			{
				Focus(FocusState.Pointer);
			}

			args.Handled = true;
		}

		protected override void OnTapped(TappedRoutedEventArgs e)
		{
			base.OnTapped(e);

			OnTappedPartial();
		}

		partial void OnTappedPartial();

		/// <inheritdoc />
		protected override void OnKeyDown(KeyRoutedEventArgs args)
		{
			base.OnKeyDown(args);

			// Note: On windows only keys that are "moving the cursor" are handled
			//		 AND ** only KeyDown ** is handled (not KeyUp)
			switch (args.Key)
			{
				case VirtualKey.Up:
				case VirtualKey.Down:
					if (AcceptsReturn)
					{
						args.Handled = true;
					}
					break;
				case VirtualKey.Left:
				case VirtualKey.Right:
				case VirtualKey.Home:
				case VirtualKey.End:
					args.Handled = true;
					break;
			}

#if __WASM__
			if (args.Handled)
			{
				// Marking the routed event as Handled makes the browser call preventDefault() for key events.
				// This is a problem as it breaks the browser caret navigation within the input.
				((IHtmlHandleableRoutedEventArgs)args).HandledResult &= ~HtmlEventDispatchResult.PreventDefault;
			}
#endif
		}

		protected virtual void UpdateButtonStates()
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug(nameof(UpdateButtonStates));
			}

			// Minimum width for TextBox with DeleteButton visible is 5em.
			if (CanShowButton && _isButtonEnabled && ActualWidth > FontSize * 5)
			{
				VisualStateManager.GoToState(this, TextBoxConstants.ButtonVisibleStateName, true);
			}
			else
			{
				VisualStateManager.GoToState(this, TextBoxConstants.ButtonCollapsedStateName, true);
			}
		}

		/// <summary>
		/// Respond to text input from user interaction.
		/// </summary>
		/// <param name="newText">The most recent version of the text from the input field.</param>
		/// <returns>The value of the <see cref="Text"/> property, which may have been modified programmatically.</returns>
		internal string ProcessTextInput(string newText)
		{
#if !HAS_EXPENSIVE_TRYFINALLY // Try/finally incurs a very large performance hit in mono-wasm - https://github.com/dotnet/runtime/issues/50783
			try
#endif
			{
				_isInputModifyingText = true;
				Text = newText;
			}
#if !HAS_EXPENSIVE_TRYFINALLY // Try/finally incurs a very large performance hit in mono-wasm - https://github.com/dotnet/runtime/issues/50783
			finally
#endif
			{
				_isInputModifyingText = false;
			}

			return Text; //This may have been modified by BeforeTextChanging, TextChanging, DP callback, etc
		}

		private void DeleteButtonClick()
		{
#if !HAS_EXPENSIVE_TRYFINALLY // Try/finally incurs a very large performance hit in mono-wasm - https://github.com/dotnet/runtime/issues/50783
			try
#endif
			{
				_isInputClearingText = true;

				Text = string.Empty;
				OnDeleteButtonClickPartial();
			}
#if !HAS_EXPENSIVE_TRYFINALLY // Try/finally incurs a very large performance hit in mono-wasm - https://github.com/dotnet/runtime/issues/50783
			finally
#endif
			{
				_isInputClearingText = false;
			}
		}

		partial void OnDeleteButtonClickPartial();

		internal void OnSelectionChanged()
		{
			SelectionChanged?.Invoke(this, new RoutedEventArgs(this));
		}


		public void OnTemplateRecycled()
		{
			_suppressTextChanged = true;
			Text = string.Empty;
		}

		protected override AutomationPeer OnCreateAutomationPeer() => new TextBoxAutomationPeer(this);

		public override string GetAccessibilityInnerText() => Text;

		protected override void OnVerticalContentAlignmentChanged(VerticalAlignment oldVerticalContentAlignment, VerticalAlignment newVerticalContentAlignment)
		{
			base.OnVerticalContentAlignmentChanged(oldVerticalContentAlignment, newVerticalContentAlignment);

			if (_contentElement != null)
			{
				_contentElement.VerticalContentAlignment = newVerticalContentAlignment;
			}

			if (_placeHolder != null)
			{
				_placeHolder.VerticalAlignment = newVerticalContentAlignment;
			}

			OnVerticalContentAlignmentChangedPartial(oldVerticalContentAlignment, newVerticalContentAlignment);
		}

		partial void OnVerticalContentAlignmentChangedPartial(VerticalAlignment oldVerticalContentAlignment, VerticalAlignment newVerticalContentAlignment);

		public void Select(int start, int length)
		{
			if (start < 0)
			{
				throw new ArgumentException($"'{start}' cannot be negative.", nameof(start));
			}

			if (length < 0)
			{
				throw new ArgumentException($"'{length}' cannot be negative.", nameof(length));
			}

			// TODO: Test and adjust (if needed) this logic for surrogate pairs.

			var textLength = Text.Length;

			if (start >= textLength)
			{
				start = textLength;
				length = 0;
			}
			else if (start + length > textLength)
			{
				length = textLength - start;
			}

			if (SelectionStart == start && SelectionLength == length)
			{
				return;
			}

			SelectPartial(start, length);
			OnSelectionChanged();
		}

		public void SelectAll() => SelectAllPartial();

		partial void SelectPartial(int start, int length);

		partial void SelectAllPartial();

		/// <summary>
		/// Copies content from the OS clipboard into the text control.
		/// </summary>
		public void PasteFromClipboard()
		{
			_ = Dispatcher.RunAsync(CoreDispatcherPriority.High, async () =>
			{
				var content = Clipboard.GetContent();
				var clipboardText = await content.GetTextAsync();
				var selectionStart = SelectionStart;
				var selectionLength = SelectionLength;
				var currentText = Text;

				if (selectionLength > 0)
				{
					currentText = currentText.Remove(selectionStart, selectionLength);
				}

				currentText = currentText.Insert(selectionStart, clipboardText);

				Text = currentText;
			});
		}

		/// <summary>
		/// Copies the selected content to the OS clipboard.
		/// </summary>
		public void CopySelectionToClipboard()
		{
			if (SelectionLength > 0)
			{
				var text = SelectedText;
				var dataPackage = new DataPackage();
				dataPackage.SetText(text);
				Clipboard.SetContent(dataPackage);
			}
		}

		/// <summary>
		/// Moves the selected content to the OS clipboard and removes it from the text control.
		/// </summary>
		public void CutSelectionToClipboard()
		{
			CopySelectionToClipboard();
			Text = Text.Remove(SelectionStart, SelectionLength);
		}

		internal override bool CanHaveChildren() => true;

		internal override void UpdateThemeBindings(Data.ResourceUpdateReason updateReason)
		{
			base.UpdateThemeBindings(updateReason);

			UpdateKeyboardThemePartial();
		}

		partial void UpdateKeyboardThemePartial();

		private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
		{
			base.OnIsEnabledChanged(e);
			UpdateVisualState();
			OnIsEnabledChangedPartial(e);
		}

		partial void OnIsEnabledChangedPartial(IsEnabledChangedEventArgs e);

		private bool ShouldFocusOnPointerPressed(PointerRoutedEventArgs args) =>
			// For mouse and pen, the TextBox should focus on pointer press
			// (and then capture pointer to make sure to handle the whol down->move->up sequence).
			// For touch we wait for the release to focus (avoid flickering in case of cancel due to scroll for instance).
			args.Pointer.PointerDeviceType != PointerDeviceType.Touch;
	}
}
