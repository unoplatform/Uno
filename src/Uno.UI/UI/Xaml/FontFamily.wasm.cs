#if __WASM__
#nullable enable

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno;

namespace Windows.UI.Xaml.Media
{
	public partial class FontFamily
	{
		private FontLoader _loader;

		partial void Init(string fontName) => _loader = FontLoader.GetLoaderForFontFamily(this);

		/// <summary>
		/// Contains the font-face name to use in CSS.
		/// </summary>
		internal string CssFontName => _loader.CssFontName;

		/// <summary>
		/// Use this to launch the loading of a font before it is actually required to
		/// minimize loading time and prevent potential flicking.
		/// </summary>
		public static void Preload(FontFamily family) => family._loader.LaunchLoading();

		/// <summary>
		/// Use this to launch the loading of a font before it is actually required to
		/// minimize loading time and prevent potential flicking.
		/// </summary>
		public static void Preload(string familyName) => Preload(new FontFamily(familyName));

		private string ParseFontFamilySource(string familyName)
		{
			const string ForwardSlash = "/";
			const string Hash = "#";
			const string Dot = ".";
			if (string.IsNullOrEmpty(familyName))
			{
				throw new ArgumentException("Font family name must not be empty string nor null", nameof(familyName));
			}

			//check if family name is a pure name or a path
			if (familyName.Contains(ForwardSlash) || familyName.Contains(Hash))
			{
				//we have a path to font family name, parse just the name itself
				//there are two possible formats:
				//1) "some/path/to/font/MyNiceFont.ttf#My Nice Font" (actually works even with pure "MyNiceFont.ttf#My Font")
				//   -> we extract the part after #

				var hashFontNameStart = familyName.LastIndexOf(Hash);
				if (hashFontNameStart != -1)
				{
					return familyName.Substring(hashFontNameStart + 1);
				}

				//or 
				//2) "some/path/to/font/MyNiceFont.ttf"
				//   -> we fall back to the font file name

				var slashFontNameStart = familyName.LastIndexOf(ForwardSlash) + 1; //works even if slash is not present at all -> 0				
				var extensionStart = familyName.LastIndexOf(Dot);
				if (extensionStart < slashFontNameStart) //no dot after slash
				{
					extensionStart = familyName.Length;
				}
				return familyName.Substring(slashFontNameStart, extensionStart - slashFontNameStart);
			}
			return familyName;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void RegisterForInvalidateMeasureOnFontLoaded(UIElement uiElement)
		{
			_loader.RegisterRemeasureOnFontLoaded(uiElement);
		}

		/// <summary>
		/// Callback from javascript when the font is loaded in the browser.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Preserve]
		public static void NotifyFontLoaded(string cssFontName) => FontLoader.NotifyFontLoaded(cssFontName);
	}
}
#endif
