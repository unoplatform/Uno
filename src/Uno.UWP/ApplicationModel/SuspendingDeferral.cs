#nullable enable

using System;
using System.Diagnostics;
using Windows.Foundation;

namespace Windows.ApplicationModel;

/// <summary>
/// Manages a delayed app suspending operation.
/// </summary>
public sealed partial class SuspendingDeferral : ISuspendingDeferral
{
	private readonly DeferralCompletedHandler? _handler;

	internal SuspendingDeferral(DeferralCompletedHandler handler) =>
		_handler = handler;

	/// <summary>
	/// Notifies the operating system that the app has saved its data and is ready to be suspended.
	/// </summary>
	public void Complete()
	{
		_handler?.Invoke();
	}
}
