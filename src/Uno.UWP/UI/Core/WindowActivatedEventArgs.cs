namespace Windows.UI.Core
{
	/// <summary>
	/// Contains the windows activation state information returned by the CoreWindow.Activated event.
	/// </summary>
	public sealed partial class WindowActivatedEventArgs
	{
		internal WindowActivatedEventArgs(CoreWindowActivationState windowActivationState)
		{
			WindowActivationState = windowActivationState;
		}

		/// <summary>
		/// Specifies the property that gets or sets whether the window activation event was handled.
		/// </summary>
		public bool Handled { get; set; }

		/// <summary>
		/// Gets the activation state of the window at the time the Activated event was raised.
		/// </summary>
		public CoreWindowActivationState WindowActivationState { get; }
	}
}
