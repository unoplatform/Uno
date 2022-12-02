using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;

namespace DirectUI;

#region Selection.h

/// <summary>
/// Class for transaction-based selection changes
/// </summary>
public interface SelectionChanger
{
	/// <summary>
	/// End selection change.
	/// </summary>
	/// <param name="canSelectMultiple"></param>
	/// <returns></returns>
	/// <remarks>This SelectionChanger instance should not be used again after this method completes.</remarks>
	(IReadOnlyList<object> pUnselectedItems, IReadOnlyList<object> pSelectedItems) End(bool canSelectMultiple);

	/// <summary>
	/// Select the given item.
	/// </summary>
	/// <param name="index"></param>
	/// <param name="pItem"></param>
	/// <param name="canSelectMultiple"></param>
	void Select(int index, object pItem, bool canSelectMultiple);

	/// <summary>
	/// Unselect a specific item.
	/// </summary>
	/// <param name="index"></param>
	/// <param name="pItem"></param>
	void Unselect(int index, object pItem);

	/// <summary>
	/// Unselect all selected items.
	/// </summary>
	void UnselectAll();

	/// <summary>
	/// Cancels all changes and invalidates this SelectionChanger.
	/// This SelectionChanger instance should not be used again after this method completes.
	/// </summary>
	void Cancel();
};

/// <summary>
/// Callback, used to notify interested parties of indexes being selected or unselected.
/// For example, used by Selector to notify SelectorItems of their Selected state changing.
/// </summary>
public interface SelectionChangeApplier
{
	void SelectIndex(int index);

	void UnselectIndex(int index);
};

public partial class Selection
{
	//public:
	//    Selection();
	//    ~Selection();

	//    _Check_return_ HRESULT Initialize(_In_ SelectionChangeApplier* pChangeApplier);

	//    // Returns a copy of the list of selected indexes.
	//    std::vector<UINT> GetSelectedIndexes() const;

	//    // Obtains the index of the selected item at the given position in the selection.
	//    _Check_return_ HRESULT GetIndexAt(
	//        _In_ UINT position,
	//        _Out_ UINT& itemIndex);

	//    // Obtains the the selected item at the given position in the selection.
	//    _Check_return_ HRESULT GetAt(
	//        _In_ UINT position,
	//        _Outptr_ IInspectable** ppSelectedItem);

	//    // Obtains the number of selected items.
	//    _Check_return_ HRESULT GetNumItemsSelected(
	//        _Out_ UINT& size);

	//    _Check_return_ HRESULT AddSelectedIndex(
	//            _In_ UINT itemIndex);

	//    _Check_return_ HRESULT RemoveSelectedIndex(
	//            _In_ UINT itemIndex);

	//    _Check_return_ HRESULT Has(
	//            _In_ UINT itemIndex,
	//            _Out_ UINT& position,
	//            _Out_ BOOLEAN& hasItem);

	//    // Start selection change.
	//    _Check_return_ HRESULT BeginChange(
	//        _Outptr_ SelectionChanger** changer);

	//    // Whether or not we're in the middle of a selection change.
	//    BOOLEAN IsChangeActive();

	//private:
	/// <summary>
	/// A collection of selected items with their associated indexes in the items collection.
	/// Conceptually, a List&lt;Pair&lt;IInspectable, UINT&gt;&gt;, where the UINT is the
	/// index of the respective selected item. The Collection superclass is used for its ability
	/// to properly handle IInspectable references.
	/// Ideally, this would be replaced with a single list of IInspectable, UINT pairs for greater
	/// performance.
	/// </summary>
	private sealed partial class InternalSelectedItemsStorage : TrackerCollection<object>
	{
		//    public:
		//        _Check_return_ HRESULT Add(
		//            _In_ UINT itemIndex,
		//            _In_ IInspectable* pItem);

		//        _Check_return_ HRESULT Has(
		//            _In_ UINT itemIndex,
		//            _Out_ UINT& position,
		//            _Out_ BOOLEAN& hasItem);

