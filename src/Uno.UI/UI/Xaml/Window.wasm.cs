#if __WASM__
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.Xaml.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml
{
	public sealed partial class Window
	{
		private static Window _current;
		private RootVisual _rootVisual;
		private ScrollViewer _rootScrollViewer;
		private Border _rootBorder;
		private UIElement _content;
		private bool _invalidateRequested;

		public Window()
		{
			Init();

			InitializeCommon();
		}

		private void Init()
		{
			Dispatcher = CoreDispatcher.Main;
			CoreWindow = new CoreWindow();
		}

		internal static void InvalidateMeasure()
		{
			Current?.InnerInvalidateMeasure();
		}

		private void InnerInvalidateMeasure()
		{
			if (!_invalidateRequested)
			{
				_invalidateRequested = true;

				if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
				{
					this.Log().Debug("DispatchInvalidateMeasure scheduled");
				}

				CoreDispatcher.Main.RunAsync(
					CoreDispatcherPriority.Normal,
					() =>
					{
						_invalidateRequested = false;

						Current?.DispatchInvalidateMeasure();
					}
				);
			}
		}

		private void DispatchInvalidateMeasure()
		{
			if (_rootVisual != null)
			{
				var sw = Stopwatch.StartNew();
				_rootVisual.Measure(Bounds.Size);
				_rootVisual.Arrange(Bounds);
				sw.Stop();

				if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
				{
					this.Log().Debug($"DispatchInvalidateMeasure: {sw.Elapsed}");
				}
			}
		}

		[Preserve]
		public static void Resize(double width, double height)
		{
			var window = Current?._rootVisual;
			if (window == null)
			{
				typeof(Window).Log().Error($"Resize ignore, no current window defined");
				return; // nothing to measure
			}

			Current.OnNativeSizeChanged(new Size(width, height));
		}

		private void OnNativeSizeChanged(Size size)
		{
			var newBounds = new Rect(0, 0, size.Width, size.Height);

			if (newBounds != Bounds)
			{
				if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
				{
					this.Log().Debug($"OnNativeSizeChanged: {size}");
				}

				Bounds = newBounds;

				DispatchInvalidateMeasure();
				RaiseSizeChanged(new Windows.UI.Core.WindowSizeChangedEventArgs(size));

				// Note that UWP raises the ApplicationView.VisibleBoundsChanged event
				// *after* Window.SizeChanged.

				// TODO: support for "viewport-fix" on devices with a notch.
				ApplicationView.GetForCurrentView()?.SetVisibleBounds(newBounds);
			}
		}

		partial void InternalActivate()
		{
			WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.activate();");
		}

		private void InternalSetContent(UIElement content)
		{
			if (_rootVisual == null)
			{
				_rootBorder = new Border();
				_rootScrollViewer = new ScrollViewer()
				{
					VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,
					HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
					VerticalScrollMode = ScrollMode.Disabled,
					HorizontalScrollMode = ScrollMode.Disabled,
					Content = _rootBorder
				};
				//TODO Uno: We can set and RootScrollViewer properly in case of WASM
				CoreServices.Instance.PutVisualRoot(_rootScrollViewer);
				_rootVisual = CoreServices.Instance.MainRootVisual;

				if (_rootVisual == null)
				{
					throw new InvalidOperationException("The root visual could not be created.");
				}
			}

			_rootBorder.Child = _content = content;
			if (content != null)
			{
				if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded && !_rootVisual.IsLoaded)
				{
					UIElement.LoadingRootElement(_rootVisual);
				}

				WebAssemblyRuntime.InvokeJS($"Uno.UI.WindowManager.current.setRootContent({_rootVisual.HtmlId});");

				if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded && !_rootVisual.IsLoaded)
				{
					UIElement.RootElementLoaded(_rootVisual);
				}
			}
			else
			{
				WebAssemblyRuntime.InvokeJS($"Uno.UI.WindowManager.current.setRootContent();");

				if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded && _rootVisual.IsLoaded)
				{
					UIElement.RootElementUnloaded(_rootVisual);
				}
			}

			UpdateRootAttributes();
		}

		private UIElement InternalGetContent() => _content;

		private UIElement InternalGetRootElement() => _rootVisual!;

		private static Window InternalGetCurrentWindow()
		{
			if (_current == null)
			{
				_current = new Window();
			}

			return _current;
		}

		internal void UpdateRootAttributes()
		{
			if (_rootVisual == null)
			{
				throw new InvalidOperationException("Internal window root is not yet set.");
			}

			if (FeatureConfiguration.Cursors.UseHandForInteraction)
			{
				_rootVisual.SetAttribute("data-use-hand-cursor-interaction", "true");
			}
			else
			{
				_rootVisual.RemoveAttribute("data-use-hand-cursor-interaction");
			}
		}

		internal IDisposable OpenPopup(Popup popup)
		{
			if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
			{
				this.Log().Debug($"Creating popup");
			}

			if (PopupRoot == null)
			{
				throw new InvalidOperationException("PopupRoot is not initialized yet.");
			}

			var popupPanel = popup.PopupPanel;
			PopupRoot.Children.Add(popupPanel);

			return new CompositeDisposable(
				Disposable.Create(() =>
				{

					if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
					{
						this.Log().Debug($"Closing popup");
					}

					PopupRoot.Children.Remove(popupPanel);
				}),
				VisualTreeHelper.RegisterOpenPopup(popup)
			);
		}
	}
}
#endif
