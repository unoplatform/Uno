﻿#nullable enable

using System.Collections.Specialized;

namespace Windows.Foundation.Collections;

internal class VectorChangedEventArgs : IVectorChangedEventArgs
{
	public VectorChangedEventArgs(CollectionChange change, uint index)
	{
		CollectionChange = change;
		Index = index;
	}

	public VectorChangedEventArgs(NotifyCollectionChangedEventArgs ncArgs, CollectionChange change, uint index)
	{
		NotifyCollectionChanged = ncArgs;
		CollectionChange = change;
		Index = index;
	}

	public NotifyCollectionChangedEventArgs? NotifyCollectionChanged { get; }

	public CollectionChange CollectionChange { get; }

	public uint Index { get; }
}
