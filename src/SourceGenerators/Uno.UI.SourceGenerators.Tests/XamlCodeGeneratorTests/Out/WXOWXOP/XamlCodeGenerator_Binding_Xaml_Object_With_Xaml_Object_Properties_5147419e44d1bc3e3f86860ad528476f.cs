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

namespace Uno.UI.Tests.Windows_UI_Xaml_Data.BindingTests.Controls
{
	partial class Binding_Xaml_Object_With_Xaml_Object_Properties : global::Windows.UI.Xaml.Controls.Page
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f = "ms-appx:///TestProject/";
		private global::Windows.UI.Xaml.NameScope __nameScope = new global::Windows.UI.Xaml.NameScope();
		private void InitializeComponent()
		{
			NameScope.SetNameScope(this, __nameScope);
			var __that = this;
			base.IsParsing = true;
			// Source 0\Binding_Xaml_Object_With_Xaml_Object_Properties.xaml (Line 1:2)
			base.Content = 
			new global::Windows.UI.Xaml.Controls.Grid
			{
				IsParsing = true,
				// Source 0\Binding_Xaml_Object_With_Xaml_Object_Properties.xaml (Line 10:6)
				Children = 
				{
					new global::Windows.UI.Xaml.Controls.TextBlock
					{
						IsParsing = true,
						Name = "topLevel",
						Tag = @"42",
						// Source 0\Binding_Xaml_Object_With_Xaml_Object_Properties.xaml (Line 11:10)
					}
					.Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f_XamlApply((Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476fXamlApplyExtensions.XamlApplyHandler0)(__p1 => 
					{
					/* _isTopLevelDictionary:False */
					__that._component_0 = __p1;
					__nameScope.RegisterName("topLevel", __p1);
					__that.topLevel = __p1;
					// FieldModifier public
					__p1.SetBinding(
						global::Windows.UI.Xaml.Controls.TextBlock.TextProperty,
						new Windows.UI.Xaml.Data.Binding()
						{
							Path = @"Tag",
							ElementName = _topLevelSubject,
							Converter = new global::Uno.UI.Tests.Windows_UI_Xaml_Data.BindingTests.Controls.Binding_Xaml_Object_With_Xaml_Object_Properties_Return_Value_Converter(),
							ConverterParameter = "topLevel",
							ConverterLanguage = "topLevel",
							UpdateSourceTrigger = global::Windows.UI.Xaml.Data.UpdateSourceTrigger.Default,
							TargetNullValue = "TargetNullValue",
							FallbackValue = "FallbackValue",
							Mode = global::Windows.UI.Xaml.Data.BindingMode.OneWay,
							RelativeSource = new RelativeSource(RelativeSourceMode.None),
							Source = "Source",
						}
					);
					global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f);
					__p1.CreationComplete();
					}
					))
					,
				}
			}
			.Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f_XamlApply((Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476fXamlApplyExtensions.XamlApplyHandler1)(__p1 => 
			{
			global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f);
			__p1.CreationComplete();
			}
			))
			;
			
			this
			.Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f_XamlApply((Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476fXamlApplyExtensions.XamlApplyHandler2)(__p1 => 
			{
			// Source 0\Binding_Xaml_Object_With_Xaml_Object_Properties.xaml (Line 1:2)
			
			// WARNING Property __p1.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Page, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f_XamlApply((Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476fXamlApplyExtensions.XamlApplyHandler2)(__p1 => 
			{
			// Class Uno.UI.Tests.Windows_UI_Xaml_Data.BindingTests.Controls.Binding_Xaml_Object_With_Xaml_Object_Properties
			global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f);
			__p1.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();

			Bindings = new Binding_Xaml_Object_With_Xaml_Object_Properties_Bindings(this);
			((global::Windows.UI.Xaml.FrameworkElement)this).Loading += __UpdateBindingsAndResources;
		}
		partial void OnInitializeCompleted();
		private void __UpdateBindingsAndResources(global::Windows.UI.Xaml.FrameworkElement s, object e)
		{
			this.Bindings.UpdateResources();
		}
		private global::Windows.UI.Xaml.Data.ElementNameSubject _topLevelSubject = new global::Windows.UI.Xaml.Data.ElementNameSubject();
		public global::Windows.UI.Xaml.Controls.TextBlock topLevel
		{
			get
			{
				return (global::Windows.UI.Xaml.Controls.TextBlock)_topLevelSubject.ElementInstance;
			}
			set
			{
				_topLevelSubject.ElementInstance = value;
			}
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
		private interface IBinding_Xaml_Object_With_Xaml_Object_Properties_Bindings
		{
			void Initialize();
			void Update();
			void UpdateResources();
			void StopTracking();
			void NotifyXLoad(string name);
		}
		#pragma warning disable 0169 //  Suppress unused field warning in case Bindings is not used.
		private IBinding_Xaml_Object_With_Xaml_Object_Properties_Bindings Bindings;
		#pragma warning restore 0169
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		private class Binding_Xaml_Object_With_Xaml_Object_Properties_Bindings : IBinding_Xaml_Object_With_Xaml_Object_Properties_Bindings
		{
			#if UNO_HAS_UIELEMENT_IMPLICIT_PINNING
			private global::System.WeakReference _ownerReference;
			private global::Uno.UI.Tests.Windows_UI_Xaml_Data.BindingTests.Controls.Binding_Xaml_Object_With_Xaml_Object_Properties Owner { get => (global::Uno.UI.Tests.Windows_UI_Xaml_Data.BindingTests.Controls.Binding_Xaml_Object_With_Xaml_Object_Properties)_ownerReference?.Target; set => _ownerReference = new global::System.WeakReference(value); }
			#else
			private global::Uno.UI.Tests.Windows_UI_Xaml_Data.BindingTests.Controls.Binding_Xaml_Object_With_Xaml_Object_Properties Owner { get; set; }
			#endif
			public Binding_Xaml_Object_With_Xaml_Object_Properties_Bindings(global::Uno.UI.Tests.Windows_UI_Xaml_Data.BindingTests.Controls.Binding_Xaml_Object_With_Xaml_Object_Properties owner)
			{
				Owner = owner;
			}
			void IBinding_Xaml_Object_With_Xaml_Object_Properties_Bindings.NotifyXLoad(string name)
			{
			}
			void IBinding_Xaml_Object_With_Xaml_Object_Properties_Bindings.Initialize()
			{
			}
			void IBinding_Xaml_Object_With_Xaml_Object_Properties_Bindings.Update()
			{
				var owner = Owner;
			}
			void IBinding_Xaml_Object_With_Xaml_Object_Properties_Bindings.UpdateResources()
			{
				var owner = Owner;
				owner._component_0.UpdateResourceBindings();
			}
			void IBinding_Xaml_Object_With_Xaml_Object_Properties_Bindings.StopTracking()
			{
			}
		}
	}
}
namespace MyProject
{
	static class Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476fXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Windows.UI.Xaml.Controls.TextBlock instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.TextBlock Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f_XamlApply(this global::Windows.UI.Xaml.Controls.TextBlock instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler1(global::Windows.UI.Xaml.Controls.Grid instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.Grid Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f_XamlApply(this global::Windows.UI.Xaml.Controls.Grid instance, XamlApplyHandler1 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler2(global::Windows.UI.Xaml.Controls.Page instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.Page Binding_Xaml_Object_With_Xaml_Object_Properties_5147419e44d1bc3e3f86860ad528476f_XamlApply(this global::Windows.UI.Xaml.Controls.Page instance, XamlApplyHandler2 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
