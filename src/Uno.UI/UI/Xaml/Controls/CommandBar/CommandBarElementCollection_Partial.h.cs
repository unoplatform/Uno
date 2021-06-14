using System.Collections;
using System.Collections.Generic;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml.Controls
{
	internal partial class CommandBarElementCollection : IObservableVector<ICommandBarElement>
	{
		bool m_notifyCollectionChanging = false;
		CommandBar m_parent = null;
	}
}
