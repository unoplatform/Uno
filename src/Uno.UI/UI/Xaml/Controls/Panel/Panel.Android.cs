using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.Controls;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Android.Views;
using Uno.UI.DataBinding;
using Uno.Disposables;
using Windows.UI.Xaml.Data;
using System.Runtime.CompilerServices;
using Android.Graphics;
using Android.Graphics.Drawables;
using Uno.UI;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls
{
	public partial class Panel : IEnumerable
	{
		private readonly SerialDisposable _backgroundBrushChanged = new SerialDisposable();
		private readonly SerialDisposable _borderBrushChanged = new SerialDisposable();
		private BorderLayerRenderer _borderRenderer = new BorderLayerRenderer();

		public Panel()
		{
			Initialize();
		}

		protected override void OnChildViewAdded(View child)
		{
			IsChildrenRenderOrderDirty = true;
			
			if (child is IFrameworkElement element)
			{
				OnChildAdded(element);
			}

			base.OnChildViewAdded(child);
		}

		partial void Initialize();

		partial void OnLoadedPartial()
		{
			UpdateBorder();
		}

		partial void OnUnloadedPartial()
		{
			_borderRenderer.Clear();
		}

		partial void UpdateBorder()
		{
			UpdateBorder(false);
		}

		private void UpdateBorder(bool willUpdateMeasures)
		{
			if (IsLoaded)
			{
				_borderRenderer.UpdateLayer(
					this,
					Background,
					InternalBackgroundSizing,
					BorderThicknessInternal,
					BorderBrushInternal,
					CornerRadiusInternal,
					PaddingInternal,
					willUpdateMeasures
				);
			}
		}

		protected override void OnLayoutCore(bool changed, int left, int top, int right, int bottom, bool localIsLayoutRequested)
		{
			base.OnLayoutCore(changed, left, top, right, bottom, localIsLayoutRequested);

			UpdateBorder(changed);
		}

		protected override void OnDraw(Android.Graphics.Canvas canvas)
		{
			AdjustCornerRadius(canvas, CornerRadiusInternal);
		}

		protected virtual void OnChildrenChanged()
		{
			IsChildrenRenderOrderDirty = true;
			UpdateBorder();
		}

		partial void OnPaddingChangedPartial(Thickness oldValue, Thickness newValue)
		{
			UpdateBorder(true);
		}

		partial void OnBorderBrushChangedPartial(Brush oldValue, Brush newValue)
		{
			_borderBrushChanged.Disposable = Brush.AssignAndObserveBrush(newValue, _ => UpdateBorder(), UpdateBorder);
			UpdateBorder();
		}

		partial void OnBorderThicknessChangedPartial(Thickness oldValue, Thickness newValue)
		{
			UpdateBorder();
		}

		partial void OnCornerRadiusChangedPartial(CornerRadius oldValue, CornerRadius newValue)
		{
			UpdateBorder();
		}

		protected override void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
		{
			// Don't call base, just update the filling color.
			_backgroundBrushChanged.Disposable = Brush.AssignAndObserveBrush(e.NewValue as Brush, _ => UpdateBorder(), UpdateBorder);
			UpdateBorder();
		}

		protected override void OnBeforeArrange()
		{
			base.OnBeforeArrange();

			//We set childrens position for the animations before the arrange
			_transitionHelper?.SetInitialChildrenPositions();

			CheckChildrenDrawingOrder();
		}

		protected override void OnAfterArrange()
		{
			base.OnAfterArrange();

			//We trigger all layoutUpdated animations
			_transitionHelper?.LayoutUpdatedTransition();
		}

		/// <summary>        
		/// Support for the C# collection initializer style.
		/// Allows items to be added like this 
		/// new Panel 
		/// {
		///    new Border()
		/// }
		/// </summary>
		/// <param name="view"></param>
		public void Add(UIElement view)
		{
			Children.Add(view);
		}

		public IEnumerator GetEnumerator()
		{
			return this.GetChildren().GetEnumerator();
		}

		bool ICustomClippingElement.AllowClippingToLayoutSlot => true;
		bool ICustomClippingElement.ForceClippingToLayoutSlot => CornerRadiusInternal != CornerRadius.None;

		internal bool IsChildrenRenderOrderDirty { get; set; }

		/// <summary>
		/// Draw order of children as determined by Canvas.ZIndex
		/// </summary>
		private int[] _drawOrders;

		private void CheckChildrenDrawingOrder()
		{
			// Sorting is only needed when Children count is above 1
			if (Children.Count > 1 && IsChildrenRenderOrderDirty)
			{
				if (_drawOrders?.Length != Children.Count)
				{
					_drawOrders = new int[Children.Count];
				}

				var sorted = Children
					.Select((view, childrenIndex) => (view, childrenIndex))
					.OrderBy(tpl => tpl.view is DependencyObject obj ? Canvas.GetZIndex(obj) : 0); // Note: this has to be a stable sort

				var drawOrder = 0;
				foreach (var tpl in sorted)
				{
					_drawOrders[tpl.childrenIndex] = drawOrder;
					drawOrder++;
				}

				ChildrenDrawingOrderEnabled = true;
			}
			else
			{
				_drawOrders = null;
			}

			IsChildrenRenderOrderDirty = false;
		}

		protected override int GetChildDrawingOrder(int childCount, int i)
		{
			return _drawOrders?.Length == childCount ? _drawOrders[i] : i;
		}
	}
}
