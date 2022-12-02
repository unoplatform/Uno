// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectUI;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Uno.Disposables;

namespace Windows.UI.Xaml.Controls.Primitives;

partial class Selector
{
	internal protected Selection m_selection;

	private ISelectionInfo m_tpDataSourceAsSelectionInfo;

	private TrackerCollection<ItemIndexRange> m_tpSelectedRangesImpl;

	//private TrackerCollection<object> m_tpSelectedItemsImpl;

	private bool m_isSelectionReentrancyLocked;

	internal ISelectionInfo DataSourceAsSelectionInfo
	{
		get => m_tpDataSourceAsSelectionInfo;
		set => m_tpDataSourceAsSelectionInfo = value;
	}

	private void Initialize()
	{
		//ctl::ComPtr<wfc::VectorChangedEventHandler<IInspectable*>> spSelectedItemsVectorChangedHandler;
		//ctl::ComPtr<ObservableTrackerCollection<IInspectable*>> spSelectedItems;
		//ctl::ComPtr<wf::ITypedEventHandler<xaml::Controls::Control*, xaml::Controls::FocusEngagedEventArgs*>> spFocusEngagedHandler;
		//IFC(SelectorGenerated::Initialize());

		//// Provide our Selection instance a SelectionChangeApplier so we can forward selection change
		//// notifications to our SelectorItems.
		//IFC(m_selection.Initialize(static_cast<SelectionChangeApplier*>(this)));

		//IFC(ctl::make < ObservableTrackerCollection < IInspectable* >> (&spSelectedItems));
		//SetPtrValue(m_tpSelectedItemsImpl, spSelectedItems);

		//spSelectedItemsVectorChangedHandler.Attach(
		//	new ClassMemberEventHandler <
		//	Selector,
		//	xaml_primitives::ISelector,
		//	wfc::VectorChangedEventHandler<IInspectable*>,
		//	wfc::IObservableVector<IInspectable*>,
		//	wfc::IVectorChangedEventArgs > (this, &Selector::OnSelectedItemsCollectionChanged, true /* subsribeToSelf */ ));

		//IFC(m_tpSelectedItemsImpl->add_VectorChanged(spSelectedItemsVectorChangedHandler.Get(), &m_SelectedItemsVectorChangedToken));

		//IFC(add_FocusEngaged(
		//	wrl::Callback<wf::ITypedEventHandler<xaml_controls::Control*, xaml::Controls::FocusEngagedEventArgs*>>(this, &Selector::OnFocusEngaged).Get(),
		//	&m_focusEnagedToken));

		m_tpSelectedRangesImpl = new();
	}

	/// <summary>
	/// Used to inform the data source of a range selection/deselection
	/// </summary>
	/// <param name="select">bool select indicates whether it's a select or deselect</param>
	/// <param name="firstIndex"></param>
	/// <param name="length"></param>
	/// <remarks>Caller must ensure m_tpDataSourceAsSelectionInfo is not null.</remarks>
	private void InvokeDataSourceRangeSelection(bool select, int firstIndex, uint length)
	{
		// Before the end of the function, we call UpdateVisibleAndCachedItemsSelectionAndVisualState
		// This function updates the IsSelected property of the SelectorItem
		// That triggers OnPropertyChanged2
		// OnPropertyChanged2 triggers OnIsSelectedChanged
		// OnIsSelectedChanged triggers NotifyListIsItemSelected
		// NotifyListIsItemSelected triggers InvokeDataSourceRangeSelection again

		if (!IsSelectionReentrancyAllowed())
		{
			return;
		}

		PreventSelectionReentrancy();

		using var allowSelectionReentrancy = Disposable.Create(AllowSelectionReentrancy);

		// when SelectedIndex < 0, it means we have no selection (cleared selection)
		// SelectJustThisItemInternal handles the call to invoke clear selection for ISelectionInfo interfaces
		if (firstIndex >= 0)
		{
			var spItemIndexRange = new ItemIndexRange(firstIndex, length);
			if (select)
			{
				m_tpDataSourceAsSelectionInfo.SelectRange(spItemIndexRange);
			}
			else
			{
				m_tpDataSourceAsSelectionInfo.DeselectRange(spItemIndexRange);
			}
		}

		// call the Selector::InvokeSelectionChanged with AddedItems and RemovedItems being null
		// when the SelectionInterface is implemented, we let the developer handle selecteditems and selectedranges
		// in here, we simply invoke a selection changed event
		InvokeSelectionChanged(removedItems: null /* pUnselectedItems */, addedItems: null /* pSelectedItems */);

		// updates SelectedIndex
		UpdatePublicSelectionPropertiesAfterDataSourceSelectionInfo();

		// updates the selection and visual state of visible and cached items
		UpdateVisibleAndCachedItemsSelectionAndVisualState(true /* updateIsSelected */);
	}

	/// <summary>
	/// Prevent reentrancy even if m_selection.IsChangeActive() is false.
	/// </summary>
	private void PreventSelectionReentrancy()
	{
		m_isSelectionReentrancyLocked = true;
	}

