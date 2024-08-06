﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Private.Infrastructure;
using Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Controls.ContentPresenterPages;
using Windows.Foundation;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using MUXControlsTestApp.Utilities;
using Uno.UI.RuntimeTests.Helpers;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Controls;

[TestClass]
[RunsOnUIThread]
[RequiresFullWindow]
#if __MACOS__
[Ignore("Currently fails on macOS, part of #9282! epic")]
#endif
public class Given_ContentPresenter
{
	[TestMethod]
	public async Task When_DataContext_Is_Inherited()
	{
		var parentStackPanel = new StackPanel();
		var cp = new ContentPresenter() { Width = 100, Height = 100, };
		parentStackPanel.Children.Add(cp);
		await UITestHelper.Load(parentStackPanel);

		var sp = new StackPanel() { Width = 100, Height = 100 };
		cp.Content = sp;

		parentStackPanel.DataContext = "Parent DataContext";
		var changed = new List<string>();
		sp.DataContextChanged += (sender, args) => changed.Add($"{sender.DataContext},{args.NewValue}");
		await TestServices.WindowHelper.WaitForLoaded(cp);
		await TestServices.WindowHelper.WaitForIdle();

		Assert.AreEqual(1, changed.Count);
		Assert.AreEqual("Parent DataContext,Parent DataContext", changed[0]);
	}

	[TestMethod]
	public async Task When_DataContext_Is_Inherited2()
	{
		var parentStackPanel = new StackPanel() { Width = 100, Height = 100, DataContext = "Parent DataContext" };
		await UITestHelper.Load(parentStackPanel);

		var btn = new Button();
		btn.DataContextChanged += (a, b) => { _ = a.GetValue(FrameworkElement.DataContextProperty); };
		btn.Content = "Click";
		parentStackPanel.Children.Add(btn);

		await TestServices.WindowHelper.WaitForIdle();
	}

	[TestMethod]
	public async Task When_Content_Changes_And_Is_Non_UIElement()
	{
		var SUT = new ContentPresenter() { Tag = "SUT" };
		SUT.Content = "Hello";

		SUT.DataContextChanged += (sender, args) =>
		{

		};

		SUT.RegisterPropertyChangedCallback(FrameworkElement.DataContextProperty, (s, e) =>
		{

		});

		Assert.IsNull(SUT.DataContext);

		await UITestHelper.Load(SUT);

		Assert.AreEqual("Hello", SUT.DataContext);

		SUT.Content = "Hello2";

		Assert.AreEqual("Hello", SUT.DataContext);

		await TestServices.WindowHelper.WaitForIdle();

		Assert.AreEqual("Hello2", SUT.DataContext);
	}

	[TestMethod]
	public async Task When_DC_Changes()
	{
		var SUT = new ContentPresenter()
		{
			DataContext = "Hello"
		};

		var btn = new Button();
		var changed = new List<string>();
		btn.DataContextChanged += (sender, args) => changed.Add($"sender.DataContext: {sender.DataContext}, args.NewValue: {args.NewValue}");

		Assert.AreEqual(0, VisualTreeHelper.GetChildrenCount(SUT));

		SUT.Content = btn;

		Assert.AreEqual(0, VisualTreeHelper.GetChildrenCount(SUT));

		Assert.IsNull(btn.DataContext);

		SUT.DataContext = "Hello2";

		Assert.IsNull(btn.DataContext);

		Assert.AreEqual(0, changed.Count);

		Assert.AreEqual(0, VisualTreeHelper.GetChildrenCount(SUT));

		await UITestHelper.Load(SUT);

		Assert.AreEqual(1, VisualTreeHelper.GetChildrenCount(SUT));
		Assert.AreEqual(1, changed.Count);

		Assert.IsNull(btn.DataContext);

		SUT.DataContext = "Hello3";

		Assert.AreEqual(1, VisualTreeHelper.GetChildrenCount(SUT));
		Assert.AreEqual(2, changed.Count);

		Assert.AreEqual("Hello3", btn.DataContext);

		Assert.AreEqual("sender.DataContext: , args.NewValue: ", changed[0]);
		Assert.AreEqual("sender.DataContext: Hello3, args.NewValue: Hello3", changed[1]);
	}

