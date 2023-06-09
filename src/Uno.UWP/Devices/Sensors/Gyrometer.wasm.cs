﻿#if __WASM__
using System;
using System.Diagnostics;
using Uno;
using Uno.Devices.Sensors.Helpers;

#if NET7_0_OR_GREATER
using NativeMethods = __Windows.Devices.Sensors.Gyrometer.NativeMethods;
#endif

namespace Windows.Devices.Sensors
{
	public partial class Gyrometer
	{
#if !NET7_0_OR_GREATER
		private const string JsType = "Windows.Devices.Sensors.Gyrometer";
#endif

		private DateTimeOffset _lastReading = DateTimeOffset.MinValue;

		private Gyrometer()
		{
		}

		public uint ReportInterval { get; set; }

		private static Gyrometer TryCreateInstance()
		{
#if NET7_0_OR_GREATER
			return NativeMethods.Initialize() ? new() : null;
#else
			var command = $"{JsType}.initialize()";
			var initialized = Uno.Foundation.WebAssemblyRuntime.InvokeJS(command);
			if (bool.Parse(initialized) == true)
			{
				return new Gyrometer();
			}
			return null;
#endif
		}

		private void StartReading()
		{
#if NET7_0_OR_GREATER
			NativeMethods.StartReading();
#else
			var command = $"{JsType}.startReading()";
			Uno.Foundation.WebAssemblyRuntime.InvokeJS(command);
#endif
		}

		private void StopReading()
		{
#if NET7_0_OR_GREATER
			NativeMethods.StopReading();
#else
			var command = $"{JsType}.stopReading()";
			Uno.Foundation.WebAssemblyRuntime.InvokeJS(command);
#endif
		}

		/// <summary>
		/// Handles readings from Gyrometer.
		/// Filters the readings if too frequent to match chosen ReportInterval.
		/// Uses value ReportInterval * 0.8 to make sure that reporting is
		/// still more frequent rather than less frequent than requested,
		/// which is in line with documentation
		/// </summary>
		/// <param name="x">AngularVelocity X in radians/s</param>
		/// <param name="y">AngularVelocity Y in radians/s</param>
		/// <param name="z">AngularVelocity Z in radians/s</param>
		/// <returns>0 - needed to bind method from WASM</returns>
		public static int DispatchReading(float x, float y, float z)
		{
			if (_instance == null)
			{
				throw new InvalidOperationException("Gyrometer:DispatchReading can be called only after Gyrometer is initialized");
			}
			var now = DateTimeOffset.UtcNow;
			if ((now - _instance._lastReading).TotalMilliseconds >= _instance.ReportInterval * 0.8)
			{
				_instance._lastReading = now;
				_instance.OnReadingChanged(
					new GyrometerReading(
						x * SensorConstants.RadToDeg,
						y * SensorConstants.RadToDeg,
						z * SensorConstants.RadToDeg,
						now));
			}
			return 0;
		}
	}
}
#endif