		//        _Check_return_ HRESULT GetIndexAt(
		//            _In_ UINT position,
		//            _Out_ UINT& itemIndex);

		//        _Check_return_ HRESULT Inserted(
		//            _In_ UINT itemIndex);

		//        _Check_return_ HRESULT Removed(
		//                _In_ UINT itemIndex);

		//        // Returns a copy of the list of selected indexes.
		//        std::vector<UINT> GetSelectedIndexes() const;

		//        IFACEMETHODIMP SetAt(
		//            _In_ unsigned itemIndex,
		//            _In_ IInspectable* pItem) override
		//        {
		//            RRETURN(E_UNEXPECTED);
		//        }

		//        IFACEMETHODIMP InsertAt(
		//            _In_ unsigned itemIndex,
		//            _In_ IInspectable* pItem) override
		//        {
		//            RRETURN(E_UNEXPECTED);
		//        }

		//        IFACEMETHOD(RemoveAt)(_In_ unsigned position) override;

		//        IFACEMETHODIMP Append(
		//            _In_ IInspectable* pItem) override
		//        {
		//            RRETURN(E_UNEXPECTED);
		//        }

		//        IFACEMETHODIMP RemoveAtEnd() override
		//        {
		//            RRETURN(E_UNEXPECTED);
		//        }

		//        IFACEMETHOD(Clear)() override;

		//    private:
		private readonly List<int> m_indexlist = new();
	}

	private sealed partial class SelectionChangerImpl : SelectionChanger
	{
		//    public:
		//        SelectionChangerImpl();
		//        ~SelectionChangerImpl();

		//        void BeginInternal();

		//        // End selection change.
		//        _Check_return_ virtual HRESULT End(
		//            _In_ wfc::IVector<IInspectable*>* pUnselectedItems,
		//            _In_ wfc::IVector<IInspectable*>* pSelectedItems,
		//            _In_ BOOLEAN canSelectMultiple);

		//        // Select the given item.
		//        _Check_return_ virtual HRESULT Select(
		//            _In_ int index,
		//            _In_ IInspectable* pItem,
		//            _In_ BOOLEAN canSelectMultiple);

		//        // Unselect a specific item.
		//        _Check_return_ virtual HRESULT Unselect(
		//            _In_ UINT index,
		//            _In_ IInspectable* pItem);

		//        // Unselect all selected items.
		//        _Check_return_ virtual HRESULT UnselectAll();

		//        // Cancels all changes and invalidates this SelectionChanger.
		//        // This SelectionChanger instance should not be used again after this method completes.
		//        _Check_return_ virtual HRESULT Cancel();

		//        // We need to know if an item was removed, so we can correctly differentiate
		//        // removed items from items which simply ended up with the removed item's index.
		//        _Check_return_ HRESULT AccountForRemovedItem(_In_ UINT removedItemIndex);

		//        virtual BOOLEAN IsActive();

		//        // Prepares object's state
		//        _Check_return_ HRESULT Initialize(
		//            _In_ Selection* pOwner,
		//            _In_ SelectionChangeApplier* pChangeApplier);

		//    private:

		//        _Check_return_ HRESULT Cleanup();

		//        // Ensures that the selection change is valid for the current mode
		//        _Check_return_ HRESULT ApplyCanSelectMultiple(
		//            _In_ BOOLEAN canSelectMultiple);

		//        _Check_return_ HRESULT CreateDeltaSelectionChange(
		//            _In_ wfc::IVector<IInspectable*>* pUnselectedItems,
		//            _In_ wfc::IVector<IInspectable*>* pSelectedItems);

		//        // If m_unselectAllRequested is true, clear it and
		//        // unselect all items by adding them to m_pItemsToUnselect.
		//        // This is part of a perf optimization to rapidly handle
		//        // the UnselectAll case.
		//        _Check_return_ HRESULT UnrollUnselectAllRequest();

		/// <summary>
		/// weak reference to owner Selection that this SelectionChanger belongs to.
		/// </summary>
		private Selection m_pOwnerNoRef;

