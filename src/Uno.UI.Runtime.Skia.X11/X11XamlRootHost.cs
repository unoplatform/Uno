using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Uno.Foundation.Logging;
using Uno.UI.Hosting;
using Microsoft.UI.Xaml;
using SkiaSharp;
using Uno.Disposables;
using Uno.UI;
using Uno.UI.Xaml.Controls;

namespace Uno.WinUI.Runtime.Skia.X11;

internal partial class X11XamlRootHost : IXamlRootHost
{
<<<<<<< HEAD
	private const int InitialWidth = 900;
	private const int InitialHeight = 800;
	private const IntPtr EventsMask =
=======
	private const int DefaultColorDepth = 32;
	private const int FallbackColorDepth = 24;

	private const IntPtr RootEventsMask =
		(IntPtr)EventMask.ExposureMask |
		(IntPtr)EventMask.StructureNotifyMask |
		(IntPtr)EventMask.VisibilityChangeMask |
		(IntPtr)EventMask.NoEventMask;
	private const IntPtr TopEventsMask =
>>>>>>> e3a7f56884 (chore: same fix for X11 + some cleanup)
		(IntPtr)EventMask.ExposureMask |
		(IntPtr)EventMask.ButtonPressMask |
		(IntPtr)EventMask.ButtonReleaseMask |
		(IntPtr)EventMask.PointerMotionMask |
		(IntPtr)EventMask.KeyPressMask |
		(IntPtr)EventMask.KeyReleaseMask |
		(IntPtr)EventMask.EnterWindowMask |
		(IntPtr)EventMask.LeaveWindowMask |
		(IntPtr)EventMask.StructureNotifyMask |
		(IntPtr)EventMask.FocusChangeMask |
		(IntPtr)EventMask.VisibilityChangeMask |
		(IntPtr)EventMask.NoEventMask;

	private static bool _firstWindowCreated;
	private static object _x11WindowToXamlRootHostMutex = new();
	private static Dictionary<X11Window, X11XamlRootHost> _x11WindowToXamlRootHost = new();
	private static ConcurrentDictionary<Window, X11XamlRootHost> _windowToHost = new();

	private readonly TaskCompletionSource _closed; // To keep it simple, only SetResult if you have the lock
	private readonly ApplicationView _applicationView;
	private readonly X11WindowWrapper _wrapper;
	private readonly Window _window;

	private X11Window? _x11Window;
	private IX11Renderer? _renderer;

	public X11Window X11Window => _x11Window!.Value;

	public X11XamlRootHost(X11WindowWrapper wrapper, Window winUIWindow, XamlRoot xamlRoot, Action<Size> resizeCallback, Action closingCallback, Action<bool> focusCallback, Action<bool> visibilityCallback)
	{
		_wrapper = wrapper;
		_window = winUIWindow;

		_resizeCallback = resizeCallback;
		_closingCallback = closingCallback;
		_focusCallback = focusCallback;
		_visibilityCallback = visibilityCallback;

		_applicationView = ApplicationView.GetForWindowId(winUIWindow.AppWindow.Id);
		_applicationView.PropertyChanged += OnApplicationViewPropertyChanged;
		CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBarChanged += UpdateWindowPropertiesFromCoreApplication;
		winUIWindow.AppWindow.TitleBar.ExtendsContentIntoTitleBarChanged += ExtendContentIntoTitleBar;

		_closed = new TaskCompletionSource();
		Closed = _closed.Task;

		Initialize();

		// Note: the timing of XamlRootMap.Register is very fragile. It needs to be early enough
		// so things like UpdateWindowPropertiesFromPackage can read the DPI, but also late enough so that
		// the X11Window is "initialized".
		_windowToHost[winUIWindow] = this;
		X11Manager.XamlRootMap.Register(xamlRoot, this);

		Closed.ContinueWith(_ =>
		{
			using (X11Helper.XLock(X11Window.Display))
			{
				X11Manager.XamlRootMap.Unregister(xamlRoot);
				_windowToHost.Remove(winUIWindow, out var _);
				_applicationView.PropertyChanged -= OnApplicationViewPropertyChanged;
				CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBarChanged -= UpdateWindowPropertiesFromCoreApplication;
				winUIWindow.AppWindow.TitleBar.ExtendsContentIntoTitleBarChanged -= ExtendContentIntoTitleBar;
			}
		});

		UpdateWindowPropertiesFromPackage();
		OnApplicationViewPropertyChanged(this, new PropertyChangedEventArgs(null));

		// only start listening to events after we're done setting everything up
		InitializeX11EventsThread();
	}

