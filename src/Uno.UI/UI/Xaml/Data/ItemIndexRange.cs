using System;
using System.Collections.Generic;
using System.Text;
using DirectUI;
using DirectUI.Components;

namespace Windows.UI.Xaml.Data;

public partial class ItemIndexRange
{
	internal ItemIndexRange()
	{
	}
	public ItemIndexRange(int firstIndex, uint length)
	{
		this.FirstIndex = firstIndex;
		this.Length = length;
	}

	public int FirstIndex { get; }
	public int LastIndex => FirstIndex + (int)Length - 1;
	public uint Length { get; }
}
public partial class ItemIndexRange
{
	/// <summary>
	/// goes through the vector and creates ranges from continuous indices
	/// </summary>
	/// <param name="indices"></param>
	/// <returns></returns>
	internal static TrackerCollection<ItemIndexRange> AppendItemIndexRangesFromSortedVectorToItemIndexRangeCollection(IReadOnlyList<int> indices)
	{
		var pCollection = new TrackerCollection<ItemIndexRange>();
		var size = indices.Count;
		var length = 1;

		for (var i = 0; i < size; i += length)
		{
			length = ItemIndexRangeHelper.GetContinousIndicesLengthStartingAtIndex(indices, i);

			pCollection.Add(new(indices[i], (uint)length));
		}

		return pCollection;
	}
}