		/// <summary>
		/// List of items selected in current selection change
		/// </summary>
		private InternalSelectedItemsStorage m_spItemsToSelect;

		/// <summary>
		/// List of items unselected in current selection change
		/// </summary>
		private InternalSelectedItemsStorage m_spItemsToUnselect;

		/// <summary>
		/// Whether or not we're in the middle of a selection change
		/// </summary>
		private bool m_bIsActive;

		/// <summary>
		/// Whether or not this transaction's only action is to clear
		/// all the selected items. This is a perf optimization.
		/// </summary>
		private bool m_unselectAllRequested;

		/// <summary>
		/// We need to know which items have been removed during this change, so when the change is applied
		/// we can correctly differentiate removed items from items which simply ended up with the removed item's index.
		/// </summary>
		private (int index, bool empty) m_indexDeletedDuringThisChange;

		private SelectionChangeApplier m_pChangeApplier;
	}

	private SelectionChangerImpl m_selectionChanger;

	/// <summary>
	/// The current Selection.
	/// </summary>
	private InternalSelectedItemsStorage m_spSelectedItems;
};

#endregion

#region Selection.cpp

partial class Selection
{
	public Selection()
	{
		m_selectionChanger = new();
	}

	void Initialize(SelectionChangeApplier pChangeApplier)
	{
		m_spSelectedItems = new();
		m_selectionChanger.Initialize(this, pChangeApplier);
	}

	/// <summary>
	/// Returns a copy of the list of selected indexes.
	/// </summary>
	/// <returns></returns>
	public IReadOnlyList<int> GetSelectedIndexes()
	{
		//ASSERT(m_spSelectedItems != nullptr);
		return m_spSelectedItems.GetSelectedIndexes();
	}

	/// <summary>
	/// Obtains the index of the selected item at the given position in the selection.
	/// </summary>
	/// <param name="position"></param>
	/// <returns></returns>
	public int GetIndexAt(int position)
	{
		if (m_spSelectedItems == null) throw new InvalidOperationException();

		return m_spSelectedItems.GetIndexAt(position);
	}

	// Obtains the the selected item at the given position in the selection.
	public object this[int position] => m_spSelectedItems[position];

	public void AddSelectedIndex(int itemIndex)
	{
		m_spSelectedItems.Inserted(itemIndex);
	}

	public void RemoveSelectedIndex(int itemIndex)
	{
		m_spSelectedItems.Removed(itemIndex);
		m_selectionChanger.AccountForRemovedItem(itemIndex);
	}

	public (int position, bool hasItem) Has(int itemIndex)
	{
		return m_spSelectedItems.Has(itemIndex);
	}

	// Whether or not we're in the middle of a selection change.
	public bool IsChangeActive()
	{
		return m_selectionChanger.IsActive();
	}

	// Obtains the number of selected items.
	public int GetNumItemsSelected()
	{
		return m_spSelectedItems?.Count ?? 0;
	}

	// Start selection change.
	public SelectionChanger BeginChange()
	{
		m_selectionChanger.BeginInternal();

		return m_selectionChanger;
	}

	#region SelectionChangerImpl implementation
	partial class SelectionChangerImpl
	{
		public SelectionChangerImpl()
		{
			m_pOwnerNoRef = null;
			m_pChangeApplier = null;
			m_bIsActive = false;
			m_unselectAllRequested = false;

			m_indexDeletedDuringThisChange.index = 0;
			m_indexDeletedDuringThisChange.empty = true;
		}

		~SelectionChangerImpl()
		{
			Cleanup();
		}

		// Prepares object's state
		public void Initialize(Selection pOwner, SelectionChangeApplier pChangeApplier)
		{
			if (pOwner == null) throw new ArgumentNullException(nameof(pOwner));
			if (pChangeApplier == null) throw new ArgumentNullException(nameof(pChangeApplier));

			m_pOwnerNoRef = pOwner;
			m_pChangeApplier = pChangeApplier;
			m_spItemsToSelect = new();
			m_spItemsToUnselect = new();
			Cleanup();
		}

