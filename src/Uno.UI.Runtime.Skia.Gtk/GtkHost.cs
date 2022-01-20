﻿using System;
using System.IO;
using Windows.System;
using Uno.Extensions;
using Uno.Foundation.Extensibility;
using Uno.Helpers.Theming;
using Uno.UI.Runtime.Skia.GTK.Extensions.Helpers.Theming;
using Windows.UI.Xaml;
using WUX = Windows.UI.Xaml;
using Uno.UI.Xaml.Controls.Extensions;
using Uno.UI.Runtime.Skia.GTK.Extensions.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls;
using Gtk;
using Uno.UI.Runtime.Skia.GTK.Extensions.Helpers;
using Uno.Extensions.System;
using Uno.UI.Runtime.Skia.GTK.Extensions.System;
using Uno.UI.Runtime.Skia.GTK.UI.Core;
using Uno.Extensions.Storage.Pickers;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.Foundation;
using Uno.ApplicationModel.DataTransfer;
using Uno.UI.Runtime.Skia.GTK.Extensions.ApplicationModel.DataTransfer;
using Uno.Foundation.Logging;
using Windows.System.Profile.Internal;
using Uno.UI.Runtime.Skia.GTK.System.Profile;

namespace Uno.UI.Runtime.Skia
{
	public class GtkHost : ISkiaHost
	{
		private const int UnoThemePriority = 800;

		[ThreadStatic]
		private static bool _isDispatcherThread = false;

		private readonly string[] _args;
		private readonly Func<WUX.Application> _appBuilder;
		private static Gtk.Window _window;
		private static Gtk.EventBox _eventBox;
		private UnoDrawingArea _area;
		private Fixed _fix;
		private GtkDisplayInformationExtension _displayInformationExtension;

		public static Gtk.Window Window => _window;
		public static Gtk.EventBox EventBox => _eventBox;

		public GtkHost(Func<WUX.Application> appBuilder, string[] args)
		{
			_args = args;
			_appBuilder = appBuilder;
		}

		public void Run()
		{
			Gtk.Application.Init();
			SetupTheme();

			ApiExtensibility.Register(typeof(Windows.UI.Core.ICoreWindowExtension), o => new GtkCoreWindowExtension(o));
			ApiExtensibility.Register<Windows.UI.Xaml.Application>(typeof(Uno.UI.Xaml.IApplicationExtension), o => new GtkApplicationExtension(o));
			ApiExtensibility.Register(typeof(Windows.UI.ViewManagement.IApplicationViewExtension), o => new GtkApplicationViewExtension(o));
			ApiExtensibility.Register(typeof(ISystemThemeHelperExtension), o => new GtkSystemThemeHelperExtension(o));
			ApiExtensibility.Register(typeof(Windows.Graphics.Display.IDisplayInformationExtension), o => _displayInformationExtension ??= new GtkDisplayInformationExtension(o, _window));
			ApiExtensibility.Register<TextBoxView>(typeof(ITextBoxViewExtension), o => new TextBoxViewExtension(o, _window));
			ApiExtensibility.Register(typeof(ILauncherExtension), o => new LauncherExtension(o));
			ApiExtensibility.Register<FileOpenPicker>(typeof(IFileOpenPickerExtension), o => new FileOpenPickerExtension(o));
			ApiExtensibility.Register<FolderPicker>(typeof(IFolderPickerExtension), o => new FolderPickerExtension(o));
			ApiExtensibility.Register(typeof(IClipboardExtension), o => new ClipboardExtensions(o));
			ApiExtensibility.Register<FileSavePicker>(typeof(IFileSavePickerExtension), o => new FileSavePickerExtension(o));
			ApiExtensibility.Register(typeof(IAnalyticsInfoExtension), o => new AnalyticsInfoExtension());

			_isDispatcherThread = true;
			_window = new Gtk.Window("Uno Host");
			Size preferredWindowSize = ApplicationView.PreferredLaunchViewSize;
			if (preferredWindowSize != Size.Empty)
			{
				_window.SetDefaultSize((int)preferredWindowSize.Width, (int)preferredWindowSize.Height);
			}
			else
			{
				_window.SetDefaultSize(1024, 800);
			}
			_window.SetPosition(Gtk.WindowPosition.Center);

			_window.Realized += (s, e) =>
			{
				// Load the correct cursors before the window is shown
				// but after the window has been initialized.
				Cursors.Reload();
			};

			_window.DeleteEvent += delegate
			{
				Gtk.Application.Quit();
			};

			void Dispatch(System.Action d)
			{
				if (Gtk.Application.EventsPending())
				{
					Gtk.Application.RunIteration(false);
				}

				GLib.Idle.Add(delegate
				{
					if (this.Log().IsEnabled(LogLevel.Trace))
					{
						this.Log().Trace($"Iteration");
					}

					try
					{
						d();
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}

					return false;
				});
			}

			Windows.UI.Core.CoreDispatcher.DispatchOverride = Dispatch;
			Windows.UI.Core.CoreDispatcher.HasThreadAccessOverride = () => _isDispatcherThread;

			_window.WindowStateEvent += OnWindowStateChanged;

			var overlay = new Overlay();

			_eventBox = new EventBox();
			_area = new UnoDrawingArea();
			_fix = new Fixed();
			overlay.Add(_area);
			overlay.AddOverlay(_fix);
			_eventBox.Add(overlay);
			_window.Add(_eventBox);

			_area.Realized += (s, e) =>
			{
				WUX.Window.Current.OnNativeSizeChanged(new Windows.Foundation.Size(_area.AllocatedWidth, _area.AllocatedHeight));
			};

			_area.SizeAllocated += (s, e) =>
			{
				WUX.Window.Current.OnNativeSizeChanged(new Windows.Foundation.Size(e.Allocation.Width, e.Allocation.Height));
			};

			/* avoids double invokes at window level */
			_area.AddEvents((int)GtkCoreWindowExtension.RequestedEvents);

			_window.ShowAll();

			void CreateApp(ApplicationInitializationCallbackParams _)
			{
				var app = _appBuilder();
				app.Host = this;
			}

			WUX.Application.Start(CreateApp, _args);

			UpdateWindowPropertiesFromPackage();

			Gtk.Application.Run();
		}

