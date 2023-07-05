#nullable disable

using System;

namespace Uno.Foundation.Logging
{
	internal interface IExternalLogger
	{
		void Log(LogLevel logLevel, string? message, Exception? exception = null);
		LogLevel LogLevel { get; }
	}
}
