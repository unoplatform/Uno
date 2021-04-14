using System.Windows.Input;
using System.Xml.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Uno.UI.Toolkit
{
	public abstract partial class TabBarItemBase : ListViewItem
	{
		protected override void OnPointerReleased(Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
		{
			var command = Command;
			if (command == null)
			{
				return;
			}

			var commandParameter = CommandParameter;
			if (command.CanExecute(commandParameter))
			{
				command.Execute(commandParameter);
			}
		}
	}
}
