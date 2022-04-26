﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.UI.RuntimeTests.Helpers;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using static Private.Infrastructure.TestServices;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Controls
{
#if HAS_UNO
	[TestClass]
	[RunsOnUIThread]
#if !__IOS__
	[Ignore]
#endif
	public class Given_GridView_Items
	{
		[TestMethod]
		public async Task When_GridViewItems_LayoutSlots()
		{
			var gridView = new GridView
			{
				ItemContainerStyle = TestsResourceHelper.GetResource<Style>("MyGridViewItemStyle")
			};

			var gvi = new GridViewItem();
			var gvi2 = new GridViewItem();

			gridView.ItemsSource = new[] { gvi, gvi2 };

			WindowHelper.WindowContent = gridView;
			await WindowHelper.WaitForLoaded(gridView);
			await WindowHelper.WaitForIdle();

			RectAssert.AreEqual(new Rect
			{
				X = 0d,
				Y = 0d,
				Width = 104d,
				Height = 104d,
			},
			gvi.LayoutSlot);

			RectAssert.AreEqual(new Rect
			{
				X = 0d,
				Y = 0d,
				Width = 100d,
				Height = 100d,
			},
			gvi.LayoutSlotWithMarginsAndAlignments);

			RectAssert.AreEqual(new Rect
			{
				X = 104d,
				Y = 0d,
				Width = 104d,
				Height = 104d,
			},
			gvi2.LayoutSlot);

			RectAssert.AreEqual(new Rect
			{
				X = 104d,
				Y = 0d,
				Width = 100d,
				Height = 100d,
			},
			gvi2.LayoutSlotWithMarginsAndAlignments);
		}
	}
#endif
}
