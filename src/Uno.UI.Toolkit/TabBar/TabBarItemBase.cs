using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace Uno.UI.Toolkit
{
	public partial class TabBarItemBase : ListViewItem
	{
		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		public static DependencyProperty CommandProperty { get; } =
			DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(TabBarItemBase), new PropertyMetadata(null));

		public object CommandParameter
		{
			get { return (object)GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		public static DependencyProperty CommandParameterProperty { get; } =
			DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(TabBarItemBase), new PropertyMetadata(null));
	}
}