	[TestMethod]
	public async Task When_Padding_Set_In_SizeChanged()
	{
		var SUT = new ContentPresenter()
		{
			Width = 200,
			Height = 200,
			Content = new Border()
			{
				Child = new Ellipse()
				{
					Fill = new SolidColorBrush(Colors.DarkOrange)
				}
			}
		};

		SUT.SizeChanged += (sender, args) => SUT.Padding = new Thickness(0, 200, 0, 0);

		TestServices.WindowHelper.WindowContent = SUT;
		await TestServices.WindowHelper.WaitForLoaded(SUT);
		await TestServices.WindowHelper.WaitForIdle();

		// We have a problem on IOS and Android where SUT isn't relayouted after the padding
		// change even though IsMeasureDirty is true. This is a workaround to explicity relayout.
#if __IOS__ || __ANDROID__
		SUT.InvalidateMeasure();
		SUT.UpdateLayout();
#endif

		Assert.AreEqual(200, ((UIElement)VisualTreeHelper.GetChild(SUT, 0)).ActualOffset.Y);
	}

	[TestMethod]
	public void When_Content_Alignment_Set_Default_Alignment_Not_Overriden()
	{
		var contentPresenter = new ContentPresenter()
		{
			HorizontalContentAlignment = HorizontalAlignment.Center
		};
		var border = new Border();
		contentPresenter.Content = border;

		Assert.AreEqual(HorizontalAlignment.Center, contentPresenter.HorizontalContentAlignment);
		Assert.AreEqual(HorizontalAlignment.Stretch, border.HorizontalAlignment);
	}

	[TestMethod]
	public void When_Binding_And_DataContext_Same_As_Content()
	{
		var SUT = new ContentPresenter();
		var dataContextChangedCount = 0;

		SUT.DataContextChanged += (s, e) => dataContextChangedCount++;

		SUT.DataContext = new object();
		SUT.Content = SUT.DataContext;

		TestServices.WindowHelper.WindowContent = SUT;

		// This test ensures that the ContentPresenter does not reset
		// the DataContext to null and then back to the content and have
		// two-way bindings propagating the null value back to the source.
		Assert.AreEqual(1, dataContextChangedCount);
	}

	[TestMethod]
	public void When_Content_Presenter_Empty()
	{
		var sut = new ContentPresenter_Content_DataContext();

		TestServices.WindowHelper.WindowContent = sut;

		Assert.AreEqual("", GetTextBlockText(sut, "emptyTest"));

		sut.emptyTestRoot.DataContext = "43";

		Assert.AreEqual("", GetTextBlockText(sut, "emptyTest"));
	}

	[TestMethod]
	public void When_Content_Presenter_Priority()
	{
		var sut = new ContentPresenter_Content_DataContext();

		TestServices.WindowHelper.WindowContent = sut;

		Assert.AreEqual("", GetTextBlockText(sut, "priorityTest"));

		sut.priorityTestRoot.DataContext = "44";
		Assert.AreEqual("", GetTextBlockText(sut, "priorityTest"));

		sut.priorityTestRoot.Content = "45";
		Assert.AreEqual("", GetTextBlockText(sut, "priorityTest"));

		sut.priorityTestRoot.DataContext = "46";
		Assert.AreEqual("", GetTextBlockText(sut, "priorityTest"));
	}

	[TestMethod]
	public void When_Content_Presenter_SameValue()
	{
		var sut = new ContentPresenter_Content_DataContext();

		TestServices.WindowHelper.WindowContent = sut;

		Assert.AreEqual("", GetTextBlockText(sut, "sameValueTest"));
	}

	[TestMethod]
	public void When_Content_Presenter_Inheritance()
	{
		var sut = new ContentPresenter_Content_DataContext();

		TestServices.WindowHelper.WindowContent = sut;

		Assert.AreEqual("", GetTextBlockText(sut, "inheritanceTest"));

		sut.inheritanceTestRoot.DataContext = "46";
		Assert.AreEqual("", GetTextBlockText(sut, "inheritanceTest"));

		sut.inheritanceTestRoot.DataContext = "47";
		Assert.AreEqual("", GetTextBlockText(sut, "inheritanceTest"));

		sut.inheritanceTestInner.DataContext = "48";
		Assert.AreEqual("", GetTextBlockText(sut, "inheritanceTest"));

		sut.inheritanceTestRoot.DataContext = "49";
		Assert.AreEqual("", GetTextBlockText(sut, "inheritanceTest"));
	}

