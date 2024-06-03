﻿// <autogenerated />
#pragma warning disable CS0114
#pragma warning disable CS0108
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.UI;
using Uno.UI.Xaml;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Shapes;
using Windows.UI.Text;
using Uno.Extensions;
using Uno;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using MyProject;

#if __ANDROID__
using _View = Android.Views.View;
#elif __IOS__
using _View = UIKit.UIView;
#elif __MACOS__
using _View = AppKit.NSView;
#else
using _View = Microsoft.UI.Xaml.UIElement;
#endif

namespace TestNamespace
{
	[global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdate]
	public sealed partial class TestClass : global::Microsoft.UI.Xaml.ResourceDictionary
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_MyDictionary_b7707bcf1e73425b710b6a5d04177088 = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_MyDictionary_b7707bcf1e73425b710b6a5d04177088 = "ms-appx:///TestProject/";
		public void InitializeComponent()
		{
			global::Uno.UI.Helpers.MarkupHelper.SetElementProperty(this, "OriginalSourceLocation", "file:///C:/Project/0/MyDictionary.xaml#L1:2");
		}

	}
}
namespace MyProject
{
	public sealed partial class GlobalStaticResources
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_MyDictionary_b7707bcf1e73425b710b6a5d04177088 = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_MyDictionary_b7707bcf1e73425b710b6a5d04177088 = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		internal string __MyDictionary_b7707bcf1e73425b710b6a5d04177088_checksum() => "0006bfa967d7b0e0bdb0aa951326268f007434d5";
		// This non-static inner class is a means of reducing size of AOT compilations by avoiding many accesses to static members from a static callsite, which adds costly class initializer checks each time.
		[global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdate]
		internal sealed class ResourceDictionarySingleton__MyDictionary_b7707bcf1e73425b710b6a5d04177088 : global::Uno.UI.IXamlResourceDictionaryProvider
		{
			private static global::Microsoft.UI.Xaml.Markup.INameScope __nameScope = new global::Microsoft.UI.Xaml.NameScope();
			private static global::Uno.UI.IXamlResourceDictionaryProvider __that;
			internal static global::Uno.UI.IXamlResourceDictionaryProvider Instance
			{
				get
				{
					if (__that == null)
					{
						__that = (global::Uno.UI.IXamlResourceDictionaryProvider)global::Uno.UI.Helpers.TypeMappings.CreateInstance<ResourceDictionarySingleton__MyDictionary_b7707bcf1e73425b710b6a5d04177088>();
					}

					return __that;
				}
			}

			private readonly global::Uno.UI.Xaml.XamlParseContext __ParseContext_;
			internal static global::Uno.UI.Xaml.XamlParseContext GetParseContext() => ((ResourceDictionarySingleton__MyDictionary_b7707bcf1e73425b710b6a5d04177088)Instance).__ParseContext_;

			public ResourceDictionarySingleton__MyDictionary_b7707bcf1e73425b710b6a5d04177088()
			{
				__ParseContext_ = global::MyProject.GlobalStaticResources.__ParseContext_;
			}

			private global::Microsoft.UI.Xaml.ResourceDictionary _MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary;

			internal global::Microsoft.UI.Xaml.ResourceDictionary MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary
			{
				get
				{
					if (_MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary == null)
					{
						_MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary = 
						new global::Microsoft.UI.Xaml.ResourceDictionary
						{
							IsParsing = true,
						}
						;
						_MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary.Source = new global::System.Uri("ms-resource:///Files/C:/Project/0/MyDictionary.xaml");
						_MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary.CreationComplete();
					}
					return _MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary;
				}
			}

			global::Microsoft.UI.Xaml.ResourceDictionary global::Uno.UI.IXamlResourceDictionaryProvider.GetResourceDictionary() => MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary;
		}

		internal static global::Microsoft.UI.Xaml.ResourceDictionary MyDictionary_b7707bcf1e73425b710b6a5d04177088_ResourceDictionary => ResourceDictionarySingleton__MyDictionary_b7707bcf1e73425b710b6a5d04177088.Instance.GetResourceDictionary();
	}
}
namespace MyProject.__Resources
{
}
