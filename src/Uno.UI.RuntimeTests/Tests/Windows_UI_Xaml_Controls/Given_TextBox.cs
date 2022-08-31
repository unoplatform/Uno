﻿
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.UI.RuntimeTests.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using static Private.Infrastructure.TestServices;
using Windows.UI.Xaml;
using Windows.UI;
using FluentAssertions;
using Windows.UI.Xaml.Media.Imaging;
#if NETFX_CORE
using Uno.UI.Extensions;
#elif __IOS__
using UIKit;
#elif __MACOS__
using AppKit;
#else
#endif

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Controls
{
	[TestClass]
	[RunsOnUIThread]
	public class Given_TextBox
	{
#if __ANDROID__
		[TestMethod]
		public void When_InputScope_Null_And_ImeOptions()
		{
			var tb = new TextBox();
			tb.InputScope = null;
#if !MONOANDROID80
			tb.ImeOptions = Android.Views.InputMethods.ImeAction.Search;
#endif
		}
#endif

#if HAS_UNO
		[TestMethod]
		public async Task When_Template_Recycled()
		{
			try
			{
				var textBox = new TextBox
				{
					Text = "Test"
				};

				WindowHelper.WindowContent = textBox;
				await WindowHelper.WaitForLoaded(textBox);

				FocusManager.GettingFocus += OnGettingFocus;
				textBox.OnTemplateRecycled();
			}
			finally
			{
				FocusManager.GettingFocus -= OnGettingFocus;
			}

			static void OnGettingFocus(object sender, GettingFocusEventArgs args)
			{
				Assert.Fail("Focus should not move");
			}
		}
#endif

		[TestMethod]
		public async Task When_Fluent_And_Theme_Changed()
		{
			using (StyleHelper.UseFluentStyles())
			{
				var textBox = new TextBox
				{
					PlaceholderText = "Enter..."
				};

				WindowHelper.WindowContent = textBox;
				await WindowHelper.WaitForLoaded(textBox);

				var placeholderTextContentPresenter = textBox.FindFirstChild<TextBlock>(tb => tb.Name == "PlaceholderTextContentPresenter");
				Assert.IsNotNull(placeholderTextContentPresenter);

				var lightThemeForeground = TestsColorHelper.ToColor("#9E000000");
				var darkThemeForeground = TestsColorHelper.ToColor("#C5FFFFFF");

				Assert.AreEqual(lightThemeForeground, (placeholderTextContentPresenter.Foreground as SolidColorBrush)?.Color);

				using (ThemeHelper.UseDarkTheme())
				{
					Assert.AreEqual(darkThemeForeground, (placeholderTextContentPresenter.Foreground as SolidColorBrush)?.Color);
				}

				Assert.AreEqual(lightThemeForeground, (placeholderTextContentPresenter.Foreground as SolidColorBrush)?.Color);
			}
		}

		[TestMethod]
		public async Task When_BeforeTextChanging()
		{
			var textBox = new TextBox
			{
				Text = "Test"
			};

			WindowHelper.WindowContent = textBox;
			await WindowHelper.WaitForLoaded(textBox);

			textBox.BeforeTextChanging += (s, e) =>
			{
				Assert.AreEqual("Test", textBox.Text);
			};

			textBox.Text = "Something";
		}

		[TestMethod]
		public async Task When_Calling_Select_With_Negative_Values()
		{
			var textBox = new TextBox();
			WindowHelper.WindowContent = textBox;
			await WindowHelper.WaitForLoaded(textBox);

			Assert.ThrowsException<ArgumentException>(() => textBox.Select(0, -1));
			Assert.ThrowsException<ArgumentException>(() => textBox.Select(-1, 0));
		}

		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_Calling_Select_With_In_Range_Values()
		{
			var textBox = new TextBox
			{
				Text = "0123456789"
			};

			WindowHelper.WindowContent = textBox;
			await WindowHelper.WaitForLoaded(textBox);
			textBox.Focus(FocusState.Programmatic);
			Assert.AreEqual(textBox.Text.Length, textBox.SelectionStart);
			Assert.AreEqual(0, textBox.SelectionLength);
			textBox.Select(1, 7);
			Assert.AreEqual(1, textBox.SelectionStart);
			Assert.AreEqual(7, textBox.SelectionLength);
		}

		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_Calling_Select_With_Out_Of_Range_Length()
		{
			var textBox = new TextBox
			{
				Text = "0123456789"
			};

			WindowHelper.WindowContent = textBox;
			await WindowHelper.WaitForLoaded(textBox);
			textBox.Focus(FocusState.Programmatic);
			Assert.AreEqual(textBox.Text.Length, textBox.SelectionStart);
			Assert.AreEqual(0, textBox.SelectionLength);
			textBox.Select(1, 20);
			Assert.AreEqual(1, textBox.SelectionStart);
			Assert.AreEqual(9, textBox.SelectionLength);
		}

		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_Calling_Select_With_Out_Of_Range_Start()
		{
			var textBox = new TextBox
			{
				Text = "0123456789"
			};

			WindowHelper.WindowContent = textBox;
			await WindowHelper.WaitForLoaded(textBox);
			textBox.Focus(FocusState.Programmatic);
			Assert.AreEqual(textBox.Text.Length, textBox.SelectionStart);
			Assert.AreEqual(0, textBox.SelectionLength);
			textBox.Select(20, 5);
			Assert.AreEqual(10, textBox.SelectionStart);
			Assert.AreEqual(0, textBox.SelectionLength);
		}

#if __IOS__
		[Ignore("Disabled as not working properly. See https://github.com/unoplatform/uno/issues/8016")]
#endif
		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_SelectionStart_Set()
		{
			var textBox = new TextBox
			{
				Text = "0123456789"
			};

			var button = new Button()
			{
				Content = "Some button"
			};

			var stackPanel = new StackPanel()
			{
				Children =
				{
					textBox,
					button
				}
			};

			WindowHelper.WindowContent = stackPanel;
			await WindowHelper.WaitForLoaded(textBox);

			button.Focus(FocusState.Programmatic);

			await WindowHelper.WaitForIdle();

			textBox.SelectionStart = 3;

			textBox.Focus(FocusState.Programmatic);
			Assert.AreEqual(3, textBox.SelectionStart);
		}

#if __IOS__
		[Ignore("Disabled as not working properly. See https://github.com/unoplatform/uno/issues/8016")]
#endif
		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_Focus_Changes_SelectionStart_Preserved()
		{
			var textBox = new TextBox
			{
				Text = "0123456789"
			};

			var button = new Button()
			{
				Content = "Some button"
			};

			var stackPanel = new StackPanel()
			{
				Children =
				{
					textBox,
					button
				}
			};

			WindowHelper.WindowContent = stackPanel;
			await WindowHelper.WaitForLoaded(textBox);

			textBox.Focus(FocusState.Programmatic);

			await WindowHelper.WaitForIdle();

			textBox.SelectionStart = 3;

			button.Focus(FocusState.Programmatic);
			Assert.AreEqual(3, textBox.SelectionStart);

			textBox.Focus(FocusState.Programmatic);
			Assert.AreEqual(3, textBox.SelectionStart);
		}

		[TestMethod]
		public async Task When_IsEnabled_Set()
		{
			var foregroundColor = new SolidColorBrush(Colors.Red);
			var disabledColor = new SolidColorBrush(Colors.Blue);

			var textbox = new TextBox
			{
				Text = "Original Text",
				Foreground = foregroundColor,
				Style = TestsResourceHelper.GetResource<Style>("MaterialOutlinedTextBoxStyle"),
				IsEnabled = false
			};

			var stackPanel = new StackPanel()
			{
				Children = { textbox }
			};


			WindowHelper.WindowContent = stackPanel;
			await WindowHelper.WaitForLoaded(textbox);


			var contentPresenter = (ScrollViewer)textbox.FindName("ContentElement");

			await WindowHelper.WaitForIdle();

			Assert.IsFalse(textbox.IsEnabled);
			Assert.AreEqual(contentPresenter.Foreground, disabledColor);

			textbox.IsEnabled = true;

			Assert.IsTrue(textbox.IsEnabled);
			Assert.AreEqual(contentPresenter.Foreground, foregroundColor);
		}

#if __ANDROID__
		[TestMethod]
		public async Task When_Text_IsWrapping_Set()
		{
			var textbox = new TextBox();

			textbox.Width = 100;
			StackPanel panel = new() { Orientation = Orientation.Vertical };
			panel.Children.Add(textbox);
			WindowHelper.WindowContent = panel;
			await WindowHelper.WaitForLoaded(textbox);
			var originalActualHeigth = textbox.ActualHeight;
			textbox.Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremaaaaaaaaaaaaaaaaaa";
			textbox.TextWrapping = TextWrapping.Wrap;
			await WindowHelper.WaitForIdle();
			textbox.ActualHeight.Should().BeGreaterThan(originalActualHeigth);
		}


		[TestMethod]
		public async Task When_Text_IsNoWrap_Set()
		{
			var textbox = new TextBox();

			textbox.Width = 100;
			StackPanel panel = new() { Orientation = Orientation.Vertical };
			panel.Children.Add(textbox);
			WindowHelper.WindowContent = panel;
			await WindowHelper.WaitForLoaded(textbox);
			var originalActualHeigth = textbox.ActualHeight;
			textbox.Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremaaaaaaaaaaaaaaaaaa";
			textbox.TextWrapping = TextWrapping.NoWrap;
			await WindowHelper.WaitForIdle();
			textbox.ActualHeight.Should().Be(originalActualHeigth);
		}


		[TestMethod]
		public async Task When_AcceptsReturn_Set()
		{
			var textbox = new TextBox();

			textbox.Width = 100;
			StackPanel panel = new() { Orientation = Orientation.Vertical };
			panel.Children.Add(textbox);
			WindowHelper.WindowContent = panel;
			await WindowHelper.WaitForLoaded(textbox);
			var originalActualHeigth = textbox.ActualHeight;
			textbox.AcceptsReturn = true;
			textbox.Text = "Sed ut perspiciatis unde omnis iste natus \nerror sit voluptatem accusantium doloremaaaaaaaaaaaaaaaaaa";
			await WindowHelper.WaitForIdle();
			textbox.ActualHeight.Should().BeGreaterThan(originalActualHeigth * 2);
		}

		[TestMethod]
		public async Task When_AcceptsReturn_Set_On_Init()
		{
			var textbox = new TextBox();
			textbox.AcceptsReturn = true;
			textbox.Text = "Sed ut perspiciatis unde omnis iste natus \nerror sit voluptatem accusantium doloremaaaaaaaaaaaaaaaaaa";
			textbox.Width = 100;

			StackPanel panel = new() { Orientation = Orientation.Vertical };
			panel.Children.Add(textbox);
			WindowHelper.WindowContent = panel;
			await WindowHelper.WaitForLoaded(textbox);
			var originalActualHeigth = textbox.ActualHeight;
			textbox.AcceptsReturn = false;
			await WindowHelper.WaitForIdle();
			textbox.ActualHeight.Should().BeLessThan(originalActualHeigth / 2);
		}
#endif

		[TestMethod]
		public async Task When_SelectedText_StartZero()
		{
			var textBox = new TextBox
			{
				Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			};

			WindowHelper.WindowContent = textBox;
			await WindowHelper.WaitForLoaded(textBox);

			textBox.Focus(FocusState.Programmatic);

			textBox.SelectionStart = 0;
			textBox.SelectionLength = 0;
			textBox.SelectedText = "1234";

			Assert.AreEqual("1234ABCDEFGHIJKLMNOPQRSTUVWXYZ", textBox.Text);
		}

		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_SelectedText_EndOfText()
		{
			var textBox = new TextBox
			{
				Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			};

			WindowHelper.WindowContent = textBox;
			await WindowHelper.WaitForLoaded(textBox);

			textBox.Focus(FocusState.Programmatic);

			textBox.SelectionStart = 26;
			textBox.SelectedText = "1234";

			Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234", textBox.Text);
		}

		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_SelectedText_MiddleOfText()
		{
			var textBox = new TextBox
			{
				Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			};

			WindowHelper.WindowContent = textBox;
			await WindowHelper.WaitForLoaded(textBox);

			textBox.Focus(FocusState.Programmatic);

			textBox.SelectionStart = 2;
			textBox.SelectionLength = 22;
			textBox.SelectedText = "1234";

			Assert.AreEqual("AB1234YZ", textBox.Text);
		}

		[TestMethod]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_SelectedText_AllTextToEmpty()
		{
			var textBox = new TextBox
			{
				Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			};

			WindowHelper.WindowContent = textBox;
			await WindowHelper.WaitForLoaded(textBox);

			textBox.Focus(FocusState.Programmatic);

			textBox.SelectionStart = 0;
			textBox.SelectionLength = 26;
			textBox.SelectedText = String.Empty;

			Assert.AreEqual(String.Empty, textBox.Text);
			Assert.AreEqual(0, textBox.SelectionStart);
			Assert.AreEqual(0, textBox.SelectionLength);
		}

		[TestMethod]
		public async Task When_Text_Overflows()
		{
			// iOS used to produce ellipsis when text overflows.
			// We make the text overflow with spaces (has no color),
			// then we assert that we don't have red pixels in the textbox.
			var SUT = new TextBox
			{
				Text = new string(' ', 100),
				Width = 100,
				Foreground = Colors.Red,
			};

			WindowHelper.WindowContent = SUT;
			await WindowHelper.WaitForIdle();
			var renderer = new RenderTargetBitmap();
			await renderer.RenderAsync(SUT);
			var si = new RawBitmap(renderer, SUT);
			await si.Populate();

			ImageAssert.DoesNotHaveColorInRectangle(si, new System.Drawing.Rectangle(new System.Drawing.Point(0, 0), si.Size), Colors.Red, tolerance: 20);
		}

	}
}
