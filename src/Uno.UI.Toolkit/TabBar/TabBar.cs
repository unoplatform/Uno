using System;
using System.Collections.ObjectModel;
using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Toolkit
{
	public partial class TabBar : Control
	{
		private const string TabBarGridName = "TabBarGrid";
		private const string SelectionIndicatorPresenterName = "SelectionIndicatorPresenter";
		private const string TabBarItemsHostName = "TabBarItemsHost";
		private const string SelectionIndicatorTransformName = "SelectionIndicatorTranslateTransform";

		private ListView _tabBarItemsHost;
		private Grid _tabBarGrid;
		private ContentPresenter _selectionIndicatorPresenter;
		private TranslateTransform _selectionIndicatorTransform;

		private SerialDisposable _tabBarListSubscriptions = new SerialDisposable();
		private SerialDisposable _sizeChangedSubscription = new SerialDisposable();

		public TabBar()
		{
			DefaultStyleKey = typeof(TabBar);

			var items = new ObservableCollection<object>();
			SetValue(ItemsProperty, items);

			Loaded += OnLoaded;
			Unloaded += OnUnloaded;
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			SizeChanged += OnSizeChanged;
			_sizeChangedSubscription.Disposable = Disposable.Create(() => SizeChanged -= OnSizeChanged);
		}

		private void OnUnloaded(object sender, RoutedEventArgs e)
		{
			UnhookTabBarListEvents();
			_sizeChangedSubscription.Disposable = null;
		}

		private void UnhookTabBarListEvents()
		{
			_tabBarListSubscriptions.Disposable = null;
		}

		protected override void OnApplyTemplate()
		{
			UnhookTabBarListEvents();

			var disposable = new CompositeDisposable();
			_tabBarListSubscriptions.Disposable = disposable;

			_tabBarGrid = GetTemplateChild(TabBarGridName) as Grid;
			_selectionIndicatorPresenter = GetTemplateChild(SelectionIndicatorPresenterName) as ContentPresenter;
			_tabBarItemsHost = GetTemplateChild(TabBarItemsHostName) as ListView;
			_selectionIndicatorTransform = GetTemplateChild(SelectionIndicatorTransformName) as TranslateTransform;

			if (GetTemplateChild(TabBarItemsHostName) is ListView tabBarItemsHost)
			{
				_tabBarItemsHost = tabBarItemsHost;

				_tabBarItemsHost.Loaded += OnTabBarListLoaded;
				_tabBarItemsHost.SelectionChanged += OnTabBarListSelectionChanged;

				disposable.Add(() => _tabBarItemsHost.Loaded -= OnTabBarListLoaded);
				disposable.Add(() => _tabBarItemsHost.SelectionChanged -= OnTabBarListSelectionChanged);
			}

			UpdateItemsSource();
		}


		private void OnTabBarListLoaded(object sender, RoutedEventArgs e)
		{
			var item = SelectedItem;
			if (item != null)
			{
				if (item is TabBarItem tabBarItem)
				{
					tabBarItem.IsSelected = true;
				}
				AnimateSelectionChanged(null /* prevItem */, item);
			}
		}

		private void OnTabBarListSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			object prevItem = null;
			object nextItem = null;

			if (e.RemovedItems.Count > 0)
			{
				prevItem = e.RemovedItems[0];
			}

			if (e.AddedItems.Count > 0)
			{
				nextItem = e.AddedItems[0];
			}

			if (prevItem != null && nextItem == null) // try to unselect an item but it's not allowed
			{
				// Always keep one item is selected
				if (prevItem is TabBarItem tabBarItem)
				{
					tabBarItem.IsSelected = true;
				}
			}
			else
			{
				SelectedItem = nextItem;
			}
		}

		private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			DependencyProperty property = args.Property;

			if (property == SelectedItemProperty)
			{
				OnSelectedItemChanged(args);
			}
			else if (property == ItemsProperty)
			{
				UpdateItemsSource();
			}
			else if (property == ItemsSourceProperty)
			{
				UpdateItemsSource();
			}
		}

		private void OnSelectedItemChanged(DependencyPropertyChangedEventArgs args)
		{
			ChangeSelection(args.OldValue, args.NewValue);
		}

		private void ChangeSelection(object prevItem, object nextItem)
		{
			ChangeSelectStatusForItem(nextItem, true);
			RaiseSelectionChangedEvent(prevItem, nextItem);

			AnimateSelectionChanged(prevItem, nextItem);
		}

		void AnimateSelectionChanged(object prevItem, object nextItem)
		{
			if (prevItem != nextItem)
			{
				_selectionIndicatorPresenter.Opacity = 1f;
				MoveSelectionIndicator(nextItem);
			}

		}

		private void OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			MoveSelectionIndicator(SelectedItem);
		}

		private bool ShouldShowSelectionIndicator() =>
			_selectionIndicatorPresenter != null && SelectionIndicator != null && ShowSelectionIndicator;


		private void MoveSelectionIndicator(object item)
		{
			if (!ShouldShowSelectionIndicator() || !AnimateSelectionIndicator)
			{
				return;
			}

			var tabBarItem = GetContainerForData<TabBarItemBase>(item);
			if (tabBarItem == null)
			{
				return;
			}

			var centerXPos = GetRelativeCenterPosition(tabBarItem);
			if (_selectionIndicatorTransform != null)
			{
				_selectionIndicatorTransform.X = centerXPos - ((_selectionIndicatorPresenter?.ActualWidth ?? 0) / 2);
			}
		}

		private double GetRelativeCenterPosition(TabBarItemBase tabBarItem)
		{
			if (_tabBarGrid == null)
			{
				return 0d;
			}

			var point = new Point(0, 0);
			double nextPos;

			var nextPosPoint = tabBarItem.TransformToVisual(_tabBarGrid).TransformPoint(point);

			nextPos = nextPosPoint.X + (tabBarItem.ActualWidth / 2);
			return nextPos;
		}

		void ChangeSelectStatusForItem(object item, bool selected)
		{
			var container = GetContainerForData<TabBarItemBase>(item);
			if (container != null)
			{
				container.IsSelected = selected;
			}
		}

		private void RaiseSelectionChangedEvent(object prevItem, object nextItem)
		{
			var eventArgs = new TabBarSelectionChangedEventArgs();
			eventArgs.OldItem = prevItem;
			eventArgs.NewItem = nextItem;

			var newContainer = GetContainerForData<TabBarItemBase>(nextItem);
			if (newContainer != null)
			{
				eventArgs.NewItemCenterX = GetRelativeCenterPosition(newContainer);
				eventArgs.NewItemContainer = newContainer;
			}

			var oldContainer = GetContainerForData<TabBarItemBase>(prevItem);
			if (oldContainer != null)
			{
				eventArgs.OldItemCenterX = GetRelativeCenterPosition(oldContainer);
				eventArgs.OldItemContainer = oldContainer;
			}

			SelectionChanged?.Invoke(this, eventArgs);
		}

		private void UpdateItemsSource()
		{
			if (_tabBarItemsHost != null)
			{
				_tabBarItemsHost.ItemsSource = ItemsSource ?? Items;
				InvalidateMeasure();
			}
		}

		private T GetContainerForData<T>(object data) where T : class
		{
			if (data == null)
			{
				return null;
			}

			if (data is T container)
			{
				return container;
			}

			var lv = _tabBarItemsHost;
			if (lv != null)
			{
				var itemContainer = lv.ContainerFromItem(data);
				if (itemContainer != null)
				{
					return itemContainer as T;
				}
			}

			return null;
		}
	}
}
