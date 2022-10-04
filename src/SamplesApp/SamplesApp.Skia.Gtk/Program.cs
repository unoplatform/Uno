﻿#nullable disable

using System;
using GLib;
using SkiaSharp;
using Gtk;
using Uno.Foundation.Extensibility;
using System.Threading;
using Uno.UI.Runtime.Skia;

namespace SkiaSharpExample
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			SamplesApp.App.ConfigureFilters(); // Enable tracing of the host

			ExceptionManager.UnhandledException += delegate (UnhandledExceptionArgs expArgs)
			{
				Console.WriteLine("GLIB UNHANDLED EXCEPTION" + expArgs.ExceptionObject.ToString());
				expArgs.ExitApplication = true;
			};

			var host = new GtkHost(() => new SamplesApp.App());

			host.Run();
		}
	}
}