		private void OnWindowStateChanged(object o, WindowStateEventArgs args)
		{
			var winUIApplication = WUX.Application.Current;
			var winUIWindow = WUX.Window.Current;
			var newState = args.Event.NewWindowState;
			var changedState = args.Event.ChangedMask;

			var isVisible =
				!(newState.HasFlag(Gdk.WindowState.Withdrawn) ||
				newState.HasFlag(Gdk.WindowState.Iconified));

			var isVisibleChanged =
				changedState.HasFlag(Gdk.WindowState.Withdrawn) ||
				changedState.HasFlag(Gdk.WindowState.Iconified);

			var focused = newState.HasFlag(Gdk.WindowState.Focused);
			var focusChanged = changedState.HasFlag(Gdk.WindowState.Focused);

			if (!focused && focusChanged)
			{
				winUIWindow?.OnActivated(Windows.UI.Core.CoreWindowActivationState.Deactivated);
			}

			if (isVisibleChanged)
			{
				if (isVisible)
				{
					winUIApplication?.OnLeavingBackground();
					winUIWindow?.OnVisibilityChanged(true);
				}
				else
				{
					winUIWindow?.OnVisibilityChanged(false);
					winUIApplication?.OnEnteredBackground();
				}
			}

			if (focused && focusChanged)
			{
				winUIWindow?.OnActivated(Windows.UI.Core.CoreWindowActivationState.CodeActivated);
			}
		}

		private void UpdateWindowPropertiesFromPackage()
		{
			if (Windows.ApplicationModel.Package.Current.Logo is Uri uri)
			{
				var basePath = uri.OriginalString.Replace('\\', Path.DirectorySeparatorChar);
				var iconPath = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, basePath);

				if (File.Exists(iconPath))
				{
					if (this.Log().IsEnabled(LogLevel.Information))
					{
						this.Log().Info($"Loading icon file [{iconPath}] from Package.appxmanifest file");
					}

					GtkHost.Window.SetIconFromFile(iconPath);
				}
				else
				{
					if (this.Log().IsEnabled(LogLevel.Warning))
					{
						this.Log().Warn($"Unable to find icon file [{iconPath}] specified in the Package.appxmanifest file.");
					}
				}
			}

			Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().Title = Windows.ApplicationModel.Package.Current.DisplayName;
		}

		public void TakeScreenshot(string filePath)
		{
			_area.TakeScreenshot(filePath);
		}

		private void SetupTheme()
		{
			var cssProvider = new CssProvider();
			cssProvider.LoadFromEmbeddedResource("Theming.UnoGtk.css");
			StyleContext.AddProviderForScreen(Gdk.Screen.Default, cssProvider, UnoThemePriority);
		}
	}
}
