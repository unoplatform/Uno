using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Toolkit
{
	public partial class TabBar
	{
		public object ItemsSource
		{
			get { return (object)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public static readonly DependencyProperty ItemsSourceProperty =
			DependencyProperty.Register(nameof(ItemsSource), typeof(object), typeof(TabBar), new PropertyMetadata(default));

		public DataTemplateSelector TabBarItemTemplateSelector
		{
			get { return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty); }
			set { SetValue(ItemTemplateSelectorProperty, value); }
		}

		public static readonly DependencyProperty ItemTemplateSelectorProperty =
			DependencyProperty.Register(nameof(TabBarItemTemplateSelector), typeof(DataTemplateSelector), typeof(TabBar), new PropertyMetadata(default));

		public DataTemplate TabBarItemTemplate
		{
			get { return (DataTemplate)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}

		public static readonly DependencyProperty ItemTemplateProperty =
			DependencyProperty.Register(nameof(TabBarItemTemplate), typeof(DataTemplate), typeof(TabBar), new PropertyMetadata(default));

		public StyleSelector TabBarItemContainerStyleSelector
		{
			get { return (StyleSelector)GetValue(ItemContainerStyleSelectorProperty); }
			set { SetValue(ItemContainerStyleSelectorProperty, value); }
		}

		public static readonly DependencyProperty ItemContainerStyleSelectorProperty =
			DependencyProperty.Register(nameof(TabBarItemContainerStyleSelector), typeof(StyleSelector), typeof(TabBar), new PropertyMetadata(default));

		public Style TabBarItemContainerStyle
		{
			get { return (Style)GetValue(ItemContainerStyleProperty); }
			set { SetValue(ItemContainerStyleProperty, value); }
		}

		public static readonly DependencyProperty ItemContainerStyleProperty =
			DependencyProperty.Register(nameof(TabBarItemContainerStyle), typeof(Style), typeof(TabBar), new PropertyMetadata(default));

		public ItemsPanelTemplate TabBarItemsPanel
		{
			get { return (ItemsPanelTemplate)GetValue(ItemsPanelProperty); }
			set { SetValue(ItemsPanelProperty, value); }
		}

		public static readonly DependencyProperty ItemsPanelProperty =
			DependencyProperty.Register(nameof(TabBarItemsPanel), typeof(ItemsPanelTemplate), typeof(TabBar), new PropertyMetadata(default));

		public IList<object> Items
		{
			get { return (IList<object>)GetValue(ItemsProperty); }
			set { SetValue(ItemsProperty, value); }
		}

		public static readonly DependencyProperty ItemsProperty =
			DependencyProperty.Register(nameof(Items), typeof(IList<object>), typeof(TabBar), new PropertyMetadata(default));

		public object SelectedItem
		{
			get { return (object)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		public static readonly DependencyProperty SelectedItemProperty =
			DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(TabBar), new PropertyMetadata(default));

		public bool CanShowOverflow
		{
			get { return (bool)GetValue(CanShowOverflowProperty); }
			set { SetValue(CanShowOverflowProperty, value); }
		}

		public static readonly DependencyProperty CanShowOverflowProperty =
			DependencyProperty.Register(nameof(CanShowOverflow), typeof(bool), typeof(TabBar), new PropertyMetadata(default));

		public Style OverflowButtonStyle
		{
			get { return (Style)GetValue(OverflowButtonStyleProperty); }
			set { SetValue(OverflowButtonStyleProperty, value); }
		}

		public static readonly DependencyProperty OverflowButtonStyleProperty =
			DependencyProperty.Register(nameof(OverflowButtonStyle), typeof(Style), typeof(TabBar), new PropertyMetadata(default));

		public SelectionIndicatorPlacement SelectionIndicatorPlacement
		{
			get { return (SelectionIndicatorPlacement)GetValue(SelectionIndicatorPlacementProperty); }
			set { SetValue(SelectionIndicatorPlacementProperty, value); }
		}

		public static readonly DependencyProperty SelectionIndicatorPlacementProperty =
			DependencyProperty.Register(nameof(SelectionIndicatorPlacement), typeof(SelectionIndicatorPlacement), typeof(TabBar), new PropertyMetadata(SelectionIndicatorPlacement.Below));

		public UIElement SelectionIndicator
		{
			get { return (UIElement)GetValue(SelectionIndicatorProperty); }
			set { SetValue(SelectionIndicatorProperty, value); }
		}

		public static readonly DependencyProperty SelectionIndicatorProperty =
			DependencyProperty.Register(nameof(SelectionIndicator), typeof(UIElement), typeof(TabBar), new PropertyMetadata(default));

		public Style SelectionIndicatorStyle
		{
			get { return (Style)GetValue(SelectionIndicatorStyleProperty); }
			set { SetValue(SelectionIndicatorStyleProperty, value); }
		}

		public static readonly DependencyProperty SelectionIndicatorStyleProperty =
			DependencyProperty.Register(nameof(SelectionIndicatorStyle), typeof(Style), typeof(TabBar), new PropertyMetadata(default));

		public DataTemplate SelectionIndicatorTemplate
		{
			get { return (DataTemplate)GetValue(SelectionIndicatorTemplateProperty); }
			set { SetValue(SelectionIndicatorTemplateProperty, value); }
		}

		public static readonly DependencyProperty SelectionIndicatorTemplateProperty =
			DependencyProperty.Register(nameof(SelectionIndicatorTemplate), typeof(DataTemplate), typeof(TabBar), new PropertyMetadata(default));

		public DataTemplateSelector SelectionIndicatorTemplateSelector
		{
			get { return (DataTemplateSelector)GetValue(SelectionIndicatorTemplateSelectorProperty); }
			set { SetValue(SelectionIndicatorTemplateSelectorProperty, value); }
		}

		public static readonly DependencyProperty SelectionIndicatorTemplateSelectorProperty =
			DependencyProperty.Register(nameof(SelectionIndicatorTemplateSelector), typeof(DataTemplateSelector), typeof(TabBar), new PropertyMetadata(default));
	}
}
