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

namespace Uno.UI.Tests.Given_ResourceDictionary
{
	partial class When_Nested_With_Sibling_Ref_And_Event : global::Windows.UI.Xaml.Controls.Page
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20 = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20 = "ms-appx:///TestProject/";
		private global::Windows.UI.Xaml.NameScope __nameScope = new global::Windows.UI.Xaml.NameScope();
		private void InitializeComponent()
		{
			NameScope.SetNameScope(this, __nameScope);
			var __that = this;
			base.IsParsing = true;
			Resources[
			"RootResource"
			] = 
			new global::Uno.UI.Xaml.WeakResourceInitializer(this, __ResourceOwner_1 => 
			{
				return 
					new global::Windows.UI.Xaml.DataTemplate(__ResourceOwner_1, (__owner) => 					new __ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_UnoUITestsGiven_ResourceDictionaryWhen_Nested_With_Sibling_Ref_And_Event.SC0().Build(__owner)
					)				;
			}
			)
			;
			// Source 0\ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event.xaml (Line 1:2)
			;
			
			this
			.ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_XamlApply((ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20XamlApplyExtensions.XamlApplyHandler0)(__p1 => 
			{
			// Source 0\ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event.xaml (Line 1:2)
			
			// WARNING Property __p1.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Page, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_XamlApply((ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20XamlApplyExtensions.XamlApplyHandler0)(__p1 => 
			{
			// Class Uno.UI.Tests.Given_ResourceDictionary.When_Nested_With_Sibling_Ref_And_Event
			global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20);
			__p1.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();

		}
		partial void OnInitializeCompleted();
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		[global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdate]
		private class __ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_UnoUITestsGiven_ResourceDictionaryWhen_Nested_With_Sibling_Ref_And_Event
		{
			[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
			[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2026")]
			[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2111")]
			public class SC0
			{
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
				private const string __baseUri_prefix_ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20 = "ms-appx:///TestProject/";
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
				private const string __baseUri_ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20 = "ms-appx:///TestProject/";
				global::Windows.UI.Xaml.NameScope __nameScope = new global::Windows.UI.Xaml.NameScope();
				global::System.Object __ResourceOwner_1;
				_View __rootInstance = null;
				public _View Build(object __ResourceOwner_1)
				{
					var __that = this;
					this.__ResourceOwner_1 = __ResourceOwner_1;
					this.__rootInstance = 
					new global::Windows.UI.Xaml.Controls.Border
					{
						IsParsing = true,
						Resources = {
						[
						"SiblingResource"
						] = 
						new global::Windows.UI.Xaml.Controls.FontIconSource
						{
							// Source 0\ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event.xaml (Line 14:7)
						}
						,
						[
						"FailingResource"
						] = 
						new global::Uno.UI.Xaml.WeakResourceInitializer(__ResourceOwner_1, __ResourceOwner_2 => 
						{
							return 
								new global::Windows.UI.Xaml.Controls.SwipeItems
								{
									// Source 0\ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event.xaml (Line 15:7)
								}
								.ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_XamlApply((ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20XamlApplyExtensions.XamlApplyHandler1)(__p1 => 
								{
								__p1.Add(
									new global::Windows.UI.Xaml.Controls.SwipeItem
									{
										// Source 0\ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event.xaml (Line 16:8)
									}
									.ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_XamlApply((ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20XamlApplyExtensions.XamlApplyHandler2)(__p1 => 
									{
									/* _isTopLevelDictionary:False */
									__that._component_0 = __p1;
									global::Windows.UI.Xaml.NameScope.SetNameScope(__that._component_0, __nameScope);
									global::Uno.UI.ResourceResolverSingleton.Instance.ApplyResource(__p1, global::Windows.UI.Xaml.Controls.SwipeItem.IconSourceProperty, "SiblingResource", isThemeResourceExtension: false, isHotReloadSupported: false, context: global::MyProject.GlobalStaticResources.__ParseContext_);
									var Invoked_Handler = new __ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_MyProject__ResourcesSC0_UnoUITestsGiven_ResourceDictionaryWhen_Nested_With_Sibling_Ref_And_Event.ApplyMethod_3_Invoked_Handler((__ResourceOwner_2 as global::Uno.UI.DataBinding.IWeakReferenceProvider).WeakReference);
									/* second level */ __p1.Invoked += Invoked_Handler.Invoke;
									}
									))
								);
								}
								))
							;
						}
						)
						,
						},
						// Source 0\ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event.xaml (Line 12:5)
					}
					.ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_XamlApply((ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20XamlApplyExtensions.XamlApplyHandler3)(__p1 => 
					{
					/* _isTopLevelDictionary:False */
					__that._component_1 = __p1;
					global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20);
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
				private global::Windows.UI.Xaml.Controls.SwipeItem _component_0
				{
					get
					{
						return (global::Windows.UI.Xaml.Controls.SwipeItem)_component_0_Holder.Instance;
					}
					set
					{
						_component_0_Holder.Instance = value;
					}
				}
				private global::Windows.UI.Xaml.Markup.ComponentHolder _component_1_Holder = new global::Windows.UI.Xaml.Markup.ComponentHolder(isWeak: true);
				private global::Windows.UI.Xaml.Controls.Border _component_1
				{
					get
					{
						return (global::Windows.UI.Xaml.Controls.Border)_component_1_Holder.Instance;
					}
					set
					{
						_component_1_Holder.Instance = value;
					}
				}
				private void __UpdateBindingsAndResources(global::Windows.UI.Xaml.FrameworkElement s, object e)
				{
					var owner = this;
					_component_0.UpdateResourceBindings();
				}
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
				[global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdate]
				private class __ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_MyProject__ResourcesSC0_UnoUITestsGiven_ResourceDictionaryWhen_Nested_With_Sibling_Ref_And_Event
				{
						public class ApplyMethod_3_Invoked_Handler(global::Uno.UI.DataBinding.ManagedWeakReference target)
						{
							public void Invoke(global::Windows.UI.Xaml.Controls.SwipeItem sender, global::Windows.UI.Xaml.Controls.SwipeItemInvokedEventArgs args)
							{
								(target.Target as global::Uno.UI.Tests.Given_ResourceDictionary.When_Nested_With_Sibling_Ref_And_Event)?.AnEventHandler(sender, args);
							}
						}

				}
			}
		}
	}
}
namespace MyProject
{
	static class ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20XamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Windows.UI.Xaml.Controls.Page instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.Page ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_XamlApply(this global::Windows.UI.Xaml.Controls.Page instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler1(global::Windows.UI.Xaml.Controls.SwipeItems instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.SwipeItems ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_XamlApply(this global::Windows.UI.Xaml.Controls.SwipeItems instance, XamlApplyHandler1 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler2(global::Windows.UI.Xaml.Controls.SwipeItem instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.SwipeItem ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_XamlApply(this global::Windows.UI.Xaml.Controls.SwipeItem instance, XamlApplyHandler2 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler3(global::Windows.UI.Xaml.Controls.Border instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.Border ResourceDictionary_When_Nested_With_Sibling_Ref_And_Event_6d62c5ee15120ed189e095faf6d37e20_XamlApply(this global::Windows.UI.Xaml.Controls.Border instance, XamlApplyHandler3 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
