﻿#nullable enable

using System;
using Android.App;
using Android.Graphics;
using AndroidBitmap = Android.Graphics.Bitmap;
using AndroidCanvas = Android.Graphics.Canvas;
using AndroidColor = Android.Graphics.Color;
using AndroidPaint = Android.Graphics.Paint;

namespace Uno.UI.Toolkit;

partial class ElevatedView
{
	private const int MaximumRadius = 128;

	private AndroidCanvas? _shadowCanvas;
	private AndroidPaint? _shadowPaint;
	private AndroidPaint? _renderPaint;
	private AndroidBitmap? _shadowBitmap;
	private bool _invalidateShadow = true;

#if NET8_0_OR_GREATER
	protected override void DispatchDraw(Canvas canvas)
#else
	protected override void DispatchDraw(Canvas? canvas)
#endif
	{
		if (Elevation > 0)
		{
			DrawShadow(canvas);
		}
		else
		{
			DisposeShadow();
		}

		// Draw children
		base.DispatchDraw(canvas!);
	}

	private void DisposeShadow()
	{
		_shadowCanvas?.Dispose();
		_shadowPaint?.Dispose();
		_shadowBitmap?.Dispose();
		_shadowCanvas = null;
		_shadowPaint = null;
		_shadowBitmap = null;
	}

	private void DrawShadow(AndroidCanvas? canvas)
	{
		_shadowCanvas ??= new AndroidCanvas();

		_shadowPaint ??= new AndroidPaint
		{
			AntiAlias = true,
			Dither = true,
			FilterBitmap = true
		};

		_renderPaint ??= new AndroidPaint
		{
			AntiAlias = true,
			Dither = true,
			FilterBitmap = true
		};

		if (_invalidateShadow)
		{
			var viewHeight = ActualHeight;
			var viewWidth = ActualWidth;
			var scaleFactor = GetScaleFactorForLayoutRounding();

			// If bounds is zero
			if (viewHeight != 0 && viewWidth != 0)
			{
				var bitmapHeight = (viewHeight + MaximumRadius) * scaleFactor;
				var bitmapWidth = (viewWidth + MaximumRadius) * scaleFactor;

				// Reset bitmap to bounds
				_shadowBitmap = AndroidBitmap.CreateBitmap(
					(int)bitmapWidth,
					(int)bitmapHeight,
					AndroidBitmap.Config.Argb8888!);

				// Reset Canvas
				_shadowCanvas.SetBitmap(_shadowBitmap);

				_invalidateShadow = false;

				// Create the local copy of all content to draw bitmap as a
				// bottom layer of natural canvas.
				base.DispatchDraw(_shadowCanvas!);

				// Get the alpha bounds of bitmap
				var extractAlpha = _shadowBitmap!.ExtractAlpha();
				if (extractAlpha is not null)
				{
					// Clear past content content to draw shadow
					_shadowCanvas.DrawColor(AndroidColor.Black, PorterDuff.Mode.Clear!);

					_shadowPaint.Color = ShadowColor;
					const float x = 0.28f;
					const float y = 0.90f * 0.5f; // Looks more accurate than the recommended 0.92f.
												  // Apply the shadow radius 
					var radius = (float)Math.Round(0.3f * (float)Elevation, 1, MidpointRounding.AwayFromZero);

					if (radius > 0)
					{
						_shadowPaint.SetMaskFilter(new BlurMaskFilter(radius, BlurMaskFilter.Blur.Normal));
					}

					float shadowOffsetX = (float)(Elevation * x * scaleFactor);
					float shadowOffsetY = (float)(Elevation * y * scaleFactor);

					_shadowCanvas.DrawBitmap(extractAlpha!, (int)shadowOffsetX, (int)shadowOffsetY, _shadowPaint);

					extractAlpha?.Recycle();
				}
			}
		}

		// Draw shadow bitmap
		if (_shadowCanvas != null && _shadowBitmap != null && !_shadowBitmap.IsRecycled)
		{
			canvas!.DrawBitmap(_shadowBitmap, 0.0F, 0.0F, _renderPaint);
		}
	}
}
