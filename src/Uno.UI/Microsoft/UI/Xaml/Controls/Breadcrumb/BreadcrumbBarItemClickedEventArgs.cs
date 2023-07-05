#nullable disable

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// MUX Reference BreadcrumbBarItemClickedEventArgs.cpp, commit 085fbf9

namespace Microsoft.UI.Xaml.Controls;

/// <summary>
/// Provides data for the BreadcrumbBar.ItemClicked event.
/// </summary>
public sealed partial class BreadcrumbBarItemClickedEventArgs
{
	internal BreadcrumbBarItemClickedEventArgs(object item, int index)
	{
		Item = item;
		Index = index;
	}

	/// <summary>
	/// Gets the Content property value of the BreadcrumbBarItem that is clicked.
	/// </summary>
	public object Item { get; }

	/// <summary>
	/// Gets the index of the item that was clicked.
	/// </summary>
	public int Index { get; }
}
