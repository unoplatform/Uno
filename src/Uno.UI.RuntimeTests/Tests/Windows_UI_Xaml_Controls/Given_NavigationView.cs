﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Input.Preview.Injection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Private.Infrastructure;
using Uno.UI.RuntimeTests.ListViewPages;
#if NETFX_CORE
using Uno.UI.Extensions;
#elif __IOS__
using UIKit;
#elif __MACOS__
using AppKit;
#else
using Uno.UI;
#endif

#if HAS_UNO_WINUI
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using NavigationView = Windows.UI.Xaml.Controls.NavigationView;
using NavigationViewItem = Windows.UI.Xaml.Controls.NavigationViewItem;
using NavigationViewList = Windows.UI.Xaml.Controls.NavigationViewList;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
#endif

using static Private.Infrastructure.TestServices;
using Uno.Extensions;
using Uno.UI.RuntimeTests.Extensions;
using Uno.UI.RuntimeTests.Helpers;
using Uno.UI.RuntimeTests.Tests.Uno_UI_Xaml_Core;
using Uno.UI.Toolkit.Extensions;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Controls
{
	[TestClass]
	[RunsOnUIThread]
	public partial class Given_NavigationView
	{
		[TestMethod]
		[RunsOnUIThread]
#if __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task When_NavView()
		{
			var SUT = new MyNavigationView() { IsSettingsVisible = false };
			SUT.MenuItems.Add(new NavigationViewItem { DataContext = this, Content = "Item 1" });

			WindowHelper.WindowContent = SUT;

			await WindowHelper.WaitForLoaded(SUT);

			var list = SUT.MenuItemsHost;
			var panel = list.ItemsPanelRoot;

			Assert.IsNotNull(panel);

			NavigationViewItem item2 = null;
			await SUT.Dispatcher.RunIdleAsync(a => SUT.MenuItems.Add(new NavigationViewItem() { DataContext = this, Content = "Item 2" }));
			await SUT.Dispatcher.RunIdleAsync(a => SUT.MenuItems.RemoveAt(1));
			await SUT.Dispatcher.RunIdleAsync(a => SUT.MenuItems.Add(item2 = new NavigationViewItem() { DataContext = this, Content = "Item 2" }));

			await WindowHelper.WaitForLoaded(item2);

			var children =
#if __ANDROID__ || __IOS__ // ItemsStackPanel is just a Xaml facade on Android/iOS, its Children list isn't populated
				list.GetItemsPanelChildren();
#else
				panel.Children;
#endif
			Assert.AreEqual(item2, children.Last());
		}

		[TestMethod]
		[RunsOnUIThread]
		[RequiresFullWindow]
		[Ignore("Failing on CI due to animations")]
#if false && __MACOS__
		[Ignore("Currently fails on macOS, part of #9282 epic")]
#endif
		public async Task MUX_When_MinimalHierarchicalAndSelectItem_Then_RemoveOverState()
		{
			var items = Enumerable
				.Range(0, 10)
				.Select(g =>
				{
					var item = new Microsoft.UI.Xaml.Controls.NavigationViewItem { Content = $"Group {g}" };
					item.MenuItems.AddRange(Enumerable
						.Range(0, 30)
						.Select(i => new Microsoft.UI.Xaml.Controls.NavigationViewItem { Content = $"Group {g} - Item {i}" } as object));

					return item;
				})
				.ToList();

			var SUT = new Microsoft.UI.Xaml.Controls.NavigationView
			{
				PaneDisplayMode = Microsoft.UI.Xaml.Controls.NavigationViewPaneDisplayMode.LeftMinimal,
				IsPaneToggleButtonVisible = true,
				IsBackButtonVisible = Microsoft.UI.Xaml.Controls.NavigationViewBackButtonVisible.Collapsed,
				IsPaneOpen = false
			};
			SUT.MenuItems.AddRange(items);

			await UITestHelper.Load(SUT);

			using var finger = InputInjector.TryCreate()?.GetFinger() ?? throw new InvalidOperationException("Failed to create finger");

			// This might not fail for each item, try to repro on mutliple items
			var item9 = await Select(0, 9);
			var item7 = await Select(0, 7);
			var item5 = await Select(0, 5);

			// Open the pane and expend the group 0 for screenshot
			await Expend(0);

			var screenShot = await UITestHelper.ScreenShot(SUT);

			ImageAssert.HasColorAt(screenShot, item9.GetLocation().Offset(5), "#E6E6E6");
			ImageAssert.HasColorAt(screenShot, item7.GetLocation().Offset(5), "#E6E6E6");
			ImageAssert.HasColorAt(screenShot, item5.GetLocation().Offset(5), "#E6E6E6");

			async Task OpenPane()
			{
				SUT.IsPaneOpen = true;
				await WindowHelper.WaitForIdle();
			}

			async Task Expend(int group)
			{
				await OpenPane();

				items[group].IsExpanded = true;
				await WindowHelper.WaitForIdle();
			}


			async Task<Rect> Select(int group, int item)
			{
				await Expend(group);

				var itemBounds = ((Microsoft.UI.Xaml.Controls.NavigationViewItem)items[group].MenuItems[item]).GetAbsoluteBounds();
				finger.Press(itemBounds.GetCenter());
				await WindowHelper.WaitForIdle();
				await Task.Delay(250 + 100); // Close animation

				return itemBounds;
			}
		}

	}
	public partial class MyNavigationView : NavigationView
	{
		public NavigationViewList MenuItemsHost { get; private set; }
		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			MenuItemsHost = GetTemplateChild("MenuItemsHost") as NavigationViewList;
		}
	}
}
