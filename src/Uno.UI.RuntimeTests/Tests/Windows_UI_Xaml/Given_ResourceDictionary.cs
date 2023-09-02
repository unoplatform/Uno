﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

#if HAS_UNO
using Uno.UI.Xaml;
#endif

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml
{
	[TestClass]
	public class Given_ResourceDictionary
	{
		[TestMethod]
		[RunsOnUIThread]
		public void When_Key_Overwritten()
		{
			const string key = "TestKey";
			const string originalValue = "original";
			const string newValue = "newValue";

			var resourceDictionary = new ResourceDictionary();
			resourceDictionary[key] = originalValue;
			resourceDictionary[key] = newValue;

			Assert.AreEqual(newValue, resourceDictionary[key]);
		}

#if HAS_UNO // uses uno specifics code
		[TestMethod]
		[RunsOnUIThread]
		public void When_LinkedResDict_ThemeUpdated()
		{
			const string TestBrush = nameof(TestBrush);
			const string TestThemeColor = nameof(TestThemeColor);
			const string Light = nameof(Light);
			const string Dark = nameof(Dark);

			var theme = ResourceDictionary.GetActiveTheme();
			try
			{
				// setup
				ResourceDictionary.SetActiveTheme("Light");

				// initialize source res-dict
				var parserContext = new XamlParseContext();
				var dontcare = new object();
				var source = new ResourceDictionary()
				{
					IsParsing = true,
					ThemeDictionaries =
					{
						[Light] = new WeakResourceInitializer(dontcare, that => new ResourceDictionary { [TestThemeColor] = Colors.Red, }),
						[Dark] = new WeakResourceInitializer(dontcare, that => new ResourceDictionary { [TestThemeColor] = Colors.Blue, }),
					},
					[TestBrush] = new WeakResourceInitializer(dontcare, that =>
					{
						var brush = new SolidColorBrush();
						ResourceResolverSingleton.Instance.ApplyResource(brush, SolidColorBrush.ColorProperty, TestThemeColor, true, false, parserContext);

						return brush;
					})
				};
				source.CreationComplete();

				// making a copy from source
				var copy = new ResourceDictionary();
				copy.CopyFrom(source);

				// retrieve the "TestBrush" from each res-dict while also materializing it in both the source and in the copy
				var materialized1 = (SolidColorBrush)source[TestBrush];
				var materialized2 = (SolidColorBrush)copy[TestBrush];
				var materialized2Color = materialized2.Color;

				// set active theme and update the copy res-dict
				ResourceDictionary.SetActiveTheme(Dark);
				copy.UpdateThemeBindings(Windows.UI.Xaml.Data.ResourceUpdateReason.ThemeResource);

				// retrieve the "TestBrush" again from each res-dict
				var materialized3 = (SolidColorBrush)source[TestBrush];
				var materialized4 = (SolidColorBrush)copy[TestBrush];

				// validation
				Assert.AreEqual(false, ReferenceEquals(materialized1, materialized2)); // we are expecting these to be different, as the CopyFrom should copy them as WeakResourceInitializer...
				Assert.AreEqual(false, ReferenceEquals(materialized3, materialized4)); // ^same
				Assert.AreNotEqual(materialized2Color, materialized4.Color); // check the theme change is actually applied (otherwise it would void the next check)
				Assert.AreEqual(materialized3.Color, materialized4.Color); // check the theme change is propagated to the source res-dict
			}
			finally
			{
				// clean up
				ResourceDictionary.SetActiveTheme(theme);
			}
		}
#endif
	}
}
