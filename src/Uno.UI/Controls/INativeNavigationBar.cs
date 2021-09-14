#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Windows.UI.Xaml;

namespace Uno.UI.Controls
{
	public interface INativeNavigationBar
	{
		/// <summary>
		/// Connects the <see cref="INativeNavigationBar"/> to the navigation controller. 
		/// </summary>
		/// <param name="navigationBar">The navigation bar of the page's controller</param>
		void SetNavigationBar(UINavigationBar? navigationBar);

		/// <summary>
		/// Set navigation bar properties for the page that is about to become visible.
		/// </summary>
		/// <param name="navigationBar">The navigation bar for the page that is about to become visible</param>
		void ResetNavigationBar(UINavigationBar? navigationBar);

		/// <summary>
		/// Configures the <see cref="INativeNavigationBar" /> for a given page <see cref="UIViewController" />.
		/// </summary>
		/// <param name="navigationItem">The navigation item of the page's controller</param>
		void SetNavigationItem(UINavigationItem? navigationItem);

		/// <summary>
		/// Visibility of the implementing view
		/// </summary>
		Visibility Visibility { get; set; }
	}
}