		// Start selection change
		public void BeginInternal()
		{
			//Assert(!m_bIsActive, L"SelectionChanger already active");

			m_bIsActive = true;
			m_unselectAllRequested = false;
		}

		// End selection change

		public (IReadOnlyList<object> pUnselectedItems, IReadOnlyList<object> pSelectedItems) End(bool canSelectMultiple)
		{
			//Assert(m_bIsActive, L"Selection change must be active before calling SelectionChanger.End()");

			// Make sure that we're not selecting too many items
			// Skip this if we're optimizing for a UnselectAll-only transaction.
			if (!m_unselectAllRequested)
			{
				ApplyCanSelectMultiple(canSelectMultiple);
			}

			// Dispatch any pending UnselectAll requests.
			UnrollUnselectAllRequest();

			// Create lists of what was actually selected and unselected
			var change = CreateDeltaSelectionChange();

			Cleanup();

			return change;
		}

		public void Select(int itemIndex, object pItem, bool canSelectMultiple)
		{
			var bHasSelected = false;
			var bHasUnselected = false;
			var position = 0;

			// If we were optimizing for the UnselectAll-only case, turn off the optimization here.
			UnrollUnselectAllRequest();

			(position, bHasUnselected) = m_spItemsToUnselect.Has(itemIndex);
			if (bHasUnselected)
			{
				var spUnselectedItem = m_spItemsToUnselect[position];
				if (PropertyValue.AreEqualImpl(pItem, spUnselectedItem))
				{
					// We were going to unselect it, so don't
					m_spItemsToUnselect.RemoveAt(position);
					return;
				}
			}

			(position, bHasSelected) = m_pOwnerNoRef.Has(itemIndex);
			if (bHasSelected)
			{
				var spSelectedItem = m_pOwnerNoRef[position];
				if (PropertyValue.AreEqualImpl(pItem, spSelectedItem))
				{
					// It's already selected
					return;
				}
			}

			(position, bHasSelected) = m_spItemsToSelect.Has(itemIndex);
			if (bHasSelected)
			{
				var spSelectedItem = m_pOwnerNoRef[position];
				if (PropertyValue.AreEqualImpl(pItem, spSelectedItem))
				{
					// We're already going to select it
					return;
				}
			}

			// Too many items would be selected for the mode, deselect some
			if (!canSelectMultiple)
			{
				var nSelectedCount = m_spItemsToSelect.Count;

				for (var i = 0; i < nSelectedCount; ++i)
				{
					var spSelectedItem = m_spItemsToSelect[i];
					var itemIndexToUnselect = m_spItemsToSelect.GetIndexAt(i);
					m_spItemsToUnselect.Add(itemIndexToUnselect, spSelectedItem);
				}

				m_spItemsToSelect.Clear();
			}

			m_spItemsToSelect.Add(itemIndex, pItem);
		}

		public void Unselect(int itemIndex, object pItem)
		{
			var bHasSelected = false;
			var bHasUnselected = false;
			var position = 0;

			if (m_unselectAllRequested)
			{
				// We are going to clear the entire selection anyway.
				return;
			}

			(position, bHasSelected) = m_spItemsToSelect.Has(itemIndex);
			if (bHasSelected)
			{
				var spSelectedItem = m_spItemsToSelect[position];
				if (PropertyValue.AreEqualImpl(pItem, spSelectedItem))
				{
					// If we were going to select it, don't
					m_spItemsToSelect.RemoveAt(position);
					return;
				}
			}

			(position, bHasSelected) = m_pOwnerNoRef.Has(itemIndex);
			if (!bHasSelected)
			{
				// If it's not selected, nothing to do
				return;
			}

			(position, bHasUnselected) = m_spItemsToUnselect.Has(itemIndex);
			if (bHasUnselected)
			{
				var spUnselectedItem = m_spItemsToUnselect[position];
				if (PropertyValue.AreEqualImpl(pItem, spUnselectedItem))
				{
					// We're already going to unselect it
					return;
				}
			}

			m_spItemsToUnselect.Add(itemIndex, pItem);
		}

