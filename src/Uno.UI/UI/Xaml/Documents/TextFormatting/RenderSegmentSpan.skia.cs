#nullable disable

namespace Windows.UI.Xaml.Documents.TextFormatting
{
	/// <summary>
	/// Represents a span of a segment that is rendered on a render line.
	/// </summary>
	internal record RenderSegmentSpan(Segment Segment, int GlyphsStart, int GlyphsLength, int TrailingSpaces, float CharacterSpacing, float Width, float WidthWithoutTrailingSpaces);
}
