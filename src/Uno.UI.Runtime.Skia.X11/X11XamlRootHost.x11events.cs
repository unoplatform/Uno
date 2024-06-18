﻿using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Diagnostics.CodeAnalysis;
=======
using System.Diagnostics;
>>>>>>> f21ec962c7 (chore: listen to X resource updates)
using System.Globalization;
using System.Threading;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Uno.Foundation.Logging;
using Uno.UI.Hosting;

namespace Uno.WinUI.Runtime.Skia.X11;

internal partial class X11XamlRootHost
{
	private static int _threadCount;

	private readonly Action<Size> _resizeCallback;
	private readonly Action _closingCallback;
	private readonly Action<bool> _focusCallback;
	private readonly Action<bool> _visibilityCallback;

	private Thread? _eventsThread;
	private X11PointerInputSource? _pointerSource;
	private X11KeyboardInputSource? _keyboardSource;
	private X11DragDropExtension? _dragDrop;
	private X11DisplayInformationExtension? _displayInformationExtension;

	private void InitializeX11EventsThread()
	{
		_eventsThread = new Thread(Run)
		{
			Name = $"Uno XEvents {Interlocked.Increment(ref _threadCount) - 1}",
			IsBackground = true
		};

		_eventsThread.Start();
	}

	public void SetPointerSource(X11PointerInputSource pointerSource)
	{
		if (_pointerSource is not null)
		{
			throw new InvalidOperationException($"{nameof(X11PointerInputSource)} is set twice.");
		}
		_pointerSource = pointerSource;
	}

	public void SetKeyboardSource(X11KeyboardInputSource keyboardSource)
	{
		if (_keyboardSource is not null)
		{
			throw new InvalidOperationException($"{nameof(X11KeyboardInputSource)} is set twice.");
		}
		_keyboardSource = keyboardSource;
	}

	public void SetDragDropExtension(X11DragDropExtension dragDrop)
	{
		if (_dragDrop is not null)
		{
			throw new InvalidOperationException($"{nameof(X11DragDropExtension)} is set twice.");
		}
		_dragDrop = dragDrop;
	}

	public void SetDisplayInformationExtension(X11DisplayInformationExtension extension)
	{
		if (_displayInformationExtension is not null)
		{
			throw new InvalidOperationException($"{nameof(X11DisplayInformationExtension)} is set twice.");
		}
		_displayInformationExtension = extension;
	}