		//// Unselect all selected items.
		public void UnselectAll()
		{
			m_unselectAllRequested = true;
		}

		// If m_unselectAllRequested is true, clear it and
		// remove all items by adding them to m_spItemsToUnselect.
		// This is part of a perf optimization to rapidly handle
		// the UnselectAll case.
		private void UnrollUnselectAllRequest()
		{
			if (m_unselectAllRequested)
			{
				// Very important we clear this here, because
				// Unselect short-circuits if we don't.
				m_unselectAllRequested = false;

				var nSelectedCount = m_pOwnerNoRef.GetNumItemsSelected();
				for (var i = 0; i < nSelectedCount; ++i)
				{
					var spSelectedItem = m_pOwnerNoRef[i];
					var itemIndex = m_pOwnerNoRef.GetIndexAt(i);
					Unselect(itemIndex, spSelectedItem);
				}
			}
		}

		public void Cancel()
		{
			//Assert(m_bIsActive, L"SelectionChanger not active");

			Cleanup();
		}

		// We need to know if an item was removed, so we can correctly differentiate
		// removed items from items which simply ended up with the removed item's index.
		public void AccountForRemovedItem(int removedItemIndex)
		{
			m_indexDeletedDuringThisChange.index = removedItemIndex;
			m_indexDeletedDuringThisChange.empty = false;
		}

		public bool IsActive()
		{
			return m_bIsActive;
		}

		private void Cleanup()
		{
			m_bIsActive = false;
			m_unselectAllRequested = false;
			if (m_spItemsToSelect is { })
			{
				m_spItemsToSelect.Clear();
			}
			if (m_spItemsToUnselect is { })
			{
				m_spItemsToUnselect.Clear();
			}

			m_indexDeletedDuringThisChange.empty = true;
		}

		// Ensures that the selection change is valid for the current mode
		private void ApplyCanSelectMultiple(bool canSelectMultiple)
		{
			if (canSelectMultiple)
			{
				return;
			}

			var nToSelectCount = m_spItemsToSelect.Count;
			//Assert(nToSelectCount <= 1, L"Too many items selected for a single select selector");

			if (nToSelectCount == 1)
			{
				var nSelectedCount = m_pOwnerNoRef.m_spSelectedItems.Count;
				if (nSelectedCount > 0)
				{
					m_spItemsToUnselect.Clear();
					for (var nIndex = 0; nIndex < nSelectedCount; ++nIndex)
					{
						var spItem = m_pOwnerNoRef[nIndex];
						var itemIndex = m_pOwnerNoRef.GetIndexAt(nIndex);

						m_spItemsToUnselect.Add(itemIndex, spItem);
					}
				}
			}

			else
			{
				m_spItemsToSelect.Clear();
				var nSelectedCount = m_pOwnerNoRef.m_spSelectedItems.Count;
				if (nSelectedCount > 1)
				{
					m_spItemsToUnselect.Clear();
					for (var nIndex = 1; nIndex < nSelectedCount; ++nIndex)
					{
						var spItem = m_pOwnerNoRef[nIndex];
						var itemIndex = m_pOwnerNoRef.GetIndexAt(nIndex);

						m_spItemsToUnselect.Add(itemIndex, spItem);
					}
				}
			}
		}

