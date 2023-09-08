#nullable enable

using System;
using System.Collections.Generic;
using Uno.Disposables;
using Uno.Foundation.Logging;
using Uno.UI.Xaml;
using Uno.UI.Xaml.Controls;
using Uno.UI.Xaml.Core;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Foundation;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using WinUICoreServices = Uno.UI.Xaml.Core.CoreServices;

namespace Windows.UI.Xaml
{
	/// <summary>
	/// Represents an application window.
	/// </summary>
	[ContentProperty(Name = nameof(Content))]
	public partial class Window
	{
		private static Window? _current;

		private readonly IWindowImplementation _windowImplementation;

		private CoreWindowActivationState? _lastActivationState;
		private Brush? _background;
		private bool _wasActivated;
		private bool _splashScreenDismissed;

		private List<WeakEventHelper.GenericEventHandler> _sizeChangedHandlers = new List<WeakEventHelper.GenericEventHandler>();
		private List<WeakEventHelper.GenericEventHandler>? _backgroundChangedHandlers;

		internal Window(WindowType windowType)
		{
#if !__SKIA__
			if (windowType != WindowType.CoreWindow)
			{
				if (this.Log().IsEnabled(LogLevel.Warning))
				{
					this.Log().LogWarning(
						"Creating a secondary Window instance is currently not supported in Uno Platform targets. " +
						"Use the Window.Current property instead (you can use #if HAS_UNO to differentiate " +
						"between Uno Platform targets and Windows App SDK).");
				}
			}
#endif

			_windowImplementation = windowType switch
			{
				WindowType.CoreWindow => new CoreWindowWindow(this),
				WindowType.DesktopXamlSource => new DesktopWindow(this),
				_ => throw new InvalidOperationException("Unsupported window type")
			};

			Dispatcher = CoreDispatcher.Main;

			Compositor = Windows.UI.Composition.Compositor.GetSharedCompositor();

			InitPlatform();

			InitializeCommon();
		}

		partial void InitPlatform();

#pragma warning disable 67
		/// <summary>
		/// Occurs when the window has successfully been activated.
		/// </summary>
		public event WindowActivatedEventHandler? Activated;

		/// <summary>
		/// Occurs when the window has closed.
		/// </summary>
		public event WindowClosedEventHandler? Closed;

		/// <summary>
		/// Occurs when the app window has first rendered or has changed its rendering size.
		/// </summary>
		public event WindowSizeChangedEventHandler? SizeChanged;

		/// <summary>
		/// Occurs when the value of the Visible property changes.
		/// </summary>
		public event WindowVisibilityChangedEventHandler? VisibilityChanged;

		/// <summary>
		/// Gets the Compositor for this window.
		/// </summary>
		public Compositor Compositor { get; private set; }

		public UIElement? Content
		{
			get => _windowImplementation.Content;
			set
			{
				_windowImplementation.Content = value;
				TryDismissSplashScreen();
			}
		}

		/// <summary>
		/// This is the real root of the **managed** visual tree.
		/// This means its the root panel which contains the <see cref="Content"/>
		/// but also the PopupRoot, the DragRoot and all other internal UI elements.
		/// On platforms like iOS and Android, we might still have few native controls above this.
		/// </summary>
		/// <remarks>This element is flagged with IsVisualTreeRoot.</remarks>
		internal UIElement? RootElement => _windowImplementation.XamlRoot?.VisualTree?.RootElement; //TODO:MZ: Is it ok to change to RootElement instead of PublicRootVisual?

		internal PopupRoot? PopupRoot => _windowImplementation.XamlRoot?.VisualTree?.PopupRoot;

		internal FullWindowMediaRoot? FullWindowMediaRoot => _windowImplementation.XamlRoot?.VisualTree?.FullWindowMediaRoot;

		internal Canvas? FocusVisualLayer => _windowImplementation.XamlRoot?.VisualTree?.FocusVisualRoot;

		/// <summary>
		/// Gets a Rect value containing the height and width of the application window in units of effective (view) pixels.
		/// </summary>
		public Rect Bounds { get; private set; }

#if HAS_UNO_WINUI
		/// <summary>
		/// Always null in Uno.WinUI.
		/// </summary>
		public CoreWindow? CoreWindow { get; }
#else
		/// <summary>
		/// Gets the window of the current thread.
		/// </summary>
		public CoreWindow? CoreWindow => _windowImplementation.CoreWindow;
#endif

#pragma warning disable RS0030 // CoreWindow is banned
		/// <summary>
		/// Use this instead of Window.Current throughout this codebase
		/// to prove it is intentional (the property is null throughout Uno.WinUI).
		/// </summary>
		public CoreWindow? CoreWindowSafe => CoreWindow;
#pragma warning restore RS0030

		public CoreWindow? IShouldntUseCoreWindow => _windowImplementation.CoreWindow;

		/// <summary>
		/// Gets the CoreDispatcher object for the Window, which is generally the CoreDispatcher for the UI thread.
		/// </summary>
		public CoreDispatcher Dispatcher { get; private set; }

