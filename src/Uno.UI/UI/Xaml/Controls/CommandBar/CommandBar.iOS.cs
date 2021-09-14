#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Uno.UI.Controls;

namespace Windows.UI.Xaml.Controls
{
	partial class CommandBar : INativeNavigationBar
	{
		public void ResetNavigationBar(UINavigationBar? navigationBar)
		{
			if (this.GetRenderer(() => (CommandBarRenderer?)null) is { } renderer)
			{
				renderer.Native = navigationBar;
			}
		}

		public void SetNavigationBar(UINavigationBar? navigationBar) =>
			this.GetRenderer(() => new CommandBarRenderer(this)).Native = navigationBar;

		public void SetNavigationItem(UINavigationItem? navigationItem) =>
			this.GetRenderer(() => new CommandBarNavigationItemRenderer(this)).Native = navigationItem;
	}
}
