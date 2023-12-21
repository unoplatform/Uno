namespace Windows.UI.Xaml.Controls;

/// <summary>
/// Provides data for the Closed event.
/// </summary>
public partial class ContentDialogClosedEventArgs
{
	internal ContentDialogClosedEventArgs(ContentDialogResult result)
	{
		Result = result;
	}

	/// <summary>
	/// Gets the ContentDialogResult of the button click event.
	/// </summary>
	public ContentDialogResult Result { get; }
}
