﻿using NUnit.Framework;
using SamplesApp.UITests.TestFramework;
using Uno.UITest.Helpers;
using Uno.UITest.Helpers.Queries;

namespace SamplesApp.UITests.MessageDialogTests
{
	[TestFixture]
	public partial class MessageDialogTest : SampleControlUITestBase
	{
		[Test]
		[AutoRetry]
		public void When_Click_Outside_Dialog_Expect_No_Dismiss()
		{
			Run("UITests.MessageDialog.MessageDialogTest");
			var button = _app.Marked("showDialogBtn");
			_app.WaitForElement(button);
			button.FastTap();

			using var screenshot = TakeScreenshot("BeforeClicking");

			var label = _app.Marked("labelOutside");
			_app.WaitForElement(label);
			label.FastTap();

			using var screenshot2 = TakeScreenshot("AfterClicking");

			ImageAssert.AreEqual(screenshot, screenshot2);

			// Close the dialog.
			var chkBox = _app.Marked("chkBox");
			chkBox.SetDependencyPropertyValue("IsChecked", "True");
		}
	}
}
