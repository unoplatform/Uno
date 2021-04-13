using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Toolkit
{
	public partial class TabBarItem : TabBarItemBase
	{
		public TabBarItem()
		{
			DefaultStyleKey = typeof(TabBarItem);
		}

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			UpdateLocalVisualState();
		}

		private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			var property = args.Property;
			if (property == IconProperty)
			{
				UpdateLocalVisualState();
			}
		}

		private void UpdateLocalVisualState()
		{
			bool shouldShowIcon = ShouldShowIcon();
			bool shouldShowContent = ShouldShowContent();

			UpdateVisualStateForIconAndContent(shouldShowIcon, shouldShowContent);
		}

		private void UpdateVisualStateForIconAndContent(bool showIcon, bool showContent)
		{
			var stateName = showIcon ? (showContent ? "IconOnTop" : "IconOnly") : "ContentOnly";
			VisualStateManager.GoToState(this, stateName, false /*useTransitions*/);
		}

		private bool ShouldShowIcon()
		{
			return Icon != null;
		}

		private bool ShouldShowContent()
		{
			return Content != null;
		}
	}
}
