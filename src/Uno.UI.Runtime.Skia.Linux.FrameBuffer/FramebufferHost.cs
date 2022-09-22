using System;
using Windows.System;
using Windows.UI.Xaml;
using WUX = Windows.UI.Xaml;
using Uno.WinUI.Runtime.Skia.LinuxFB;
using Windows.UI.Core;
using Uno.Foundation.Extensibility;
using System.ComponentModel;
using Uno.UI.Xaml.Core;
using Uno.Foundation.Logging;
using Windows.Graphics.Display;
using Uno.Extensions;
using System.Threading;

namespace Uno.UI.Runtime.Skia
{
	public class FrameBufferHost : ISkiaHost
	{
		[ThreadStatic]
		private static bool _isDispatcherThread = false;

		private Func<Application> _appBuilder;
		private readonly EventLoop _eventLoop;
		private Renderer? _renderer;
		private DisplayInformationExtension? _displayInformationExtension;
		private ApplicationExtension? _applicationExtension;
		private ManualResetEvent _terminationGate = new(false);

		/// <summary>
		/// Creates a host for a Uno Skia FrameBuffer application.
		/// </summary>
		/// <param name="appBuilder">App builder.</param>
		/// <param name="args">Deprecated, value ignored.</param>		
		/// <remarks>
		/// Args are obsolete and will be removed in the future. Environment.CommandLine is used instead
		/// to fill LaunchEventArgs.Arguments.
		/// </remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FrameBufferHost(Func<WUX.Application> appBuilder, string[] args) : this(appBuilder)
		{
		}

		public FrameBufferHost(Func<WUX.Application> appBuilder)
		{
			_appBuilder = appBuilder;

			_eventLoop = new EventLoop();
		}

		/// <summary>
		/// Provides a display scale to override framebuffer default scale
		/// </summary>
		/// <remarks>This value can be overriden by the UNO_DISPLAY_SCALE_OVERRIDE environment variable</remarks>
		public float? DisplayScale { get; set; }

		public void Run()
		{
			StartConsoleInterception();

			_eventLoop.Schedule(Initialize);

			_terminationGate.WaitOne();

			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"Application is exiting");
			}
		}

		private void StartConsoleInterception()
		{
			Thread consoleInterceptionThread = new(() => {

				// Loop until Application.Current.Exit() is invoked
				while (!_applicationExtension?.ShouldExit ?? true)
				{
					// Read the console keys without showing them on screen.
					// The keyboard input is handled by libinput. 
					Console.ReadKey(true);
				}

				// The process asked to exit
				_terminationGate.Set();
			});

			// The thread must not block the process from exiting
			consoleInterceptionThread.IsBackground = true;
			
			consoleInterceptionThread.Start();
		}

		private void Initialize()
		{
			_isDispatcherThread = true;

			ApiExtensibility.Register(typeof(Windows.UI.Core.ICoreWindowExtension), o => new CoreWindowExtension(o));
			ApiExtensibility.Register(typeof(Windows.UI.ViewManagement.IApplicationViewExtension), o => new ApplicationViewExtension(o));
			ApiExtensibility.Register<Application>(typeof(Uno.UI.Xaml.IApplicationExtension), o => _applicationExtension = new ApplicationExtension(o));
			ApiExtensibility.Register(typeof(Windows.Graphics.Display.IDisplayInformationExtension), o => _displayInformationExtension ??= new DisplayInformationExtension(o, DisplayScale));

			void Dispatch(System.Action d)
				=> _eventLoop.Schedule(() => d());

			void CreateApp(ApplicationInitializationCallbackParams _)
			{
				var app = _appBuilder();
				app.Host = this;

				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"Display Information: " +
						$"{_renderer?.FrameBufferDevice.ScreenSize.Width}x{_renderer?.FrameBufferDevice.ScreenSize.Height} " +
						$"({_renderer?.FrameBufferDevice.ScreenPhysicalDimensions} mm), " +
						$"PixelFormat: {_renderer?.FrameBufferDevice.PixelFormat}, " +
						$"ResolutionScale: {DisplayInformation.GetForCurrentView().ResolutionScale}, " +
						$"LogicalDpi: {DisplayInformation.GetForCurrentView().LogicalDpi}, " +
						$"RawPixelsPerViewPixel: {DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel}, " +
						$"DiagonalSizeInInches: {DisplayInformation.GetForCurrentView().DiagonalSizeInInches}, " +
						$"ScreenInRawPixels: {DisplayInformation.GetForCurrentView().ScreenWidthInRawPixels}x{DisplayInformation.GetForCurrentView().ScreenHeightInRawPixels}");
				}

				if (_applicationExtension is not null)
				{
					// Register the exit handler to terminate the app gracefully
					_applicationExtension.ExitRequested += (s, e) => {

						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							this.Log().Debug($"Application has requested an exit");
						}
						
						_terminationGate.Set();
					};
				}
			}

			Windows.UI.Core.CoreDispatcher.DispatchOverride = Dispatch;
			Windows.UI.Core.CoreDispatcher.HasThreadAccessOverride = () => _isDispatcherThread;

			_renderer = new Renderer();
			_displayInformationExtension!.Renderer = _renderer;

			CoreServices.Instance.ContentRootCoordinator.CoreWindowContentRootSet += OnCoreWindowContentRootSet;

			WUX.Application.StartWithArguments(CreateApp);
		}

		private void OnCoreWindowContentRootSet(object? sender, object e)
		{
			var xamlRoot = CoreServices.Instance
				.ContentRootCoordinator
				.CoreWindowContentRoot?
				.GetOrCreateXamlRoot();

			if (xamlRoot is null)
			{
				throw new InvalidOperationException("XamlRoot was not properly initialized");
			}

			xamlRoot.InvalidateRender += _renderer!.InvalidateRender;

			CoreServices.Instance.ContentRootCoordinator.CoreWindowContentRootSet -= OnCoreWindowContentRootSet;
		}
	}
}
