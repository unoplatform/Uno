namespace Windows.UI.Xaml.Controls;

/// <summary>
/// Specifies identifiers to indicate the return value of a ContentDialog.
/// </summary>
public enum ContentDialogResult
{
	/// <summary>
	/// No button was tapped.
	/// </summary>
	None,

	/// <summary>
	/// The primary button was tapped by the user.
	/// </summary>
	Primary,

	/// <summary>
	/// The secondary button was tapped by the user.
	/// </summary>
	Secondary,
}
