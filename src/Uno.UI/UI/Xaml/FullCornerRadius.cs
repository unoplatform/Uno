#nullable disable

using Windows.Foundation;

namespace Windows.UI.Xaml;

internal partial record struct FullCornerRadius
(
	NonUniformCornerRadius Outer,
	NonUniformCornerRadius Inner
)
{
	public static FullCornerRadius None { get; }

	public bool IsEmpty => Outer.IsEmpty && Inner.IsEmpty;
}
