﻿using System.Linq;
using System.Threading.Tasks;
using Uno.Helpers;
using Uno.UI.RuntimeTests.Helpers;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using FluentAssertions;
using static Private.Infrastructure.TestServices;
using System.Collections.Generic;

#if __SKIA__
using SkiaSharp;
using Microsoft.UI.Xaml.Documents.TextFormatting;
#endif

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Controls
{
	[TestClass]
	[RunsOnUIThread]
	public class Given_TextBlock
	{
#if __SKIA__
		[TestMethod]
		// It looks like CI might not have any installed fonts with Chinese characters which could cause the test to fail
		[Ignore("Fails on CI")]
		public async Task Check_FontFallback()
		{
			var SUT = new TextBlock { Text = "示例文本", FontSize = 24 };
			var skFont = FontDetailsCache.GetFont(SUT.FontFamily?.Source, (float)SUT.FontSize, SUT.FontWeight, SUT.FontStyle).SKFont;
			Assert.IsFalse(skFont.ContainsGlyph(SUT.Text[0]));

			var fallbackFont = SKFontManager.Default.MatchCharacter(SUT.Text[0]);

			Assert.IsTrue(fallbackFont.ContainsGlyph(SUT.Text[0]));

			var expected = new TextBlock { Text = "示例文本", FontSize = 24, FontFamily = new FontFamily(fallbackFont.FamilyName) };

			await UITestHelper.Load(SUT);
			var screenshot1 = await UITestHelper.ScreenShot(SUT);

			await UITestHelper.Load(expected);
			var screenshot2 = await UITestHelper.ScreenShot(expected);

			Assert.AreEqual(screenshot2.Width, screenshot1.Width);
			Assert.AreEqual(screenshot2.Height, screenshot1.Height);

			await ImageAssert.AreSimilarAsync(screenshot1, screenshot2, imperceptibilityThreshold: 0.15);
		}
#endif

		[TestMethod]
		public async Task Check_TextDecorations_Binding()
		{
			var SUT = new TextDecorationsBinding();
			WindowHelper.WindowContent = SUT;
			await WindowHelper.WaitForIdle();
			Assert.AreEqual(TextDecorations.Strikethrough, SUT.textBlock1.TextDecorations);
			Assert.AreEqual(TextDecorations.Underline, SUT.textBlock2.TextDecorations);
			Assert.AreEqual(TextDecorations.Strikethrough, SUT.textBlock3.TextDecorations);
			Assert.AreEqual(TextDecorations.None, SUT.textBlock4.TextDecorations);
			Assert.AreEqual(TextDecorations.Strikethrough, SUT.textBlock5.TextDecorations);
			Assert.AreEqual(TextDecorations.None, SUT.textBlock6.TextDecorations);
		}

		[TestMethod]
		public void Check_ActualWidth_After_Measure()
		{
			var SUT = new TextBlock { Text = "Some text" };
			var size = new Size(1000, 1000);
			SUT.Measure(size);
			Assert.IsTrue(SUT.DesiredSize.Width > 0);
			Assert.IsTrue(SUT.DesiredSize.Height > 0);

			// For simplicity, currently we don't insist on a specific value here. The exact details of text measurement are highly
			// platform-specific, and additionally on UWP the ActualWidth and DesiredSize.Width are not exactly the same, a subtlety Uno
			// currently doesn't try to replicate.
			Assert.IsTrue(SUT.ActualWidth > 0);
			Assert.IsTrue(SUT.ActualHeight > 0);
		}

		[TestMethod]
		public void Check_ActualWidth_After_Measure_Collapsed()
		{
			var SUT = new TextBlock { Text = "Some text", Visibility = Visibility.Collapsed };
			var size = new Size(1000, 1000);
			SUT.Measure(size);
			Assert.AreEqual(0, SUT.DesiredSize.Width);
			Assert.AreEqual(0, SUT.DesiredSize.Height);

			Assert.AreEqual(0, SUT.ActualWidth);
			Assert.AreEqual(0, SUT.ActualHeight);
		}

		[TestMethod]
		public void Check_Text_When_Having_Inline_Text_In_Span()
		{
			var SUT = new InlineTextInSpan();
			var panel = (StackPanel)SUT.Content;
			var span = (Span)((TextBlock)panel.Children.Single()).Inlines.Single();
			var inlines = span.Inlines;
			Assert.AreEqual(3, inlines.Count);
			Assert.AreEqual("Where ", ((Run)inlines[0]).Text);
			Assert.AreEqual("did", ((Run)((Italic)inlines[1]).Inlines.Single()).Text);
			Assert.AreEqual(" my text go?", ((Run)inlines[2]).Text);
		}

		[TestMethod]
		public void When_Null_FontFamily()
		{
			var SUT = new TextBlock { Text = "Some text", FontFamily = null };
			WindowHelper.WindowContent = SUT;
			SUT.Measure(new Size(1000, 1000));
		}

		[TestMethod]
		public async Task Check_Single_Character_Run_With_Wrapping_Constrained()
		{
#if __MACOS__
			Assert.Inconclusive("https://github.com/unoplatform/uno/issues/626");
#endif

			var SUT = new TextBlock
			{
				Inlines = {
					new Run { Text = "", FontSize = 16, CharacterSpacing = 18 }
				},
				TextWrapping = TextWrapping.Wrap,
				FontSize = 16,
				CharacterSpacing = 18
			};

			WindowHelper.WindowContent = new Border
			{
				Width = 10,
				Height = 10,
				Child = SUT
			};

			await WindowHelper.WaitForIdle();

			Assert.AreNotEqual(0, SUT.DesiredSize.Width);
			Assert.AreNotEqual(0, SUT.DesiredSize.Height);

			Assert.AreNotEqual(0, SUT.ActualWidth);
			Assert.AreNotEqual(0, SUT.ActualHeight);
		}

		[TestMethod]
		[RunsOnUIThread]
		public async Task When_Multiline_Wrapping_LongWord_Then_Space_Then_Word()
		{
			var SUT = new TextBlock
			{
				Width = 150,
				TextWrapping = TextWrapping.Wrap,
				Text = "abcdefghijklmnopqrstuvwxyzabcdefg"
			};

			WindowHelper.WindowContent = SUT;

			await WindowHelper.WaitForLoaded(SUT);
			await WindowHelper.WaitForIdle();

			var height = SUT.ActualHeight;

			SUT.Text += " a";
			await WindowHelper.WaitForIdle();

			Assert.AreEqual(height, SUT.ActualHeight);
		}

		[TestMethod]
		[RunsOnUIThread]
		public async Task When_Multiline_Wrapping_LeadingSpaces()
		{
			var SUT = new TextBlock
			{
				Width = 150,
				TextWrapping = TextWrapping.Wrap,
				Text = "initial"
			};

			WindowHelper.WindowContent = new Border
			{
				Child = SUT,
				BorderBrush = new SolidColorBrush(Colors.Pink),
				BorderThickness = new Thickness(1)
			};

			await WindowHelper.WaitForLoaded(SUT);
			await WindowHelper.WaitForIdle();

			var height = SUT.ActualHeight;

			SUT.Text = new string(' ', 120);
			await WindowHelper.WaitForIdle();

			Assert.AreEqual(height, SUT.ActualHeight);
		}

		[TestMethod]
#if __IOS__
		[Ignore("Fails")]
#endif
		public async Task When_Multiline_Wrapping_Text_Ends_In_Too_Many_Spaces()
		{
			var SUT = new TextBlock
			{
				TextWrapping = TextWrapping.Wrap,
				Text = "hello world"
			};

			WindowHelper.WindowContent = new Border
			{
				Width = 150,
				Child = SUT
			};

			await WindowHelper.WaitForIdle();

			var height = SUT.ActualHeight;

			SUT.Text = "mmmmmmmmm               ";
			await WindowHelper.WaitForIdle();

			// Trailing space shouldn't wrap
			Assert.AreEqual(height, SUT.ActualHeight);
		}

		[TestMethod]
		[RunsOnUIThread]
#if !__SKIA__
		[Ignore("Only skia handled trailing newlines correctly for now.")]
#endif
		public async Task When_Text_Ends_In_CarriageReturn()
		{
			var SUT0 = new TextBlock();
			var SUT1 = new TextBlock();

			SUT0.Text = "text";
			SUT1.Text = "text\r";

			var sp = new StackPanel
			{
				Children =
				{
					new Border
					{
						Child = SUT0,
						BorderBrush = new SolidColorBrush(Colors.Chartreuse)
					},
					new Border
					{
						Child = SUT1,
						BorderBrush = new SolidColorBrush(Colors.Pink)
					}
				}
			};

			WindowHelper.WindowContent = sp;
			await WindowHelper.WaitForIdle();

			SUT1.ActualHeight.Should().BeGreaterThan(SUT0.ActualHeight);
		}

		[TestMethod]
		[RunsOnUIThread]
#if !__SKIA__
		[Ignore("Only skia handled trailing newlines correctly for now.")]
#endif
		public async Task When_Text_Ends_In_CarriageReturn2()
		{
			var SUT0 = new TextBlock();
			var SUT1 = new TextBlock();
			var SUT2 = new TextBlock();
			var SUT3 = new TextBlock();

			SUT1.Text = "\r";
			SUT2.Text = "\r\r";
			SUT3.Text = "\r\r\r";

			var sp = new StackPanel
			{
				Children =
				{
					new Border
					{
						Child = SUT0,
						BorderBrush = new SolidColorBrush(Colors.Chartreuse)
					},
					new Border
					{
						Child = SUT1,
						BorderBrush = new SolidColorBrush(Colors.Pink)
					},
					new Border
					{
						Child = SUT2,
						BorderBrush = new SolidColorBrush(Colors.Brown)
					},
					new Border
					{
						Child = SUT3,
						BorderBrush = new SolidColorBrush(Colors.Yellow)
					}
				}
			};

			WindowHelper.WindowContent = sp;
			await WindowHelper.WaitForIdle();

			SUT1.ActualHeight.Should().BeGreaterThan(SUT0.ActualHeight);
			SUT2.ActualHeight.Should().BeGreaterThan(SUT1.ActualHeight);
			SUT3.ActualHeight.Should().BeGreaterThan(SUT2.ActualHeight);
		}

		[TestMethod]
		[RunsOnUIThread]
#if !__SKIA__
		[Ignore("Only skia handled trailing newlines correctly for now.")]
#endif
		public async Task When_Text_Ends_In_Return()
		{
			var SUT = new TextBlock { Text = "hello world" };

			WindowHelper.WindowContent = new Border { Child = SUT };

			await WindowHelper.WaitForLoaded(SUT);
			await WindowHelper.WaitForIdle();

			var height = SUT.ActualHeight;

			SUT.Text += "\r";
			await WindowHelper.WaitForIdle();

			SUT.ActualHeight.Should().BeGreaterThan(height * 1.5);
		}

		[TestMethod]
		[RunsOnUIThread]
#if !__SKIA__
		[Ignore("Only skia handled trailing newlines correctly for now.")]
#endif
		public async Task When_Text_Ends_In_LineBreak()
		{
			var SUT0 = new TextBlock();
			var SUT1 = new TextBlock();

			SUT0.Text = "text";
			SUT1.Inlines.Add(new Run { Text = "text" });
			SUT1.Inlines.Add(new LineBreak());

			var sp = new StackPanel
			{
				Children =
				{
					new Border
					{
						Child = SUT0,
						BorderBrush = new SolidColorBrush(Colors.Chartreuse)
					},
					new Border
					{
						Child = SUT1,
						BorderBrush = new SolidColorBrush(Colors.Pink)
					}
				}
			};

			WindowHelper.WindowContent = sp;
			await WindowHelper.WaitForIdle();

			SUT1.ActualHeight.Should().BeGreaterThan(SUT0.ActualHeight);
		}

		[TestMethod]
		[RunsOnUIThread]
#if !__SKIA__
		[Ignore("Only skia handled trailing newlines correctly for now.")]
#endif
		public async Task When_Text_Ends_In_LineBreak2()
		{
			var SUT0 = new TextBlock();
			var SUT1 = new TextBlock();
			var SUT2 = new TextBlock();
			var SUT3 = new TextBlock();

			SUT1.Inlines.Add(new LineBreak());

			SUT2.Inlines.Add(new LineBreak());
			SUT2.Inlines.Add(new LineBreak());

			SUT3.Inlines.Add(new LineBreak());
			SUT3.Inlines.Add(new LineBreak());
			SUT3.Inlines.Add(new LineBreak());

			var sp = new StackPanel
			{
				Children =
				{
					new Border
					{
						Child = SUT0,
						BorderBrush = new SolidColorBrush(Colors.Chartreuse)
					},
					new Border
					{
						Child = SUT1,
						BorderBrush = new SolidColorBrush(Colors.Pink)
					},
					new Border
					{
						Child = SUT2,
						BorderBrush = new SolidColorBrush(Colors.Brown)
					},
					new Border
					{
						Child = SUT3,
						BorderBrush = new SolidColorBrush(Colors.Yellow)
					}
				}
			};

			WindowHelper.WindowContent = sp;
			await WindowHelper.WaitForIdle();

			SUT1.ActualHeight.Should().BeGreaterThan(SUT0.ActualHeight);
			SUT2.ActualHeight.Should().BeGreaterThan(SUT1.ActualHeight);
			SUT3.ActualHeight.Should().BeGreaterThan(SUT2.ActualHeight);
		}

		[TestMethod]
		public void When_Inlines_XamlRoot()
		{
			var SUT = new InlineTextInSpan();
			WindowHelper.WindowContent = SUT;
			var panel = (StackPanel)SUT.Content;
			var span = (Span)((TextBlock)panel.Children.Single()).Inlines.Single();
			var inlines = span.Inlines;
			foreach (var inline in inlines)
			{
				Assert.AreEqual(SUT.XamlRoot, inline.XamlRoot);
			}
		}

		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_FontFamily_In_Separate_Assembly()
		{
			var SUT = new TextBlock { Text = "\xE102\xE102\xE102\xE102\xE102" };
			WindowHelper.WindowContent = SUT;
			await WindowHelper.WaitForIdle();

			var size = new Size(1000, 1000);
			SUT.Measure(size);

			var originalSize = SUT.DesiredSize;

			Assert.AreNotEqual(0, SUT.DesiredSize.Width);
			Assert.AreNotEqual(0, SUT.DesiredSize.Height);

			SUT.FontFamily = new Microsoft.UI.Xaml.Media.FontFamily("ms-appx:///Uno.UI.RuntimeTests/Assets/Fonts/uno-fluentui-assets-runtimetest01.ttf");

			int counter = 3;

			do
			{
				await WindowHelper.WaitForIdle();
				await Task.Delay(100);

				SUT.InvalidateMeasure();
			}
			while (SUT.DesiredSize == originalSize && counter-- > 0);

			Assert.AreNotEqual(originalSize, SUT.DesiredSize);
		}

		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_FontFamily_Default()
		{
			var SUT = new TextBlock { Text = "\xE102\xE102\xE102\xE102\xE102" };
			WindowHelper.WindowContent = SUT;
			await WindowHelper.WaitForIdle();

			var size = new Size(1000, 1000);
			SUT.Measure(size);

			var originalSize = SUT.DesiredSize;

			Assert.AreNotEqual(0, SUT.DesiredSize.Width);
			Assert.AreNotEqual(0, SUT.DesiredSize.Height);

			SUT.FontFamily = Application.Current.Resources["SymbolThemeFontFamily"] as FontFamily;

			int counter = 3;

			do
			{
				await WindowHelper.WaitForIdle();
				await Task.Delay(100);

				SUT.InvalidateMeasure();
			}
			while (SUT.DesiredSize == originalSize && counter-- > 0);

			Assert.AreNotEqual(originalSize, SUT.DesiredSize);
		}

		[TestMethod]
#if !__ANDROID__
		[Ignore("Android-only test for AndroidAssets backward compatibility")]
#endif
		public async Task When_FontFamily_In_AndroidAsset()
		{
			var SUT = new TextBlock { Text = "\xE102\xE102\xE102\xE102\xE102" };
			WindowHelper.WindowContent = SUT;
			await WindowHelper.WaitForIdle();

			var size = new Size(1000, 1000);
			SUT.Measure(size);

			var originalSize = SUT.DesiredSize;

			Assert.AreNotEqual(0, SUT.DesiredSize.Width);
			Assert.AreNotEqual(0, SUT.DesiredSize.Height);

			SUT.FontFamily = new Microsoft.UI.Xaml.Media.FontFamily("ms-appx:///Assets/Fonts/SymbolsRuntimeTest02.ttf#SymbolsRuntimeTest02");

			for (int i = 0; i < 3; i++)
			{
				await WindowHelper.WaitForIdle();
				await Task.Delay(100);
				SUT.InvalidateMeasure();

				if (SUT.DesiredSize != originalSize) break;
			}

			Assert.AreNotEqual(originalSize, SUT.DesiredSize);
		}

		[TestMethod]
		public async Task When_SolidColorBrush_With_Opacity()
		{
			if (!ApiInformation.IsTypePresent("Microsoft.UI.Xaml.Media.Imaging.RenderTargetBitmap"))
			{
				Assert.Inconclusive(); // System.NotImplementedException: RenderTargetBitmap is not supported on this platform.;
			}

#if __MACOS__
			Assert.Inconclusive();
#endif
			var SUT = new TextBlock
			{
				Text = "••••••••",
				FontSize = 24,
				Foreground = new SolidColorBrush(Colors.Red) { Opacity = 0.5 },
			};

			await UITestHelper.Load(SUT);
			var bitmap = await UITestHelper.ScreenShot(SUT);

			ImageAssert.HasColorInRectangle(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), Colors.Red.WithOpacity(.5));
		}

		[TestMethod]
		[RunsOnUIThread]
		public async Task When_TextWrapping_Changed()
		{
			var SUT = new TextBlock
			{
				TextWrapping = TextWrapping.Wrap,
				Text = "This is Long Text! This is Long Text! This is Long Text! This is Long Text! This is Long Text! This is Long Text! ",
			};
			StackPanel panel = new StackPanel
			{
				Width = 100,
				Children =
				{
					SUT
				}
			};
			await UITestHelper.Load(panel);
			var height1 = SUT.ActualHeight;
			SUT.TextWrapping = TextWrapping.NoWrap;
			await Task.Delay(500);
			var height2 = SUT.ActualHeight;
			Assert.AreNotEqual(height1, height2);
		}

		[TestMethod]
		[RunsOnUIThread]
		public async Task When_Empty_TextBlock_Measure()
		{
			var container = new Grid()
			{
				Height = 200,
				Width = 200,
			};
			var SUT = new TextBlock { Text = "" };
			container.Children.Add(SUT);
			WindowHelper.WindowContent = container;
			await WindowHelper.WaitForLoaded(container);
			await WindowHelper.WaitFor(() => SUT.DesiredSize != default);

#if !__WASM__ // Disabled due to #14231
			Assert.AreEqual(0, SUT.DesiredSize.Width);
#endif
			Assert.IsTrue(SUT.DesiredSize.Height > 0);
		}

#if !__IOS__ // Line height is not supported on iOS
		[TestMethod]
		public async Task When_Empty_TextBlock_LineHeight_Override()
		{
			var container = new Grid()
			{
				Height = 200,
				Width = 200,
			};
			var SUT = new TextBlock { Text = "", LineHeight = 100 };
			container.Children.Add(SUT);
			WindowHelper.WindowContent = container;
			await WindowHelper.WaitForLoaded(container);
			await WindowHelper.WaitFor(() => SUT.DesiredSize != default);

#if !__WASM__ // Disabled due to #14231
			Assert.AreEqual(0, SUT.DesiredSize.Width);
#endif
			Assert.AreEqual(100, SUT.DesiredSize.Height);
		}
#endif

		[TestMethod]
		public async Task When_Empty_TextBlocks_Stacked()
		{
			var container = new StackPanel();
			for (int i = 0; i < 3; i++)
			{
				container.Children.Add(new TextBlock { Text = "" });
			}

			container.Children.Add(new TextBlock { Text = "Some text" });

			for (int i = 0; i < 3; i++)
			{
				container.Children.Add(new TextBlock { Text = "" });
			}

			WindowHelper.WindowContent = container;
			await WindowHelper.WaitForLoaded(container);
			foreach (var child in container.Children)
			{
				await WindowHelper.WaitFor(() => child.DesiredSize != default);
			}

			// Get the transform of the top left of the container
			var previousTransform = container.TransformToVisual(null);
			var previousOrigin = previousTransform.TransformPoint(new Point(0, 0));

			for (int i = 1; i < container.Children.Count; i++)
			{
				// Get the same for SUT
				var textBlockTransform = container.Children[i].TransformToVisual(null);
				var textBlockOrigin = textBlockTransform.TransformPoint(new Point(0, 0));

				Assert.AreEqual(previousOrigin.X, textBlockOrigin.X);
				Assert.IsTrue(previousOrigin.Y < textBlockOrigin.Y);

				previousOrigin = textBlockOrigin;
			}
		}

#if !__MACOS__
		[TestMethod]
		[RunsOnUIThread]
		public async Task When_TextTrimming()
		{
			var sut = new TextBlock
			{
				Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
				TextTrimming = TextTrimming.Clip,
			};
			var container = new Border
			{
				BorderThickness = new Thickness(1),
				BorderBrush = new SolidColorBrush(Colors.Red),
				Width = 100,
				Child = sut,
			};

			var states = new List<bool>();
			sut.IsTextTrimmedChanged += (s, e) => states.Add(sut.IsTextTrimmed);

			WindowHelper.WindowContent = container;
			await WindowHelper.WaitForLoaded(container);
			await WindowHelper.WaitForIdle(); // necessary on ios, since the container finished loading before the text is drawn

			Assert.IsTrue(sut.IsTextTrimmed, "IsTextTrimmed should be trimmed.");
			Assert.IsTrue(states.Count == 1 && states[0] == true, $"IsTextTrimmedChanged should only proc once for IsTextTrimmed=true. states: {(string.Join(", ", states) is string { Length: > 0 } tmp ? tmp : "(-empty-)")}");
		}

		[TestMethod]
		[RunsOnUIThread]
		public async Task When_TextTrimmingNone()
		{
			var sut = new TextBlock
			{
				Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
				TextTrimming = TextTrimming.None,
			};
			var container = new Border
			{
				BorderThickness = new Thickness(1),
				BorderBrush = new SolidColorBrush(Colors.Red),
				Width = 100,
				Child = sut,
			};

			var states = new List<bool>();
			sut.IsTextTrimmedChanged += (s, e) => states.Add(sut.IsTextTrimmed);

			WindowHelper.WindowContent = container;
			await WindowHelper.WaitForLoaded(container);
			await WindowHelper.WaitForIdle(); // necessary on ios, since the container finished loading before the text is drawn

			Assert.IsFalse(sut.IsTextTrimmed, "IsTextTrimmed should not be trimmed.");
			Assert.IsTrue(states.Count == 0, $"IsTextTrimmedChanged should not proc at all. states: {(string.Join(", ", states) is string { Length: > 0 } tmp ? tmp : "(-empty-)")}");
		}
#endif
	}
}
