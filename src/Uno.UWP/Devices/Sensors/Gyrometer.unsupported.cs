﻿#if __MACOS__ || IS_UNIT_TESTS || __NETSTD_REFERENCE__
namespace Windows.Devices.Sensors
{
	public partial class Gyrometer
	{
		private Gyrometer()
		{
		}

		/// <summary>
		/// API not supported, always returns null.
		/// </summary>
		/// <returns>Null.</returns>
		public static Gyrometer GetDefault() => null;
	}
}
#endif