		private (IReadOnlyList<object> pUnselectedItems, IReadOnlyList<object> pSelectedItems) CreateDeltaSelectionChange()
		{
			var nUnselectedCount = m_spItemsToUnselect.Count;
			var nSelectedCount = m_spItemsToSelect.Count;

			// Make sure that selection change is consistent
			// Create list of items that are actually to be selected/deselected
			if (nUnselectedCount == 0 && nSelectedCount == 0)
			{
				return (Array.Empty<object>(), Array.Empty<object>());
			}

			var pUnselectedItems = new List<object>();
			var pSelectedItems = new List<object>();

			// We currently don't support removing items and selecting items in one operation.
			// The way our code is architected we shouldn't ever try this. This is here in case
			// there's a side-path we don't know about.
			//ASSERT(nSelectedCount == 0 || m_indexDeletedDuringThisChange.empty);

			for (var nIndex = 0; nIndex < nUnselectedCount; ++nIndex)
			{
				var spItem = m_spItemsToUnselect[nIndex];
				var itemIndex = m_spItemsToUnselect.GetIndexAt(nIndex);
				// Note that itemIndex may well be an old index if items were added or removed.
				// This is fine but we need to be careful because the removed item's index
				// may now belong an item that used to be just after the removed item.
				// This will confuse the change applier, which isn't capable of understanding
				// removed items.
				// If the item was removed, we don't do any extra processing as the item
				// was already removed from m_spSelectedItems by RemoveSelectedIndex.
				if (m_indexDeletedDuringThisChange.empty || m_indexDeletedDuringThisChange.index != itemIndex)
				{
					// itemIdx can be -1 for Custom values, these values don't inherit from ISelectorItem so don't try to unselect them.
					if ((int)itemIndex >= 0)
					{
						m_pChangeApplier.UnselectIndex(itemIndex);
					}

					var (position, hasSelected) = m_pOwnerNoRef.Has(itemIndex);
					//IFCEXPECT_RETURN(hasSelected);

					m_pOwnerNoRef.m_spSelectedItems.RemoveAt(position);
				}

				pUnselectedItems.Add(spItem);
			}

			// Select all selected items
			for (var nIndex = 0; nIndex < nSelectedCount; ++nIndex)
			{
				var spItem = m_spItemsToSelect[nIndex];
				var itemIndex = m_spItemsToSelect.GetIndexAt(nIndex);

				// itemIdx can be -1 for Custom values, these values don't inherit from ISelectorItem so don't try to select them.
				if ((int)itemIndex >= 0)
				{
					m_pChangeApplier.SelectIndex(itemIndex);
				}

				//ASSERT(SUCCEEDED(m_pOwnerNoRef->Has(itemIndex, position, hasSelected)) && !hasSelected);

				m_pOwnerNoRef.m_spSelectedItems.Add(itemIndex, spItem);
				pSelectedItems.Add(spItem);
			}

			return (pUnselectedItems, pSelectedItems);
		}
	}
	#endregion

	#region InternalSelectedItemsStorage implementation
	partial class InternalSelectedItemsStorage
	{
		public void Add(int itemIndex, object pItem)
		{
			m_indexlist.Add(itemIndex);
			Add(pItem);
		}

		public (int position, bool hasItem) Has(int itemIndex)
		{
			var nPosition = 0;
			foreach (var item in m_indexlist)
			{
				if (nPosition == itemIndex)
				{
					return (nPosition, true);
				}

				nPosition++;
			}

			return (0, false);
		}

		public int GetIndexAt(int position)
		{
			return m_indexlist[position];
		}

		public void Inserted(int itemIndex)
		{
			// An item was inserted. Update the selected index
			// list so our indexes keep matching up.
			for (int i = 0; i < m_indexlist.Count; i++)
			{
				if (itemIndex <= i)
				{
					m_indexlist[i]++;
				}
			}
		}

		public void Removed(int itemIndex)
		{
			// An item was removed. Update the selected index
			// list so our indexes keep matching up.
			// We also need to remove the item which has been removed.
			for (int i = 0; i < m_indexlist.Count; i++)
			{
				if (itemIndex == m_indexlist[i])
				{
					m_indexlist.RemoveAt(i);
					RemoveAt(i);
				}
				else
				{
					if (itemIndex < i)
					{
						m_indexlist[i]--;
					}
				}
			}
		}

		// Returns a copy of the list of selected indexes.
		public IReadOnlyList<int> GetSelectedIndexes()
		{
			// Clone the selected index list.
			return m_indexlist;
		}

		public new void RemoveAt(int position)
		{
			if (position >= m_indexlist.Count) throw new IndexOutOfRangeException();

			m_indexlist.RemoveAt(position);
			base.RemoveAt(position);
		}

		public new void Clear()
		{
			m_indexlist.Clear();
			base.Clear();
		}
	}
	#endregion
}
#endregion
