﻿using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml.Wasm;
using Uno.Extensions;
using Uno.UI.Xaml;

namespace Windows.UI.Xaml.Shapes
{
	partial class Polygon
	{
		protected override Size MeasureOverride(Size availableSize)
		{
			WindowManagerInterop.SetSvgPolyPoints(_mainSvgElement.HtmlId, Points?.Flatten());

			return MeasureAbsoluteShape(availableSize, this);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			UpdateRender();
			return ArrangeAbsoluteShape(finalSize, this);
		}

		internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
		{
			base.OnPropertyChanged2(args);

			if (_bboxCacheKey != null && (
				args.Property == PointsProperty
			))
			{
				_bboxCacheKey = null;
			}
		}

		private protected override string GetBBoxCacheKeyImpl() =>
			Points is { } points
				? ("polygone:" + string.Join(',', points.Flatten()))
				: null;
	}
}
