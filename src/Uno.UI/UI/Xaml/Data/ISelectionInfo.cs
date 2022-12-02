using System.Collections.Generic;

namespace Windows.UI.Xaml.Data;

public interface ISelectionInfo
{
	void SelectRange(ItemIndexRange itemIndexRange);
	void DeselectRange(ItemIndexRange itemIndexRange);
	bool IsSelected(int index);
	IReadOnlyList<ItemIndexRange> GetSelectedRanges();
}
