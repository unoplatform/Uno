using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Toolkit
{
	public partial class TabBar : Control
	{
		private const string TabBarGridName = "TabBarGrid";
		private const string RootGridName = "RootGrid";
		private const string SelectionIndicatorPresenterName = "SelectionIndicatorPresenter";
		private const string TabBarItemsHostName = "TabBarItemsHost";
		private const string SelectionIndicatorTransformName = "SelectionIndicatorTransform";

		private ListView _tabBarItemsHost;
		private Grid _tabBarGrid;
		private Grid _rootGrid;
		private ContentPresenter _selectionIndicatorPresenter;
		private TranslateTransform _selectionIndicatorTransform;


		public TabBar()
		{
			DefaultStyleKey = typeof(TabBar);

			var items = new ObservableCollection<TabBarItemBase>();
			SetValue(ItemsProperty, items);
		}

		protected override void OnApplyTemplate()
		{
			_tabBarGrid = GetTemplateChild<Grid>(TabBarGridName);
			_rootGrid = GetTemplateChild<Grid>(RootGridName);
			_selectionIndicatorPresenter = GetTemplateChild<ContentPresenter>(SelectionIndicatorPresenterName);
			_tabBarItemsHost = GetTemplateChild<ListView>(TabBarItemsHostName);
			_selectionIndicatorTransform = GetTemplateChild<TranslateTransform>(SelectionIndicatorTransformName);

			_tabBarItemsHost?.RegisterDisposablePropertyChangedCallback(ListView.SelectedItemProperty, OnInnerSelectedItemChanged);

			UpdateItems();
		}

		private void OnInnerSelectedItemChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue == SelectedItem)
			{
				return;
			}

			SelectedItem = args.NewValue as TabBarItemBase;
		}

		private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			if (sender is TabBar tabBar)
			{
				tabBar.OnSelectedItemChanged(args);
			}
		}

		private static void OnItemsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			if (sender is TabBar tabBar)
			{
				tabBar.UpdateItems();
			}
		}

		private void OnSelectedItemChanged(DependencyPropertyChangedEventArgs args)
		{
			var oldItem = args.OldValue as TabBarItemBase;
			var newItem = args.NewValue as TabBarItemBase;

			Point point = new Point(0, 0);
			double nextPos;

			nextPos = newItem.TransformToVisual(_tabBarGrid).TransformPoint(point).X;

			_selectionIndicatorTransform.X = nextPos;

			_tabBarItemsHost.SelectedItem = newItem;
		}

		private void UpdateItems()
		{
			if (_tabBarItemsHost != null)
			{
				_tabBarItemsHost.ItemsSource = Items;
				InvalidateMeasure();
			}
		}
	}
}
