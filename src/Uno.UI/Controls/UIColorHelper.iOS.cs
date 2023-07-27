﻿using System;
using UIKit;
using ObjCRuntime;

namespace Windows.UI
{
	public static class UIColors
	{
		public static UIColor FromHex(uint hex)
		{
			var red = (byte)((hex >> 16) & 0xff);
			var green = (byte)((hex >> 8) & 0xff);
			var blue = (byte)((hex >> 0) & 0xff);
			var alpha = (byte)((hex >> 24) & 0xff);

			var color = UIColor.FromRGBA(red / 255f, green / 255f, blue / 255f, alpha / 255f);
			return color;
		}

		public static UIColor AddAlpha(UIColor color, float alpha)
		{
			nfloat r, g, b, a;
			color.GetRGBA(out r, out g, out b, out a);
			return UIColor.FromRGBA(r, g, b, alpha);
		}
	}
}

