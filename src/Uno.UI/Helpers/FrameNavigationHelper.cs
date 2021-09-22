#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Uno.UI.Helpers
{
	public static class FrameNavigationHelper
	{
		public static PageStackEntry? GetCurrentEntry(Frame? frame) => frame?.CurrentEntry;

		public static Page? GetInstance(PageStackEntry? entry) => entry?.Instance;

		public static NavigationEventArgs CreateNavigationEventArgs(
			object? content,
			NavigationMode navigationMode,
			NavigationTransitionInfo? navigationTransitionInfo,
			object? parameter,
			Type sourcePageType,
			Uri? uri
		) => new NavigationEventArgs(content, navigationMode, navigationTransitionInfo, parameter, sourcePageType, uri);
	}
}
