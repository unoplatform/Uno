using System;
using System.Collections.Generic;
using System.Text;

namespace Uno.UI.Toolkit
{
    public partial class TabBarSelectionChangedEventArgs
    {
		public object NewItem
		{
			get; internal set;
		}

		public object OldItem
		{
			get; internal set;
		}

		public TabBarItemBase NewItemContainer
		{
			get; internal set;
		}

		public TabBarItemBase OldItemContainer
		{
			get; internal set;
		}

		public double NewItemCenterX
		{
			get; internal set;
		}

		public double OldItemCenterX
		{
			get; internal set;
		}
	}
}
