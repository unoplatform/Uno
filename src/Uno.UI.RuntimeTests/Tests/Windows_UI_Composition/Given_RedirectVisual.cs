﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Private.Infrastructure;
using Uno.Extensions;
using Uno.UI.RuntimeTests.Helpers;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Composition;

[TestClass]
public class Given_RedirectVisual
{
	[TestMethod]
#if !HAS_RENDER_TARGET_BITMAP
	[Ignore("Render target bitmap is not supported on this target")]
#endif
	[RunsOnUIThread]
	public async Task When_Source_Changes()
	{
		var compositor = Window.Current.Compositor;
		var expected = new Image
		{
			Width = 200,
			Height = 200,
			Stretch = Stretch.UniformToFill,
			Source = new BitmapImage(new Uri("https://uno-assets.platform.uno/logos/uno.png")),
		};
		var sut = new ContentControl
		{
			Width = 200,
			Height = 200
		};

		var redirectVisual = compositor.CreateRedirectVisual(ElementCompositionPreview.GetElementVisual(expected));
		redirectVisual.Size = new(200, 200);

		ElementCompositionPreview.SetElementChildVisual(sut, redirectVisual);

		var result = await Render(expected, sut);
		await ImageAssert.AreEqualAsync(result.actual, result.expected);
	}

	private async Task<(RawBitmap expected, RawBitmap actual)> Render(FrameworkElement expected, FrameworkElement sut)
	{
		await UITestHelper.Load(new Grid
		{
			ColumnDefinitions =
			{
				new ColumnDefinition(),
				new ColumnDefinition()
			},
			Children =
			{
				expected.Apply(e => Grid.SetColumn(e, 0)),
				sut.Apply(e => Grid.SetColumn(e, 1))
			}
		});

		return (await UITestHelper.ScreenShot(expected), await UITestHelper.ScreenShot(sut));
	}
}
