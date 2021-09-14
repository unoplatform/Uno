using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Uno.UI.Controls
{
	public interface INativeNavigationBar
	{
		/// <summary>
		/// Configures the <see cref="INativeNavigationBar" /> for a given page <see cref="UIViewController" />.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		void PageCreated(UIViewController pageController);

		/// <summary>
		/// Cleans up the <see cref="INativeNavigationBar" /> of a page <see cref="UIViewController" />.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		void PageDestroyed(UIViewController pageController);

		/// <summary>
		/// When a page's <see cref="UIViewController" /> will appear, connects the <see cref="INativeNavigationBar" /> to the navigation controller.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		void PageWillAppear(UIViewController pageController);

		/// <summary>
		/// When a page's <see cref="UIViewController" /> did disappear, disconnects the <see cref="INativeNavigationBar" /> from the navigation controller.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		void PageDidDisappear(UIViewController pageController);

		/// <summary>
		/// When a page's <see cref="UIViewController" /> will disappear, disconnects the <see cref="INativeNavigationBar" /> from the navigation controller.
		/// </summary>
		/// <param name="pageController">The controller of the page</param>
		void PageWillDisappear(UIViewController pageController);

		/// <summary>
		/// Set navigation bar properties for the Page about to become visible.
		/// </summary>
		/// <param name="navigationBar">The navigation bar of the page about to become visible</param>
		void PopViewController(UINavigationBar navigationBar);
	}
}
