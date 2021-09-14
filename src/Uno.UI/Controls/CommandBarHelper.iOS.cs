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
			topNativeNavBar.PageCreated(pageController);
		}

		/// <summary>
		/// Cleanups the <see cref="CommandBar" /> of a page <see cref="UIViewController" />.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		public static void PageDestroyed(UIViewController pageController)
		{
			if (pageController.FindNativeNavigationBar() is { } topNativeNavBar)
			{
				topNativeNavBar.PageDestroyed(pageController);
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
				topNativeNavBar.PageWillAppear(pageController);
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
				topNativeNavBar.PageDidDisappear(pageController);

			}
		}

		public static void PageWillDisappear(UIViewController pageController)
		{
			if (pageController.FindNativeNavigationBar() is { } topNativeNavBar)
			{
				// Set the native navigation bar to null so it does not render when the page is not visible
				topNativeNavBar.PageWillDisappear(pageController);

			}
		}

		private static INativeNavigationBar? FindNativeNavigationBar(this UIViewController controller)
		{
			return (controller.View as Page)?.TopAppBar as INativeNavigationBar
				?? controller.View.FindSubviewsOfType<INativeNavigationBar>().Safe().FirstOrDefault();
		}
	}
}
