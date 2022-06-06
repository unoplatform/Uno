using System;
using System.Linq;
using Windows.Devices.Input;

namespace Windows.UI.Core
{
	internal interface ICoreWindowExtension
	{
		public CoreCursor PointerCursor { get; set; }

		void ReleasePointerCapture(PointerDevice pointer);

		void SetPointerCapture(PointerDevice pointer);
	}
}
