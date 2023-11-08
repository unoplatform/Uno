using System;

namespace Windows.UI.Xaml.Controls;

/// <summary>
/// Provides data for the button click events.
/// </summary>
public partial class ContentDialogButtonClickEventArgs
{
	private readonly Action<ContentDialogButtonClickEventArgs> _deferralAction;

	internal ContentDialogButtonClickEventArgs(Action<ContentDialogButtonClickEventArgs> deferralAction)
	{
		_deferralAction = deferralAction;

	}

	/// <summary>
	/// Gets or sets a value that can cancel the button click.
	/// A true value for Cancel cancels the default behavior.
	/// </summary>
	public bool Cancel { get; set; }
	
	internal ContentDialogButtonClickDeferral Deferral { get; private set; }

	/// <summary>
	/// Gets a ContentDialogButtonClickDeferral that the app can use to respond
	/// asynchronously to a button click event.
	/// </summary>
	/// <returns>
	/// A ContentDialogButtonClickDeferral that the app can use
	/// to respond asynchronously to a button click event.
	/// </returns>
	public ContentDialogButtonClickDeferral GetDeferral() =>
		Deferral = new ContentDialogButtonClickDeferral(() => _deferralAction(this));
}
