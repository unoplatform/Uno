﻿using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MUXControlsTestApp.Utilities;
using Private.Infrastructure;
using Uno.UI.RuntimeTests.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Tests.MUXControls.ApiTests
{
	[TestClass]
	public class DropDownButtonTests
	{
#if !WINDOWS_UWP // GetTemplateChild is protected in UWP while public in Uno.
		[TestMethod]
		[Description("Verifies that the TextBlock representing the Chevron glyph uses the correct font")]
		[Ignore("Fluent styles V2 use AnimatedIcon instead of FontIcon")]
		public void VerifyFontFamilyForChevron()
		{
			DropDownButton dropDownButton = null;
			using (StyleHelper.UseFluentStyles())
			{
				RunOnUIThread.Execute(() =>
				{
					dropDownButton = new DropDownButton();
					TestServices.WindowHelper.WindowContent = dropDownButton;

					var chevronTextBlock = dropDownButton.GetTemplateChild("ChevronTextBlock") as TextBlock;
					var font = chevronTextBlock.FontFamily;
					Verify.AreEqual((FontFamily)Application.Current.Resources["SymbolThemeFontFamily"], font);
				});
			}
		}
#endif
	}
}
