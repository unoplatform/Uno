using System.Numerics;
using Windows.Foundation;
using Windows.Graphics.Display;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Hosting;
using SkiaSharp;
using Uno.Disposables;

namespace Microsoft.UI.Xaml.Controls;

/// <summary>
/// A wrapper around <see cref="SkiaVisual"/> that takes care of sizing, layouting and DPI.
/// </summary>
public abstract class SKCanvasElement : FrameworkElement
{
	private class SKCanvasVisual(SKCanvasElement owner, Compositor compositor) : SkiaVisual(compositor)
	{
		protected override void RenderOverride(SKCanvas canvas) => owner.RenderOverride(canvas, Size.ToSize());
	}

	private const float DpiBase = 96.0f;
	private double _dpi = 1;

	private readonly SkiaVisual _skiaVisual;
	private readonly SerialDisposable _dpiChangedDisposable = new SerialDisposable();

	protected SKCanvasElement()
	{
		_skiaVisual = new SKCanvasVisual(this, Visual.Compositor);
		ElementCompositionPreview.SetElementChildVisual(this, _skiaVisual!);
	}

	public static DependencyProperty RespectFlowDirectionProperty { get; } = DependencyProperty.Register(
		nameof(RespectFlowDirection),
		typeof(bool),
		typeof(SKCanvasElement),
		new FrameworkPropertyMetadata((dO, _) => ((SKCanvasElement)dO).RespectFlowDirectionChanged()));

	/// <summary>
	/// By default, SKCanvasElement will have the origin at the top-left of the drawing area with the normal directions increasing down and right.
	/// If RespectFlowDirection is true, the drawing will be horizontally reflected when <see cref="SKCanvasElement.FlowDirection"/> is <see cref="FlowDirection.RightToLeft"/>.
	/// </summary>
	public bool RespectFlowDirection
	{
		get => (bool)GetValue(RespectFlowDirectionProperty);
		set => SetValue(RespectFlowDirectionProperty, value);
	}

	private void RespectFlowDirectionChanged()
	{
		if (ApplyFlowDirection())
		{
			_skiaVisual.Invalidate();
		}
	}

	/// <summary>
	/// The SkiaSharp drawing logic goes here.
	/// </summary>
	/// <param name="canvas">The SKCanvas that should be drawn on. The drawing will directly appear in the clipping area.</param>
	/// <param name="area">The dimensions of the clipping area.</param>
	protected abstract void RenderOverride(SKCanvas canvas, Size area);

	/// <summary>
	/// By default, SKCanvasElement uses all the <see cref="availableSize"/> given. Subclasses of SKCanvasElement
	/// should override this method if they need something different.
	/// </summary>
	protected override Size MeasureOverride(Size availableSize) => availableSize;

	protected override Size ArrangeOverride(Size finalSize)
	{
		var dpiAwareSize = new Size(finalSize.Width * _dpi, finalSize.Height * _dpi);
		_skiaVisual.Size = new Vector2((float)dpiAwareSize.Width, (float)dpiAwareSize.Height);
		_skiaVisual.Clip = _skiaVisual.Compositor.CreateRectangleClip(0, 0, (float)dpiAwareSize.Width, (float)dpiAwareSize.Height);

		ApplyFlowDirection(); // if FlowDirection Changes, it will cause an InvalidateArrange, so we recalculate the TransformMatrix here

		return base.ArrangeOverride(finalSize);
	}

	private bool ApplyFlowDirection()
	{
		var oldMatrix = _skiaVisual.TransformMatrix;
		if (FlowDirection == FlowDirection.RightToLeft && !RespectFlowDirection)
		{
			_skiaVisual.TransformMatrix = new Matrix4x4(new Matrix3x2(-1.0f, 0.0f, 0.0f, 1.0f, (float)LayoutSlot.Width, 0.0f));
		}
		else
		{
			_skiaVisual.TransformMatrix = Matrix4x4.Identity;
		}

		return oldMatrix != _skiaVisual.TransformMatrix;
	}

	private protected override void OnLoaded()
	{
		var display = DisplayInformation.GetForCurrentView();
		_dpiChangedDisposable.Disposable = Disposable.Create(() => display.DpiChanged -= OnDpiChanged);
		display.DpiChanged += OnDpiChanged;
		OnDpiChanged(display);
	}

	private protected override void OnUnloaded() => _dpiChangedDisposable.Dispose();

	private void OnDpiChanged(DisplayInformation sender, object args = null)
	{
		_dpi = sender.LogicalDpi / DpiBase;
		_skiaVisual.Invalidate();
	}
}
