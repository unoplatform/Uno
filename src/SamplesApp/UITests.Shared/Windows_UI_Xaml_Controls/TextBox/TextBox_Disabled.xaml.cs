﻿using System;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UITests.Shared.Windows_UI_Xaml_Controls.TextBoxTests
{
	[SampleControlInfo("TextBox", "TextBox_Disabled", description: "Illustrates that disabling TextBox actually disables it.")]
	public sealed partial class TextBox_Disabled : UserControl
	{
		public TextBox_Disabled()
		{
			this.InitializeComponent();
		}

		private static void DisableOnf_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
		{
			if (args.NewText.EndsWith("f"))
			{
				args.Cancel = true;
				sender.IsEnabled = false;
			}
		}
	}
}
