using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

/// <summary>
/// Represents a deferral that can be used by an app to respond
/// asynchronously to the closing event of the ContentDialog.
/// </summary>
public partial class ContentDialogClosingDeferral
{
	private readonly DeferralCompletedHandler _handler;

	internal ContentDialogClosingDeferral(DeferralCompletedHandler handler) =>
		_handler = handler;

	/// <summary>
	/// Notifies the system that the app has finished processing the closing event.
	/// </summary>
	public void Complete() => _handler?.Invoke();
}