	[TestMethod]
	public async Task When_Inside_ContentControl_Template()
	{
		var control = new ContentPresenter_Inside_ContentControlTemplate();

		await UITestHelper.Load(control);

		var cc1 = control.FindName("CCWithContentTemplateSelectorAndContent") as ContentControl;
		var presenter1 = cc1.FindVisualChildByType<ContentPresenter>();
		var border1 = presenter1.FindVisualChildByType<Border>();
		var tb1 = presenter1.FindVisualChildByType<TextBlock>();

		Assert.AreEqual(new SolidColorBrush(Microsoft.UI.Colors.LightGreen), border1.Background);
		Assert.AreEqual("Item 1", tb1.Text);

		var cc2 = control.FindName("CCWithContentTemplate") as ContentControl;
		var presenter2 = cc2.FindVisualChildByType<ContentPresenter>();
		var border2 = presenter2.FindVisualChildByType<Border>();
		var tb2 = presenter2.FindVisualChildByType<TextBlock>();

		Assert.AreEqual(new SolidColorBrush(Microsoft.UI.Colors.LightPink), border2.Background);
		Assert.AreEqual("Item 2", tb2.Text);

		var cc3 = control.FindName("CCWithContentTemplateAndContent") as ContentControl;
		var presenter3 = cc3.FindVisualChildByType<ContentPresenter>();
		var border3 = presenter3.FindVisualChildByType<Border>();
		var tb3 = presenter3.FindVisualChildByType<TextBlock>();

		Assert.AreEqual(new SolidColorBrush(Microsoft.UI.Colors.LightGreen), border3.Background);
		Assert.AreEqual("Item 3", tb3.Text);

		var cc4 = control.FindName("CCWithContent") as ContentControl;
		var presenter4 = cc4.FindVisualChildByType<ContentPresenter>();
		var tb4 = presenter4.FindVisualChildByType<TextBlock>();

		Assert.AreEqual("Item 4", tb4.Text);

	}

	[TestMethod]
	public void When_Content_Presenter_SameValue_Changing()
	{
		var sut = new ContentPresenter_Content_DataContext();

		TestServices.WindowHelper.WindowContent = sut;

		Assert.AreEqual("", GetTextBlockText(sut, "sameValueChangingTest"));
	}

	[TestMethod]
	public void When_Content_Presenter_Null_Content_Changed()
	{
		var sut = new ContentPresenter_Content_DataContext();

		TestServices.WindowHelper.WindowContent = sut;

		Assert.AreEqual("", GetTextBlockText(sut, "nullContentChanged"));
	}

	static string GetTextBlockText(FrameworkElement sut, string v)
		=> (sut.FindName(v) as TextBlock)?.Text ?? "";

	public static IEnumerable<object[]> GetAlignments()
	{
		var configurations = new List<AlignmentTestConfiguration>();
		// Centered content

		foreach (var outerHorizontalAlignment in Enum.GetValues<HorizontalAlignment>())
		{
			foreach (var outerVerticalAlignment in Enum.GetValues<VerticalAlignment>())
			{
				foreach (var innerHorizontalAlignment in Enum.GetValues<HorizontalAlignment>())
				{
					foreach (var innerVerticalAlignment in Enum.GetValues<VerticalAlignment>())
					{
						double expectedX = 0;
						if (outerHorizontalAlignment == HorizontalAlignment.Center)
						{
							expectedX = 50;
						}
						else if (outerHorizontalAlignment == HorizontalAlignment.Right)
						{
							expectedX = 100;
						}
						else if (outerHorizontalAlignment == HorizontalAlignment.Stretch)
						{
							// Inner alignment matters only now
							if (innerHorizontalAlignment == HorizontalAlignment.Center)
							{
								expectedX = 50;
							}
							else if (innerHorizontalAlignment == HorizontalAlignment.Right)
							{
								expectedX = 100;
							}
						}

						double expectedY = 0;
						if (outerVerticalAlignment == VerticalAlignment.Center)
						{
							expectedY = 50;
						}
						else if (outerVerticalAlignment == VerticalAlignment.Bottom)
						{
							expectedY = 100;
						}
						else if (outerVerticalAlignment == VerticalAlignment.Stretch)
						{
							// Inner alignment matters only now
							if (innerVerticalAlignment == VerticalAlignment.Center)
							{
								expectedY = 50;
							}
							else if (innerVerticalAlignment == VerticalAlignment.Bottom)
							{
								expectedY = 100;
							}
						}

						double expectedWidth = 100;
						if (outerHorizontalAlignment == HorizontalAlignment.Stretch &&
							innerHorizontalAlignment == HorizontalAlignment.Stretch)
						{
							expectedWidth = 200;
						}

						double expectedHeight = 100;
						if (outerVerticalAlignment == VerticalAlignment.Stretch &&
							innerVerticalAlignment == VerticalAlignment.Stretch)
						{
							expectedHeight = 200;
						}

						configurations.Add(new AlignmentTestConfiguration(
							outerHorizontalAlignment,
							outerVerticalAlignment,
							innerHorizontalAlignment,
							innerVerticalAlignment,
							new Point(expectedX, expectedY),
							new Size(expectedWidth, expectedHeight)
						));
					}
				}
			}
		}

		return configurations.Select(c => new object[] { c });
	}

