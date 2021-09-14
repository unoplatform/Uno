#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Uno.UI.Controls;

namespace Windows.UI.Xaml.Controls
{
	partial class CommandBar : INativeNavigationBar
	{
		public void PageCreated(UIViewController pageController) => SetNavigationItem(pageController.NavigationItem);

		public void PageDestroyed(UIViewController pageController) => SetNavigationItem(null);

		public void PageDidDisappear(UIViewController pageController) => SetNavigationBar(null);

		public void PageWillAppear(UIViewController pageController)
		{
			if (Visibility == Visibility.Visible)
			{
				SetNavigationBar(pageController.NavigationController.NavigationBar);

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

				SetNavigationBar(pageController.NavigationController.NavigationBar);
			}
		}
		public void PageWillDisappear(UIViewController pageController) => SetNavigationBar(null);

		public void PopViewController(UINavigationBar navigationBar)
		{
			if (this.GetRenderer(() => (CommandBarRenderer?)null) is { } renderer)
			{
				// Set navigation bar properties for page about to become visible. This gives a nice animation and works around bug on 
				// iOS 11.2 where TitleTextAttributes aren't updated properly (https://openradar.appspot.com/37567828)
				renderer.Native = navigationBar;
			}
		}

		private void SetNavigationBar(UINavigationBar? navigationBar)
		{
			this.GetRenderer(() => new CommandBarRenderer(this)).Native = navigationBar;
		}

		private void SetNavigationItem(UINavigationItem? navigationItem)
		{
			this.GetRenderer(() => new CommandBarNavigationItemRenderer(this)).Native = navigationItem;
		}
	}
}
