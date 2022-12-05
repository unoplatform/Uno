using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.UI.Xaml.Controls;

public partial class Canvas
{
	static partial void OnZIndexChangedPartial(UIElement element, double? zindex)
	{
		if (element.GetParent() is Panel panel)
		{
			panel.IsChildrenRenderOrderDirty = true;
		}
	}
}
