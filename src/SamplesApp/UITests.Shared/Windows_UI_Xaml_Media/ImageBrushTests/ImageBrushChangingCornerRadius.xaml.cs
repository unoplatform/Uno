#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uno.UI.Samples.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Uno.UI.Samples.UITests.ImageBrushTestControl
{
	[SampleControlInfo("Brushes", "ImageBrushChangingCornerRadius")]
	public sealed partial class ImageBrushChangingCornerRadius : UserControl
	{
		public ImageBrushChangingCornerRadius()
		{
			this.InitializeComponent();
		}

		int n = 0;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			n++;
			MyBorder.CornerRadius = CornerRadiusHelper.FromUniformRadius(n * 5);
		}
	}
}
