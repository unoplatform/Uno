﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Uno.Extensions;
using Uno.SourceGeneration;
using Uno.UI.SourceGenerators.XamlGenerator;

namespace Uno.UI.SourceGenerators.DependencyObject
{
	public class DependencyObjectGenerator : SourceGenerator
	{
		public override void Execute(SourceGeneratorContext context)
		{
			if (PlatformHelper.IsValidPlatform(context))
			{
				var visitor = new SerializationMethodsGenerator(context);
				visitor.Visit(context.Compilation.SourceModule);
			}
		}

		private class SerializationMethodsGenerator : SymbolVisitor
		{
			private readonly SourceGeneratorContext _context;
			private readonly Compilation _comp;
			private readonly INamedTypeSymbol _dependencyObjectSymbol;
			private readonly INamedTypeSymbol _unoViewgroupSymbol;
			private readonly INamedTypeSymbol _iosViewSymbol;
			private readonly INamedTypeSymbol _androidViewSymbol;
			private readonly INamedTypeSymbol _javaObjectSymbol;
			private readonly INamedTypeSymbol _androidActivitySymbol;
			private readonly INamedTypeSymbol _androidFragmentSymbol;
			private readonly INamedTypeSymbol _iFrameworkElementSymbol;


			public SerializationMethodsGenerator(SourceGeneratorContext context)
			{
				_context = context;

				_comp = context.Compilation;

				_dependencyObjectSymbol = context.Compilation.GetTypeByMetadataName(XamlConstants.Types.DependencyObject);
				_unoViewgroupSymbol = context.Compilation.GetTypeByMetadataName("Uno.UI.UnoViewGroup");
				_iosViewSymbol = context.Compilation.GetTypeByMetadataName("UIKit.UIView");
				_androidViewSymbol = context.Compilation.GetTypeByMetadataName("Android.Views.View");
				_javaObjectSymbol = context.Compilation.GetTypeByMetadataName("Java.Lang.Object");
				_androidActivitySymbol = context.Compilation.GetTypeByMetadataName("Android.App.Activity");
				_androidFragmentSymbol = context.Compilation.GetTypeByMetadataName("Android.App.Fragment");
				_iFrameworkElementSymbol = context.Compilation.GetTypeByMetadataName(XamlConstants.Types.IFrameworkElement);
			}

			public override void VisitNamedType(INamedTypeSymbol type)
			{
				foreach (var t in type.GetTypeMembers())
				{
					VisitNamedType(t);
				}

				ProcessType(type);
			}

			public override void VisitModule(IModuleSymbol symbol)
			{
				VisitNamespace(symbol.GlobalNamespace);
			}

			public override void VisitNamespace(INamespaceSymbol symbol)
			{
				foreach (var n in symbol.GetNamespaceMembers())
				{
					VisitNamespace(n);
				}

				foreach (var t in symbol.GetTypeMembers())
				{
					VisitNamedType(t);
				}
			}

