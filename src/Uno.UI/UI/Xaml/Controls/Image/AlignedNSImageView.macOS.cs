using System;
using System.Collections.Generic;
using System.Text;
using AppKit;
using Uno.Extensions;
using Windows.UI.Xaml.Media;
using CoreGraphics;

namespace Windows.UI.Xaml.Controls
{
	// https://github.com/reydanro/UIImageViewAligned
	internal partial class AlignedNSImageView : NSImageView
	{
		private readonly NSImageView _realImageView;
		private Stretch _stretch = Stretch.Fill;
		private HorizontalAlignment _hAlign = HorizontalAlignment.Stretch;
		private VerticalAlignment _vAlign = VerticalAlignment.Stretch;

		public override NSImage Image
		{
			get => _realImageView.Image;
			set => _realImageView.Image = value;
		}

		public AlignedNSImageView()
		{
			_realImageView = new NSImageView();

			AddSubview(_realImageView);
		}

		public void UpdateContentMode(Stretch stretch, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
		{
			_stretch = stretch;
			_hAlign = horizontalAlignment;
			_vAlign = verticalAlignment;

			if (_realImageView?.Image == null)
			{
				return;
			}

			_realImageView.Layer = new CoreAnimation.CALayer();

			switch (stretch)
			{
				case Stretch.Uniform:
					_realImageView.Layer.ContentsGravity = (string)CoreAnimation.CALayer.GravityResizeAspect;
					break;
				case Stretch.None:
					_realImageView.Layer.ContentsGravity = (string)CoreAnimation.CALayer.GravityTopLeft;

					break;
				case Stretch.UniformToFill:
					_realImageView.Layer.ContentsGravity = (string)CoreAnimation.CALayer.GravityResizeAspectFill;
					break;
				case Stretch.Fill:
					_realImageView.Layer.ContentsGravity = (string)CoreAnimation.CALayer.GravityResize;
					break;
				default:
					throw new NotSupportedException("Stretch mode {0} is not supported".InvariantCultureFormat(stretch));
			}

			_realImageView.Layer.SetContents(Image);
			_realImageView.WantsLayer = true;

			Layout();
		}


		public override void Layout()
		{
			var realSize = GetContentSize();
			if (_stretch == Stretch.Uniform)
			{
				_realImageView.Frame = Bounds;
			}
			else
			{
				var realFrame = new CGRect(
					x: 0,
					y: 0,
					width: realSize.Width,
					height: realSize.Height);

				//if (_hAlign == HorizontalAlignment.Center)
				//	realFrame.X = (Bounds.Size.Width - realSize.Width) / 2;
				//else if (_hAlign == HorizontalAlignment.Left)
				//	realFrame.X = Bounds.Right - realFrame.Size.Width;

				//if (_vAlign == VerticalAlignment.Center)
				//	realFrame.Y = (Bounds.Size.Height - realSize.Height) / 2;
				//else if (_vAlign == VerticalAlignment.Bottom)
				//	realFrame.Y = Bounds.Bottom - realFrame.Size.Height;

				_realImageView.Frame = realFrame;
			}

			base.Layout();
			// Make sure we clear the contents of this container layer, since it refreshes from the image property once in a while.
			//Layer.Contents = null;
		}

		private CGSize GetContentSize()
		{
			CGSize size = Bounds.Size;

			if (_realImageView?.Image == null)
			{
				return size;
			}

			switch (_stretch)
			{
				case Stretch.Uniform:
					{
						var scalex = Bounds.Size.Width / _realImageView.Image.Size.Width;
						var scaley = Bounds.Size.Height / _realImageView.Image.Size.Height;
						var scale = (nfloat)Math.Min(scalex, scaley);

						
						size = new CGSize(_realImageView.Image.Size.Width * scale, _realImageView.Image.Size.Height * scale);
						break;
					}

				case Stretch.UniformToFill:
					{
						var scalex = Bounds.Size.Width / _realImageView.Image.Size.Width;
						var scaley = Bounds.Size.Height / _realImageView.Image.Size.Height;
						var scale = (nfloat)Math.Max(scalex, scaley);

						size = new CGSize(_realImageView.Image.Size.Width * scale, _realImageView.Image.Size.Height * scale);
						break;
					}

				case Stretch.Fill:
					{
						var scalex = Bounds.Size.Width / _realImageView.Image.Size.Width;
						var scaley = Bounds.Size.Height / _realImageView.Image.Size.Height;


						size = new CGSize(_realImageView.Image.Size.Width * scalex, _realImageView.Image.Size.Height * scaley);
						break;
					}

				default:
					size = _realImageView.Image.Size;
					break;
			}

			return size;
		}
	}
}
