using System;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Data;

public interface IItemsRangeInfo : IDisposable
{
	void RangesChanged(ItemIndexRange visibleRange, IReadOnlyList<ItemIndexRange> trackedItems);
}
