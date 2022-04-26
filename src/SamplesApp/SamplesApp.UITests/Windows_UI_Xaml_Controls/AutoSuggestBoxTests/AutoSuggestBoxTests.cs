﻿using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using SamplesApp.UITests.TestFramework;
using Uno.UITest;
using Uno.UITest.Helpers;
using Uno.UITest.Helpers.Queries;

namespace SamplesApp.UITests.Windows_UI_Xaml_Controls.TextBoxTests
{
	[TestFixture]
	public partial class AutoSuggestBoxTests : SampleControlUITestBase
	{
		[Test]
		[AutoRetry]
		public void PasswordBox_With_Description()
		{
			Run("UITests.Windows_UI_Xaml_Controls.AutoSuggestBoxTests.AutoSuggestBox_Description", skipInitialScreenshot: true);
			var autoSuggestBoxRect = ToPhysicalRect(_app.WaitForElement("DescriptionAutoSuggestBox")[0].Rect);
			using var screenshot = TakeScreenshot("AutoSuggestBox Description", new ScreenshotOptions() { IgnoreInSnapshotCompare = true });
			ImageAssert.HasColorAt(screenshot, autoSuggestBoxRect.X + autoSuggestBoxRect.Width / 2, autoSuggestBoxRect.Y + autoSuggestBoxRect.Height - 50, Color.Red);
		}
	}
}
