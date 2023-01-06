﻿using Windows.UI.Xaml.Controls;
using Uno.UI;
using Uno.UI.Samples.Controls;

namespace UITests.Shared.Windows_UI_Xaml_Controls.ToolTip
{
	[SampleControlInfo("ToolTip", "TextOnlyToolTipSample")]
	public sealed partial class TextOnlyToolTipSample : Page
	{
		public TextOnlyToolTipSample()
		{
#if !WINDOWS_UWP
			FeatureConfiguration.ToolTip.UseToolTips = true;
#endif
			this.InitializeComponent();
		}
	}
}
