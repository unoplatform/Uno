﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Uno.UI.Tests.Windows_UI_Xaml_Data.BindingTests.Controls
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Binding_Xaml_Object_With_Common_Properties : Page
	{
		public Binding_Xaml_Object_With_Common_Properties()
		{
			this.InitializeComponent();
		}
	}

	public sealed class Binding_Xaml_Object_With_Common_Properties_Return_Value_Converter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value;
		}
	}
}
