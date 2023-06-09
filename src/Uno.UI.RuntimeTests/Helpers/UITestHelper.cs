﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Input.Preview.Injection;
using Windows.UI.Xaml;
using Private.Infrastructure;

namespace Uno.UI.RuntimeTests.Tests.Uno_UI_Xaml_Core;

// Note: This file contains a bunch of helpers that are expected to be moved to the test engine among the pointer injection work

public static class UITestHelper
{
	public static async Task<Windows.Foundation.Rect> Load(FrameworkElement element)
	{
		TestServices.WindowHelper.WindowContent = element;
		await TestServices.WindowHelper.WaitForLoaded(element);
		element.UpdateLayout();
		await TestServices.WindowHelper.WaitForIdle();

		return element.GetAbsoluteBounds();
	}
}

public static class InputInjectorExtensions
{
	public static Finger GetFinger(this InputInjector injector, uint id = 42)
		=> new(injector, id);

#if !WINDOWS_UWP
	public static Mouse GetMouse(this InputInjector injector)
		=> new(injector);
#endif
}

public interface IInjectedPointer
{
	void Press(Point position);

	void MoveTo(Point position);

	void MoveBy(double deltaX = 0, double deltaY = 0);

	void Release();
}

public static class FrameworkElementExtensions
{
	public static Rect GetAbsoluteBounds(this FrameworkElement element)
		=> element.TransformToVisual(null).TransformBounds(new Rect(0, 0, element.ActualWidth, element.ActualHeight));
}

public static class PointExtensions
{
	public static Point Offset(this Point point, double xAndY)
		=> new(point.X + xAndY, point.Y + xAndY);

	public static Point Offset(this Point point, double x, double y)
		=> new(point.X + x, point.Y + y);
}

public static class InjectedPointerExtensions
{
	public static void Press(this IInjectedPointer pointer, double x, double y)
		=> pointer.Press(new(x, y));

	public static void MoveTo(this IInjectedPointer pointer, double x, double y)
		=> pointer.MoveTo(new(x, y));

	public static void Drag(this IInjectedPointer pointer, Point from, Point to)
	{
		pointer.Press(from);
		pointer.MoveTo(to);
		pointer.Release();
	}
}

public class Finger : IInjectedPointer, IDisposable
{
	private const uint _defaultMoveSteps = 10;

	private readonly InputInjector _injector;
	private readonly uint _id;

	private Point? _currentPosition;

	public Finger(InputInjector injector, uint id)
	{
		_injector = injector;
		_id = id;

		_injector.InitializeTouchInjection(InjectedInputVisualizationMode.Default);
	}

	public void Press(Point position)
	{
		if (_currentPosition is null)
		{
			Inject(GetPress(_id, position));
			_currentPosition = position;
		}
	}

	void IInjectedPointer.MoveTo(Point position) => MoveTo(position);
	public void MoveTo(Point position, uint steps = _defaultMoveSteps)
	{
		if (_currentPosition is { } current)
		{
			Inject(GetMove(current, position, steps));
			_currentPosition = position;
		}
	}

	void IInjectedPointer.MoveBy(double deltaX, double deltaY) => MoveBy(deltaX, deltaY);
	public void MoveBy(double deltaX, double deltaY, uint steps = _defaultMoveSteps)
	{
		if (_currentPosition is { } current)
		{
			MoveTo(current.Offset(deltaX, deltaY), steps);
		}
	}

	public void Release()
	{
		if (_currentPosition is { } current)
		{
			Inject(GetRelease(current));
			_currentPosition = null;
		}
	}

	public void Dispose()
	{
		Release();
		_injector.UninitializeTouchInjection();
	}

	public static InjectedInputTouchInfo GetPress(uint id, Point position)
		=> new()
		{
			PointerInfo = new()
			{
				PointerId = id,
				PixelLocation = At(position),
				PointerOptions = InjectedInputPointerOptions.New
					| InjectedInputPointerOptions.FirstButton
					| InjectedInputPointerOptions.PointerDown
					| InjectedInputPointerOptions.InContact
			}
		};

	public static IEnumerable<InjectedInputTouchInfo> GetMove(Point fromPosition, Point toPosition, uint steps = _defaultMoveSteps)
	{
		steps += 1; // We need to send at least the final location, but steps refers to the number of intermediate points

		var stepX = (toPosition.X - fromPosition.X) / steps;
		var stepY = (toPosition.Y - fromPosition.Y) / steps;
		for (var step = 1; step <= steps; step++)
		{
			yield return new()
			{
				PointerInfo = new()
				{
					PixelLocation = At(fromPosition.X + step * stepX, fromPosition.Y + step * stepY),
					PointerOptions = InjectedInputPointerOptions.Update
						| InjectedInputPointerOptions.FirstButton
						| InjectedInputPointerOptions.InContact
						| InjectedInputPointerOptions.InRange
				}
			};
		}
	}

