// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using System;
using System.Collections.Generic;
using System.Text;
using DirectUI;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Controls;

//  Abstract:
//      ListViewBase displays a rich, interactive collection of items.
partial class ListViewBase
{
	private IItemsRangeInfo m_tpDataSourceAsItemsRangeInfo;

	private ItemIndexRange m_tpLastPassedVisibleRange;

	private TrackerCollection<ItemIndexRange> m_tpLastPassedTrackedRanges;

	//public IReadOnlyList<ItemIndexRange> SelectedRanges { get; }

	/// <summary>
	/// Stores a handle to the items source as an IItemsRangeInfo if possible
	/// </summary>
	private void InitializeDataSourceItemsRangeInfo()
	{
#if false // Uno specific: fix setting a new ItemsSource not cleaning up previous ItemsSource
		var spItemsSourceAsIInspectable = ItemsSource;
		if (spItemsSourceAsIInspectable is { })
		{
			var spItemsSourceAsIRI = spItemsSourceAsIInspectable as IItemsRangeInfo;
			if (spItemsSourceAsIRI)
			{
				m_tpDataSourceAsItemsRangeInfo = spItemsSourceAsIRI;
				m_tpLastPassedVisibleRange = new();
		
				// if it was already created, just clear the collection
				if (m_tpLastPassedTrackedRanges is { })
				{
					m_tpLastPassedTrackedRanges.Clear();
				}
				else
				{
					m_tpLastPassedTrackedRanges = new();
				}
			}
		}
#else
		m_tpDataSourceAsItemsRangeInfo = ItemsSource as IItemsRangeInfo;
		if (m_tpDataSourceAsItemsRangeInfo is { })
		{
			m_tpLastPassedVisibleRange = new();
			m_tpLastPassedTrackedRanges?.Clear();
			m_tpLastPassedTrackedRanges ??= new();
		}
		else
		{
			m_tpLastPassedVisibleRange = default;
			m_tpLastPassedTrackedRanges?.Clear();
		}
#endif
	}

	/// <summary>
	/// Used to inform the data source of the items it is tracking
	/// in this function, we collect the data
	/// </summary>
	private void InitializeDataSourceSelectionInfo()
	{
#if false // Uno specific: fix setting a new ItemsSource not cleaning up previous ItemsSource
		if (ItemsSource is ISelectionInfo spItemsSourceAsSI)
		{
			DataSourceAsSelectionInfo = spItemsSourceAsSI;
		}
#else
		DataSourceAsSelectionInfo = ItemsSource as ISelectionInfo;
#endif
	}
}
