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

			var gravityResize = stretch switch
			{
				Stretch.Uniform => (string)CoreAnimation.CALayer.GravityResizeAspect,
				Stretch.None => (string)CoreAnimation.CALayer.GravityLeft,
				Stretch.UniformToFill => (string)CoreAnimation.CALayer.GravityResizeAspectFill,
				Stretch.Fill => (string)CoreAnimation.CALayer.GravityResize,
				_ => throw new NotSupportedException("Stretch mode {0} is not supported".InvariantCultureFormat(stretch)),
			};

			if (gravityResize != null)
			{
				_native.Layer.ContentsGravity = gravityResize;
			}

			_native.Layer.SetContents(image);
			_native.WantsLayer = true;
		}
	}
}

