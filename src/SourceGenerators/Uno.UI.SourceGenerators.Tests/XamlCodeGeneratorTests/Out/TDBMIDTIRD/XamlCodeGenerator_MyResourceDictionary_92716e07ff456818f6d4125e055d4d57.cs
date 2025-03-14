﻿// <autogenerated />
#pragma warning disable CS0114
#pragma warning disable CS0108
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.UI;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
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
using _View = Windows.UI.Xaml.UIElement;
#endif

namespace TestRepro
{
	public sealed partial class MyResourceDictionary : global::Windows.UI.Xaml.ResourceDictionary
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
		public void InitializeComponent()
		{
			this[
			"myTemplate"
			] = 
			new global::Uno.UI.Xaml.WeakResourceInitializer(this, __ResourceOwner_1 => 
			{
				return 
					new global::Windows.UI.Xaml.DataTemplate(__ResourceOwner_1, (__owner) => 					new __MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_TestReproMyResourceDictionary.SC0().Build(__owner)
					)				;
			}
			)
			;
		}

		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		[global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdate]
		private class __MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_TestReproMyResourceDictionary
		{
			[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
			[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2026")]
			[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2111")]
			public class SC0
			{
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
				private const string __baseUri_prefix_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
				private const string __baseUri_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
				global::Windows.UI.Xaml.NameScope __nameScope = new global::Windows.UI.Xaml.NameScope();
				global::System.Object __ResourceOwner_1;
				_View __rootInstance = null;
				public _View Build(object __ResourceOwner_1)
				{
					var __that = this;
					this.__ResourceOwner_1 = __ResourceOwner_1;
					this.__rootInstance = 
					new global::Windows.UI.Xaml.Controls.TextBlock
					{
						IsParsing = true,
						Name = "tb",
						// Source 0\MyResourceDictionary.xaml (Line 12:5)
					}
					.MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_XamlApply((MyResourceDictionary_92716e07ff456818f6d4125e055d4d57XamlApplyExtensions.XamlApplyHandler0)(__p1 => 
					{
					/* _isTopLevelDictionary:True */
					__that._component_0 = __p1;
					__nameScope.RegisterName("tb", __p1);
					__that.tb = __p1;
					__p1.SetBinding(
						global::Windows.UI.Xaml.Controls.TextBlock.TextProperty,
						new Windows.UI.Xaml.Data.Binding()
						{
							Mode = BindingMode.OneWay,
						}
							.BindingApply(___b => /*defaultBindModeOneWay*/ global::Uno.UI.Xaml.BindingHelper.SetBindingXBindProvider(___b, null, ___ctx => ___ctx is global::TestRepro.MyModel ___tctx ? (TryGetInstance_xBind_1(___tctx, out var bindResult1) ? (true, bindResult1) : (false, default)) : (false, default), null , new [] {"MyString"}))
					);
					global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57);
					__p1.CreationComplete();
					}
					))
					;
					if (__rootInstance is FrameworkElement __fe)
					{
						__fe.Loading += __UpdateBindingsAndResources;
					}
					if (__rootInstance is DependencyObject d)
					{
						if (global::Windows.UI.Xaml.NameScope.GetNameScope(d) == null)
						{
							global::Windows.UI.Xaml.NameScope.SetNameScope(d, __nameScope);
							__nameScope.Owner = d;
						}
						global::Uno.UI.FrameworkElementHelper.AddObjectReference(d, this);
					}
					return __rootInstance;
				}
				private global::Windows.UI.Xaml.Markup.ComponentHolder _component_0_Holder = new global::Windows.UI.Xaml.Markup.ComponentHolder(isWeak: true);
				private global::Windows.UI.Xaml.Controls.TextBlock _component_0
				{
					get
					{
						return (global::Windows.UI.Xaml.Controls.TextBlock)_component_0_Holder.Instance;
					}
					set
					{
						_component_0_Holder.Instance = value;
					}
				}
				private global::Windows.UI.Xaml.Data.ElementNameSubject _tbSubject = new global::Windows.UI.Xaml.Data.ElementNameSubject();
				private global::Windows.UI.Xaml.Controls.TextBlock tb
				{
					get
					{
						return (global::Windows.UI.Xaml.Controls.TextBlock)_tbSubject.ElementInstance;
					}
					set
					{
						_tbSubject.ElementInstance = value;
					}
				}
				private void __UpdateBindingsAndResources(global::Windows.UI.Xaml.FrameworkElement s, object e)
				{
					var owner = this;
					_component_0.UpdateResourceBindings();
					_component_0.ApplyXBind();
				}
				private static bool TryGetInstance_xBind_1(global::TestRepro.MyModel ___tctx, out object o)
				{
					o = null;
					o = ___tctx.MyString;
					return true;
				}
			}
		}
	}
}
namespace MyProject
{
	[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2026")]
	[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2111")]
	public sealed partial class GlobalStaticResources
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
		// This non-static inner class is a means of reducing size of AOT compilations by avoiding many accesses to static members from a static callsite, which adds costly class initializer checks each time.
		internal sealed class ResourceDictionarySingleton__MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 : global::Uno.UI.IXamlResourceDictionaryProvider
		{
			private static global::Windows.UI.Xaml.NameScope __nameScope = new global::Windows.UI.Xaml.NameScope();
			private static global::Uno.UI.IXamlResourceDictionaryProvider __that;
			internal static global::Uno.UI.IXamlResourceDictionaryProvider Instance
			{
				get
				{
					if (__that == null)
					{
						__that = new ResourceDictionarySingleton__MyResourceDictionary_92716e07ff456818f6d4125e055d4d57();
					}

					return __that;
				}
			}

			private readonly global::Uno.UI.Xaml.XamlParseContext __ParseContext_;
			internal static global::Uno.UI.Xaml.XamlParseContext GetParseContext() => ((ResourceDictionarySingleton__MyResourceDictionary_92716e07ff456818f6d4125e055d4d57)Instance).__ParseContext_;

			public ResourceDictionarySingleton__MyResourceDictionary_92716e07ff456818f6d4125e055d4d57()
			{
				__ParseContext_ = global::MyProject.GlobalStaticResources.__ParseContext_;
			}

			// Method for resource myTemplate 
			[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2026")]
			[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2111")]
			private object Get_1(object __ResourceOwner_1) =>
				new global::Windows.UI.Xaml.DataTemplate(__ResourceOwner_1, (__owner) => 				new __Resources.__MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_MyResourceDictionaryRD.SC1().Build(__owner)
				)				;

			private global::Windows.UI.Xaml.ResourceDictionary _MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_ResourceDictionary;

			internal global::Windows.UI.Xaml.ResourceDictionary MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_ResourceDictionary
			{
				get
				{
					if (_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_ResourceDictionary == null)
					{
						_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_ResourceDictionary = 
						new global::Windows.UI.Xaml.ResourceDictionary
						{
							IsParsing = true,
							[
							"myTemplate"
							] = 
							new global::Uno.UI.Xaml.WeakResourceInitializer(this, __ResourceOwner_1 => 
							{
								return 
									new global::Windows.UI.Xaml.DataTemplate(__ResourceOwner_1, (__owner) => 									new __Resources.__MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_MyResourceDictionaryRD.SC2().Build(__owner)
									)								;
							}
							)
							,
						}
						;
						_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_ResourceDictionary.Source = new global::System.Uri("ms-resource:///Files/C:/Project/0/MyResourceDictionary.xaml");
						_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_ResourceDictionary.CreationComplete();
					}
					return _MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_ResourceDictionary;
				}
			}

			global::Windows.UI.Xaml.ResourceDictionary global::Uno.UI.IXamlResourceDictionaryProvider.GetResourceDictionary() => MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_ResourceDictionary;
		}

		internal static global::Windows.UI.Xaml.ResourceDictionary MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_ResourceDictionary => ResourceDictionarySingleton__MyResourceDictionary_92716e07ff456818f6d4125e055d4d57.Instance.GetResourceDictionary();
	}
}
namespace MyProject.__Resources
{
	[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
	[global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdate]
	internal class __MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_MyResourceDictionaryRD
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2026")]
		[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2111")]
		public class SC1
		{
			[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
			private const string __baseUri_prefix_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
			[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
			private const string __baseUri_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
			global::Windows.UI.Xaml.NameScope __nameScope = new global::Windows.UI.Xaml.NameScope();
			global::System.Object __ResourceOwner_1;
			_View __rootInstance = null;
			public _View Build(object __ResourceOwner_1)
			{
				var __that = this;
				this.__ResourceOwner_1 = __ResourceOwner_1;
				this.__rootInstance = 
				new global::Windows.UI.Xaml.Controls.TextBlock
				{
					IsParsing = true,
					Name = "tb",
					// Source 0\MyResourceDictionary.xaml (Line 12:5)
				}
				.MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_XamlApply((MyResourceDictionary_92716e07ff456818f6d4125e055d4d57XamlApplyExtensions.XamlApplyHandler0)(__p1 => 
				{
				/* _isTopLevelDictionary:True */
				__that._component_0 = __p1;
				__nameScope.RegisterName("tb", __p1);
				__that.tb = __p1;
				__p1.SetBinding(
					global::Windows.UI.Xaml.Controls.TextBlock.TextProperty,
					new Windows.UI.Xaml.Data.Binding()
					{
						Mode = BindingMode.OneWay,
					}
						.BindingApply(___b => /*defaultBindModeOneWay*/ global::Uno.UI.Xaml.BindingHelper.SetBindingXBindProvider(___b, null, ___ctx => ___ctx is global::TestRepro.MyModel ___tctx ? (TryGetInstance_xBind_2(___tctx, out var bindResult2) ? (true, bindResult2) : (false, default)) : (false, default), null , new [] {"MyString"}))
				);
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57);
				__p1.CreationComplete();
				}
				))
				;
				if (__rootInstance is FrameworkElement __fe)
				{
					__fe.Loading += __UpdateBindingsAndResources;
				}
				if (__rootInstance is DependencyObject d)
				{
					if (global::Windows.UI.Xaml.NameScope.GetNameScope(d) == null)
					{
						global::Windows.UI.Xaml.NameScope.SetNameScope(d, __nameScope);
						__nameScope.Owner = d;
					}
					global::Uno.UI.FrameworkElementHelper.AddObjectReference(d, this);
				}
				return __rootInstance;
			}
			private global::Windows.UI.Xaml.Markup.ComponentHolder _component_0_Holder = new global::Windows.UI.Xaml.Markup.ComponentHolder(isWeak: true);
			private global::Windows.UI.Xaml.Controls.TextBlock _component_0
			{
				get
				{
					return (global::Windows.UI.Xaml.Controls.TextBlock)_component_0_Holder.Instance;
				}
				set
				{
					_component_0_Holder.Instance = value;
				}
			}
			private global::Windows.UI.Xaml.Data.ElementNameSubject _tbSubject = new global::Windows.UI.Xaml.Data.ElementNameSubject();
			private global::Windows.UI.Xaml.Controls.TextBlock tb
			{
				get
				{
					return (global::Windows.UI.Xaml.Controls.TextBlock)_tbSubject.ElementInstance;
				}
				set
				{
					_tbSubject.ElementInstance = value;
				}
			}
			private void __UpdateBindingsAndResources(global::Windows.UI.Xaml.FrameworkElement s, object e)
			{
				var owner = this;
				_component_0.UpdateResourceBindings();
				_component_0.ApplyXBind();
			}
			private static bool TryGetInstance_xBind_2(global::TestRepro.MyModel ___tctx, out object o)
			{
				o = null;
				o = ___tctx.MyString;
				return true;
			}
		}
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2026")]
		[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2111")]
		public class SC2
		{
			[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
			private const string __baseUri_prefix_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
			[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
			private const string __baseUri_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57 = "ms-appx:///TestProject/";
			global::Windows.UI.Xaml.NameScope __nameScope = new global::Windows.UI.Xaml.NameScope();
			global::System.Object __ResourceOwner_1;
			_View __rootInstance = null;
			public _View Build(object __ResourceOwner_1)
			{
				var __that = this;
				this.__ResourceOwner_1 = __ResourceOwner_1;
				this.__rootInstance = 
				new global::Windows.UI.Xaml.Controls.TextBlock
				{
					IsParsing = true,
					Name = "tb",
					// Source 0\MyResourceDictionary.xaml (Line 12:5)
				}
				.MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_XamlApply((MyResourceDictionary_92716e07ff456818f6d4125e055d4d57XamlApplyExtensions.XamlApplyHandler0)(__p1 => 
				{
				/* _isTopLevelDictionary:True */
				__that._component_0 = __p1;
				__nameScope.RegisterName("tb", __p1);
				__that.tb = __p1;
				__p1.SetBinding(
					global::Windows.UI.Xaml.Controls.TextBlock.TextProperty,
					new Windows.UI.Xaml.Data.Binding()
					{
						Mode = BindingMode.OneWay,
					}
						.BindingApply(___b => /*defaultBindModeOneWay*/ global::Uno.UI.Xaml.BindingHelper.SetBindingXBindProvider(___b, null, ___ctx => ___ctx is global::TestRepro.MyModel ___tctx ? (TryGetInstance_xBind_3(___tctx, out var bindResult3) ? (true, bindResult3) : (false, default)) : (false, default), null , new [] {"MyString"}))
				);
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MyResourceDictionary_92716e07ff456818f6d4125e055d4d57);
				__p1.CreationComplete();
				}
				))
				;
				if (__rootInstance is FrameworkElement __fe)
				{
					__fe.Loading += __UpdateBindingsAndResources;
				}
				if (__rootInstance is DependencyObject d)
				{
					if (global::Windows.UI.Xaml.NameScope.GetNameScope(d) == null)
					{
						global::Windows.UI.Xaml.NameScope.SetNameScope(d, __nameScope);
						__nameScope.Owner = d;
					}
					global::Uno.UI.FrameworkElementHelper.AddObjectReference(d, this);
				}
				return __rootInstance;
			}
			private global::Windows.UI.Xaml.Markup.ComponentHolder _component_0_Holder = new global::Windows.UI.Xaml.Markup.ComponentHolder(isWeak: true);
			private global::Windows.UI.Xaml.Controls.TextBlock _component_0
			{
				get
				{
					return (global::Windows.UI.Xaml.Controls.TextBlock)_component_0_Holder.Instance;
				}
				set
				{
					_component_0_Holder.Instance = value;
				}
			}
			private global::Windows.UI.Xaml.Data.ElementNameSubject _tbSubject = new global::Windows.UI.Xaml.Data.ElementNameSubject();
			private global::Windows.UI.Xaml.Controls.TextBlock tb
			{
				get
				{
					return (global::Windows.UI.Xaml.Controls.TextBlock)_tbSubject.ElementInstance;
				}
				set
				{
					_tbSubject.ElementInstance = value;
				}
			}
			private void __UpdateBindingsAndResources(global::Windows.UI.Xaml.FrameworkElement s, object e)
			{
				var owner = this;
				_component_0.UpdateResourceBindings();
				_component_0.ApplyXBind();
			}
			private static bool TryGetInstance_xBind_3(global::TestRepro.MyModel ___tctx, out object o)
			{
				o = null;
				o = ___tctx.MyString;
				return true;
			}
		}
	}
}
namespace MyProject
{
	static class MyResourceDictionary_92716e07ff456818f6d4125e055d4d57XamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Windows.UI.Xaml.Controls.TextBlock instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.TextBlock MyResourceDictionary_92716e07ff456818f6d4125e055d4d57_XamlApply(this global::Windows.UI.Xaml.Controls.TextBlock instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
