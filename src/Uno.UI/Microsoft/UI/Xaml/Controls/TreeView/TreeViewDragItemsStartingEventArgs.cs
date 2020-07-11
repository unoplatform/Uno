﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

// MUX reference 4dd6b16

using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class TreeViewDragItemsStartingEventArgs
    {
		private readonly DragItemsStartingEventArgs _dragItemsStartingEventArgs;

		public TreeViewDragItemsStartingEventArgs(DragItemsStartingEventArgs args)
		{
			_dragItemsStartingEventArgs = args;
		}

		public bool Cancel { get; set; }

		public DataPackage Data => _dragItemsStartingEventArgs.Data;

		public IList<object> Items => _dragItemsStartingEventArgs.Items;
    }
}
