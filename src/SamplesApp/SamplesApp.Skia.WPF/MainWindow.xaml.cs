﻿using SkiaSharp.Views.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Uno.UI.Skia.Platform;

namespace SamplesApp.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var host = new WpfHost(Dispatcher, () => new SamplesApp.App());
			root.Content = host;
			SampleControl.Presentation.SampleChooserViewModel.TakeScreenShot = filePath => host.TakeScreenshot(filePath);
		}
	}
}
