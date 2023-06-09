﻿using System;
using System.Globalization;
using Uno.Foundation;

#if NET7_0_OR_GREATER
using NativeMethods = __Windows.__System.MemoryManager.NativeMethods;
#endif

namespace Windows.System
{
	public partial class MemoryManager
	{
#if !NET7_0_OR_GREATER
		private const string JsType = "Windows.System.MemoryManager";
#endif

		static MemoryManager()
		{
			IsAvailable = true;
		}

		public static ulong AppMemoryUsage
		{
			get
			{
#if NET7_0_OR_GREATER
				return (ulong)NativeMethods.GetAppMemoryUsage();
#else
				if (ulong.TryParse(WebAssemblyRuntime.InvokeJS(
					$"{JsType}.getAppMemoryUsage()"),
					NumberStyles.Any,
					CultureInfo.InvariantCulture, out var value))
				{
					return value;
				}

				throw new Exception($"getAppMemoryUsage returned an unsupported value");
#endif
			}
		}

		public static ulong AppMemoryUsageLimit
		{
			get
			{
				if (Environment.GetEnvironmentVariable("UNO_BOOTSTRAP_EMSCRIPTEN_MAXIMUM_MEMORY") == "4GB")
				{
					return 4ul * 1024 * 1024 * 1024;
				}

				return 2ul * 1024 * 1024 * 1024;
			}
		}
	}
}
