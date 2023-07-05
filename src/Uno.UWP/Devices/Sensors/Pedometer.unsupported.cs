#nullable disable

#if __MACOS__ || __WASM__ || IS_UNIT_TESTS
using System;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Windows.Devices.Sensors
{
	public partial class Pedometer
	{
		private Pedometer()
		{
		}

		/// <summary>
		/// API not supported, always returns null.
		/// </summary>
		/// <returns>Null.</returns>
		public static IAsyncOperation<Pedometer> GetDefaultAsync() => Task.FromResult<Pedometer>(null).AsAsyncOperation();
	}
}
#endif
