#nullable disable

using Uno.UI.Samples.Controls;
using Windows.UI.Xaml.Controls;
using Uno.UI.Samples.Presentation.SamplePages;

namespace Uno.UI.Samples.Content.UITests.TextBoxControl
{
	[SampleControlInfo("TextBox", "Input_Simple", typeof(TextBoxViewModel))]
	public sealed partial class Input_Simple : UserControl
	{
		public Input_Simple()
		{
			this.InitializeComponent();
		}
	}
}