	public static X11XamlRootHost? GetHostFromWindow(Window window)
		=> _windowToHost.TryGetValue(window, out var host) ? host : null;

	public Task Closed { get; }

	private void OnApplicationViewPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		var minSize = _applicationView.PreferredMinSize;

		if (minSize != Size.Empty)
		{
			var hints = new XSizeHints
			{
				flags = (int)XSizeHintsFlags.PMinSize,
				min_width = (int)minSize.Width,
				min_height = (int)minSize.Height
			};

			XLib.XSetWMNormalHints(X11Window.Display, X11Window.Window, ref hints);
		}
	}

	internal void UpdateWindowPropertiesFromCoreApplication()
	{
		var coreApplicationView = CoreApplication.GetCurrentView();

		ExtendContentIntoTitleBar(coreApplicationView.TitleBar.ExtendViewIntoTitleBar);
	}

	internal void ExtendContentIntoTitleBar(bool extend) => X11Helper.SetMotifWMDecorations(X11Window, !extend, 0xFF);

	private void UpdateWindowPropertiesFromPackage()
	{
		if (Windows.ApplicationModel.Package.Current.Logo is { } uri)
		{
			var basePath = uri.OriginalString.Replace('\\', Path.DirectorySeparatorChar);
			var iconPath = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledPath, basePath);

			if (File.Exists(iconPath))
			{
				if (this.Log().IsEnabled(LogLevel.Information))
				{
					this.Log().Info($"Loading icon file [{iconPath}] from Package.appxmanifest file");
				}

				SetIconFromFile(iconPath);
			}
			else if (Microsoft.UI.Xaml.Media.Imaging.BitmapImage.GetScaledPath(basePath) is { } scaledPath && File.Exists(scaledPath))
			{
				if (this.Log().IsEnabled(LogLevel.Information))
				{
					this.Log().Info($"Loading icon file [{scaledPath}] scaled logo from Package.appxmanifest file");
				}

				SetIconFromFile(scaledPath);
			}
			else
			{
				if (this.Log().IsEnabled(LogLevel.Warning))
				{
					this.Log().Warn($"Unable to find icon file [{iconPath}] specified in the Package.appxmanifest file.");
				}
			}
		}

		if (!string.IsNullOrEmpty(Windows.ApplicationModel.Package.Current.DisplayName))
		{
			_applicationView.Title = Windows.ApplicationModel.Package.Current.DisplayName;
		}

		unsafe void SetIconFromFile(string iconPath)
		{
			using var fileStream = File.OpenRead(iconPath);
			using var codec = SKCodec.Create(fileStream);
			if (codec is null)
			{
				if (this.Log().IsEnabled(LogLevel.Error))
				{
					this.Log().Error($"Unable to create an SKCodec instance for icon file {iconPath}.");
				}
				return;
			}
			using var bitmap = new SKBitmap(codec.Info.Width, codec.Info.Height, SKColorType.Rgba8888, SKAlphaType.Unpremul);
			var result = codec.GetPixels(bitmap.Info, bitmap.GetPixels());
			if (result != SKCodecResult.Success)
			{
				if (this.Log().IsEnabled(LogLevel.Error))
				{
					this.Log().Error($"Unable to decode icon file [{iconPath}] specified in the Package.appxmanifest file.");
				}
				return;
			}

			var pixels = bitmap.Pixels;
			var data = Marshal.AllocHGlobal((pixels.Length + 2) * sizeof(IntPtr));
			using var _1 = Disposable.Create(() => Marshal.FreeHGlobal(data));

			var ptr = (IntPtr*)data.ToPointer();
			*(ptr++) = bitmap.Width;
			*(ptr++) = bitmap.Height;
			foreach (var pixel in bitmap.Pixels)
			{
				*(ptr++) = pixel.Alpha << 24 | pixel.Red << 16 | pixel.Green << 8 | pixel.Blue << 0;
			}

			var display = _x11Window!.Value.Display;
			using var _2 = X11Helper.XLock(display);

			var wmIconAtom = X11Helper.GetAtom(display, X11Helper._NET_WM_ICON);
			var cardinalAtom = X11Helper.GetAtom(display, X11Helper.XA_CARDINAL);
			var _3 = XLib.XChangeProperty(
				display,
				_x11Window!.Value.Window,
				wmIconAtom,
				cardinalAtom,
				32,
				PropertyMode.Replace,
				data,
				pixels.Length + 2);

			var _4 = XLib.XFlush(display);
			var _5 = XLib.XSync(display, false); // wait until the pixels are actually copied
		}
	}

	public static X11XamlRootHost? GetXamlRootHostFromX11Window(X11Window window)
	{
		lock (_x11WindowToXamlRootHostMutex)
		{
			return _x11WindowToXamlRootHost.TryGetValue(window, out var root) ? root : null;
		}
	}

	public static void CloseAllWindows()
	{
		lock (_x11WindowToXamlRootHostMutex)
		{
			foreach (var host in _x11WindowToXamlRootHost.Values)
			{
				using (X11Helper.XLock(host.X11Window.Display))
				{
					host._closed.SetResult();
				}
			}

			_x11WindowToXamlRootHost.Clear();
		}
	}

	public static bool AllWindowsDone()
	{
		// This probably doesn't need a lock, since it doesn't modify anything and reading outdated values is fine,
		// but let's be cautious.
		lock (_x11WindowToXamlRootHostMutex)
		{
			return _firstWindowCreated && _x11WindowToXamlRootHost.Count == 0;
		}
	}

	public static void Close(X11Window x11window)
	{
		lock (_x11WindowToXamlRootHostMutex)
		{
			if (_x11WindowToXamlRootHost.Remove(x11window, out var host))
			{
				using (X11Helper.XLock(x11window.Display))
				{
					host._closed.SetResult();
				}
			}
			else
			{
				if (typeof(X11XamlRootHost).Log().IsEnabled(LogLevel.Error))
				{
					typeof(X11XamlRootHost).Log().Error($"{nameof(Close)} could not find X11Window {x11window}");
				}
			}
		}
	}

	private void Initialize()
	{
		using var _1 = Disposable.Create(() =>
		{
			// set _firstWindowCreated even if we crash. This prevents the Main thread from being
			// kept alive forever even if the main window creation crashed.
			lock (_x11WindowToXamlRootHostMutex)
			{
				_firstWindowCreated = true;
			}
		});

		IntPtr display = XLib.XOpenDisplay(IntPtr.Zero);

		using var _2 = X11Helper.XLock(display);

		if (display == IntPtr.Zero)
		{
			if (this.Log().IsEnabled(LogLevel.Error))
			{
				this.Log().Error("XLIB ERROR: Cannot connect to X server");
			}
			throw new InvalidOperationException("XLIB ERROR: Cannot connect to X server");
		}

		int screen = XLib.XDefaultScreen(display);

		var size = ApplicationView.PreferredLaunchViewSize;
		if (size == Size.Empty)
		{
			size = new Size(NativeWindowWrapperBase.InitialWidth, NativeWindowWrapperBase.InitialHeight);
		}

<<<<<<< HEAD
		IntPtr window;
		if (FeatureConfiguration.Rendering.UseOpenGLOnX11 ?? IsOpenGLSupported(display))
		{
			_x11Window = CreateGLXWindow(display, screen, size);
			window = _x11Window.Value.Window;
		}
		else
		{
			window = XLib.XCreateSimpleWindow(
				display,
				XLib.XRootWindow(display, screen),
				0,
				0,
				(int)size.Width,
				(int)size.Height,
				0,
				XLib.XBlackPixel(display, screen),
				XLib.XWhitePixel(display, screen));
			XLib.XSelectInput(display, window, EventsMask);
			_x11Window = new X11Window(display, window);
=======
		// For the root window (that does nothing but act as an anchor for children,
		// we don't bother with OpenGL, since we don't render on this window anyway.
		IntPtr rootWindow = CreateSoftwareRenderWindow(display, screen, size, XLib.XRootWindow(display, screen));
		XLib.XSelectInput(display, rootWindow, RootEventsMask);
		_x11Window = new X11Window(display, rootWindow);
		if (FeatureConfiguration.Rendering.UseOpenGLOnX11 ?? IsOpenGLSupported(display))
		{
			_x11TopWindow = CreateGLXWindow(display, screen, size, rootWindow);
		}
		else
		{
			var topWindow = CreateSoftwareRenderWindow(display, screen, size, rootWindow);
			XLib.XSelectInput(display, topWindow, TopEventsMask);
			_x11TopWindow = new X11Window(display, topWindow);
>>>>>>> e3a7f56884 (chore: same fix for X11 + some cleanup)
		}

		QueueAction(this, () => _resizeCallback(size));

		// Tell the WM to send a WM_DELETE_WINDOW message before closing
		IntPtr deleteWindow = X11Helper.GetAtom(display, X11Helper.WM_DELETE_WINDOW);
		var _3 = XLib.XSetWMProtocols(display, window, new[] { deleteWindow }, 1);

		lock (_x11WindowToXamlRootHostMutex)
		{
			_firstWindowCreated = true;
			_x11WindowToXamlRootHost[_x11Window.Value] = this;
		}

<<<<<<< HEAD
		// The window must be mapped before DisplayInformationExtension is initialized.
		var _4 = XLib.XMapWindow(display, window);
=======
		_ = X11Helper.XClearWindow(RootX11Window.Display, RootX11Window.Window); // the root window is never drawn, just always blank
>>>>>>> e3a7f56884 (chore: same fix for X11 + some cleanup)

		if (FeatureConfiguration.Rendering.UseOpenGLOnX11 ?? IsOpenGLSupported(display))
		{
			_renderer = new X11OpenGLRenderer(this, _x11Window.Value);
		}
		else
		{
			_renderer = new X11SoftwareRenderer(this, _x11Window.Value);
		}
	}

	// https://github.com/gamedevtech/X11OpenGLWindow/blob/4a3d55bb7aafd135670947f71bd2a3ee691d3fb3/README.md
	// https://learnopengl.com/Advanced-OpenGL/Framebuffers
	private unsafe X11Window CreateGLXWindow(IntPtr display, int screen, Size size, IntPtr parent)
	{
		int[] glxAttribs = {
			GlxConsts.GLX_X_RENDERABLE    , /* True */ 1,
			GlxConsts.GLX_DRAWABLE_TYPE   , GlxConsts.GLX_WINDOW_BIT,
			GlxConsts.GLX_RENDER_TYPE     , GlxConsts.GLX_RGBA_BIT,
			GlxConsts.GLX_X_VISUAL_TYPE   , GlxConsts.GLX_TRUE_COLOR,
			GlxConsts.GLX_RED_SIZE        , 8,
			GlxConsts.GLX_GREEN_SIZE      , 8,
			GlxConsts.GLX_BLUE_SIZE       , 8,
			GlxConsts.GLX_ALPHA_SIZE      , 8,
			GlxConsts.GLX_DEPTH_SIZE      , 24,
			GlxConsts.GLX_STENCIL_SIZE    , 8,
			GlxConsts.GLX_DOUBLEBUFFER    , /* True */ 1,
			(int)X11Helper.None
		};

		IntPtr bestFbc = IntPtr.Zero;
		XVisualInfo* visual = null;
		var ptr = GlxInterface.glXChooseFBConfig(display, screen, glxAttribs, out var count);
		if (ptr == null || *ptr == IntPtr.Zero)
		{
			throw new InvalidOperationException($"{nameof(GlxInterface.glXChooseFBConfig)} failed to retrieve GLX frambuffer configurations.");
		}
		for (var c = 0; c < count; c++)
		{
			XVisualInfo* visual_ = GlxInterface.glXGetVisualFromFBConfig(display, ptr[c]);
			if (visual_->depth == 32) // 24bit color + 8bit stencil as requested above
			{
				bestFbc = ptr[c];
				visual = visual_;
				break;
			}
		}

		if (visual == null)
		{
			throw new InvalidOperationException("Could not create correct visual window.\n");
		}

		IntPtr context = GlxInterface.glXCreateNewContext(display, bestFbc, GlxConsts.GLX_RGBA_TYPE, IntPtr.Zero, /* True */ 1);
		var _1 = XLib.XSync(display, false);

		XSetWindowAttributes attribs = default;
		attribs.border_pixel = XLib.XBlackPixel(display, screen);
		attribs.background_pixel = XLib.XWhitePixel(display, screen);
		// Not sure why this is needed, commented out until further notice
		// attribs.override_redirect = /* True */ 1;
<<<<<<< HEAD
		attribs.colormap = XLib.XCreateColormap(display, XLib.XRootWindow(display, screen), visual->visual, /* AllocNone */ 0);
		attribs.event_mask = EventsMask;
=======
		attribs.colormap = XLib.XCreateColormap(display, parent, visual->visual, /* AllocNone */ 0);
		attribs.event_mask = TopEventsMask;
>>>>>>> e3a7f56884 (chore: same fix for X11 + some cleanup)
		var window = XLib.XCreateWindow(
			display,
			parent,
			0,
			0,
			(int)size.Width,
			(int)size.Height,
			0,
			(int)visual->depth,
			/* InputOutput */ 1,
			visual->visual,
			(UIntPtr)(XCreateWindowFlags.CWBackPixel | XCreateWindowFlags.CWColormap | XCreateWindowFlags.CWBorderPixel | XCreateWindowFlags.CWEventMask),
			ref attribs);

		var _2 = GlxInterface.glXGetFBConfigAttrib(display, bestFbc, GlxConsts.GLX_STENCIL_SIZE, out var stencil);
		var _3 = GlxInterface.glXGetFBConfigAttrib(display, bestFbc, GlxConsts.GLX_SAMPLES, out var samples);
		return new X11Window(display, window, (stencil, samples, context));
	}

<<<<<<< HEAD
=======
	private IntPtr CreateSoftwareRenderWindow(IntPtr display, int screen, Size size, IntPtr parent)
	{
		var matchVisualInfoResult = XLib.XMatchVisualInfo(display, screen, DefaultColorDepth, 4, out var info);
		var success = matchVisualInfoResult != 0;
		if (!success)
		{
			matchVisualInfoResult = XLib.XMatchVisualInfo(display, screen, FallbackColorDepth, 4, out info);

			success = matchVisualInfoResult != 0;
			if (!success)
			{
				if (this.Log().IsEnabled(LogLevel.Error))
				{
					this.Log().Error("XLIB ERROR: Cannot match visual info");
				}
				throw new InvalidOperationException("XLIB ERROR: Cannot match visual info");
			}
		}

		var visual = info.visual;
		var depth = info.depth;

		var xSetWindowAttributes = new XSetWindowAttributes()
		{
			backing_store = 1,
			bit_gravity = Gravity.NorthWestGravity,
			win_gravity = Gravity.NorthWestGravity,
			// Settings to true when WindowStyle is None
			//override_redirect = true,
			colormap = XLib.XCreateColormap(display, parent, visual, /* AllocNone */ 0),
			border_pixel = 0,
			// Settings background pixel to zero means Transparent background,
			// and it will use the background color from `Window.SetBackground`
			background_pixel = IntPtr.Zero,
		};
		var valueMask =
				0
				| SetWindowValuemask.BackPixel
				| SetWindowValuemask.BorderPixel
				| SetWindowValuemask.BitGravity
				| SetWindowValuemask.WinGravity
				| SetWindowValuemask.BackingStore
				| SetWindowValuemask.ColorMap
			//| SetWindowValuemask.OverrideRedirect
			;
		var window = XLib.XCreateWindow(display, parent, 0, 0, (int)size.Width,
			(int)size.Height, 0, (int)depth, /* InputOutput */ 1, visual,
			(UIntPtr)(valueMask), ref xSetWindowAttributes);
		return window;
	}

>>>>>>> e3a7f56884 (chore: same fix for X11 + some cleanup)
	private bool IsOpenGLSupported(IntPtr display)
	{
		try
		{
			return GlxInterface.glXQueryExtension(display, out _, out _);
		}
		catch (Exception) // most likely DllNotFoundException, but can be other types
		{
			return false;
		}
	}

	void IXamlRootHost.InvalidateRender() => _renderer?.InvalidateRender();

	UIElement? IXamlRootHost.RootElement => _window.RootElement;
}