	/// <summary>
	/// Undo the effects of PreventSelectionReentrancy to allow reentrancy
	/// when m_selection.IsChangeActive() is false.
	/// </summary>
	private void AllowSelectionReentrancy()
	{
		m_isSelectionReentrancyLocked = false;
	}

	/// <summary>
	/// Updating selection causes reentrancy due to our event handler
	/// layout.We prevent reentrancy into selection-related functions
	/// if there is an active SelectionChanger or someone explicitly prevents
	/// reentrancy via PreventSelectionReentrancy.
	/// </summary>
	/// <returns></returns>
	private bool IsSelectionReentrancyAllowed()
	{
		return !m_isSelectionReentrancyLocked
			//&& !m_selection.IsChangeActive()
			;
	}

	/// <summary>
	/// updates SelectedIndex, SelectedItem and SelectedValue after a selection using SelectionInfo occurs
	/// </summary>
	/// <remarks>Caller must ensure m_tpDataSourceAsSelectionInfo is not null.</remarks>
	private void UpdatePublicSelectionPropertiesAfterDataSourceSelectionInfo()
	{
		bool selectedPropertiesUpdated = false;
		var spSelectedRanges = m_tpDataSourceAsSelectionInfo.GetSelectedRanges();
		var selectedRangesCount = spSelectedRanges.Count;

		if (selectedRangesCount > 0)
		{
			var spItems = Items;
			var itemsCount = spItems.Size;

			if (itemsCount > 0)
			{
				var spFirstRange = spSelectedRanges[0];

				// update SelectedIndex
				var currentSelectedIndex = SelectedIndex;
				var newSelectedIndex = spFirstRange.FirstIndex;
				if (currentSelectedIndex != newSelectedIndex)
				{
					SelectedIndex = newSelectedIndex;
				}

				if (newSelectedIndex >= 0 && newSelectedIndex < itemsCount)
				{
					// update SelectedItem
					var spCurrentSelectedItem = SelectedItem;
					var spNewSelectedItem = spItems[newSelectedIndex];
					if (!PropertyValue.AreEqualImpl(spCurrentSelectedItem, spNewSelectedItem))
					{
						SelectedItem = spNewSelectedItem;

						// update SelectedValue
						var spCurrentSelectedValue = SelectedValue;
						var spNewSelectedValue = GetSelectedValue(spNewSelectedItem);
						if (!PropertyValue.AreEqualImpl(spCurrentSelectedValue, spNewSelectedValue))
						{
							SelectedValue = spNewSelectedValue;
						}
					}

					// If the ItemCollection contains an ICollectionView sync the selected index
					//IFC(UpdateCurrentItemInCollectionView(spNewSelectedItem.Get(), &fDone));

					newSelectedIndex = SelectedIndex;
					spNewSelectedItem = SelectedItem;
					//IFC(OnSelectionChanged(currentSelectedIndex, newSelectedIndex, spCurrentSelectedItem.Get(), spNewSelectedItem.Get()));

					selectedPropertiesUpdated = true;
				}
			}
		}

		if (!selectedPropertiesUpdated)
		{
			//IFC(put_SelectedIndex(-1));
			//IFC(put_SelectedItem(nullptr));
			//IFC(put_SelectedValue(nullptr));

			// todo@xy: check side effect
			SelectedIndex = -1;
			SelectedItem = null;
			SelectedValue = null;
		}
	}

	/// <summary>
	/// goes through the visible and cached items and updates their IsSelected property and their visual state
	/// </summary>
	/// <param name="updateIsSelected"></param>
	private void UpdateVisibleAndCachedItemsSelectionAndVisualState(bool updateIsSelected)
	{
		var spItemsPanelRoot = (IPanel)ItemsPanelRoot;
		if (spItemsPanelRoot is { })
		{
			//ctl::ComPtr<IModernCollectionBasePanel> spIModernCollectionBasePanel;

			//spIModernCollectionBasePanel = spItemsPanelRoot.AsOrNull<IModernCollectionBasePanel>();
			//if (spIModernCollectionBasePanel)
			//{
			//	int firstCachedIndex = -1;
			//	int lastCachedIndex = -1;
			//	std::vector <unsigned int> pinnedElementsIndices;

			//	// get the data from the panel
			//	IFC_RETURN(spIModernCollectionBasePanel.Cast<ModernCollectionBasePanel>()->get_FirstCacheIndexBase(&firstCachedIndex));
			//	IFC_RETURN(spIModernCollectionBasePanel.Cast<ModernCollectionBasePanel>()->get_LastCacheIndexBase(&lastCachedIndex));
			//	IFC_RETURN(spIModernCollectionBasePanel.Cast<ModernCollectionBasePanel>()->GetPinnedElementsIndexVector(xaml_controls::ElementType_ItemContainer, &pinnedElementsIndices));

			//void UpdateVisualState(int itemIndex)
			//{
			//	if (ContainerFromIndex(itemIndex) is SelectorItem pSelectorItem)
			//	{
			//		// querying for the selection state from the ISelectionInfo interface
			//		if (updateIsSelected && m_tpDataSourceAsSelectionInfo is { })
			//		{
			//			var isSelected = m_tpDataSourceAsSelectionInfo.IsSelected(itemIndex);

			//			// this will call ChangeVisualState internally so there is no point calling the below ChangeVisualState
			//			pSelectorItem.IsSelected = isSelected;
			//		}
			//		else
			//		{
			//			pSelectorItem.UpdateVisualState(useTransitions: true);
			//		}
			//	}
			//}

			//	for (int i = firstCachedIndex; i <= lastCachedIndex; ++i)
			//	{
			//		IFC_RETURN(updateVisualState(i));
			//	}

			//	for (int pinnedIndex : pinnedElementsIndices)
			//	{
			//		// Ignore containers for which we already updated the visual state.
			//		if (pinnedIndex < firstCachedIndex || pinnedIndex > lastCachedIndex)
			//		{
			//			IFC_RETURN(updateVisualState(pinnedIndex));
			//		}
			//	}
			//}
		}

		//return S_OK;
	}

