#nullable disable

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class ImageIcon : IconElement
	{
		private Image? m_rootImage = null;

		public ImageIcon()
		{
			Loaded += ImageIcon_Loaded;
		}

		private void ImageIcon_Loaded(object sender, RoutedEventArgs e)
		{
#if HAS_UNO
			// Uno specific: Called to ensure OnApplyTemplate runs
			EnsureInitialized();
#endif
		}

		protected override void OnApplyTemplate()
		{
			if (VisualTreeHelper.GetChild(this, 0) is Grid grid)
			{
				var image = (Image)VisualTreeHelper.GetChild(grid, 0);
				image.Source = Source;
				m_rootImage = image;
			}
			else
			{
				m_rootImage = null;
			}

			_applyTemplateCalled = true;
		}

		private void OnSourcePropertyChanged(DependencyPropertyChangedEventArgs agrs)
		{
			if (m_rootImage is { } image)
			{
				image.Source = Source;
			}
		}
	}
}