	private unsafe void Run()
	{
		var fds = stackalloc X11Helper.Pollfd[1];
		fds[0].fd = XLib.XConnectionNumber(X11Window.Display);
		fds[0].events = X11Helper.POLLIN;

		while (true)
		{
			var ret = X11Helper.poll(fds, 1, 1000); // timeout every second to see if the window is closed

			if (_closed.Task.IsCompleted)
			{
				return;
			}

			if (ret == 0) // timeout
			{
				// If the fd becomes "ready" between the timeout and the next poll request, the second poll will
				// return immediately, not block forever.
				continue;
			}
			else if (ret < 0)
			{
				if (this.Log().IsEnabled(LogLevel.Error))
				{
					this.Log().Error("Polling for X11 events failed, defaulting to SpinWait");
				}

				SpinWait.SpinUntil(() =>
				{
					using (X11Helper.XLock(X11Window.Display))
					{
						return X11Helper.XPending(X11Window.Display) > 0;
					}
				});
			}
			else if ((fds[0].revents & X11Helper.POLLIN) == 0)
			{
				continue;
			}

			// Only hold the lock when fetching the next event
			static IEnumerable<XEvent> GetEvents(IntPtr display)
			{
				while (true)
				{
					XEvent @event;
					using (var @lock = X11Helper.XLock(display))
					{
						if (X11Helper.XPending(display) == 0)
						{
							yield break;
						}

						XLib.XNextEvent(display, out @event);
					}
					yield return @event;
				}
			}

			foreach (var @event in GetEvents(X11Window.Display))
			{
				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().Trace($"XLIB EVENT: {@event.type}");
				}

				if (@event.AnyEvent.window != x11Window.Window)
				{
<<<<<<< HEAD
					case XEventName.ClientMessage:
						if (@event.ClientMessageEvent.ptr1 == X11Helper.GetAtom(X11Window.Display, X11Helper.WM_DELETE_WINDOW))
						{
							// This happens when we click the titlebar X, not like xkill,
							// which, according to the source code, just calls XKillClient
							// https://gitlab.freedesktop.org/xorg/app/xkill/-/blob/a5f704e4cd30f03859f66bafd609a75aae27cc8c/xkill.c#L234
							// In the case of xkill, we can't really do much, it's similar to a SIGKILL but for x connections
							QueueAction(this, _closingCallback);
						}
						else if (@event.ClientMessageEvent.message_type == X11Helper.GetAtom(X11Window.Display, X11Helper.XdndEnter) ||
							@event.ClientMessageEvent.message_type == X11Helper.GetAtom(X11Window.Display, X11Helper.XdndPosition) ||
							@event.ClientMessageEvent.message_type == X11Helper.GetAtom(X11Window.Display, X11Helper.XdndPosition) ||
							@event.ClientMessageEvent.message_type == X11Helper.GetAtom(X11Window.Display, X11Helper.XdndLeave) ||
							@event.ClientMessageEvent.message_type == X11Helper.GetAtom(X11Window.Display, X11Helper.XdndDrop))
						{
							QueueAction(this, () => _dragDrop?.ProcessXdndMessage(@event.ClientMessageEvent));
						}
						break;
					case XEventName.ConfigureNotify:
						var configureEvent = @event.ConfigureEvent;
						_displayInformationExtension?.UpdateDetails();
						_wrapper.RasterizationScale = (float)(_displayInformationExtension?.RawPixelsPerViewPixel ?? 1.0f);
						QueueAction(this, () => _resizeCallback(new Size(configureEvent.width, configureEvent.height)));
						break;
					case XEventName.FocusIn:
						QueueAction(this, () => _focusCallback(true));
						break;
					case XEventName.FocusOut:
						QueueAction(this, () => _focusCallback(false));
						break;
					case XEventName.VisibilityNotify:
						QueueAction(this, () => _visibilityCallback(@event.VisibilityEvent.state != /* VisibilityFullyObscured */ 2));
						break;
					case XEventName.Expose:
						QueueAction(this, () => ((IXamlRootHost)this).InvalidateRender());
						break;
					case XEventName.MotionNotify:
						_pointerSource?.ProcessMotionNotifyEvent(@event.MotionEvent);
						break;
					case XEventName.ButtonPress:
						_pointerSource?.ProcessButtonPressedEvent(@event.ButtonEvent);
						break;
					case XEventName.ButtonRelease:
						_pointerSource?.ProcessButtonReleasedEvent(@event.ButtonEvent);
						break;
					case XEventName.LeaveNotify:
						_pointerSource?.ProcessLeaveEvent(@event.CrossingEvent);
						break;
					case XEventName.EnterNotify:
						_pointerSource?.ProcessEnterEvent(@event.CrossingEvent);
						break;
					case XEventName.KeyPress:
						_keyboardSource?.ProcessKeyboardEvent(@event.KeyEvent, true);
						break;
					case XEventName.KeyRelease:
						_keyboardSource?.ProcessKeyboardEvent(@event.KeyEvent, false);
						break;
					case XEventName.DestroyNotify:
						// We handle the WM_DELETE_WINDOW message above, so ignore this.
						break;
					case XEventName.MapNotify:
						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							this.Log().Debug($"Window {X11Window.Window.ToString("X", CultureInfo.InvariantCulture)} is mapped.");
						}
						break;
					case XEventName.UnmapNotify:
						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							this.Log().Debug($"Window {X11Window.Window.ToString("X", CultureInfo.InvariantCulture)} is unmapped.");
						}
						break;
					case XEventName.ReparentNotify:
						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							this.Log().Debug($"Window {X11Window.Window.ToString("X", CultureInfo.InvariantCulture)} was reparented to parent window {@event.ReparentEvent.parent.ToString("X", CultureInfo.InvariantCulture)}.");
						}
						break;
					default:
						if (this.Log().IsEnabled(LogLevel.Error))
						{
							this.Log().Error($"XLIB ERROR: received an unexpected {@event.type} event");
						}
						break;
=======
#if DEBUG
					_ = XLib.XQueryTree(x11Window.Display, x11Window.Window, out IntPtr root, out _, out var children, out _);
					_ = XLib.XFree(children);
					Debug.Assert(@event.AnyEvent.window == root);
#endif
					switch (@event.type)
					{
						case XEventName.PropertyNotify:
							using (X11Helper.XLock(x11Window.Display))
							{
								if (@event.PropertyEvent.atom == X11Helper.GetAtom(x11Window.Display, X11Helper.RESOURCE_MANAGER))
								{
									if (this.Log().IsEnabled(LogLevel.Information))
									{
										this.Log().Info($"X resources changed. Updating DPI scaling.");
									}
									XWindowAttributes attributes = default;
									_ = XLib.XGetWindowAttributes(x11Window.Display, x11Window.Window, ref attributes);
									UpdateSizeAndDpi(new Size(attributes.width, attributes.height));
								}
							}
							break;
						default:
							if (this.Log().IsEnabled(LogLevel.Error))
							{
								this.Log().Error($"XLIB ERROR: received an unexpected {@event.type} event on the root X11 window.");
							}
							break;
					}
				}
				else
				{
					switch (@event.type)
					{
						case XEventName.ClientMessage:
							if (@event.ClientMessageEvent.ptr1 == X11Helper.GetAtom(x11Window.Display, X11Helper.WM_DELETE_WINDOW))
							{
								// This happens when we click the titlebar X, not like xkill,
								// which, according to the source code, just calls XKillClient
								// https://gitlab.freedesktop.org/xorg/app/xkill/-/blob/a5f704e4cd30f03859f66bafd609a75aae27cc8c/xkill.c#L234
								// In the case of xkill, we can't really do much, it's similar to a SIGKILL but for x connections
								QueueAction(this, _closingCallback);
							}
							else if (@event.ClientMessageEvent.message_type == X11Helper.GetAtom(x11Window.Display, X11Helper.XdndEnter) ||
								@event.ClientMessageEvent.message_type == X11Helper.GetAtom(x11Window.Display, X11Helper.XdndPosition) ||
								@event.ClientMessageEvent.message_type == X11Helper.GetAtom(x11Window.Display, X11Helper.XdndPosition) ||
								@event.ClientMessageEvent.message_type == X11Helper.GetAtom(x11Window.Display, X11Helper.XdndLeave) ||
								@event.ClientMessageEvent.message_type == X11Helper.GetAtom(x11Window.Display, X11Helper.XdndDrop))
							{
								QueueAction(this, () => _dragDrop?.ProcessXdndMessage(@event.ClientMessageEvent));
							}
							break;
						case XEventName.ConfigureNotify:
							var configureEvent = @event.ConfigureEvent;
							UpdateSizeAndDpi(new Size(configureEvent.width, configureEvent.height));
							break;
						case XEventName.FocusIn:
							QueueAction(this, () => _focusCallback(true));
							break;
						case XEventName.FocusOut:
							QueueAction(this, () => _focusCallback(false));
							break;
						case XEventName.VisibilityNotify:
							QueueAction(this, () => _visibilityCallback(@event.VisibilityEvent.state != /* VisibilityFullyObscured */ 2));
							break;
						case XEventName.Expose:
							QueueAction(this, () => ((IXamlRootHost)this).InvalidateRender());
							break;
						case XEventName.MotionNotify:
							_pointerSource?.ProcessMotionNotifyEvent(@event.MotionEvent);
							break;
						case XEventName.ButtonPress:
							_pointerSource?.ProcessButtonPressedEvent(@event.ButtonEvent);
							break;
						case XEventName.ButtonRelease:
							_pointerSource?.ProcessButtonReleasedEvent(@event.ButtonEvent);
							break;
						case XEventName.LeaveNotify:
							_pointerSource?.ProcessLeaveEvent(@event.CrossingEvent);
							break;
						case XEventName.EnterNotify:
							_pointerSource?.ProcessEnterEvent(@event.CrossingEvent);
							break;
						case XEventName.KeyPress:
							_keyboardSource?.ProcessKeyboardEvent(@event.KeyEvent, true);
							break;
						case XEventName.KeyRelease:
							_keyboardSource?.ProcessKeyboardEvent(@event.KeyEvent, false);
							break;
						case XEventName.DestroyNotify:
							// We handle the WM_DELETE_WINDOW message above, so ignore this.
							break;
						case XEventName.MapNotify:
							if (this.Log().IsEnabled(LogLevel.Debug))
							{
								this.Log().Debug($"Window {x11Window.Window.ToString("X", CultureInfo.InvariantCulture)} is mapped.");
							}
							break;
						case XEventName.UnmapNotify:
							if (this.Log().IsEnabled(LogLevel.Debug))
							{
								this.Log().Debug($"Window {x11Window.Window.ToString("X", CultureInfo.InvariantCulture)} is unmapped.");
							}
							break;
						case XEventName.ReparentNotify:
							if (this.Log().IsEnabled(LogLevel.Debug))
							{
								this.Log().Debug($"Window {x11Window.Window.ToString("X", CultureInfo.InvariantCulture)} was reparented to parent window {@event.ReparentEvent.parent.ToString("X", CultureInfo.InvariantCulture)}.");
							}
							break;
						default:
							if (this.Log().IsEnabled(LogLevel.Error))
							{
								this.Log().Error($"XLIB ERROR: received an unexpected {@event.type} event on window {x11Window.Window.ToString("X", CultureInfo.InvariantCulture)}");
							}
							break;
					}
>>>>>>> f21ec962c7 (chore: listen to X resource updates)
				}
			}
		}
		// ReSharper disable once FunctionNeverReturns
	}
	private void UpdateSizeAndDpi(Size size)
	{
		QueueAction(this, () =>
		{
			_displayInformationExtension?.UpdateDetails();
			_wrapper.RasterizationScale = (float)(_displayInformationExtension?.RawPixelsPerViewPixel ?? 1.0f);
			_resizeCallback(size);
		});
	}

	public static void QueueAction(IXamlRootHost host, Action action)
		=> host.RootElement?.Dispatcher.RunAsync(CoreDispatcherPriority.High, new DispatchedHandler(action));

	public static VirtualKeyModifiers XModifierMaskToVirtualKeyModifiers(XModifierMask state)
	{
		var modifiers = VirtualKeyModifiers.None;
		if ((state & XModifierMask.ShiftMask) != 0)
		{
			modifiers |= VirtualKeyModifiers.Shift;
		}
		if ((state & XModifierMask.Mod1Mask) != 0)
		{
			// TODO: Modifier keys can be mapped to different keys. What to do?
			modifiers |= VirtualKeyModifiers.Shift;
		}
		if ((state & XModifierMask.ControlMask) != 0)
		{
			modifiers |= VirtualKeyModifiers.Control;
		}
		if ((state & XModifierMask.ControlMask) != 0)
		{
			modifiers |= VirtualKeyModifiers.Control;
		}
		if ((state & XModifierMask.Mod4Mask) != 0)
		{
			// TODO: Modifier keys can be mapped to different keys. What to do?
			modifiers |= VirtualKeyModifiers.Windows;
		}

		return modifiers;
	}
}
