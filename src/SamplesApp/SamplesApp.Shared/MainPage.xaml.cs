using System.Threading.Tasks;
using SampleControl.Presentation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SamplesApp
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
			this.Loaded += MainPage_Loaded;
			
		}

		private async void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			await Task.Delay(500);
			var transform = ContentElement.TransformToVisual(Window.Current.Content);
			var point = transform.TransformPoint(new Windows.Foundation.Point(0, 0));
		}
	}
}
