using System;

using Uno.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Foundation;
using AppKit;
using CoreGraphics;
using Uno.Disposables;
using Uno.Diagnostics.Eventing;
using Windows.UI.Core;
using System.Threading.Tasks;
using System.Threading;
using Windows.Foundation;
using Uno.Logging;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Automation.Peers;

namespace Windows.UI.Xaml.Controls
{
	public partial class Image
	{

		private void SetImage(CGImage cgImage, CGSize size) => SetImage(new NSImage(cgImage, size));

		private void UpdateContentMode(Stretch stretch, NSImage image)
		{
			if (_native == null)
			{
				return;
			}

			_native.Layer = new CoreAnimation.CALayer();

			switch (stretch)
			{
				case Stretch.Uniform:
					_native.Layer.ContentsGravity = (string)CoreAnimation.CALayer.GravityResizeAspect;
					break;
				case Stretch.None:
					_native.Layer.ContentsGravity = (string)CoreAnimation.CALayer.GravityTopLeft;

					break;
				case Stretch.UniformToFill:
					_native.Layer.ContentsGravity = (string)CoreAnimation.CALayer.GravityResizeAspectFill;
					break;
				case Stretch.Fill:
					_native.Layer.ContentsGravity = (string)CoreAnimation.CALayer.GravityResize;
					_native.Alignment = NSTextAlignment.Left;
					break;
				default:
					throw new NotSupportedException("Stretch mode {0} is not supported".InvariantCultureFormat(stretch));
			}

			_native.Layer.SetContents(image);
			_native.WantsLayer = true;
		}
	}
}

