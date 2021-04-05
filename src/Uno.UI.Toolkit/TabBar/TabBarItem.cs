using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Toolkit
{
	public partial class TabBarItem : TabBarItemBase
	{
		public IconElement Icon
		{
			get { return (IconElement)GetValue(IconProperty); }
			set { SetValue(IconProperty, value); }
		}

		public static readonly DependencyProperty IconProperty =
			DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(TabBarItem), new PropertyMetadata(null));

		public IconElement SelectedIcon
		{
			get { return (IconElement)GetValue(SelectedIconProperty); }
			set { SetValue(SelectedIconProperty, value); }
		}

		public static readonly DependencyProperty SelectedIconProperty =
			DependencyProperty.Register(nameof(SelectedIcon), typeof(IconElement), typeof(TabBarItem), new PropertyMetadata(null));
	}
}
