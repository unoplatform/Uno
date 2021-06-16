using System;
using System.Collections.Generic;
using System.Text;

namespace Windows.UI.Xaml.Controls
{
	partial class AppBar
	{
		public event EventHandler<object> Closed;
		public event EventHandler<object> Closing;
		public event EventHandler<object> Opened;
		public event EventHandler<object> Opening;
	}
}
