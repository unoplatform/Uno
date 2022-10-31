using System.Collections.Generic;
using System.Globalization;
using Windows.Foundation;
using Windows.System;

namespace Windows.UI.Xaml.Input;

/// <summary>
/// Represents a keyboard shortcut (or accelerator) that lets a user perform
/// an action using the keyboard instead of navigating the app UI (directly or through access keys).
/// </summary>
public partial class KeyboardAccelerator : DependencyObject
{
	/// <summary>
	/// Initializes a new instance of the KeyboardAccelerator class.
	/// </summary>
	public KeyboardAccelerator()
	{
	}

#pragma warning disable CS0067
	/// <summary>
	/// Occurs when the key combination for this KeyboardAccelerator is pressed.
	/// </summary>
	public event TypedEventHandler<KeyboardAccelerator, KeyboardAcceleratorInvokedEventArgs> Invoked;
#pragma warning restore CS0067

	/// <summary>
	/// Gets or sets whether a keyboard shortcut (accelerator) is available to the user.
	/// </summary>
	public bool IsEnabled
	{
		get => (bool)GetValue(IsEnabledProperty);
		set => SetValue(IsEnabledProperty, value);
	}

	/// <summary>
	/// Identifies the IsEnabled dependency property.
	/// </summary>
	public static DependencyProperty IsEnabledProperty { get; } =
		DependencyProperty.Register(
			nameof(IsEnabled),
			typeof(bool),
			typeof(KeyboardAccelerator),
			new FrameworkPropertyMetadata(true));
	
	/// <summary>
	/// Gets or sets the virtual key (used in conjunction with one or more modifier keys) for a keyboard shortcut (accelerator).
	/// </summary>
	/// <remarks>
	/// A keyboard shortcut is invoked when the modifier keys associated with the shortcut are pressed and then the non-modifier
	/// key is pressed at the same time. For example, Ctrl+C for copy and Ctrl+S for save.
	/// </remarks>
	public VirtualKey Key
	{
		get => (VirtualKey)GetValue(KeyProperty);
		set => SetValue(KeyProperty, value);
	}

	/// <summary>
	/// Identifies the Key dependency property.
	/// </summary>
	public static DependencyProperty KeyProperty { get; } =
		DependencyProperty.Register(
			nameof(Key),
			typeof(VirtualKey),
			typeof(KeyboardAccelerator),
			new FrameworkPropertyMetadata(default(VirtualKey)));

	/// <summary>
	/// Gets or sets the virtual key used to modify another keypress for a keyboard shortcut (accelerator).
	/// </summary>
	/// <remarks>
	/// A keyboard shortcut is invoked when the modifier keys associated with the shortcut are pressed and then the non-modifier
	/// key is pressed at the same time. For example, Ctrl+C for copy and Ctrl+S for save.
	/// </remarks>
	public VirtualKeyModifiers Modifiers
	{
		get => (VirtualKeyModifiers)GetValue(ModifiersProperty);
		set => SetValue(ModifiersProperty, value);
	}

	/// <summary>
	/// Identifies the Modifiers dependency property.
	/// </summary>
	public static DependencyProperty ModifiersProperty { get; } =
		DependencyProperty.Register(
			nameof(Modifiers),
			typeof(VirtualKeyModifiers),
			typeof(KeyboardAccelerator),
			new FrameworkPropertyMetadata(default(VirtualKeyModifiers)));

	/// <summary>
	/// Gets or sets the scope (or target) of the keyboard accelerator.
	/// </summary>
	/// <remarks>
	/// The default is null (global scope).
	/// </remarks>
	public DependencyObject ScopeOwner
	{
		get => (DependencyObject)GetValue(ScopeOwnerProperty);
		set => SetValue(ScopeOwnerProperty, value);
	}

	/// <summary>
	/// Identifies the ScopeOwner dependency property.
	/// </summary>
	public static DependencyProperty ScopeOwnerProperty { get; } =
		DependencyProperty.Register(
			nameof(ScopeOwner),
			typeof(DependencyObject),
			typeof(KeyboardAccelerator),
			new FrameworkPropertyMetadata(default(DependencyObject), FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));
	
	internal static string GetStringRepresentationForUIElement(UIElement uiElement)
	{
		// We don't want to bother doing anything if we've never actually set a keyboard accelerator,
		// so we'll just return null unless we have.
		// UNO TODO if (!uiElement.GetHandle().CheckOnDemandProperty(KnownPropertyIndex.UIElement_KeyboardAccelerators).IsNull())
		if (uiElement.KeyboardAccelerators.Count != 0)
		{
			IList<KeyboardAccelerator> keyboardAccelerators;
			int keyboardAcceleratorCount;

			keyboardAccelerators = uiElement.KeyboardAccelerators;
			keyboardAcceleratorCount = keyboardAccelerators.Count;

			if (keyboardAcceleratorCount > 0)
			{
				var keyboardAcceleratorStringRepresentation = keyboardAccelerators[0];
				return keyboardAcceleratorStringRepresentation.GetStringRepresentation();
			}
		}

		return null;
	}

	private string GetStringRepresentation()
	{
		var key = Key;
		var modifiers = Modifiers;
		var stringRepresentationLocal = "";

		if ((modifiers & VirtualKeyModifiers.Control) != 0)
		{
			ConcatVirtualKey(VirtualKey.Control, ref stringRepresentationLocal);
		}

		if ((modifiers & VirtualKeyModifiers.Menu) != 0)
		{
			ConcatVirtualKey(VirtualKey.Menu, ref stringRepresentationLocal);
		}

		if ((modifiers & VirtualKeyModifiers.Windows) != 0)
		{
			ConcatVirtualKey(VirtualKey.LeftWindows, ref stringRepresentationLocal);
		}

		if ((modifiers & VirtualKeyModifiers.Shift) != 0)
		{
			ConcatVirtualKey(VirtualKey.Shift, ref stringRepresentationLocal);
		}

		ConcatVirtualKey(key, ref stringRepresentationLocal);

		return stringRepresentationLocal;
	}

	private void ConcatVirtualKey(VirtualKey key, ref string keyboardAcceleratorString)
	{
		string keyName;

		// UNO TODO
		//(DXamlCore.GetCurrent().GetLocalizedResourceString(GetResourceStringIdFromVirtualKey(key), keyName.ReleaseAndGetAddressOf()));
		keyName = key.ToString();


		if (string.IsNullOrEmpty(keyboardAcceleratorString))
		{
			// If this is the first key string we've accounted for, then
			// we can just set the keyboard accelerator string equal to it.
			keyboardAcceleratorString = keyName;
		}
		else
		{
			// Otherwise, if we already had an existing keyboard accelerator string,
			// then we'll use the formatting string to join strings together
			// to combine it with the new key string.
			string joiningFormatString;
			// UNO TODO
			// (DXamlCore.GetCurrent().GetLocalizedResourceString(KEYBOARD_ACCELERATOR_TEXT_JOIN, joiningFormatString.ReleaseAndGetAddressOf()));
			joiningFormatString = "{0} + {1}";

			keyboardAcceleratorString = string.Format(CultureInfo.InvariantCulture, joiningFormatString, keyboardAcceleratorString, keyName);
		}
	}
}
