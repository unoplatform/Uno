using System.Collections;
using System.Collections.Generic;
using DirectUI;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml.Controls
{
	internal partial class CommandBarElementCollection : IObservableVector<ICommandBarElement>, IVector<ICommandBarElement>
	{
		bool m_notifyCollectionChanging = false;
		CommandBar m_parent = null;
	}
}
