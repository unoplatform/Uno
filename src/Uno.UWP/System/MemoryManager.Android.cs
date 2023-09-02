﻿#nullable enable

using System;
using Android.OS;
using Android.App;
using Uno.UI;

namespace Windows.System
{
	public partial class MemoryManager
	{
		private static ulong _appMemoryUsage;
		private static ulong _appMemoryUsageLimit;

		private static Debug.MemoryInfo? _mi;
		private static ActivityManager.MemoryInfo? _memoryInfo;
		private static global::System.Diagnostics.Stopwatch _updateWatch = global::System.Diagnostics.Stopwatch.StartNew();
		private static TimeSpan _lastUpdate = TimeSpan.FromSeconds(-_updateInterval.TotalSeconds);

		private readonly static TimeSpan _updateInterval = TimeSpan.FromSeconds(10);

		public static ulong AppMemoryUsage
		{
			get
			{
				Update();

				return _appMemoryUsage;
			}
		}

		public static ulong AppMemoryUsageLimit
		{
			get
			{
				Update();

				return _appMemoryUsageLimit;
			}
		}

		private static void Update()
		{
			var now = _updateWatch.Elapsed;
			if (_lastUpdate + _updateInterval < now)
			{
				_lastUpdate = now;

				_mi ??= new Debug.MemoryInfo();
				Debug.GetMemoryInfo(_mi);
				var totalMemory = _mi.TotalPss * 1024;
				_appMemoryUsage = (ulong)totalMemory;

				_memoryInfo ??= new ActivityManager.MemoryInfo();
				ActivityManager.FromContext(ContextHelper.Current)?.GetMemoryInfo(_memoryInfo);

				_appMemoryUsageLimit = _appMemoryUsage + (ulong)_memoryInfo.AvailMem - (ulong)_memoryInfo.Threshold;
			}
		}
	}
}
