using Uno;

namespace Windows.UI.Xaml.Controls.Primitives
{
	public partial class AppBarToggleButtonTemplateSettings : global::Windows.UI.Xaml.DependencyObject
	{
		public double KeyboardAcceleratorTextMinWidth
		{
			get => (double)GetValue(KeyboardAcceleratorTextMinWidthProperty);
			internal set => SetValue(KeyboardAcceleratorTextMinWidthProperty, value);
		}

		internal static DependencyProperty KeyboardAcceleratorTextMinWidthProperty { get; } =
			DependencyProperty.Register("KeyboardAcceleratorTextMinWidth", typeof(double), typeof(AppBarToggleButtonTemplateSettings), new FrameworkPropertyMetadata(0.0));
	}
}
