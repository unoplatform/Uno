using System;

namespace Windows.UI.Xaml.Controls;

/// <summary>
/// Represents a deferral that can be used by an app
/// to respond asynchronously to the closing event of the ContentDialog.
/// </summary>
public partial class ContentDialogButtonClickDeferral
{
	private readonly Action _deferralAction;

	internal ContentDialogButtonClickDeferral(Action deferralAction)
	{
		_deferralAction = deferralAction;
	}

	/// <summary>
	/// Notifies the system that the app has finished processing the closing event.
	/// </summary>
	public void Complete() => _deferralAction?.Invoke();
}
