﻿using System;
using System.Collections.Generic;

namespace Microsoft.UI.Xaml.Controls
{
	internal struct SelectedItemInfo
	{
		internal WeakReference<SelectionNode> Node;
		internal IndexPath Path;
	}

	public partial class SelectionModel
	{
		internal SelectionNode SharedLeafNode => m_leafNode;

		private SelectionNode m_rootNode;
		private bool m_singleSelect;

		private IReadOnlyList<IndexPath> m_selectedIndicesCached;
		private IReadOnlyList<object> m_selectedItemsCached;

		// Cached Event args to avoid creation cost every time
		private SelectionModelChildrenRequestedEventArgs m_childrenRequestedEventArgs;
		private SelectionModelSelectionChangedEventArgs m_selectionChangedEventArgs;

		// use just one instance of a leaf node to avoid creating a bunch of these.
		private SelectionNode m_leafNode;
	}
}
