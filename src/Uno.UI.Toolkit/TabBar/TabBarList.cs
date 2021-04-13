using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Toolkit
{
	public partial class TabBarList : ListView
	{
		protected override bool IsItemItsOwnContainerOverride(object item) => item is TabBarItem;

		protected override DependencyObject GetContainerForItemOverride() => new TabBarItem();

		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			if (element is TabBarItem container)
			{
				// Case A from xaml: item is TabBarButton for source
				if (item is TabBarItem)
				{

				}
				// Case B with databind: item is a view-model or anything
				else
				{
					container.DataContext = item;
				}
			}

			base.PrepareContainerForItemOverride(element, item);
		}

		protected override void ClearContainerForItemOverride(DependencyObject element, object item)
		{
			if (element is TabBarItem container)
			{
				container.DataContext = null;
			}

			base.ClearContainerForItemOverride(element, item);
		}
	}
}