			private void ProcessType(INamedTypeSymbol typeSymbol)
			{
				var isDependencyObject = typeSymbol.Interfaces.Any(t => t == _dependencyObjectSymbol)
					&& (typeSymbol.BaseType?.GetAllInterfaces().None(t => t == _dependencyObjectSymbol) ?? true);

				if (isDependencyObject && typeSymbol.TypeKind == TypeKind.Class)
				{
					var builder = new IndentedStringBuilder();
					builder.AppendLineInvariant("// <auto-generated>");
					builder.AppendLineInvariant("// ******************************************************************");
					builder.AppendLineInvariant("// This file has been generated by Uno.UI (DependencyObjectGenerator)");
					builder.AppendLineInvariant("// ******************************************************************");
					builder.AppendLineInvariant("// </auto-generated>");
					builder.AppendLine();

					builder.AppendLineInvariant($"using System;");
					builder.AppendLineInvariant($"using System.Linq;");
					builder.AppendLineInvariant($"using System.Collections.Generic;");
					builder.AppendLineInvariant($"using System.Collections;");
					builder.AppendLineInvariant($"using System.Diagnostics.CodeAnalysis;");
					builder.AppendLineInvariant($"using Uno.Disposables;");
					builder.AppendLineInvariant($"using System.Runtime.CompilerServices;");
					builder.AppendLineInvariant($"using Uno.Extensions;");
					builder.AppendLineInvariant($"using Uno.Logging;");
					builder.AppendLineInvariant($"using Uno.UI;");
					builder.AppendLineInvariant($"using Uno.UI.DataBinding;");
					builder.AppendLineInvariant($"using Windows.UI.Xaml;");
					builder.AppendLineInvariant($"using Windows.UI.Xaml.Data;");
					builder.AppendLineInvariant($"using Uno.Diagnostics.Eventing;");

					using (builder.BlockInvariant($"namespace {typeSymbol.ContainingNamespace}"))
					{
						builder.AppendLineInvariant(@"[Windows.UI.Xaml.Data.Bindable]");

						using (GenerateNestingContainers(builder, typeSymbol))
						{
							using (builder.BlockInvariant($"{typeSymbol.GetAccessibilityAsCodeString()} partial class {typeSymbol.Name} : IDependencyObjectStoreProvider, IWeakReferenceProvider"))
							{
								GenerateDependencyObjectImplementation(builder);
								GenerateIBinderImplementation(typeSymbol, builder);
							}
						}
					}

					_context.AddCompilationUnit(typeSymbol.GetFullName(), builder.ToString());
				}
			}

			private IDisposable GenerateNestingContainers(IndentedStringBuilder builder, INamedTypeSymbol typeSymbol)
			{
				var disposables = new List<IDisposable>();

				while (typeSymbol?.ContainingType != null)
				{
					disposables.Add(builder.BlockInvariant($"partial class {typeSymbol?.ContainingType.Name}"));

					typeSymbol = typeSymbol?.ContainingType;
				}

				return new DisposableAction(() => disposables.ForEach(d => d.Dispose()));
			}

			private void GenerateIBinderImplementation(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				WriteInitializer(typeSymbol, builder);

				WriteToStringOverride(typeSymbol, builder);

				WriteAndroidEqualityOverride(typeSymbol, builder);

				WriteAndroidBinderDetails(typeSymbol, builder);

				WriteAndroidAttachedToWindow(typeSymbol, builder);

				WriteAttachToWindow(typeSymbol, builder);

				WriteiOSMoveToSuperView(typeSymbol, builder);

				WriteDispose(typeSymbol, builder);

				WriteBinderImplementation(typeSymbol, builder);
			}

			private void WriteToStringOverride(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var hasNoToString = typeSymbol
					.GetMethods()
					.Where(m => IsNotDependencyObjectGeneratorSourceFile(m))
					.None(m => m.Name == "ToString");

				if (hasNoToString)
				{
					builder.AppendFormatInvariant(@"public override string ToString() => GetType().FullName;");
				}
			}

