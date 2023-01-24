﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;

using Color = global::Windows/*Intentional space for WinUI upgrade tool*/.UI.Color;

namespace Windows.UI
{
#if HAS_UNO_WINUI && !IS_UNO_UI_PROJECT
	internal
#else
	public
#endif
	static partial class Colors
	{
		private static Dictionary<string, Color> _colorMap = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase);

		public static Color FromARGB(byte a, byte r, byte g, byte b)
		{
			return Color.FromArgb(a, r, g, b);
		}

		public static Color FromInteger(int color)
		{
			return FromARGB(
				(byte)((color & 0xFF000000) >> 24),
				(byte)((color & 0x00FF0000) >> 16),
				(byte)((color & 0x0000FF00) >> 8),
				(byte)((color & 0x000000FF))
			);
		}

		/// <summary>
		/// Parses a string representing a color
		/// </summary>
		/// <param name="colorCode"></param>
		/// <returns></returns>
		public static Color Parse(string colorCode)
		{
			if (colorCode?.StartsWith("#", StringComparison.Ordinal) ?? false)
			{
				return FromARGB(colorCode);
			}
			else
			{
				if (!string.IsNullOrWhiteSpace(colorCode))
				{
					Color color;

					if (!_colorMap.TryGetValue(colorCode, out color))
					{
						var property = typeof(Colors).GetProperty(colorCode);

						if (property != null)
						{
							_colorMap[colorCode] = color = (Color)property.GetValue(null);
						}
						else
						{
							throw new InvalidOperationException($"The color {colorCode} is unknown");
						}
					}

					return color;
				}
				else
				{
					throw new InvalidOperationException($"Cannot parse an empty color string");
				}
			}
		}

		/// <summary>
		/// Takes a color code as an ARGB, RGB, #ARGB, #RGB string and returns a color.
		///
		/// Remark: if single digits are used to define the color, they will
		/// be duplicated (example: FFD8 will become FFFFDD88)
		/// </summary>
		/// <param name="colorCode"></param>
		/// <returns></returns>
		public static Color FromARGB(string colorCode)
		{
			byte a, r, b, g;

			colorCode = colorCode.TrimStart(new char[] { '#' });

			if (colorCode.Length == 3)
			{
				a = 0xFF;
				r = Convert.ToByte(new String(colorCode[0], 2), 16);
				g = Convert.ToByte(new String(colorCode[1], 2), 16);
				b = Convert.ToByte(new String(colorCode[2], 2), 16);
			}
			else if (colorCode.Length == 4)
			{
				a = Convert.ToByte(new String(colorCode[0], 2), 16);
				r = Convert.ToByte(new String(colorCode[1], 2), 16);
				g = Convert.ToByte(new String(colorCode[2], 2), 16);
				b = Convert.ToByte(new String(colorCode[3], 2), 16);
			}
			else if (colorCode.Length == 6)
			{
				a = 0xFF;
				r = Convert.ToByte(colorCode.Substring(0, 2), 16);
				g = Convert.ToByte(colorCode.Substring(2, 2), 16);
				b = Convert.ToByte(colorCode.Substring(4, 2), 16);
			}
			else if (colorCode.Length == 8)
			{
				a = Convert.ToByte(colorCode.Substring(0, 2), 16);
				r = Convert.ToByte(colorCode.Substring(2, 2), 16);
				g = Convert.ToByte(colorCode.Substring(4, 2), 16);
				b = Convert.ToByte(colorCode.Substring(6, 2), 16);
			}
			else
			{
				a = 0xFF;
				r = 0xFF;
				g = 0x0;
				b = 0x0;
			}
			return Color.FromArgb(a, r, g, b);
		}

