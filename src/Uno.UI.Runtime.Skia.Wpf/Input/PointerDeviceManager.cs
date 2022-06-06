using System.Collections.Generic;
using System.Windows.Input;
using Windows.Devices.Input;

namespace Uno.UI.Runtime.Skia.Wpf.Input
{
	internal class PointerDeviceManager
	{
		private static readonly Dictionary<InputDevice, PointerDevice> _pointerDeviceCache = new();
		private static readonly Dictionary<PointerDevice, InputDevice> _inputDeviceCache = new();

		public static PointerDevice GetForInputDevice(InputDevice inputDevice)
		{
			if (!_pointerDeviceCache.TryGetValue(inputDevice, out var pointerDevice))
			
				pointerDevice = inputDevice switch
				{
					System.Windows.Input.MouseDevice _ => PointerDevice.For(PointerDeviceType.Mouse),
					StylusDevice _ => PointerDevice.For(PointerDeviceType.Pen),
					TouchDevice _ => new PointerDevice(PointerDeviceType.Touch),
					_ => PointerDevice.For(PointerDeviceType.Mouse),
				};
				_pointerDeviceCache[inputDevice] = pointerDevice;
				_inputDeviceCache[pointerDevice] = inputDevice;
			}
			return pointerDevice;
		}

		public static InputDevice? GetInputDevice(PointerDevice pointerDevice) =>
			_inputDeviceCache.GetValueOrDefault(pointerDevice);

		public static void SetPointerCapture(PointerDevice pointerDevice)
		{

		}

		public static void ReleasePointerCapture(PointerDevice pointerDevice)
		{

		}
	}
}
