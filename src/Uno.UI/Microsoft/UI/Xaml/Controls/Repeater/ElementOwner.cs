﻿using System;
using System.Linq;

namespace Microsoft/* UWP don't rename */.UI.Xaml.Controls
{
	internal enum ElementOwner
	{
		// All elements are originally owned by the view generator.
		ElementFactory,
		// Ownership is transferred to the layout when it calls GetElement.
		Layout,
		// Ownership is transferred to the pinned pool if the element is cleared (outside of
		// a 'remove' collection change of course).
		PinnedPool,
		// Ownership is transferred to the reset pool if the element is cleared by a reset and
		// the data source supports unique ids.
		UniqueIdResetPool,
		// Ownership is transferred to the animator if the element is cleared due to a
		// 'remove'-like collection change.
		Animator
	};
}
