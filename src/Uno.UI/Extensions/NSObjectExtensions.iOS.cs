﻿using Uno.Extensions;
using System;
using Uno.Foundation.Logging;
using Windows.UI.Core;

using Foundation;
using UIKit;
using CoreGraphics;

namespace Foundation
{
	public static class NSObjectExtensions
	{
		/// <summary>
		/// Validates the call to the Dispose method.
		/// </summary>
		/// <param name="view">The view to be disposed.</param>
		/// <param name="disposing">True if called from View.Dispose, False if called from the finalizer.</param>
		/// <returns>True if the dispose method can continue executing, otherwise, false.</returns>
		/// <remarks>This method will requeue the call to Dispose on the UIThread if called from the finalizer.</remarks>
		public static bool ValidateDispose(this NSObject view, bool disposing)
		{
			if (!disposing)
			{
				view.Log()
					.ErrorFormat(
						"The instance {0}/{1:X8} has not been disposed properly, re-scheduling. This usually indicates that the creator of this view did not dispose it properly.",
						view.GetType(),
						view.Handle
					);

				// Make sure the instance is kept alive
				GC.ReRegisterForFinalize(view);

				// We cannot execute the content of the dispose actions off of the UI Thread.
				// So we reschedule the dispose on the UI Thread to avoid concurrency issues.
				_ = CoreDispatcher.Main.RunIdleAsync(_ =>
				{

					view.Dispose();
				});

				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
