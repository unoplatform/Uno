namespace Windows.UI.Xaml.Controls;

/// <summary>
/// Defines constants that specify the default button on a content dialog.
/// </summary>
/// <remarks>
/// This enumeration is used by the ContentDialog.DefaultButton property.
/// The default button responds to the Enter key and has a different visual style.
/// </remarks>
public enum ContentDialogButton
{
	/// <summary>
	/// No button is specified as the default.
	/// </summary>
	None,

	/// <summary>
	/// The primary button is the default.
	/// </summary>
	Primary,
	
	/// <summary>
	/// The secondary button is the default.
	/// </summary>
	Secondary,
	
	/// <summary>
	/// The close button is the default.
	/// </summary>
	Close,
}
