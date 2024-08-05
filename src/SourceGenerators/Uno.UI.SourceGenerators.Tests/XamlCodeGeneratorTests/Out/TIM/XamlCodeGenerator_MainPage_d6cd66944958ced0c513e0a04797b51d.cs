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

namespace TestRepro
{
	partial class MainPage : global::Microsoft.UI.Xaml.Controls.Page
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_MainPage_d6cd66944958ced0c513e0a04797b51d = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d = "ms-appx:///TestProject/";
		private global::Microsoft.UI.Xaml.Markup.INameScope __nameScope = new global::Microsoft.UI.Xaml.NameScope();
		private void InitializeComponent()
		{
			if (NameScope.GetNameScope(this) is { } existingRootNameScope)
			{
				__nameScope = existingRootNameScope;
			}
			else
			{
				NameScope.SetNameScope(this, __nameScope);
			}
			var __that = this;
			base.IsParsing = true;
			// Source 0\MainPage.xaml (Line 1:2)
			base.Content = 
			new global::Microsoft.UI.Xaml.Controls.Grid
			{
				IsParsing = true,
				// Source 0\MainPage.xaml (Line 11:3)
				Children = 
				{
					new global::Microsoft.UI.Xaml.Controls.Button
					{
						IsParsing = true,
						// Source 0\MainPage.xaml (Line 12:4)
					}
					.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler0)(c0 => 
					{
						/* _isTopLevelDictionary:False */
						__that._component_0 = c0;
						__that.__0_Click_P1_Button_Click_Builder = (__owner) => 
						{
							var Click_P1_Button_Click_That = (__that as global::Uno.UI.DataBinding.IWeakReferenceProvider).WeakReference;
							/* first level targetMethod:TestRepro.C1.Button_Click(object, Microsoft.UI.Xaml.RoutedEventArgs) */ __owner.Click += (_sender,_e) => 
							{
								(Click_P1_Button_Click_That.Target as global::TestRepro.MainPage)?.P1.Button_Click(_sender,_e);
							}
							;
						}
						;
						global::Uno.UI.FrameworkElementHelper.SetBaseUri(c0, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
						c0.CreationComplete();
					}
					))
					,
					new global::Microsoft.UI.Xaml.Controls.Button
					{
						IsParsing = true,
						// Source 0\MainPage.xaml (Line 13:4)
					}
					.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler0)(c1 => 
					{
						/* _isTopLevelDictionary:False */
						__that._component_1 = c1;
						__that.__1_Click_P2_Button_Click_Builder = (__owner) => 
						{
							var Click_P2_Button_Click_That = (__that as global::Uno.UI.DataBinding.IWeakReferenceProvider).WeakReference;
							/* first level targetMethod:TestRepro.ImplicitImpl.Button_Click(object, Microsoft.UI.Xaml.RoutedEventArgs) */ __owner.Click += (_sender,_e) => 
							{
								(Click_P2_Button_Click_That.Target as global::TestRepro.MainPage)?.P2.Button_Click(_sender,_e);
							}
							;
						}
						;
						global::Uno.UI.FrameworkElementHelper.SetBaseUri(c1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
						c1.CreationComplete();
					}
					))
					,
					new global::Microsoft.UI.Xaml.Controls.Button
					{
						IsParsing = true,
						// Source 0\MainPage.xaml (Line 14:4)
					}
					.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler0)(c2 => 
					{
						/* _isTopLevelDictionary:False */
						__that._component_2 = c2;
						__that.__2_Click_P3_Button_Click_Builder = (__owner) => 
						{
							var Click_P3_Button_Click_That = (__that as global::Uno.UI.DataBinding.IWeakReferenceProvider).WeakReference;
							/* first level targetMethod:TestRepro.I.Button_Click(object, Microsoft.UI.Xaml.RoutedEventArgs) */ __owner.Click += (_sender,_e) => 
							{
								(Click_P3_Button_Click_That.Target as global::TestRepro.MainPage)?.P3.Button_Click(_sender,_e);
							}
							;
						}
						;
						global::Uno.UI.FrameworkElementHelper.SetBaseUri(c2, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
						c2.CreationComplete();
					}
					))
					,
				}
			}
			.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler1)(c3 => 
			{
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c3, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
				c3.CreationComplete();
			}
			))
			;
			
			this
			.GenericApply(((c4) => 
			{
				// Source 0\MainPage.xaml (Line 1:2)
				
				// WARNING Property c4.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Page, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.GenericApply(((c5) => 
			{
				/* _isTopLevelDictionary:False */
				__that._component_3 = c5;
				// Class TestRepro.MainPage
				global::Uno.UI.ResourceResolverSingleton.Instance.ApplyResource(c5, global::Microsoft.UI.Xaml.Controls.Page.BackgroundProperty, "ApplicationPageBackgroundThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: false, context: global::MyProject.GlobalStaticResources.__ParseContext_);
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c5, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
				c5.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();

			Bindings = new MainPage_Bindings(this);
			Loading += (s, e) =>
			{
				__that.Bindings.Update();
				__that.Bindings.UpdateResources();
			}
			;
		}
		partial void OnInitializeCompleted();
		private global::System.Action<global::Microsoft.UI.Xaml.Controls.Primitives.ButtonBase> __0_Click_P1_Button_Click_Builder;
		private global::System.Action<global::Microsoft.UI.Xaml.Controls.Primitives.ButtonBase> __1_Click_P2_Button_Click_Builder;
		private global::System.Action<global::Microsoft.UI.Xaml.Controls.Primitives.ButtonBase> __2_Click_P3_Button_Click_Builder;
		private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_0_Holder  = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Microsoft.UI.Xaml.Controls.Button _component_0
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Button)_component_0_Holder.Instance;
			}
			set
			{
				_component_0_Holder.Instance = value;
			}
		}
		private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_1_Holder  = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Microsoft.UI.Xaml.Controls.Button _component_1
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Button)_component_1_Holder.Instance;
			}
			set
			{
				_component_1_Holder.Instance = value;
			}
		}
		private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_2_Holder  = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Microsoft.UI.Xaml.Controls.Button _component_2
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Button)_component_2_Holder.Instance;
			}
			set
			{
				_component_2_Holder.Instance = value;
			}
		}
		private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_3_Holder  = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Microsoft.UI.Xaml.Controls.Page _component_3
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Page)_component_3_Holder.Instance;
			}
			set
			{
				_component_3_Holder.Instance = value;
			}
		}
		private interface IMainPage_Bindings
		{
			void Initialize();
			void Update();
			void UpdateResources();
			void StopTracking();
			void NotifyXLoad(string name);
		}
		#pragma warning disable 0169 //  Suppress unused field warning in case Bindings is not used.
		private IMainPage_Bindings Bindings;
		#pragma warning restore 0169
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		private class MainPage_Bindings : IMainPage_Bindings
		{
			#if UNO_HAS_UIELEMENT_IMPLICIT_PINNING
			private global::System.WeakReference _ownerReference;
			private global::TestRepro.MainPage Owner { get => (global::TestRepro.MainPage)_ownerReference?.Target; set => _ownerReference = new global::System.WeakReference(value); }
			#else
			private global::TestRepro.MainPage Owner { get; set; }
			#endif
			public MainPage_Bindings(global::TestRepro.MainPage owner)
			{
				Owner = owner;
			}
			void IMainPage_Bindings.NotifyXLoad(string name)
			{
			}
			void IMainPage_Bindings.Initialize()
			{
			}
			void IMainPage_Bindings.Update()
			{
				var owner = Owner;
				owner._component_0.ApplyXBind();
				owner.__0_Click_P1_Button_Click_Builder?.Invoke( owner._component_0);
				owner.__0_Click_P1_Button_Click_Builder = null;
				owner.__1_Click_P2_Button_Click_Builder?.Invoke( owner._component_1);
				owner.__1_Click_P2_Button_Click_Builder = null;
				owner.__2_Click_P3_Button_Click_Builder?.Invoke( owner._component_2);
				owner.__2_Click_P3_Button_Click_Builder = null;
				owner._component_1.ApplyXBind();
				owner.__0_Click_P1_Button_Click_Builder?.Invoke( owner._component_0);
				owner.__0_Click_P1_Button_Click_Builder = null;
				owner.__1_Click_P2_Button_Click_Builder?.Invoke( owner._component_1);
				owner.__1_Click_P2_Button_Click_Builder = null;
				owner.__2_Click_P3_Button_Click_Builder?.Invoke( owner._component_2);
				owner.__2_Click_P3_Button_Click_Builder = null;
				owner._component_2.ApplyXBind();
				owner.__0_Click_P1_Button_Click_Builder?.Invoke( owner._component_0);
				owner.__0_Click_P1_Button_Click_Builder = null;
				owner.__1_Click_P2_Button_Click_Builder?.Invoke( owner._component_1);
				owner.__1_Click_P2_Button_Click_Builder = null;
				owner.__2_Click_P3_Button_Click_Builder?.Invoke( owner._component_2);
				owner.__2_Click_P3_Button_Click_Builder = null;
				owner.__0_Click_P1_Button_Click_Builder?.Invoke( owner._component_0);
				owner.__0_Click_P1_Button_Click_Builder = null;
				owner.__1_Click_P2_Button_Click_Builder?.Invoke( owner._component_1);
				owner.__1_Click_P2_Button_Click_Builder = null;
				owner.__2_Click_P3_Button_Click_Builder?.Invoke( owner._component_2);
				owner.__2_Click_P3_Button_Click_Builder = null;
			}
			void IMainPage_Bindings.UpdateResources()
			{
				var owner = Owner;
				owner._component_0.UpdateResourceBindings(resourceContextProvider: null);
				owner._component_1.UpdateResourceBindings(resourceContextProvider: null);
				owner._component_2.UpdateResourceBindings(resourceContextProvider: null);
				owner._component_3.UpdateResourceBindings(resourceContextProvider: null);
			}
			void IMainPage_Bindings.StopTracking()
			{
			}
		}
	}
}
namespace MyProject
{
	static class MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Microsoft.UI.Xaml.Controls.Button instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.Button MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.Controls.Button instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler1(global::Microsoft.UI.Xaml.Controls.Grid instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.Grid MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.Controls.Grid instance, XamlApplyHandler1 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
