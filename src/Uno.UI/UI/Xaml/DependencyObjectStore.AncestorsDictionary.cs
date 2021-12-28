#nullable enable

using System;
using Uno.UI.DataBinding;
using System.Collections.Generic;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using System.Linq;
using System.Threading;
using Uno.Collections;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Windows.UI.Xaml.Data;
using Uno.UI;
using System.Collections;

#if XAMARIN_ANDROID
using View = Android.Views.View;
#elif XAMARIN_IOS_UNIFIED
using View = UIKit.UIView;
#elif XAMARIN_IOS
using View = MonoTouch.UIKit.UIView;
#endif

namespace Windows.UI.Xaml
{
	public partial class DependencyObjectStore : IDisposable
	{
		private class AncestorsDictionary
		{
			private readonly HashtableEx _entries = new HashtableEx();

			internal bool TryGetValue(object key, out bool isAncestor)
			{
				if (_entries.TryGetValue(key, out var value))
				{
					isAncestor = (bool)value!;
					return true;
				}

				isAncestor = false;
				return false;
			}

			internal void Set(object key, bool isAncestor)
				=> _entries[key] = isAncestor;

			internal void Clear()
				=> _entries.Clear();
		}
	}
}