		private static Color? _transparent;
		private static Color? _aliceBlue;
		private static Color? _antiqueWhite;
		private static Color? _aqua;
		private static Color? _aquamarine;
		private static Color? _azure;
		private static Color? _beige;
		private static Color? _bisque;
		private static Color? _black;
		private static Color? _blanchedAlmond;
		private static Color? _blue;
		private static Color? _blueViolet;
		private static Color? _brown;
		private static Color? _burlyWood;
		private static Color? _cadetBlue;
		private static Color? _chartreuse;
		private static Color? _chocolate;
		private static Color? _coral;
		private static Color? _cornflowerBlue;
		private static Color? _cornsilk;
		private static Color? _crimson;
		private static Color? _cyan;
		private static Color? _darkBlue;
		private static Color? _darkCyan;
		private static Color? _darkGoldenrod;
		private static Color? _darkGray;
		private static Color? _darkGreen;
		private static Color? _darkKhaki;
		private static Color? _darkMagenta;
		private static Color? _darkOliveGreen;
		private static Color? _darkOrange;
		private static Color? _darkOrchid;
		private static Color? _darkRed;
		private static Color? _darkSalmon;
		private static Color? _darkSeaGreen;
		private static Color? _darkSlateBlue;
		private static Color? _darkSlateGray;
		private static Color? _darkTurquoise;
		private static Color? _darkViolet;
		private static Color? _deepPink;
		private static Color? _deepSkyBlue;
		private static Color? _dimGray;
		private static Color? _dodgerBlue;
		private static Color? _firebrick;
		private static Color? _floralWhite;
		private static Color? _forestGreen;
		private static Color? _fuchsia;
		private static Color? _gainsboro;
		private static Color? _ghostWhite;
		private static Color? _gold;
		private static Color? _goldenrod;
		private static Color? _gray;
		private static Color? _green;
		private static Color? _greenYellow;
		private static Color? _honeydew;
		private static Color? _hotPink;
		private static Color? _indianRed;
		private static Color? _indigo;
		private static Color? _ivory;
		private static Color? _khaki;
		private static Color? _lavender;
		private static Color? _lavenderBlush;
		private static Color? _lawnGreen;
		private static Color? _lemonChiffon;
		private static Color? _lightBlue;
		private static Color? _lightCoral;
		private static Color? _lightCyan;
		private static Color? _lightGoldenrodYellow;
		private static Color? _lightGray;
		private static Color? _lightGreen;
		private static Color? _lightPink;
		private static Color? _lightSalmon;
		private static Color? _lightSeaGreen;
		private static Color? _lightSkyBlue;
		private static Color? _lightSlateGray;
		private static Color? _lightSteelBlue;
		private static Color? _lightYellow;
		private static Color? _lime;
		private static Color? _limeGreen;
		private static Color? _linen;
		private static Color? _magenta;
		private static Color? _maroon;
		private static Color? _mediumAquamarine;
		private static Color? _mediumBlue;
		private static Color? _mediumOrchid;
		private static Color? _mediumPurple;
		private static Color? _mediumSeaGreen;
		private static Color? _mediumSlateBlue;
		private static Color? _mediumSpringGreen;
		private static Color? _mediumTurquoise;
		private static Color? _mediumVioletRed;
		private static Color? _midnightBlue;
		private static Color? _mintCream;
		private static Color? _mistyRose;
		private static Color? _moccasin;
		private static Color? _navajoWhite;
		private static Color? _navy;
		private static Color? _oldLace;
		private static Color? _olive;
		private static Color? _oliveDrab;
		private static Color? _orange;
		private static Color? _orangeRed;
		private static Color? _orchid;
		private static Color? _paleGoldenrod;
		private static Color? _paleGreen;
		private static Color? _paleTurquoise;
		private static Color? _paleVioletRed;
		private static Color? _papayaWhip;
		private static Color? _peachPuff;
		private static Color? _peru;
		private static Color? _pink;
		private static Color? _plum;
		private static Color? _powderBlue;
		private static Color? _purple;
		private static Color? _red;
		private static Color? _rosyBrown;
		private static Color? _royalBlue;
		private static Color? _saddleBrown;
		private static Color? _salmon;
		private static Color? _sandyBrown;
		private static Color? _seaGreen;
		private static Color? _seaShell;
		private static Color? _sienna;
		private static Color? _silver;
		private static Color? _skyBlue;
		private static Color? _slateBlue;
		private static Color? _slateGray;
		private static Color? _snow;
		private static Color? _springGreen;
		private static Color? _steelBlue;
		private static Color? _tan;
		private static Color? _teal;
		private static Color? _thistle;
		private static Color? _tomato;
		private static Color? _turquoise;
		private static Color? _violet;
		private static Color? _wheat;
		private static Color? _white;
		private static Color? _whiteSmoke;
		private static Color? _yellow;
		private static Color? _yellowGreen;

