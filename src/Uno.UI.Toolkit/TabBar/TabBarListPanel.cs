using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Toolkit
{
    public partial class TabBarListPanel : Panel
    {
		protected override Size MeasureOverride(Size availableSize)
		{
			Size cellSize = new Size(availableSize.Width / Children.Count, availableSize.Height);
			foreach (var child in Children)
			{
				child.Measure(cellSize);
			}

			return availableSize;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			Size cellSize = new Size(finalSize.Width / Children.Count, finalSize.Height);
			int col = 0;

			foreach (var child in Children)
			{
				child.Arrange(new Rect(new Point(cellSize.Width * col, 0), cellSize));
				col++;
			}

			return finalSize;
		}
	}
}