		/// <summary>
		/// Gets a value that reports whether the window is visible.
		/// </summary>
		public bool Visible
		{
			get => _windowImplementation.Visible;
			private set
			{
				//TODO:MZ: Visibility should not be set here, but in window impl
				if (Visible != value)
				{
					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().LogDebug($"Window visibility changing to {value}");
					}

					if (IShouldntUseCoreWindow is not null)
					{
						IShouldntUseCoreWindow.Visible = value;
					}

					var args = new VisibilityChangedEventArgs() { Visible = value };

					if (IShouldntUseCoreWindow is not null) // TODO:MZ: CoreWindow may be null.
					{
						IShouldntUseCoreWindow.OnVisibilityChanged(args);
					}
					VisibilityChanged?.Invoke(this, args);
				}
			}
		}

#if HAS_UNO_WINUI
		/// <summary>
		/// Always null in Uno.WinUI.
		/// </summary>
		public static Window? Current { get; }
#else
		/// <summary>
		/// Gets the window of the current thread.		
		/// </summary>
		public static Window Current => _current ??= new Window(WindowType.CoreWindow);
#endif

#pragma warning disable RS0030 // Current is banned
		/// <summary>
		/// Use this instead of Window.Current throughout this codebase
		/// to prove it is intentional (the property is null throughout Uno.WinUI).
		/// </summary>
		internal static Window? CurrentSafe => Current;
#pragma warning restore RS0030

		internal static Window? IShouldntUseCurrentWindow => CurrentSafe; // TODO: We should make sure Current returns null in case of WinUI tree.

		private void InitializeCommon()
		{
#if !HAS_UNO_WINUI
			RaiseCreated();
#endif

			Background = SolidColorBrushHelper.White;
		}

		public void Activate()
		{
			_windowImplementation.Activate();
			if (!_wasActivated)
			{
				ShowPartial();
				_wasActivated = true;
			}
			TryDismissSplashScreen();
		}

		partial void ShowPartial();

		private void TryDismissSplashScreen()
		{
			if (_wasActivated && Content != null && !_splashScreenDismissed)
			{
				DismissSplashScreenPlatform();
				_splashScreenDismissed = true;
			}
		}

		partial void DismissSplashScreenPlatform();

		public void Close() { }

		// The parameter name differs between UWP and WinUI.
		// UWP: https://learn.microsoft.com/en-us/uwp/api/windows.ui.xaml.window.settitlebar?view=winrt-22621
		// WinUI: https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.window.settitlebar?view=windows-app-sdk-1.3
		public void SetTitleBar(UIElement
#if HAS_UNO_WINUI
								titleBar
#else
								value
#endif
			)
		{
		}

		/// <summary>
		/// Provides a memory-friendly registration to the <see cref="SizeChanged" /> event.
		/// </summary>
		/// <returns>A disposable instance that will cancel the registration.</returns>
		internal IDisposable RegisterSizeChangedEvent(Windows.UI.Xaml.WindowSizeChangedEventHandler handler)
		{
			return WeakEventHelper.RegisterEvent(
				_sizeChangedHandlers,
				handler,
				(h, s, e) =>
					(h as Windows.UI.Xaml.WindowSizeChangedEventHandler)?.Invoke(s, (WindowSizeChangedEventArgs)e)
			);
		}

		internal void OnNativeActivated(CoreWindowActivationState state)
		{
			if (!_wasActivated)
			{
				return;
			}

			if (_lastActivationState != state)
			{
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().LogDebug($"Window activating with {state} state.");
				}

				_lastActivationState = state;
				var activatedEventArgs = new WindowActivatedEventArgs(state);
#if HAS_UNO_WINUI
				// There are two "versions" of WindowActivatedEventArgs in Uno currently
				// when using WinUI, we need to use "legacy" version to work with CoreWindow
				// (which will eventually be removed as a legacy API as well.
				var coreWindowActivatedEventArgs = new Windows.UI.Core.WindowActivatedEventArgs(state);
#else
				var coreWindowActivatedEventArgs = activatedEventArgs;
#endif
				CoreWindowSafe?.OnActivated(coreWindowActivatedEventArgs);
				Activated?.Invoke(this, activatedEventArgs);
			}
		}

		internal void OnNativeVisibilityChanged(bool newVisibility)
		{
			if (!_wasActivated)
			{
				return;
			}

			Visible = newVisibility;
		}

		private void RootSizeChanged(object sender, SizeChangedEventArgs args) => _windowImplementation.Content?.XamlRoot?.NotifyChanged();

		private void RaiseSizeChanged(Windows.UI.Core.WindowSizeChangedEventArgs windowSizeChangedEventArgs)
		{
			var baseSizeChanged = new WindowSizeChangedEventArgs(windowSizeChangedEventArgs.Size) { Handled = windowSizeChangedEventArgs.Handled };

			SizeChanged?.Invoke(this, baseSizeChanged);

			windowSizeChangedEventArgs.Handled = baseSizeChanged.Handled;

			CoreWindow.IShouldntUseGetForCurrentThread()?.OnSizeChanged(windowSizeChangedEventArgs);

			baseSizeChanged.Handled = windowSizeChangedEventArgs.Handled;

			foreach (var action in _sizeChangedHandlers)
			{
				action(this, baseSizeChanged);
			}
		}

		internal Brush? Background
		{
			get => _background;
			set
			{
				_background = value;

				if (_backgroundChangedHandlers != null)
				{
					foreach (var action in _backgroundChangedHandlers)
					{
						action(this, EventArgs.Empty);
					}
				}
			}
		}

		internal IDisposable RegisterBackgroundChangedEvent(EventHandler handler)
			=> WeakEventHelper.RegisterEvent(
				_backgroundChangedHandlers ??= new(),
				handler,
				(h, s, e) =>
					(h as EventHandler)?.Invoke(s, (EventArgs)e)
			);

		private static Window InternalGetCurrentWindow() => _current ??= new Window(WindowType.CoreWindow);

	}
}