		public static Color Transparent => _transparent ??= FromInteger(0x00FFFFFF);
		public static Color AliceBlue => _aliceBlue ??= FromInteger(unchecked((int)0xFFF0F8FF));
		public static Color AntiqueWhite => _antiqueWhite ??= FromInteger(unchecked((int)0xFFFAEBD7));
		public static Color Aqua => _aqua ??= FromInteger(unchecked((int)0xFF00FFFF));
		public static Color Aquamarine => _aquamarine ??= FromInteger(unchecked((int)0xFF7FFFD4));
		public static Color Azure => _azure ??= FromInteger(unchecked((int)0xFFF0FFFF));
		public static Color Beige => _beige ??= FromInteger(unchecked((int)0xFFF5F5DC));
		public static Color Bisque => _bisque ??= FromInteger(unchecked(unchecked((int)0xFFFFE4C4)));
		public static Color Black => _black ??= FromInteger(unchecked((int)0xFF000000));
		public static Color BlanchedAlmond => _blanchedAlmond ??= FromInteger(unchecked((int)0xFFFFEBCD));
		public static Color Blue => _blue ??= FromInteger(unchecked((int)0xFF0000FF));
		public static Color BlueViolet => _blueViolet ??= FromInteger(unchecked((int)0xFF8A2BE2));
		public static Color Brown => _brown ??= FromInteger(unchecked((int)0xFFA52A2A));
		public static Color BurlyWood => _burlyWood ??= FromInteger(unchecked((int)0xFFDEB887));
		public static Color CadetBlue => _cadetBlue ??= FromInteger(unchecked((int)0xFF5F9EA0));
		public static Color Chartreuse => _chartreuse ??= FromInteger(unchecked((int)0xFF7FFF00));
		public static Color Chocolate => _chocolate ??= FromInteger(unchecked((int)0xFFD2691E));
		public static Color Coral => _coral ??= FromInteger(unchecked((int)0xFFFF7F50));
		public static Color CornflowerBlue => _cornflowerBlue ??= FromInteger(unchecked((int)0xFF6495ED));
		public static Color Cornsilk => _cornsilk ??= FromInteger(unchecked((int)0xFFFFF8DC));
		public static Color Crimson => _crimson ??= FromInteger(unchecked((int)0xFFDC143C));
		public static Color Cyan => _cyan ??= FromInteger(unchecked((int)0xFF00FFFF));
		public static Color DarkBlue => _darkBlue ??= FromInteger(unchecked((int)0xFF00008B));
		public static Color DarkCyan => _darkCyan ??= FromInteger(unchecked((int)0xFF008B8B));
		public static Color DarkGoldenrod => _darkGoldenrod ??= FromInteger(unchecked((int)0xFFB8860B));
		public static Color DarkGray => _darkGray ??= FromInteger(unchecked((int)0xFFA9A9A9));
		public static Color DarkGreen => _darkGreen ??= FromInteger(unchecked((int)0xFF006400));
		public static Color DarkKhaki => _darkKhaki ??= FromInteger(unchecked((int)0xFFBDB76B));
		public static Color DarkMagenta => _darkMagenta ??= FromInteger(unchecked((int)0xFF8B008B));
		public static Color DarkOliveGreen => _darkOliveGreen ??= FromInteger(unchecked((int)0xFF556B2F));
		public static Color DarkOrange => _darkOrange ??= FromInteger(unchecked((int)0xFFFF8C00));
		public static Color DarkOrchid => _darkOrchid ??= FromInteger(unchecked((int)0xFF9932CC));
		public static Color DarkRed => _darkRed ??= FromInteger(unchecked((int)0xFF8B0000));
		public static Color DarkSalmon => _darkSalmon ??= FromInteger(unchecked((int)0xFFE9967A));
		public static Color DarkSeaGreen => _darkSeaGreen ??= FromInteger(unchecked((int)0xFF8FBC8B));
		public static Color DarkSlateBlue => _darkSlateBlue ??= FromInteger(unchecked((int)0xFF483D8B));
		public static Color DarkSlateGray => _darkSlateGray ??= FromInteger(unchecked((int)0xFF2F4F4F));
		public static Color DarkTurquoise => _darkTurquoise ??= FromInteger(unchecked((int)0xFF00CED1));
		public static Color DarkViolet => _darkViolet ??= FromInteger(unchecked((int)0xFF9400D3));
		public static Color DeepPink => _deepPink ??= FromInteger(unchecked((int)0xFFFF1493));
		public static Color DeepSkyBlue => _deepSkyBlue ??= FromInteger(unchecked((int)0xFF00BFFF));
		public static Color DimGray => _dimGray ??= FromInteger(unchecked((int)0xFF696969));
		public static Color DodgerBlue => _dodgerBlue ??= FromInteger(unchecked((int)0xFF1E90FF));
		public static Color Firebrick => _firebrick ??= FromInteger(unchecked((int)0xFFB22222));
		public static Color FloralWhite => _floralWhite ??= FromInteger(unchecked((int)0xFFFFFAF0));
		public static Color ForestGreen => _forestGreen ??= FromInteger(unchecked((int)0xFF228B22));
		public static Color Fuchsia => _fuchsia ??= FromInteger(unchecked((int)0xFFFF00FF));
		public static Color Gainsboro => _gainsboro ??= FromInteger(unchecked((int)0xFFDCDCDC));
		public static Color GhostWhite => _ghostWhite ??= FromInteger(unchecked((int)0xFFF8F8FF));
		public static Color Gold => _gold ??= FromInteger(unchecked((int)0xFFFFD700));
		public static Color Goldenrod => _goldenrod ??= FromInteger(unchecked((int)0xFFDAA520));
		public static Color Gray => _gray ??= FromInteger(unchecked((int)0xFF808080));
		public static Color Green => _green ??= FromInteger(unchecked((int)0xFF008000));
		public static Color GreenYellow => _greenYellow ??= FromInteger(unchecked((int)0xFFADFF2F));
		public static Color Honeydew => _honeydew ??= FromInteger(unchecked((int)0xFFF0FFF0));
		public static Color HotPink => _hotPink ??= FromInteger(unchecked((int)0xFFFF69B4));
		public static Color IndianRed => _indianRed ??= FromInteger(unchecked((int)0xFFCD5C5C));
		public static Color Indigo => _indigo ??= FromInteger(unchecked((int)0xFF4B0082));
		public static Color Ivory => _ivory ??= FromInteger(unchecked((int)0xFFFFFFF0));
		public static Color Khaki => _khaki ??= FromInteger(unchecked((int)0xFFF0E68C));
		public static Color Lavender => _lavender ??= FromInteger(unchecked((int)0xFFE6E6FA));
		public static Color LavenderBlush => _lavenderBlush ??= FromInteger(unchecked((int)0xFFFFF0F5));
		public static Color LawnGreen => _lawnGreen ??= FromInteger(unchecked((int)0xFF7CFC00));
		public static Color LemonChiffon => _lemonChiffon ??= FromInteger(unchecked((int)0xFFFFFACD));
		public static Color LightBlue => _lightBlue ??= FromInteger(unchecked((int)0xFFADD8E6));
		public static Color LightCoral => _lightCoral ??= FromInteger(unchecked((int)0xFFF08080));
		public static Color LightCyan => _lightCyan ??= FromInteger(unchecked((int)0xFFE0FFFF));
		public static Color LightGoldenrodYellow => _lightGoldenrodYellow ??= FromInteger(unchecked((int)0xFFFAFAD2));
		public static Color LightGray => _lightGray ??= FromInteger(unchecked((int)0xFFD3D3D3));
		public static Color LightGreen => _lightGreen ??= FromInteger(unchecked((int)0xFF90EE90));
		public static Color LightPink => _lightPink ??= FromInteger(unchecked((int)0xFFFFB6C1));
		public static Color LightSalmon => _lightSalmon ??= FromInteger(unchecked((int)0xFFFFA07A));
		public static Color LightSeaGreen => _lightSeaGreen ??= FromInteger(unchecked((int)0xFF20B2AA));
		public static Color LightSkyBlue => _lightSkyBlue ??= FromInteger(unchecked((int)0xFF87CEFA));
		public static Color LightSlateGray => _lightSlateGray ??= FromInteger(unchecked((int)0xFF778899));
		public static Color LightSteelBlue => _lightSteelBlue ??= FromInteger(unchecked((int)0xFFB0C4DE));
		public static Color LightYellow => _lightYellow ??= FromInteger(unchecked((int)0xFFFFFFE0));
		public static Color Lime => _lime ??= FromInteger(unchecked((int)0xFF00FF00));
		public static Color LimeGreen => _limeGreen ??= FromInteger(unchecked((int)0xFF32CD32));
		public static Color Linen => _linen ??= FromInteger(unchecked((int)0xFFFAF0E6));
		public static Color Magenta => _magenta ??= FromInteger(unchecked((int)0xFFFF00FF));
		public static Color Maroon => _maroon ??= FromInteger(unchecked((int)0xFF800000));
		public static Color MediumAquamarine => _mediumAquamarine ??= FromInteger(unchecked((int)0xFF66CDAA));
		public static Color MediumBlue => _mediumBlue ??= FromInteger(unchecked((int)0xFF0000CD));
		public static Color MediumOrchid => _mediumOrchid ??= FromInteger(unchecked((int)0xFFBA55D3));
		public static Color MediumPurple => _mediumPurple ??= FromInteger(unchecked((int)0xFF9370DB));
		public static Color MediumSeaGreen => _mediumSeaGreen ??= FromInteger(unchecked((int)0xFF3CB371));
		public static Color MediumSlateBlue => _mediumSlateBlue ??= FromInteger(unchecked((int)0xFF7B68EE));
		public static Color MediumSpringGreen => _mediumSpringGreen ??= FromInteger(unchecked((int)0xFF00FA9A));
		public static Color MediumTurquoise => _mediumTurquoise ??= FromInteger(unchecked((int)0xFF48D1CC));
		public static Color MediumVioletRed => _mediumVioletRed ??= FromInteger(unchecked((int)0xFFC71585));
		public static Color MidnightBlue => _midnightBlue ??= FromInteger(unchecked((int)0xFF191970));
		public static Color MintCream => _mintCream ??= FromInteger(unchecked((int)0xFFF5FFFA));
		public static Color MistyRose => _mistyRose ??= FromInteger(unchecked((int)0xFFFFE4E1));
		public static Color Moccasin => _moccasin ??= FromInteger(unchecked((int)0xFFFFE4B5));
		public static Color NavajoWhite => _navajoWhite ??= FromInteger(unchecked((int)0xFFFFDEAD));
		public static Color Navy => _navy ??= FromInteger(unchecked((int)0xFF000080));
		public static Color OldLace => _oldLace ??= FromInteger(unchecked((int)0xFFFDF5E6));
		public static Color Olive => _olive ??= FromInteger(unchecked((int)0xFF808000));
		public static Color OliveDrab => _oliveDrab ??= FromInteger(unchecked((int)0xFF6B8E23));
		public static Color Orange => _orange ??= FromInteger(unchecked((int)0xFFFFA500));
		public static Color OrangeRed => _orangeRed ??= FromInteger(unchecked((int)0xFFFF4500));
		public static Color Orchid => _orchid ??= FromInteger(unchecked((int)0xFFDA70D6));
		public static Color PaleGoldenrod => _paleGoldenrod ??= FromInteger(unchecked((int)0xFFEEE8AA));
		public static Color PaleGreen => _paleGreen ??= FromInteger(unchecked((int)0xFF98FB98));
		public static Color PaleTurquoise => _paleTurquoise ??= FromInteger(unchecked((int)0xFFAFEEEE));
		public static Color PaleVioletRed => _paleVioletRed ??= FromInteger(unchecked((int)0xFFDB7093));
		public static Color PapayaWhip => _papayaWhip ??= FromInteger(unchecked((int)0xFFFFEFD5));
		public static Color PeachPuff => _peachPuff ??= FromInteger(unchecked((int)0xFFFFDAB9));
		public static Color Peru => _peru ??= FromInteger(unchecked((int)0xFFCD853F));
		public static Color Pink => _pink ??= FromInteger(unchecked((int)0xFFFFC0CB));
		public static Color Plum => _plum ??= FromInteger(unchecked((int)0xFFDDA0DD));
		public static Color PowderBlue => _powderBlue ??= FromInteger(unchecked((int)0xFFB0E0E6));
		public static Color Purple => _purple ??= FromInteger(unchecked((int)0xFF800080));
		public static Color Red => _red ??= FromInteger(unchecked((int)0xFFFF0000));
		public static Color RosyBrown => _rosyBrown ??= FromInteger(unchecked((int)0xFFBC8F8F));
		public static Color RoyalBlue => _royalBlue ??= FromInteger(unchecked((int)0xFF4169E1));
		public static Color SaddleBrown => _saddleBrown ??= FromInteger(unchecked((int)0xFF8B4513));
		public static Color Salmon => _salmon ??= FromInteger(unchecked((int)0xFFFA8072));
		public static Color SandyBrown => _sandyBrown ??= FromInteger(unchecked((int)0xFFF4A460));
		public static Color SeaGreen => _seaGreen ??= FromInteger(unchecked((int)0xFF2E8B57));
		public static Color SeaShell => _seaShell ??= FromInteger(unchecked((int)0xFFFFF5EE));
		public static Color Sienna => _sienna ??= FromInteger(unchecked((int)0xFFA0522D));
		public static Color Silver => _silver ??= FromInteger(unchecked((int)0xFFC0C0C0));
		public static Color SkyBlue => _skyBlue ??= FromInteger(unchecked((int)0xFF87CEEB));
		public static Color SlateBlue => _slateBlue ??= FromInteger(unchecked((int)0xFF6A5ACD));
		public static Color SlateGray => _slateGray ??= FromInteger(unchecked((int)0xFF708090));
		public static Color Snow => _snow ??= FromInteger(unchecked((int)0xFFFFFAFA));
		public static Color SpringGreen => _springGreen ??= FromInteger(unchecked((int)0xFF00FF7F));
		public static Color SteelBlue => _steelBlue ??= FromInteger(unchecked((int)0xFF4682B4));
		public static Color Tan => _tan ??= FromInteger(unchecked((int)0xFFD2B48C));
		public static Color Teal => _teal ??= FromInteger(unchecked((int)0xFF008080));
		public static Color Thistle => _thistle ??= FromInteger(unchecked((int)0xFFD8BFD8));
		public static Color Tomato => _tomato ??= FromInteger(unchecked((int)0xFFFF6347));
		public static Color Turquoise => _turquoise ??= FromInteger(unchecked((int)0xFF40E0D0));
		public static Color Violet => _violet ??= FromInteger(unchecked((int)0xFFEE82EE));
		public static Color Wheat => _wheat ??= FromInteger(unchecked((int)0xFFF5DEB3));
		public static Color White => _white ??= FromInteger(unchecked((int)0xFFFFFFFF));
		public static Color WhiteSmoke => _whiteSmoke ??= FromInteger(unchecked((int)0xFFF5F5F5));
		public static Color Yellow => _yellow ??= FromInteger(unchecked((int)0xFFFFFF00));
		public static Color YellowGreen => _yellowGreen ??= FromInteger(unchecked((int)0xFF9ACD32));
	}
}
