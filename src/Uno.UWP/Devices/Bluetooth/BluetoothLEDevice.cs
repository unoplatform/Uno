﻿#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Windows.Devices.Bluetooth
{
	public partial class BluetoothLEDevice : global::System.IDisposable
	{

		public ulong BluetoothAddress { get; }
		public BluetoothAddressType BluetoothAddressType { get; }
		public BluetoothConnectionStatus ConnectionStatus { get; }
		public string Name { get; }
		public BluetoothLEAppearance Appearance { get; }

		private BluetoothLEDevice()
		{
		}

		#region "device selectors"

		private static string _deviceSelectorPrefix = "System.Devices.DevObjectType:=5 AND System.Devices.Aep.ProtocolId:=\"{BB7BB05E-5972-42B5-94FC-76EAA7084D49}\" AND ";
		private static string _deviceSelectorIssueInquiry = "System.Devices.Aep.Bluetooth.IssueInquiry:=System.StructuredQueryType.Boolean";

		public static string GetDeviceSelector()
		{
			return _deviceSelectorPrefix + "(System.Devices.Aep.IsPaired:=System.StructuredQueryType.Boolean#True OR " + _deviceSelectorIssueInquiry + "#False)";
		}

		public static string GetDeviceSelectorFromPairingState(bool pairingState)
		{
			if (pairingState)
			{
				return _deviceSelectorPrefix + "(System.Devices.Aep.IsPaired:=System.StructuredQueryType.Boolean#True OR " + _deviceSelectorIssueInquiry + "#False)";
			}
			else
			{
				return _deviceSelectorPrefix + "(System.Devices.Aep.IsPaired:=System.StructuredQueryType.Boolean#False OR " + _deviceSelectorIssueInquiry + "#True)";
			}
		}

		public static string GetDeviceSelectorFromConnectionStatus(BluetoothConnectionStatus connectionStatus)
		{
			if (connectionStatus == BluetoothConnectionStatus.Connected)
			{
				return _deviceSelectorPrefix + "(System.Devices.Aep.IsConnected:=System.StructuredQueryType.Boolean#True OR " + _deviceSelectorIssueInquiry + "#False)";
			}
			else
			{
				return _deviceSelectorPrefix + "(System.Devices.Aep.IsConnected:=System.StructuredQueryType.Boolean#False OR " + _deviceSelectorIssueInquiry + "#True)";
			}
		}

		public static string GetDeviceSelectorFromDeviceName(string deviceName)
		{
			return _deviceSelectorPrefix + "(System.ItemNameDisplay:=\"" + deviceName + "\" OR " + _deviceSelectorIssueInquiry + "#True)";
		}

		public static string GetDeviceSelectorFromBluetoothAddress(ulong bluetoothAddress)
		{
			string macAddr = string.Format(CultureInfo.InvariantCulture, "{0:x12}", bluetoothAddress);
			return _deviceSelectorPrefix + "(System.DeviceInterface.Bluetooth.DeviceAddress:=\"" + macAddr + "\" OR " + _deviceSelectorIssueInquiry + "#True)";
		}

		public static string GetDeviceSelectorFromBluetoothAddress(ulong bluetoothAddress, BluetoothAddressType bluetoothAddressType)
		{
			if (bluetoothAddressType == BluetoothAddressType.Unspecified)
			{
				return GetDeviceSelectorFromBluetoothAddress(bluetoothAddress);
			}

			string macAddr = string.Format(CultureInfo.InvariantCulture, "{0:x12}", bluetoothAddress);
			string selector = _deviceSelectorPrefix + "((System.DeviceInterface.Bluetooth.DeviceAddress:=\"" + macAddr + "\"" +
				"AND System.Devices.Aep.Bluetooth.Le.AddressType:=System.Devices.Aep.Bluetooth.Le.AddressType#";

			if (bluetoothAddressType == BluetoothAddressType.Public)
			{
				selector += "Public";
			}
			else
			{
				selector += "Random";
			}

			selector = selector + ") OR " + _deviceSelectorIssueInquiry + "#True)";
			return selector;
		}

		public static string GetDeviceSelectorFromAppearance(BluetoothLEAppearance appearance)
		{
			return _deviceSelectorPrefix +
				"((System.Devices.Aep.Bluetooth.Le.Appearance.Category:=" + appearance.Category.ToString(CultureInfo.InvariantCulture) +
				"AND System.Devices.Aep.Bluetooth.Le.Appearance.Subcategory:=" + appearance.SubCategory.ToString(CultureInfo.InvariantCulture) +
				_deviceSelectorIssueInquiry + "#True";
		}

		#endregion

	}
}
