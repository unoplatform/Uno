﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using Uno.UITest;
using Uno.UI.RuntimeTests.Helpers;
using Uno.UITest.Helpers.Queries;
using static Private.Infrastructure.TestServices;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;
using MUXControlsTestApp;
using Windows.Foundation.Metadata;


namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Controls
{
	[TestClass]
	[RunsOnUIThread]
	public class Canvas_Measurement_Tests
	{
		private const string Red = "#FFFF0000";
		private const string Blue = "#FF0000FF";
		private const string Green = "#FF008000";
		private const string Brown = "#FFA52A2A";

	[TestMethod]
		public void When_Measure_CanvasChildren()
		{
			var canvas = new Measure_Children_In_Canvas();
			WindowHelper.WindowContent = canvas;
			WindowHelper.WaitForLoaded(canvas);
			var inBorder = canvas.BBorderInCanvas;
			var outBorder = canvas.BBorderOutCanvas;

			using var _ = new AssertionScope();
			inBorder.Width.Should().Be(outBorder.Width, "Border in canvas measurement failed");
			inBorder.Height.Should().Be(outBorder.Height, "Border in canvas measurement failed");
		}

		[TestMethod]

		public async Task When_Verify_Canvas_With_Outer_Clip()
		{
			#if __MACOS__ //Color are not interpreted the same way in Mac
				Assert.Inconclusive();
			#endif
			if (!ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.Imaging.RenderTargetBitmap"))
			{
				Assert.Inconclusive(); // "System.NotImplementedException: RenderTargetBitmap is not supported on this platform.";
			}

			var canvas = new Canvas_With_Outer_Clip();
			var clippedLocation = canvas.LocatorBorder1;
			var unclippedLocation = canvas.LocatorBorder2;
			var bitmap = await RawBitmap.TakeScreenshot(canvas);

			ImageAssert.HasColorAtChild(bitmap, clippedLocation, (float)clippedLocation.Width / 2, (float)clippedLocation.Height / 2, Red, tolerance: 10);
			ImageAssert.HasColorAtChild(bitmap, unclippedLocation, (float)unclippedLocation.Width / 2, (float)unclippedLocation.Height / 2, Blue, tolerance: 10);
		}

		[TestMethod]
		public async Task When_Verify_Canvas_ZIndex()
		{
			#if __MACOS__
				Assert.Inconclusive(); //Color are not interpreted the same way in Mac
			#endif
			#if __ANDROID__
				Assert.Inconclusive(); // Android doesn't support Canvas.ZIndex on any panel
			#endif
			if (!ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.Imaging.RenderTargetBitmap"))
			{
				Assert.Inconclusive(); // System.NotImplementedException: RenderTargetBitmap is not supported on this platform.;
			}

			var canvas = new CanvasZIndex();
			var redBorderRect1 = canvas.CanvasBorderRed1;
			var redBorderRect2 = canvas.CanvasBorderRed2;
			var redBorderRect3 = canvas.CanvasBorderRed3;
			var greenBorderRect1 = canvas.CanvasBorderGreen1;
			var greenBorderRect2 = canvas.CanvasBorderGreen1;
			var greenBorderRect3 = canvas.CanvasBorderGreen3;
			var bitmap = await RawBitmap.TakeScreenshot(canvas);

			
			ImageAssert.HasColorAtChild(bitmap, redBorderRect1, (float)redBorderRect1.Width / 2,
				(float)redBorderRect1.Height / 2, Green, tolerance: 10);		
			ImageAssert.HasColorAtChild(bitmap, redBorderRect2, (float)redBorderRect2.Width / 2,
				(float)redBorderRect2.Height / 2, Green, tolerance: 10);		
			ImageAssert.HasColorAtChild(bitmap, redBorderRect3, (float)redBorderRect3.Width / 2,
				(float)redBorderRect3.Height / 2, Green, tolerance: 10);
	
			ImageAssert.HasColorAtChild(bitmap, greenBorderRect1, (float)greenBorderRect1.Width / 2,
				(float)greenBorderRect1.Height / 2, Brown, tolerance: 10);
			ImageAssert.HasColorAtChild(bitmap, greenBorderRect1, (float)greenBorderRect1.Width - 1,
				(float)greenBorderRect1.Height / 2, Blue, tolerance: 10);
	
			ImageAssert.HasColorAtChild(bitmap,greenBorderRect2, (float)greenBorderRect2.Width / 2,
				(float)greenBorderRect2.Height / 2, Brown, tolerance: 10);
			ImageAssert.HasColorAtChild(bitmap,greenBorderRect2, (float)greenBorderRect2.Width - 1,
				greenBorderRect2.Height / 2, Blue, tolerance: 10);
				
			ImageAssert.HasColorAtChild(bitmap, greenBorderRect3, (float)greenBorderRect3.Width / 2,
				(float)greenBorderRect3.Height / 2, Brown, tolerance: 10);
			ImageAssert.HasColorAtChild(bitmap, greenBorderRect3, (float)greenBorderRect3.Width - 1,
				(float)greenBorderRect3.Height / 2, Blue, tolerance: 10);
		}

		[TestMethod]
		public async Task When_Verify_Canvas_In_Canvas()
		{
			#if __MACOS__
				Assert.Inconclusive(); //Color are not interpreted the same way in Mac
			# endif
			if (!ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.Imaging.RenderTargetBitmap"))
			{
				Assert.Inconclusive(); // "System.NotImplementedException: RenderTargetBitmap is not supported on this platform.";
			}

			var canvas = new Canvas_In_Canvas();
			var clippedLocation = canvas.CanvasBorderBlue1;
			var bitmap = await RawBitmap.TakeScreenshot(canvas);
			
			ImageAssert.HasColorAtChild(bitmap, clippedLocation, (float)clippedLocation.Width / 2,
				clippedLocation.Height / 2, Blue, tolerance: 10);
		}
	}
}

