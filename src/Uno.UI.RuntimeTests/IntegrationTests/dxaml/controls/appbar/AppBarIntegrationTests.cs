using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Tests.Common;
using Windows.UI.Xaml.Tests.Enterprise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Private.Infrastructure;
using Uno.UI.RuntimeTests.MUX.Helpers;
using Uno.UI.RuntimeTests.Helpers;

using static Private.Infrastructure.TestServices;
using System;
using Windows.UI.Xaml;

namespace Windows.UI.Tests.Enterprise.AppBarTests
{
	[TestClass]
	public class AppBarIntegrationTests : BaseDxamlTestClass
	{
		[ClassInitialize]
		void ClassSetup()
		{
			CommonTestSetupHelper.CommonTestClassSetup();
		}

		[ClassCleanup]
		void TestCleanup()
		{
			TestServices.WindowHelper.VerifyTestCleanup();
		}

		//
		// Test Cases
		//
		//void AppBarIntegrationTests::CanInstantiate()
		//{
		//	Generic::DependencyObjectTests < xaml_controls::AppBar >::CanInstantiate();
		//}

		[TestMethod]
		public async Task CanEnterAndLeaveLiveTree()
		{
			TestCleanupWrapper cleanup;

			AppBar appBar = null;
			Page page = null;

			var hasLoadedEvent = new Event();
			var hasUnloadedEvent = new Event();

			var loadedRegistration = CreateSafeEventRegistration<AppBar, RoutedEventHandler>("Loaded");
			var unloadedRegistration = CreateSafeEventRegistration<AppBar, RoutedEventHandler>("Unloaded");

			await RunOnUIThread(() =>
			{
				appBar = new AppBar();
				loadedRegistration.Attach(appBar, (s, e) =>
				{
					hasLoadedEvent.Set();
				});

				unloadedRegistration.Attach(appBar, (s, e) =>
				{
					hasUnloadedEvent.Set();
				});

				page = TestServices.WindowHelper.SetupSimulatedAppPage();
			});

			TestServices.WindowHelper.WaitForIdle();

			//UNO TODO: Implement TopAppBar
			// Verify enter/leave for top appbar.
			//	LOG_OUTPUT(L"Verify enter/leave for top appbar.");
			//	RunOnUIThread([&]()

			//{
			//		page->TopAppBar = appBar;
			//		appBar->IsOpen = true;
			//	});
			//	hasLoadedEvent->WaitForDefault();

			//	RunOnUIThread([&]()

			//{
			//		page->TopAppBar = nullptr;
			//	});
			//	hasUnloadedEvent->WaitForDefault();

			//UNO TODO: Implement BottomAppBar
			// Verify enter/leave for bottom appbar.
			//LOG_OUTPUT(L"Verify enter/leave for bottom appbar.");
			//RunOnUIThread([&]()

			//{
			//	page->BottomAppBar = appBar;
			//	appBar->IsOpen = true;
			//});
			//hasLoadedEvent->WaitForDefault();

			//RunOnUIThread([&]()

			//{
			//	page->BottomAppBar = nullptr;
			//});
			//hasUnloadedEvent->WaitForDefault();

			// Verify enter/leave for inline appbar.
			LOG_OUTPUT("Verify enter/leave for inline appbar.");
			await RunOnUIThread(() =>
			{
				page.Content = appBar;
				appBar.IsOpen = true;
			});
			hasLoadedEvent.WaitForDefault();

			await RunOnUIThread(() =>
			{
				page.Content = null;
			});
			hasUnloadedEvent.WaitForDefault();
		}


		[TestMethod]
		public async Task CanOpenAndCloseUsingAPI()
		{
			TestCleanupWrapper cleanup;

			AppBar appBar = null;
			Page page = null;

			var openedEvent = new Event();
			var closedEvent = new Event();

			var openedRegistration = CreateSafeEventRegistration<AppBar, EventHandler<object>>("Opened");
			var closedRegistration = CreateSafeEventRegistration<AppBar, EventHandler<object>>("Closed");

			// Setup our environment.
			await RunOnUIThread(() =>
			{
				appBar = new AppBar();
				openedRegistration.Attach(appBar, (s, e) => openedEvent.Set());
				closedRegistration.Attach(appBar, (s, e) => closedEvent.Set());

				page = TestServices.WindowHelper.SetupSimulatedAppPage();
			});
			WindowHelper.WaitForIdle();

			//UNO TODO: Implement TapAppBar
			// Verify open/close for top appbar.
			//LOG_OUTPUT(L"Verify open/close for top appbar.");
			//RunOnUIThread([&]()

			//{
			//		page->TopAppBar = appBar;
			//		appBar->IsOpen = true;
			//	});
			//	openedEvent->WaitForDefault();

			//	RunOnUIThread([&]()

			//{
			//	appBar->IsOpen = false;
			//});
			//closedEvent->WaitForDefault();

			//RunOnUIThread([&]()

			//{
			//		page->TopAppBar = nullptr;
			//	});
			//	TestServices::WindowHelper->WaitForIdle();

			//UNO TODO: Implement BottomAppBar
			//	// Verify open/close for bottom appbar.
			//	LOG_OUTPUT(L"Verify open/close for bottom appbar.");
			//	RunOnUIThread([&]()

			//{
			//	page->BottomAppBar = appBar;
			//	appBar->IsOpen = true;
			//});
			//openedEvent->WaitForDefault();

			//RunOnUIThread([&]()

			//{
			//		appBar->IsOpen = false;
			//	});
			//	closedEvent->WaitForDefault();

			//	RunOnUIThread([&]()

			//{
			//		page->BottomAppBar = nullptr;
			//	});
			//	TestServices::WindowHelper->WaitForIdle();
			//}

		}
	}
}
