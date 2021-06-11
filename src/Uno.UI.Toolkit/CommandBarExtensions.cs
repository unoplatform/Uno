using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Toolkit
{
#if __IOS__
	[global::Foundation.PreserveAttribute(AllMembers = true)]
#elif __ANDROID__
	[Android.Runtime.PreserveAttribute(AllMembers = true)]
#endif
	public static class CommandBarExtensions
	{
		#region Subtitle

		public static DependencyProperty SubtitleProperty { get; } =
			DependencyProperty.RegisterAttached(
				"Subtitle",
				typeof(string),
				typeof(CommandBarExtensions),
				new PropertyMetadata(null)
			);

		public static void SetSubtitle(this CommandBar commandBar, string subtitle)
		{
			commandBar.SetValue(SubtitleProperty, subtitle);
		}

		public static string GetSubtitle(this CommandBar commandBar)
		{
			return (string)commandBar.GetValue(SubtitleProperty);
		}

		#endregion

		#region NavigationButton

		public static DependencyProperty NavigationButtonProperty { get; } =
			DependencyProperty.RegisterAttached(
				"NavigationButton",
				typeof(AppBarButton),
				typeof(CommandBarExtensions),
#if XAMARIN
				new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext)
#else
				new PropertyMetadata(null)
#endif
			);

		public static void SetNavigationButton(this CommandBar commandBar, AppBarButton navigationButton)
		{
			commandBar.SetValue(NavigationButtonProperty, navigationButton);
		}

		public static AppBarButton GetNavigationButton(this CommandBar commandBar)
		{
			return (AppBarButton)commandBar.GetValue(NavigationButtonProperty);
		}

		#endregion

		#region NavigationButtonMode

		public static DependencyProperty NavigationButtonModeProperty { get; } =
			DependencyProperty.RegisterAttached(
				"NavigationButtonMode",
				typeof(NavigationButtonMode),
				typeof(CommandBarExtensions),
				new PropertyMetadata(NavigationButtonMode.Native)
			);

		public static void SetNavigationButtonMode(this CommandBar commandBar, NavigationButtonMode navigationButtonMode)
		{
			commandBar.SetValue(NavigationButtonModeProperty, navigationButtonMode);
		}

		public static AppBarButton GetNavigationButtonMode(this CommandBar commandBar)
		{
			return (AppBarButton)commandBar.GetValue(NavigationButtonModeProperty);
		}
		#endregion

		#region CurrentPageTitle

		public static DependencyProperty CurrentPageTitleProperty { get; } =
			DependencyProperty.RegisterAttached(
				"CurrentPageTitle",
				typeof(string),
				typeof(CommandBarExtensions),
				new PropertyMetadata(null)
			);

		public static void SetCurrentPageTitle(this CommandBar commandBar, string currentPageTitle)
		{
			commandBar.SetValue(CurrentPageTitleProperty, currentPageTitle);
		}

		public static string GetCurrentPageTitle(this CommandBar commandBar)
		{
			return (string)commandBar.GetValue(CurrentPageTitleProperty);
		}

		#endregion
	}

	public enum NavigationButtonMode
	{
		Native,
		Override,
	}

}