	[TestMethod]
	[DynamicData(nameof(GetAlignments), DynamicDataSourceType.Method)]
	public async Task When_Content_Aligned_Position_And_Size(AlignmentTestConfiguration configuration)
	{
		var contentPresenter = new ContentPresenter()
		{
			HorizontalContentAlignment = configuration.OuterHorizontal,
			VerticalContentAlignment = configuration.OuterVertical,
			Width = 200,
			Height = 200,
			Background = new SolidColorBrush(Colors.Red)
		};
		var border = new Border()
		{
			HorizontalAlignment = configuration.InnerHorizontal,
			VerticalAlignment = configuration.InnerVertical,
			Background = new SolidColorBrush(Colors.Blue),
			MinWidth = 100,
			MinHeight = 100
		};
		contentPresenter.Content = border;
		TestServices.WindowHelper.WindowContent = contentPresenter;

		await TestServices.WindowHelper.WaitForLoaded(contentPresenter);
		await TestServices.WindowHelper.WaitForIdle();

		var transform = border.TransformToVisual(contentPresenter);
		var point = transform.TransformPoint(new Point());
		Assert.AreEqual(configuration.ExpectedPosition, point);
		Assert.AreEqual(configuration.ExpectedSize, new Size(border.ActualWidth, border.ActualHeight));
	}

	[TestMethod]
	public async Task When_Content_Unset_Release()
	{
		var SUT = new ContentPresenter();

		TestServices.WindowHelper.WindowContent = SUT;

		var wref = SetContent();
		Assert.AreEqual(null, SUT.DataContext);

		SUT.Content = null;

		await TestServices.WindowHelper.WaitForIdle();

		await AssertCollectedReference(wref);

		WeakReference SetContent()
		{
			var o = new object();
			SUT.Content = o;
			return new(o);
		}
	}

	private async Task AssertCollectedReference(WeakReference reference)
	{
		var sw = Stopwatch.StartNew();
		while (sw.Elapsed < TimeSpan.FromSeconds(3))
		{
			GC.Collect(2);
			GC.WaitForPendingFinalizers();

			if (!reference.IsAlive)
			{
				return;
			}

			await Task.Delay(100);
		}

		Assert.IsFalse(reference.IsAlive);
	}

	public class AlignmentTestConfiguration
	{
		public AlignmentTestConfiguration(HorizontalAlignment outerHorizontal, VerticalAlignment outerVertical, HorizontalAlignment innerHorizontal, VerticalAlignment innerVertical, Point expectedPosition, Size expectedSize)
		{
			OuterHorizontal = outerHorizontal;
			OuterVertical = outerVertical;
			InnerHorizontal = innerHorizontal;
			InnerVertical = innerVertical;
			ExpectedPosition = expectedPosition;
			ExpectedSize = expectedSize;
		}

		public HorizontalAlignment OuterHorizontal { get; }

		public VerticalAlignment OuterVertical { get; }

		public HorizontalAlignment InnerHorizontal { get; }

		public VerticalAlignment InnerVertical { get; }

		public Point ExpectedPosition { get; }

		public Size ExpectedSize { get; }

		public override string ToString()
		{
			return $"{OuterHorizontal}/{OuterVertical}/{InnerHorizontal}/{InnerVertical}/{ExpectedPosition}/{ExpectedSize}";
		}
	}
}
