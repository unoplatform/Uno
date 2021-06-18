using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls
{
	partial class CommandBar
	{
		public event TypedEventHandler<CommandBar, DynamicOverflowItemsChangingEventArgs> DynamicOverflowItemsChanging;

		ItemsControl m_tpPrimaryItemsControlPart;
		ItemsControl m_tpSecondaryItemsControlPart;
	}
}
