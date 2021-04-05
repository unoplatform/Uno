using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Toolkit
{
	public partial class TabBar : Control
	{
		private const string TabBarItemsHostName = "TabBarItemsHost";
		private const string TabBarGridName = "TabBarGrid";
		private const string RootGridName = "RootGrid";
		private const string SelectionIndicatorPresenterName = "SelectionIndicatorPresenter";
		private const string TabBarOverflowButtonName = "TabBarOverflowButton";
		private const string TabBarItemsOverflowHostName = "TabBarItemsOverflowHost";

		private ListView _tabBarItemsHost;
		private ListView _tabBarItemsOverflowHost;
		private Grid _tabBarGrid;
		private Grid _rootGrid;
		private ContentPresenter _selectionIndicatorPresenter;
		private Button _tabBarOverflowButton;


		public TabBar()
		{
			DefaultStyleKey = typeof(TabBar);
		}

		protected override void OnApplyTemplate()
		{
			_tabBarItemsHost = GetTemplateChild<ListView>(TabBarItemsOverflowHostName);
			_tabBarItemsOverflowHost = GetTemplateChild<ListView>(TabBarItemsHostName);
			_tabBarGrid = GetTemplateChild<Grid>(TabBarGridName);
			_rootGrid = GetTemplateChild<Grid>(RootGridName);
			_selectionIndicatorPresenter = GetTemplateChild<ContentPresenter>(SelectionIndicatorPresenterName);
			_tabBarOverflowButton = GetTemplateChild<Button>(TabBarOverflowButtonName);
		}
	}
}
