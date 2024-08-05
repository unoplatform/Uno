﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Private.Infrastructure;
using SamplesApp.UITests;
using Uno.UI.RuntimeTests.Helpers;

namespace Uno.UI.RuntimeTests.Tests;

[TestClass]
[RunsOnUIThread]
public class BindingTests
{
	[TestMethod]
	public async Task When_Binding_By_Programmatically_Setting_Name()
	{
		var tb = new TextBox();
		tb.Name = "textBox";
		tb.Text = "Text";
		tb.DataContext = "Hello World";

		var button = new Button();
		button.Name = "button";
		button.SetBinding(Button.ContentProperty, new Binding()
		{
			ElementName = "textBox",
			Path = new PropertyPath("DataContext")
		});

		var sp = new StackPanel()
		{
			Children =
			{
				tb,
				button,
			},
		};

		Assert.AreEqual(null, button.Content);

		await UITestHelper.Load(sp);

#if UNO_HAS_ENHANCED_LIFECYCLE || WINAPPSDK
		Assert.AreEqual("Hello World", button.Content);
#else
		// Unfortunate wrong behavior on Android and iOS.
		Assert.AreEqual(null, button.Content);
#endif

		tb.DataContext = "Hello World Updated";

#if UNO_HAS_ENHANCED_LIFECYCLE || WINAPPSDK
		Assert.AreEqual("Hello World Updated", button.Content);
#else
		// Unfortunate wrong behavior on Android and iOS.
		Assert.AreEqual(null, button.Content);
#endif

		sp.Children.Remove(tb);

#if UNO_HAS_ENHANCED_LIFECYCLE || WINAPPSDK
		Assert.AreEqual("Hello World Updated", button.Content);
#else
		// Unfortunate wrong behavior on Android and iOS.
		Assert.AreEqual(null, button.Content);
#endif

		// At this point, the textBox name is was unregistered as it's removed from the visual tree.
		// However, on WinUI, the binding have already solved the target for ElementName and the binding will continue to work.
		tb.DataContext = "Hello World Updated 2";

#if UNO_HAS_ENHANCED_LIFECYCLE || WINAPPSDK
		Assert.AreEqual("Hello World Updated 2", button.Content);
#else
		// Unfortunate wrong behavior on Android and iOS.
		Assert.AreEqual(null, button.Content);
#endif
	}

	[TestMethod]
	public async Task When_Binding_Is_Set_After_RegisterName_And_UnregisterName()
	{
		var tb = new TextBox();
		tb.Name = "textBox";
		tb.Text = "Text";
		tb.DataContext = "Hello World";

		var button = new Button();
		button.Name = "button";

		var sp = new StackPanel()
		{
			Children =
			{
				tb,
				button,
			},
		};

		Assert.AreEqual(null, button.Content);

		await UITestHelper.Load(sp);

		sp.Children.Remove(tb);

		// The remove call will UnregisterName for the textBox.
		// The binding shouldn't be able to find the target for ElementName
		button.SetBinding(Button.ContentProperty, new Binding()
		{
			ElementName = "textBox",
			Path = new PropertyPath("DataContext")
		});

		Assert.AreEqual(null, button.Content);
	}

	[TestMethod]
	public async Task When_Binding_Setter_Value_In_Style()
	{
		var SUT = new BindingToSetterValuePage();
		await UITestHelper.Load(SUT);

		assertBorder(SUT.borderXBind, "Hello");
		assertBorder(SUT.borderBinding, null);

		void assertBorder(Border border, string expectedSetterValue)
		{
			var styleXBind = border.Style;
			var setter = (Setter)styleXBind.Setters.Single();
			Assert.AreEqual(AutomationProperties.AutomationIdProperty, setter.Property);
			Assert.AreEqual(expectedSetterValue, setter.Value);
		}
	}

	[TestMethod]
	public async Task When_BindingShouldBeAppliedOnPropertyChangedEvent()
	{
		var SUT = new BindingShouldBeAppliedOnPropertyChangedEvent();
		await UITestHelper.Load(SUT);

		var dc = (BindingShouldBeAppliedOnPropertyChangedEventVM)SUT.DataContext;
		var converter = (BindingShouldBeAppliedOnPropertyChangedEventConverter)SUT.Resources["MyConverter"];

		Assert.AreEqual(1, converter.ConvertCount);
		Assert.AreEqual("0", SUT.myTb.Text);

		dc.Increment();

		Assert.AreEqual(2, converter.ConvertCount);
		Assert.AreEqual("1", SUT.myTb.Text);
	}

#if __SKIA__ && HAS_UNO_WINUI
	[TestMethod]
	[UnoWorkItem("https://github.com/unoplatform/uno/issues/16520")]
	public async Task When_XBind_In_Window()
	{
		var SUT = new XBindInWindow();
		SUT.Activate();
		try
		{
			Assert.AreEqual(0, SUT.ClickCount);
			SUT.MyButton.AutomationPeerClick();
			Assert.AreEqual(1, SUT.ClickCount);
		}
		finally
		{
			SUT.Close();
		}
	}
#endif

	[TestMethod]
	public async Task When_TargetNullValueThemeResource()
	{
		var SUT = new TargetNullValueThemeResource();
		await UITestHelper.Load(SUT);

		var myBtn = SUT.myBtn;
		Assert.AreEqual(Microsoft.UI.Colors.Red, ((SolidColorBrush)myBtn.Foreground).Color);

		using (ThemeHelper.UseDarkTheme())
		{
			Assert.AreEqual(Microsoft.UI.Colors.Green, ((SolidColorBrush)myBtn.Foreground).Color);
		}

		Assert.AreEqual(Microsoft.UI.Colors.Red, ((SolidColorBrush)myBtn.Foreground).Color);
	}

	[TestMethod]
	public async Task When_FallbackValueThemeResource_NoDataContext()
	{
		var SUT = new FallbackValueThemeResource();
		await UITestHelper.Load(SUT);

		var myBtn = SUT.myBtn;
		Assert.AreEqual(Microsoft.UI.Colors.Red, ((SolidColorBrush)myBtn.Foreground).Color);

		using (ThemeHelper.UseDarkTheme())
		{
#if WINAPPSDK
			Assert.AreEqual(Microsoft.UI.Colors.Green, ((SolidColorBrush)myBtn.Foreground).Color);
#else
			// WRONG behavior!
			Assert.AreEqual(Microsoft.UI.Colors.Red, ((SolidColorBrush)myBtn.Foreground).Color);
#endif
		}

		Assert.AreEqual(Microsoft.UI.Colors.Red, ((SolidColorBrush)myBtn.Foreground).Color);
	}

	[TestMethod]
	public async Task When_FallbackValueThemeResource_WithDataContext()
	{
		var SUT = new FallbackValueThemeResource();
		await UITestHelper.Load(SUT);

		var myBtn = SUT.myBtn;
		myBtn.DataContext = "Hello";
		Assert.AreEqual(Microsoft.UI.Colors.Red, ((SolidColorBrush)myBtn.Foreground).Color);

		using (ThemeHelper.UseDarkTheme())
		{
			Assert.AreEqual(Microsoft.UI.Colors.Green, ((SolidColorBrush)myBtn.Foreground).Color);
		}

		Assert.AreEqual(Microsoft.UI.Colors.Red, ((SolidColorBrush)myBtn.Foreground).Color);
	}
}
