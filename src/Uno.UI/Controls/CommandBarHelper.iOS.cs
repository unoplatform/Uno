#nullable enable
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UIKit;
using Uno.Extensions;

namespace Uno.UI.Controls
{
	public static class CommandBarHelper
	{
		/// <summary>
		/// Finds and configures the <see cref="CommandBar" /> for a given page <see cref="UIViewController" />.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		public static void PageCreated(UIViewController pageController)
		{
			var topNativeNavBar = pageController.FindNativeNavigationBar();
			if (topNativeNavBar == null)
			{
				// The default CommandBar style contains information that might be relevant to all pages, including those without a CommandBar.
				// For example the Uno.UI.Toolkit.CommandBarExtensions.BackButtonTitle attached property is often set globally to "" through
				// a default CommandBar style in order to remove the back button text throughout an entire application.
				// In order to leverage this information, we create a new CommandBar instance that only exists to "render" the NavigationItem.
				// Since Uno 3.0 objects which are not part of the Visualtree does not get the Global Styles applied. Hence the fact we are manually applying it here.
				topNativeNavBar = new CommandBar
				{
					Style = Application.Current.Resources[typeof(CommandBar)] as Style
				};
			}

			// Hook CommandBar to NavigationItem
			topNativeNavBar.SetNavigationItem(pageController.NavigationItem);
		}

		/// <summary>
		/// Cleanups the <see cref="CommandBar" /> of a page <see cref="UIViewController" />.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		public static void PageDestroyed(UIViewController pageController)
		{
			if (pageController.FindNativeNavigationBar() is { } topNativeNavBar)
			{
				topNativeNavBar.SetNavigationItem(null);
			}
		}

		/// <summary>
		/// When a page <see cref="UIViewController" /> will appear, connects the <see cref="CommandBar" /> to the navigation controller.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		public static void PageWillAppear(UIViewController pageController)
		{
			var topNativeNavBar = pageController.FindNativeNavigationBar();
			if (topNativeNavBar != null)
			{
				if (topNativeNavBar.Visibility == Visibility.Visible)
				{
					topNativeNavBar.SetNavigationBar(pageController.NavigationController.NavigationBar);

					// When the CommandBar is visible, we need to call SetNavigationBarHidden
					// AFTER it has been rendered. Otherwise, it causes a bug introduced
					// in iOS 11 in which the BackButtonIcon is not rendered properly.
					pageController.NavigationController.SetNavigationBarHidden(hidden: false, animated: true);
				}
				else
				{
					// Even if the CommandBar should technically be collapsed,
					// we don't hide it using the NavigationController because it
					// automatically disables the back gesture.
					// In order to visually hide it, the CommandBarRenderer
					// will hide the native view using the UIView.Hidden property.
					pageController.NavigationController.SetNavigationBarHidden(hidden: false, animated: true);

					topNativeNavBar.SetNavigationBar(pageController.NavigationController.NavigationBar);
				}
			}
			else // No CommandBar
			{
				pageController.NavigationController.SetNavigationBarHidden(true, true);
			}
		}

		/// <summary>
		/// When a page <see cref="UIViewController" /> did disappear, disconnects the <see cref="CommandBar" /> from the navigation controller.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		public static void PageDidDisappear(UIViewController pageController)
		{
			if (pageController.FindNativeNavigationBar() is { } topNativeNavBar)
			{
				// Set the native navigation bar to null so it does not render when the page is not visible
				topNativeNavBar.SetNavigationBar(null);

			}
		}

		public static void PageWillDisappear(UIViewController pageController)
		{
			if (pageController.FindNativeNavigationBar() is { } topNativeNavBar)
			{
				// Set the native navigation bar to null so it does not render when the page is not visible
				topNativeNavBar.SetNavigationBar(null);

			}
		}

		private static INativeNavigationBar? FindNativeNavigationBar(this UIViewController controller)
		{
			return (controller.View as Page)?.TopAppBar as INativeNavigationBar
				?? controller.View.FindSubviewsOfType<INativeNavigationBar>().Safe().FirstOrDefault();
		}
	}
}
