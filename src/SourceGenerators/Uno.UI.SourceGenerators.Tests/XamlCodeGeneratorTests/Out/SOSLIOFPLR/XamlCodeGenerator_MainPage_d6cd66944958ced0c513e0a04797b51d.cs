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
		private global::Microsoft.UI.Xaml.NameScope __nameScope = new global::Microsoft.UI.Xaml.NameScope();
		private void InitializeComponent()
		{
			NameScope.SetNameScope(this, __nameScope);
			var __that = this;
			base.IsParsing = true;
			Resources[
			typeof(global::Microsoft.UI.Xaml.Controls.TextBlock)
			] = 
			new global::Uno.UI.Xaml.WeakResourceInitializer(this, __ResourceOwner_1 => 
			{
				return 
					new global::Microsoft.UI.Xaml.Style
					{
						TargetType = typeof(global::Microsoft.UI.Xaml.Controls.TextBlock),
						// Source 0\MainPage.xaml (Line 7:6)
						Setters = 
						{
							new global::Microsoft.UI.Xaml.Setter
							{
								Property = global::Microsoft.UI.Xaml.Controls.TextBlock.ForegroundProperty,
								Value = new global::Microsoft.UI.Xaml.Media.SolidColorBrush(global::Microsoft.UI.Colors.Red),
								// Source 0\MainPage.xaml (Line 8:8)
							}
							,
						}
					}
					.GenericApply(__that, __nameScope, (ApplyMethod_1					))
				;
			}
			)
			;
			Resources[
			"MyCustomButtonStyle"
			] = 
			new global::Uno.UI.Xaml.WeakResourceInitializer(this, __ResourceOwner_1 => 
			{
				return 
					new global::Microsoft.UI.Xaml.Style
					{
						TargetType = typeof(global::Microsoft.UI.Xaml.Controls.Button),
						// Source 0\MainPage.xaml (Line 10:6)
						Setters = 
						{
							new global::Microsoft.UI.Xaml.Setter
							{
								Property = global::Microsoft.UI.Xaml.Controls.Button.BackgroundProperty,
								Value = new global::Microsoft.UI.Xaml.Media.SolidColorBrush(global::Microsoft.UI.Colors.Azure),
								// Source 0\MainPage.xaml (Line 11:8)
							}
							,
						}
					}
					.GenericApply(__that, __nameScope, (ApplyMethod_4					))
				;
			}
			)
			;
			Resources[
			"MyItemTemplate"
			] = 
			new global::Uno.UI.Xaml.WeakResourceInitializer(this, __ResourceOwner_1 => 
			{
				return 
					new global::Microsoft.UI.Xaml.DataTemplate(__ResourceOwner_1, (__owner) => 					new __MainPage_d6cd66944958ced0c513e0a04797b51d_TestReproMainPage.SC0().Build(__owner)
					)					.GenericApply(__that, __nameScope, (ApplyMethod_6					))
				;
			}
			)
			;
			// Source 0\MainPage.xaml (Line 1:2)
			base.Content = 
			new global::Microsoft.UI.Xaml.Controls.ListView
			{
				IsParsing = true,
				// Source 0\MainPage.xaml (Line 20:4)
			}
			.GenericApply(__that, __nameScope, (ApplyMethod_7			))
			;
			
			this
			.GenericApply(__that, __nameScope, (ApplyMethod_8			))
			.GenericApply(__that, __nameScope, (ApplyMethod_9			))
			;
			OnInitializeCompleted();

			Bindings = new MainPage_Bindings(this);
			((global::Microsoft.UI.Xaml.FrameworkElement)this).Loading += __UpdateBindingsAndResources;
		}
		partial void OnInitializeCompleted();
		private void __UpdateBindingsAndResources(global::Microsoft.UI.Xaml.FrameworkElement s, object e)
		{
			this.Bindings.UpdateResources();
		}
							private void ApplyMethod_1(global::Microsoft.UI.Xaml.Style __p1, MainPage __that, global::Microsoft.UI.Xaml.NameScope __nameScope)
					{
						global::Uno.UI.Helpers.MarkupHelper.SetElementProperty(__p1, "OriginalSourceLocation", "file:///C:/Project/0/MainPage.xaml#L7:6");
					}

							private void ApplyMethod_4(global::Microsoft.UI.Xaml.Style __p1, MainPage __that, global::Microsoft.UI.Xaml.NameScope __nameScope)
					{
						global::Uno.UI.Helpers.MarkupHelper.SetElementProperty(__p1, "OriginalSourceLocation", "file:///C:/Project/0/MainPage.xaml#L10:6");
					}

							private void ApplyMethod_6(global::System.Object __p1, MainPage __that, global::Microsoft.UI.Xaml.NameScope __nameScope)
					{
						global::Uno.UI.Helpers.MarkupHelper.SetElementProperty(__p1, "OriginalSourceLocation", "file:///C:/Project/0/MainPage.xaml#L13:6");
					}

					private void ApplyMethod_7(global::Microsoft.UI.Xaml.Controls.ListView __p1, MainPage __that, global::Microsoft.UI.Xaml.NameScope __nameScope)
			{
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d, "file:///C:/Project/0/MainPage.xaml", 20, 4);
				__p1.CreationComplete();
			}

					private void ApplyMethod_8(global::Microsoft.UI.Xaml.Controls.Page __p1, MainPage __that, global::Microsoft.UI.Xaml.NameScope __nameScope)
			{
				// Source 0\MainPage.xaml (Line 1:2)
				
				// WARNING Property __p1.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Page, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}

					private void ApplyMethod_9(global::Microsoft.UI.Xaml.Controls.Page __p1, MainPage __that, global::Microsoft.UI.Xaml.NameScope __nameScope)
			{
				/* _isTopLevelDictionary:False */
				__that._component_0 = __p1;
				// Class TestRepro.MainPage
				global::Uno.UI.ResourceResolverSingleton.Instance.ApplyResource(__p1, global::Microsoft.UI.Xaml.Controls.Page.BackgroundProperty, "ApplicationPageBackgroundThemeBrush", isThemeResourceExtension: true, isHotReloadSupported: true, context: global::MyProject.GlobalStaticResources.__ParseContext_);
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d, "file:///C:/Project/0/MainPage.xaml", 1, 2);
				__p1.CreationComplete();
			}

		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		[global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdate]
		private class __MainPage_d6cd66944958ced0c513e0a04797b51d_TestReproMainPage
		{
			[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
			[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2026")]
			[global::System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2111")]
			public class SC0
			{
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
				private const string __baseUri_prefix_MainPage_d6cd66944958ced0c513e0a04797b51d = "ms-appx:///TestProject/";
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
				private const string __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d = "ms-appx:///TestProject/";
				global::Microsoft.UI.Xaml.NameScope __nameScope = new global::Microsoft.UI.Xaml.NameScope();
				global::System.Object __ResourceOwner_1;
				_View __rootInstance = null;
				public _View Build(object __ResourceOwner_1)
				{
					var __that = this;
					this.__ResourceOwner_1 = __ResourceOwner_1;
					this.__rootInstance = 
					new global::Microsoft.UI.Xaml.Controls.StackPanel
					{
						IsParsing = true,
						// Source 0\MainPage.xaml (Line 14:8)
						Children = 
						{
							new global::Microsoft.UI.Xaml.Controls.TextBlock
							{
								IsParsing = true,
								// Source 0\MainPage.xaml (Line 15:10)
							}
							.GenericApply(__that, __nameScope, (ApplyMethod_10							))
							,
							new global::Microsoft.UI.Xaml.Controls.Button
							{
								IsParsing = true,
								Content = @"DoSomething",
								// Source 0\MainPage.xaml (Line 16:10)
							}
							.GenericApply(__that, __nameScope, (ApplyMethod_11							))
							,
						}
					}
					.GenericApply(__that, __nameScope, (ApplyMethod_12					))
					;
					if (__rootInstance is FrameworkElement __fe)
					{
						__fe.Loading += __UpdateBindingsAndResources;
					}
					if (__rootInstance is DependencyObject d)
					{
						if (global::Microsoft.UI.Xaml.NameScope.GetNameScope(d) == null)
						{
							global::Microsoft.UI.Xaml.NameScope.SetNameScope(d, __nameScope);
							__nameScope.Owner = d;
						}
						global::Uno.UI.FrameworkElementHelper.AddObjectReference(d, this);
					}
					return __rootInstance;
				}
				private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_0_Holder { get; } = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: true);
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
				private void __UpdateBindingsAndResources(global::Microsoft.UI.Xaml.FrameworkElement s, object e)
				{
					var owner = this;
					_component_0.UpdateResourceBindings();
				}
											private void ApplyMethod_10(global::Microsoft.UI.Xaml.Controls.TextBlock __p1, SC0 __that, global::Microsoft.UI.Xaml.NameScope __nameScope)
							{
								__p1.SetBinding(
									global::Microsoft.UI.Xaml.Controls.TextBlock.TextProperty,
									new Microsoft.UI.Xaml.Data.Binding()
									{
										Path = @"",
									}
								);
								global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d, "file:///C:/Project/0/MainPage.xaml", 15, 10);
								__p1.CreationComplete();
							}

											private void ApplyMethod_11(global::Microsoft.UI.Xaml.Controls.Button __p1, SC0 __that, global::Microsoft.UI.Xaml.NameScope __nameScope)
							{
								/* _isTopLevelDictionary:False */
								__that._component_0 = __p1;
								global::Uno.UI.ResourceResolverSingleton.Instance.ApplyResource(__p1, global::Microsoft.UI.Xaml.Controls.Button.StyleProperty, "MyCustomButtonStyle", isThemeResourceExtension: false, isHotReloadSupported: true, context: global::MyProject.GlobalStaticResources.__ParseContext_);
								global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d, "file:///C:/Project/0/MainPage.xaml", 16, 10);
								__p1.CreationComplete();
							}

									private void ApplyMethod_12(global::Microsoft.UI.Xaml.Controls.StackPanel __p1, SC0 __that, global::Microsoft.UI.Xaml.NameScope __nameScope)
					{
						global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d, "file:///C:/Project/0/MainPage.xaml", 14, 8);
						__p1.CreationComplete();
					}

				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
				[global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdate]
				private class __MainPage_d6cd66944958ced0c513e0a04797b51d_MyProject__ResourcesSC0_TestReproMainPage
				{
				}
			}
		}
		private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_0_Holder { get; } = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Microsoft.UI.Xaml.Controls.Page _component_0
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Page)_component_0_Holder.Instance;
			}
			set
			{
				_component_0_Holder.Instance = value;
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
			}
			void IMainPage_Bindings.UpdateResources()
			{
				var owner = Owner;
				owner._component_0.UpdateResourceBindings();
			}
			void IMainPage_Bindings.StopTracking()
			{
			}
		}
	}
}