	/// <summary>
	/// Handles changing selection properties when a SelectorItem has IsSelected change
	/// </summary>
	/// <param name="pSelectorItem"></param>
	/// <param name="oldValue"></param>
	/// <param name="bIsSelected"></param>
	internal virtual void NotifyListItemSelected(SelectorItem pSelectorItem, bool oldValue, bool bIsSelected)
	{
		//SelectionChanger* pSelectionChanger = nullptr;

		var newIndex = IndexFromContainer(pSelectorItem);

		if (m_tpDataSourceAsSelectionInfo is { })
		{
			InvokeDataSourceRangeSelection(select: bIsSelected, newIndex, 1);
		}
		else
		{
			OnSelectorItemIsSelectedChanged(pSelectorItem, oldValue, bIsSelected);
			//UINT nCount = 0;
			//ctl::ComPtr<wfc::IObservableVector<IInspectable*>> spItems;
			//ctl::ComPtr<IInspectable> spSelectedItem;

			//if (!IsSelectionReentrancyAllowed())
			//{
			//	goto Cleanup;
			//}


			//IFC(get_Items(&spItems));
			//IFC(spItems.Cast<ItemCollection>()->get_Size(&nCount));

			//if (newIndex >= 0 && newIndex < static_cast<INT>(nCount))
			//{
			//	IFC(ItemFromContainer(pSelectorItem, &spSelectedItem));

			//	IFC(BeginChange(&pSelectionChanger));

			//	if (bIsSelected)
			//	{
			//		BOOLEAN canSelectMultiple = FALSE;
			//		IFC(get_CanSelectMultiple(&canSelectMultiple));
			//		IFC(pSelectionChanger->Select(newIndex, spSelectedItem.Get(), canSelectMultiple));
			//	}
			//	else
			//	{
			//		IFC(pSelectionChanger->Unselect(newIndex, spSelectedItem.Get()));
			//	}

			//	IFC(EndChange(pSelectionChanger));
			//	pSelectionChanger = nullptr;
			//}
		}

		//Cleanup:
		//	if (pSelectionChanger != nullptr)
		//	{
		//		VERIFYRETURNHR(pSelectionChanger->Cancel());
		//	}

		//	// returning S_OK to maintain compat with blue - bug 927905
		//	// In blue we swallowed any exception thrown in the app's
		//	// SelectionChanged event handler
		//	return S_OK;
	}

	/// <summary>
	/// helper function to invoke a DeselectAll for the data source without invoking a SelectionChangedEvent
	/// </summary>
	private void InvokeDataSourceClearSelection()
	{
		var spSelectedRanges = m_tpDataSourceAsSelectionInfo.GetSelectedRanges();

		var selectedRangesCount = spSelectedRanges.Count;

		for (int i = 0; i < selectedRangesCount; ++i)
		{
			var spItemIndexRange = spSelectedRanges[i];

			m_tpDataSourceAsSelectionInfo.DeselectRange(spItemIndexRange);
		}
	}

	protected IReadOnlyList<ItemIndexRange> SelectedRangesInternal
	{
		get
		{
			if (m_tpDataSourceAsSelectionInfo is { })
			{
				return m_tpDataSourceAsSelectionInfo.GetSelectedRanges();
			}
			else
			{
				return m_tpSelectedRangesImpl.AsReadOnly();
			}
		}
	}

	/// <summary>
	/// Updates m_tpSelectedRangesImpl
	/// </summary>
	private void UpdateSelectedRanges()
	{
		//	std::vector<unsigned int> selectedIndexes;
		//	ctl::ComPtr<TrackerCollection<xaml_data::ItemIndexRange*>> spSelectedRanges;

		// prevent reentrancy or
		// other properties from being updated.
		PreventSelectionReentrancy();
		using var _ = Disposable.Create(AllowSelectionReentrancy);

		m_tpSelectedRangesImpl.Clear();

		var selectedIndexes = m_selection.GetSelectedIndexes().ToList();

		// make sure indexes are sorted
		selectedIndexes.Sort();

		m_tpSelectedRangesImpl = ItemIndexRange.AppendItemIndexRangesFromSortedVectorToItemIndexRangeCollection(selectedIndexes);
	}
}
