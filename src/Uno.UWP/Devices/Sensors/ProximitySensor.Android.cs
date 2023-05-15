﻿#nullable enable

using System;
using System.Globalization;
using System.Linq;
using Android.Hardware;
using Android.Runtime;
using Uno.Devices.Enumeration.Internal;
using Uno.Devices.Sensors.Helpers;

namespace Windows.Devices.Sensors;

public partial class ProximitySensor
{
	private Sensor? _sensor;
	private ProximitySensorListener? _listener;

	/// <summary>
	/// Gets the device identifier.
	/// </summary>
	public string DeviceId { get; }

	/// <summary>
	/// Gets the maximum distance from the proximity sensor to the detected object.
	/// </summary>
	public uint? MaxDistanceInMillimeters => (uint)Math.Round(_sensor!.MaximumRange * 10);

	/// <summary>
	/// Obtains the proximity sensor from its identifier.
	/// </summary>
	/// <param name="sensorId">The sensor identifier.</param>
	/// <returns>Returns the ProximitySensor object from its identifier.</returns>
	public static ProximitySensor? FromId(string sensorId)
	{
		if (!DeviceIdentifier.TryParse(sensorId, out var sensorIdentifier))
		{
			return null;
		}

		var sensorManager = SensorHelpers.GetSensorManager();
		var sensors = sensorManager.GetDynamicSensorList(Android.Hardware.SensorType.Proximity);
		var androidSensor = sensors?.FirstOrDefault(s =>
			sensorIdentifier.Id.Equals(
				s.Id.ToString(CultureInfo.InvariantCulture), StringComparison.Ordinal));

		var sensor = new ProximitySensor(sensorId);
		sensor._sensor = androidSensor;
		return sensor;
	}

	partial void StartReading()
	{
		_listener = new ProximitySensorListener(this);
		SensorHelpers.GetSensorManager().RegisterListener(
			_listener,
			_sensor,
			SensorDelay.Normal);
	}

	partial void StopReading()
	{
		if (_listener is not null)
		{
			SensorHelpers.GetSensorManager().UnregisterListener(_listener, _sensor);
			_listener.Dispose();
			_listener = null;
		}
	}

	internal void OnReadingChanged(ProximitySensorReading reading)
	{
		_readingChangedWrapper.Event?.Invoke(this, new(reading));
	}

	private class ProximitySensorListener : Java.Lang.Object, ISensorEventListener, IDisposable
	{
		private readonly ProximitySensor _proximitySensor;

		public ProximitySensorListener(ProximitySensor proximitySensor)
		{
			_proximitySensor = proximitySensor;
		}

		public void OnAccuracyChanged(Sensor? sensor, [GeneratedEnum] SensorStatus accuracy)
		{
		}

		void ISensorEventListener.OnSensorChanged(SensorEvent? e)
		{
			if (e?.Values.FirstOrDefault() is not float distanceInCm)
			{
				return;
			}

			uint? distanceInMillimters = null;
			if (distanceInCm <= _proximitySensor._sensor!.MaximumRange)
			{
				distanceInMillimters = (uint)Math.Round(distanceInCm * 10);
			}

			var reading = new ProximitySensorReading(
				distanceInMillimters,
				SensorHelpers.TimestampToDateTimeOffset(e.Timestamp));

			_proximitySensor.OnReadingChanged(reading);
		}
	}

}
