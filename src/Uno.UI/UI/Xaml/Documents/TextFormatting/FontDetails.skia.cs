using HarfBuzzSharp;
using SkiaSharp;

namespace Microsoft.UI.Xaml.Documents.TextFormatting;

internal record FontDetails(SKFont SKFont, float SKFontSize, float SKFontScaleX, SKFontMetrics SKFontMetrics, SKTypeface SKTypeface, Font Font, Face Face);
