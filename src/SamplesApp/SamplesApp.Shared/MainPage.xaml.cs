using SampleControl.Presentation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SamplesApp
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		private void myButton_Click(object sender, RoutedEventArgs e)
		{
			myButton.Content = "Clicked";

			var newWindow = new Window();
			newWindow.Content = new Button() { Content = "New window!" };
			newWindow.Activate();
		}
	}
}
