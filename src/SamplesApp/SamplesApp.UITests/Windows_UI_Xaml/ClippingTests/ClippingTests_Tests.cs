#nullable disable

using System.Drawing;
using FluentAssertions.Execution;
using NUnit.Framework;
using SamplesApp.UITests.TestFramework;
using Uno.UITest.Helpers;
using Uno.UITest.Helpers.Queries;

namespace SamplesApp.UITests.Windows_UI_Xaml.ClippingTests
{
	[TestFixture]
	public partial class ClippingTests_Tests : SampleControlUITestBase
	{
		[Test]
		[AutoRetry]
		public void When_Clip_Is_Set_On_Container_Element()
		{
			Run("UITests.Windows_UI_Xaml.Clipping.Clipping652");

			var grid1 = _app.Marked("ClippingGrid1");
			var grid2 = _app.Marked("ClippingGrid2");

			_app.WaitForElement(grid1);
			_app.WaitForElement(grid2);

			var rect1 = grid1.FirstResult().Rect;
			var rect2 = grid2.FirstResult().Rect;

			using var screenshot = TakeScreenshot("Clipping");

			ImageAssert.HasColorAt(screenshot, rect1.Right + 8, rect1.Y + 75, Color.Blue);
			ImageAssert.HasColorAt(screenshot, rect1.X + 75, rect1.Bottom + 8, Color.Blue);

			ImageAssert.HasColorAt(screenshot, rect2.Right + 8, rect2.Y + 75, Color.Blue);
			ImageAssert.HasColorAt(screenshot, rect2.X + 75, rect2.Bottom + 8, Color.Blue);
		}

		[Test]
		[AutoRetry]
		public void When_Clipped_Rounded_Corners()
		{
			Run("UITests.Windows_UI_Xaml.Clipping.Clipping4273");

			_app.WaitForElement("RoundedGrid");

			var offset = LogicalToPhysical(5);
			var rect = _app.GetPhysicalRect("RoundedGrid").DeflateBy(offset);

			using var screenshot = TakeScreenshot("ClippedCorners", ignoreInSnapshotCompare: true);
			ImageAssert.HasColorAt(screenshot, rect.CenterX, rect.CenterY, Color.Blue);
			ImageAssert.HasColorAt(screenshot, rect.X, rect.Y, Color.Red);

		}

		[Test]
		[AutoRetry]
		public void When_CornerRadiusControls()
		{
			Run("UITests.Windows_UI_Xaml.Clipping.CornerRadiusControls");

			_app.WaitForElement("TestRoot");

			using var snapshot = this.TakeScreenshot("validation", ignoreInSnapshotCompare: false);

			using (new AssertionScope("Rounded corners"))
			{
				CheckRoundedCorners("ctl1");
				CheckRoundedCorners("ctl2");
				CheckRoundedCorners("ctl3");
				CheckRoundedCorners("ctl4");
				CheckRoundedCorners("ctl5");
				CheckRoundedCorners("ctl6");
				CheckRoundedCorners("ctl7");
				CheckRoundedCorners("ctl8");
			}
			using (new AssertionScope("No Rounded corners"))
			{
				CheckNoRoundedCorners("ctl1_rect");
				CheckNoRoundedCorners("ctl2_rect");
				CheckNoRoundedCorners("ctl3_rect");
			}

			void CheckRoundedCorners(string s)
			{
				var rectCtl = _app.GetPhysicalRect(s);

				var green = "#FF008000";
				var white = "#FFFFFFFF";

				ImageAssert.HasPixels(
					snapshot,
					ExpectedPixels
						.At("top-middle " + s, rectCtl.CenterX, rectCtl.Y + 2)
						.WithPixelTolerance(1, 1)
						.Pixel(green),
					ExpectedPixels
						.At("bottom-middle " + s, rectCtl.CenterX, rectCtl.Bottom - 2)
						.WithPixelTolerance(1, 1)
						.Pixel(green),
					ExpectedPixels
						.At("left-middle " + s, rectCtl.X + 2, rectCtl.CenterY)
						.WithPixelTolerance(1, 1)
						.Pixel(green),
					ExpectedPixels
						.At("right-middle " + s, rectCtl.Right - 2, rectCtl.CenterY)
						.WithPixelTolerance(1, 1)
						.Pixel(green),
					ExpectedPixels
						.At("top-left " + s, rectCtl.X + 1, rectCtl.Y + 1)
						.Pixel(white),
					ExpectedPixels
						.At("top-right " + s, rectCtl.Right - 1, rectCtl.Y + 1)
						.Pixel(white),
					ExpectedPixels
						.At("bottom-left " + s, rectCtl.X + 1, rectCtl.Bottom - 1)
						.Pixel(white),
					ExpectedPixels
						.At("bottom-right " + s, rectCtl.Right - 1, rectCtl.Bottom - 1)
						.Pixel(white)
				);
			}

			void CheckNoRoundedCorners(string s)
			{
				var rectCtl = _app.GetPhysicalRect(s);

				var green = "#FF008000";

				ImageAssert.HasPixels(
					snapshot,
					ExpectedPixels
						.At("top-middle " + s, rectCtl.CenterX, rectCtl.Y + 2)
						.WithPixelTolerance(1, 1)
						.Pixel(green),
					ExpectedPixels
						.At("bottom-middle " + s, rectCtl.CenterX, rectCtl.Bottom - 2)
						.WithPixelTolerance(1, 1)
						.Pixel(green),
					ExpectedPixels
						.At("left-middle " + s, rectCtl.X + 2, rectCtl.CenterY)
						.WithPixelTolerance(1, 1)
						.Pixel(green),
					ExpectedPixels
						.At("right-middle " + s, rectCtl.Right - 2, rectCtl.CenterY)
						.WithPixelTolerance(1, 1)
						.Pixel(green),
					ExpectedPixels
						.At("top-left " + s, rectCtl.X + 1, rectCtl.Y + 1)
						.Pixel(green),
					ExpectedPixels
						.At("top-right " + s, rectCtl.Right - 1, rectCtl.Y + 1)
						.Pixel(green),
					ExpectedPixels
						.At("bottom-left " + s, rectCtl.X + 1, rectCtl.Bottom - 1)
						.Pixel(green),
					ExpectedPixels
						.At("bottom-right " + s, rectCtl.Right - 1, rectCtl.Bottom - 1)
						.Pixel(green)
				);
			}
		}
	}
}
