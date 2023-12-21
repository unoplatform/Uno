using Uno;

namespace Windows.UI.Xaml.Controls;

public enum ContentDialogPlacement
{
	/// <summary>
	/// The dialog is rooted in the PopupRoot element of the XAML Window.
	/// </summary>
	Popup,

	/// <summary>
	/// If the dialog has a parent element, the dialog is rooted
	/// in the parent's visual tree. Otherwise, it falls back
	/// to the Popup behavior.
	/// </summary>
	InPlace,
}