			private void WriteiOSMoveToSuperView(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var isiosView = typeSymbol.Is(_iosViewSymbol);
				var hasNoWillMoveToSuperviewMethod = typeSymbol
					.GetMethods()
					.Where(m => IsNotDependencyObjectGeneratorSourceFile(m))
					.None(m => m.Name == "WillMoveToSuperview");

				var overridesWillMoveToSuperview = isiosView && hasNoWillMoveToSuperviewMethod;

				if (overridesWillMoveToSuperview)
				{
					builder.AppendFormatInvariant(@"
						public override void WillMoveToSuperview(UIKit.UIView newsuper)
						{{
							base.WillMoveToSuperview(newsuper);

							WillMoveToSuperviewPartial(newsuper);

							SyncBinder(newsuper, Window);
						}}

						partial void WillMoveToSuperviewPartial(UIKit.UIView newsuper);
		
						private void SyncBinder(UIKit.UIView superview, UIKit.UIWindow window)
						{{
							if(superview == null && window == null)
							{{
								TemplatedParent = null;
							}}
						}}
					");
				}
				else
				{
					builder.AppendLine($"// Skipped _iosViewSymbol: {typeSymbol.Is(_iosViewSymbol)}, hasNoWillMoveToSuperviewMethod: {hasNoWillMoveToSuperviewMethod}");
				}
			}

			private void WriteAndroidAttachedToWindow(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var isAndroidView = typeSymbol.Is(_androidViewSymbol);
				var isAndroidActivity = typeSymbol.Is(_androidActivitySymbol);
				var isAndroidFragment = typeSymbol.Is(_androidFragmentSymbol);
				var isUnoViewGroup = typeSymbol.Is(_unoViewgroupSymbol);
				var implementsIFrameworkElement = typeSymbol.Interfaces.Any(t => t == _iFrameworkElementSymbol);
				var hasOverridesAttachedToWindowAndroid = isAndroidView &&
					typeSymbol
					.GetMethods()
					.Where(m => IsNotDependencyObjectGeneratorSourceFile(m))
					.None(m => m.Name == "OnAttachedToWindow");

				if (isAndroidView || isAndroidActivity || isAndroidFragment)
				{
					if (!isAndroidActivity && !isAndroidFragment)
					{
						WriteRegisterLoadActions(typeSymbol, builder);
					}

					builder.AppendLine($@"
#if {hasOverridesAttachedToWindowAndroid} //Is Android view (that doesn't already override OnAttachedToWindow)

#if {isUnoViewGroup} //Is UnoViewGroup
					// Both methods below are implementation of abstract methods
					// which are called from onAttachedToWindow in Java.

					protected override void OnNativeLoaded()
					{{
						_loadActions.ForEach(a => a.Item1());

						BinderAttachedToWindow();
					}}

					protected override void OnNativeUnloaded()
					{{
						_loadActions.ForEach(a => a.Item2());

						BinderDetachedFromWindow();
					}}
#else //Not UnoViewGroup
					protected override void OnAttachedToWindow()
					{{
						base.OnAttachedToWindow();
						__Store.Parent = base.Parent;
#if {implementsIFrameworkElement} //Is IFrameworkElement
						OnLoading();
						OnLoaded();
#endif						
						_loadActions.ForEach(a => a.Item1());
						BinderAttachedToWindow();
					}}


					protected override void OnDetachedFromWindow()
					{{
						base.OnDetachedFromWindow();
						_loadActions.ForEach(a => a.Item2());
#if {implementsIFrameworkElement} //Is IFrameworkElement
						OnUnloaded();
#endif
					if(base.Parent == null)
					{{
						__Store.Parent = null;
					}}

						BinderDetachedFromWindow();
					}}
#endif // IsUnoViewGroup
#endif // OverridesAttachedToWindow

					private void BinderAttachedToWindow()
					{{
						OnAttachedToWindowPartial();
					}}


					private void BinderDetachedFromWindow()
					{{
						OnDetachedFromWindowPartial();
					}}

					/// <summary>
					/// A method called when the control is attached to the Window (equivalent of Loaded)
					/// </summary>
					partial void OnAttachedToWindowPartial();

					/// <summary>
					/// A method called when the control is attached to the Window (equivalent of Unloaded)
					/// </summary>
					partial void OnDetachedFromWindowPartial();
				");
				}
			}

			private static void WriteRegisterLoadActions(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				builder.AppendLine($@"
					// A list of actions to be executed on Load and Unload
					private List<global::System.Tuple<Action,Action>> _loadActions = new List<global::System.Tuple<Action,Action>>();

					/// <summary>
					/// Registers actions to be executed when the control is Loaded and Unloaded.
					/// </summary>
					/// <param name=""loaded""></param>
					/// <param name=""unloaded""></param>
					/// <returns></returns>
					/// <remarks>The loaded action may be executed immediately if the control is already loaded.</remarks>
					public IDisposable RegisterLoadActions(Action loaded, Action unloaded)
					{{
						var tuple = Tuple.Create(loaded, unloaded);

						_loadActions.Add(tuple);

#if __ANDROID__
						if(this.IsLoaded())
#elif __IOS__
						if(Window != null)
#else
#error Unsupported platform
#endif
						{{
							loaded();
						}}

						return Disposable.Create(() => _loadActions.Remove(tuple));
					}}
				");
			}

			private void WriteAttachToWindow(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var hasOverridesAttachedToWindowiOS = typeSymbol.Is(_iosViewSymbol) &&
									typeSymbol
									.GetMethods()
									.Where(m => m.Name == "MovedToWindow")
									.Where(m => IsNotDependencyObjectGeneratorSourceFile(m))
									.None();

				if (hasOverridesAttachedToWindowiOS)
				{
					WriteRegisterLoadActions(typeSymbol, builder);

					builder.AppendLine($@"
						public override void MovedToWindow()
						{{
							base.MovedToWindow();

							if(Window != null)
							{{
								_loadActions.ForEach(a => a.Item1());
								OnAttachedToWindowPartial();
							}}
							else
							{{
								_loadActions.ForEach(a => a.Item2());
								OnDetachedFromWindowPartial();
							}}
						}}

						/// <summary>
						/// A method called when the control is attached to the Window (equivalent of Loaded)
						/// </summary>
						partial void OnAttachedToWindowPartial();

						/// <summary>
						/// A method called when the control is attached to the Window (equivalent of Unloaded)
						/// </summary>
						partial void OnDetachedFromWindowPartial();
					");
				}
				else
				{
					builder.AppendLine($@"// hasOverridesAttachedToWindowiOS=false");
				}
			}

			private static bool IsNotDependencyObjectGeneratorSourceFile(IMethodSymbol m)
			{
				return !m.Locations.FirstOrDefault()?.SourceTree?.FilePath.Contains(nameof(DependencyObjectGenerator)) ?? true;
			}

			private void WriteAndroidBinderDetails(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var hasBinderDetails = typeSymbol.Is(_androidViewSymbol);

				if (hasBinderDetails)
				{
					builder.AppendLine($@"
						///<summary>
						/// Should not be used directly.
						/// Helper method to provide Xaml debugging information to tools like Stetho.
						///</summary>
						[Java.Interop.ExportField(""xamlBinder"")]
						public BinderDetails GetBinderDetail()
						{{
							return null;
						}}

						partial void UpdateBinderDetails()
						{{
							if (BinderDetails.IsBinderDetailsEnabled)
							{{
								var field = this.Class.GetField(""xamlBinder"");
								field.Set(this, new BinderDetails(this));
							}}
						}}
					");
				}
			}

			private static void WriteInitializer(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var content = $@"
					private readonly static IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);
					private BinderReferenceHolder _refHolder;

					public event Windows.Foundation.TypedEventHandler<DependencyObject, DataContextChangedEventArgs> DataContextChanged;

					partial void InitializeBinder();

					private void __InitializeBinder()
					{{
						if(BinderReferenceHolder.IsEnabled)
						{{
							_refHolder = new BinderReferenceHolder(this.GetType(), this);

							UpdateBinderDetails();
						}}
					}}


					partial void UpdateBinderDetails();

					public void ClearBindings()
					{{
						__Store.ClearBindings();
					}}

					public void RestoreBindings()
					{{
						__Store.RestoreBindings();
					}}

					public void ApplyCompiledBindings()
					{{
						__Store.ApplyCompiledBindings();
					}}

					private Uno.UI.DataBinding.ManagedWeakReference _selfWeakReference;
					Uno.UI.DataBinding.ManagedWeakReference IWeakReferenceProvider.WeakReference 
					{{
						get
						{{
							if(_selfWeakReference == null)
							{{
								_selfWeakReference = Uno.UI.DataBinding.WeakReferencePool.RentSelfWeakReference(this);
							}}
							
							return _selfWeakReference;
						}}
					}}
				";

				builder.AppendLine(content);
			}

			private void WriteDispose(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var hasDispose = typeSymbol.Is(_androidViewSymbol) || typeSymbol.Is(_iosViewSymbol);
				var isViewGroup = typeSymbol.Is(_unoViewgroupSymbol);

				if (hasDispose)
				{
					builder.AppendLine($@"
#if __IOS__
					private bool _isDisposed;

					[SuppressMessage(
						""Microsoft.Usage"",
						""CA2215:DisposeMethodsShouldCallBaseClassDispose"",
						Justification = ""The dispose is re-scheduled using the ValidateDispose method"")]
					protected sealed override void Dispose(bool disposing)
					{{
						if(_isDisposed)
						{{
							base.Dispose(disposing);
							return;
						}}

						if (disposing)
						{{
							// __Store may be null if the control has been recreated from
							// a native representation via the IntPtr ctor, particularly on iOS.
							__Store?.Dispose();

							var subviews = Subviews;

							RequestCollect(subviews);

							foreach (var v in subviews)
							{{
								v.RemoveFromSuperview();
							}}

							base.Dispose(disposing);

							_isDisposed = true;
						}}
						else
						{{
							GC.ReRegisterForFinalize(this);

							Dispatcher.RunIdleAsync(_ => Dispose());
						}}
					}}

					private void RequestCollect(UIKit.UIView[] subviews)
					{{
						if(subviews.Length != 0)
						{{
							BinderCollector.RequestCollect();
						}}
					}}
#endif
				");
				}
			}

			private void WriteBinderImplementation(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var virtualModifier = typeSymbol.IsSealed ? "" : "virtual";
				var protectedModifier = typeSymbol.IsSealed ? "private" : "internal protected";

				builder.AppendLine($@"

					#region DataContext DependencyProperty

					public object DataContext
					{{
						get => GetValue(DataContextProperty);
						set => SetValue(DataContextProperty, value);
					}}

					// Using a DependencyProperty as the backing store for DataContext.  This enables animation, styling, binding, etc...
					public static readonly DependencyProperty DataContextProperty =
						DependencyProperty.Register(
							name: nameof(DataContext),
							propertyType: typeof(object),
							ownerType: typeof({typeSymbol.Name}),
							typeMetadata: new FrameworkPropertyMetadata(
								defaultValue: null,
								options: FrameworkPropertyMetadataOptions.Inherits,
								propertyChangedCallback: (s, e) => (({typeSymbol.Name})s).OnDataContextChanged(e)
							)
					);

					{protectedModifier} {virtualModifier} void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
					{{
						OnDataContextChangedPartial(e);
						DataContextChanged?.Invoke(this, new DataContextChangedEventArgs(DataContext));
					}}

					#endregion

					#region TemplatedParent DependencyProperty

					public DependencyObject TemplatedParent
					{{
						get => (DependencyObject)GetValue(TemplatedParentProperty);
						set => SetValue(TemplatedParentProperty, value);
					}}

					// Using a DependencyProperty as the backing store for TemplatedParent.  This enables animation, styling, binding, etc...
					public static readonly DependencyProperty TemplatedParentProperty =
						DependencyProperty.Register(
							name: nameof(TemplatedParent),
							propertyType: typeof(DependencyObject),
							ownerType: typeof({typeSymbol.Name}),
							typeMetadata: new FrameworkPropertyMetadata(
								defaultValue: null,
								options: FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage,
								propertyChangedCallback: (s, e) => (({typeSymbol.Name})s).OnTemplatedParentChanged(e)
							)
						);


					{protectedModifier} {virtualModifier} void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
					{{
						__Store.SetTemplatedParent(e.NewValue as FrameworkElement);
						OnTemplatedParentChangedPartial(e);
					}}

					#endregion

					public void SetBinding(object target, string dependencyProperty, global::Windows.UI.Xaml.Data.BindingBase binding)
					{{
						__Store.SetBinding(target, dependencyProperty, binding);
					}}

					public void SetBinding(string dependencyProperty, global::Windows.UI.Xaml.Data.BindingBase binding)
					{{
						__Store.SetBinding(dependencyProperty, binding);
					}}

					public void SetBinding(DependencyProperty dependencyProperty, global::Windows.UI.Xaml.Data.BindingBase binding)
					{{
						__Store.SetBinding(dependencyProperty, binding);
					}}

					public void SetBindingValue(object value, [CallerMemberName] string propertyName = null)
					{{
						__Store.SetBindingValue(value, propertyName);
					}}

					[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
					internal bool IsAutoPropertyInheritanceEnabled {{ get => __Store.IsAutoPropertyInheritanceEnabled; set => __Store.IsAutoPropertyInheritanceEnabled = value; }}

					partial void OnDataContextChangedPartial(DependencyPropertyChangedEventArgs e);

					partial void OnTemplatedParentChangedPartial(DependencyPropertyChangedEventArgs e);

					public global::Windows.UI.Xaml.Data.BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
						=>  __Store.GetBindingExpression(dependencyProperty);

					public void ResumeBindings() 
						=>__Store.ResumeBindings();

					public void SuspendBindings() => 
						__Store.SuspendBindings();
				");
			}

			private void WriteAndroidEqualityOverride(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var hasEqualityOverride = typeSymbol
					.GetMethods()
					.Where(m => m.Name == "Equals")
					.Where(m => IsNotDependencyObjectGeneratorSourceFile(m))
					.None()
					&& (typeSymbol.BaseType?.GetMethods().None(m => m.Name == "Equals" && m.IsSealed) ?? true);

				if (hasEqualityOverride && typeSymbol.Is(_androidViewSymbol))
				{
					builder.AppendLine($@"
						public override int GetHashCode()
						{{
							// For the the current kind of type, we do not need to call back
							// to android for the GetHashCode implementation. The .NET proxy hash is
							// enough. This way, we do not get to pay the price of the interop to get 
							// this value.
							return RuntimeHelpers.GetHashCode(this);
						}}

						public override bool Equals(object other)
						{{
							// For the the current kind of type, we do not need to call back
							// to android for the Equals implementation. We assume that proxies are 
							// one-to-one mapping with native instances, making the reference comparison 
							// of proxies enough to do the job.
							return RuntimeHelpers.ReferenceEquals(this, other);
						}}
					");
				}
			}

			private static void GenerateDependencyObjectImplementation(IndentedStringBuilder builder)
			{
				builder.AppendLineInvariant(@"private DependencyObjectStore __storeBackingField;");
				builder.AppendLineInvariant(@"public Windows.UI.Core.CoreDispatcher Dispatcher => Windows.UI.Core.CoreDispatcher.Main;");

				using (builder.BlockInvariant($"private DependencyObjectStore __Store"))
				{
					using (builder.BlockInvariant($"get"))
					{
						using (builder.BlockInvariant($"if(__storeBackingField == null)"))
						{
							builder.AppendLineInvariant("__storeBackingField = new DependencyObjectStore(this, DataContextProperty, TemplatedParentProperty);");
							builder.AppendLineInvariant("__InitializeBinder();");
						}

						builder.AppendLineInvariant("return __storeBackingField;");
					}
				}
				builder.AppendLineInvariant(@"public bool IsStoreInitialized => __storeBackingField != null;");

				builder.AppendLineInvariant(@"DependencyObjectStore IDependencyObjectStoreProvider.Store => __Store;");

				builder.AppendLineInvariant("public object GetValue(DependencyProperty dp) => __Store.GetValue(dp);");

				builder.AppendLineInvariant("public void SetValue(DependencyProperty dp, object value) => __Store.SetValue(dp, value);");

				builder.AppendLineInvariant("public void ClearValue(DependencyProperty dp) => __Store.ClearValue(dp);");

				builder.AppendLineInvariant("public object ReadLocalValue(DependencyProperty dp) => __Store.ReadLocalValue(dp);");

				builder.AppendLineInvariant("public object GetAnimationBaseValue(DependencyProperty dp) => __Store.GetAnimationBaseValue(dp);");

				builder.AppendLineInvariant("public long RegisterPropertyChangedCallback(DependencyProperty dp, DependencyPropertyChangedCallback callback) => __Store.RegisterPropertyChangedCallback(dp, callback);");

				builder.AppendLineInvariant("public void UnregisterPropertyChangedCallback(DependencyProperty dp, long token) => __Store.UnregisterPropertyChangedCallback(dp, token);");
			}
		}
	}
}