	public static InjectedInputTouchInfo GetRelease(Point position)
		=> new()
		{
			PointerInfo = new()
			{
				PixelLocation = At(position),
				PointerOptions = InjectedInputPointerOptions.FirstButton
					| InjectedInputPointerOptions.PointerUp
			}
		};

	private void Inject(IEnumerable<InjectedInputTouchInfo> infos)
		=> _injector.InjectTouchInput(infos.ToArray());

	private void Inject(params InjectedInputTouchInfo[] infos)
		=> _injector.InjectTouchInput(infos);

	// Note: This a patch until Uno's pointer injection is being relative to the screen
	private static InjectedInputPoint At(Point position)
		=> At(position.X, position.Y);

	private static InjectedInputPoint At(double x, double y)
#if HAS_UNO
		=> new() { PositionX = (int)x, PositionY = (int)y };
#else
	{
		var bounds = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds;
		var scale = Windows.Graphics.Display.DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;

		return new()
		{
			PositionX = (int)((bounds.X + x) * scale),
			PositionY = (int)((bounds.Y + y) * scale),
		};
	}
#endif
}

#if !WINDOWS_UWP
public class Mouse
{
	private readonly InputInjector _input;

	public Mouse(InputInjector input)
	{
		_input = input;
	}

	public void Press()
		=> Inject(new InjectedInputMouseInfo()
		{
			TimeOffsetInMilliseconds = 1,
			MouseOptions = InjectedInputMouseOptions.LeftDown,
		});

	public void Release()
		=> Inject(new InjectedInputMouseInfo()
		{
			TimeOffsetInMilliseconds = 1,
			MouseOptions = InjectedInputMouseOptions.LeftUp,
		});

	public void ReleaseAny()
	{
		var options = default(InjectedInputMouseOptions);

		var current = _input.Mouse;
		if (current.Properties.IsLeftButtonPressed)
		{
			options |= InjectedInputMouseOptions.LeftUp;
		}

		if (current.Properties.IsMiddleButtonPressed)
		{
			options |= InjectedInputMouseOptions.MiddleUp;
		}

		if (current.Properties.IsRightButtonPressed)
		{
			options |= InjectedInputMouseOptions.RightUp;
		}

		if (current.Properties.IsXButton1Pressed)
		{
			options |= InjectedInputMouseOptions.XUp;
		}

		if (options != default)
		{
			Inject(new InjectedInputMouseInfo()
			{
				TimeOffsetInMilliseconds = 1,
				MouseOptions = options
			});
		}
	}

	public void MoveBy(int deltaX, int deltaY)
		=> Inject(MoveByCore(deltaX, deltaY));

	public void MoveTo(double deltaX, double deltaY, int? steps = null)
		=> Inject(MoveToCore(deltaX, deltaY, steps));

	private InjectedInputMouseInfo MoveByCore(int deltaX, int deltaY)
		=> new()
		{
			DeltaX = deltaX,
			DeltaY = deltaY,
			TimeOffsetInMilliseconds = 1,
			MouseOptions = InjectedInputMouseOptions.MoveNoCoalesce,
		};

	private IEnumerable<InjectedInputMouseInfo> MoveToCore(double x, double y, int? steps)
	{
		Point Current()
			=> _input.Mouse.Position;

		var deltaX = x - Current().X;
		var deltaY = y - Current().Y;

		steps ??= (int)Math.Min(Math.Max(Math.Abs(deltaX), Math.Abs(deltaY)), 512);
		if (steps is 0)
		{
			yield break;
		}

		var stepX = deltaX / steps.Value;
		var stepY = deltaY / steps.Value;

		stepX = stepX is > 0 ? Math.Ceiling(stepX) : Math.Floor(stepX);
		stepY = stepY is > 0 ? Math.Ceiling(stepY) : Math.Floor(stepY);

		for (var step = 0; step <= steps && (stepX is not 0 || stepY is not 0); step++)
		{
			yield return MoveByCore((int)stepX, (int)stepY);

			if (Math.Abs(Current().X - x) < stepX)
			{
				stepX = 0;
			}

			if (Math.Abs(Current().Y - y) < stepY)
			{
				stepY = 0;
			}
		}
	}

	private void Inject(IEnumerable<InjectedInputMouseInfo> infos)
		=> _input.InjectMouseInput(infos);

	private void Inject(params InjectedInputMouseInfo[] infos)
		=> _input.InjectMouseInput(infos);
}
#endif
