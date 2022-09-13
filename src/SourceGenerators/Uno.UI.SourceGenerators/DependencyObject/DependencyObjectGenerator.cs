﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Uno.Extensions;
using Uno.Roslyn;
using Uno.UI.SourceGenerators.Helpers;
using Uno.UI.SourceGenerators.XamlGenerator;

#if NETFRAMEWORK
using Uno.SourceGeneration;
#endif

namespace Uno.UI.SourceGenerators.DependencyObject
{
	[Generator]
	public partial class DependencyObjectGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
			// Debugger.Launch();
			// No initialization required for this one
			DependenciesInitializer.Init();
#if !NETFRAMEWORK
			context.RegisterForSyntaxNotifications(() => new ClassSyntaxReceiver());
#endif
		}

		public void Execute(GeneratorExecutionContext context)
		{
			if (PlatformHelper.IsValidPlatform(context))
			{
				var generator = new SerializationMethodsGenerator(context);
#if NETFRAMEWORK
				generator.Visit(context.Compilation.SourceModule);
#else
				if (context.SyntaxContextReceiver is ClassSyntaxReceiver receiver)
				{
					foreach (var symbol in receiver.NamedTypeSymbols)
					{
						generator.ProcessType(symbol);
					}
				}
#endif
			}
		}

		private sealed class SerializationMethodsGenerator
#if NETFRAMEWORK
			: SymbolVisitor
#endif
		{
			private readonly GeneratorExecutionContext _context;
			private readonly INamedTypeSymbol? _dependencyObjectSymbol;
			private readonly INamedTypeSymbol? _unoViewgroupSymbol;
			private readonly INamedTypeSymbol? _iosViewSymbol;
			private readonly INamedTypeSymbol? _macosViewSymbol;
			private readonly INamedTypeSymbol? _androidViewSymbol;
			private readonly INamedTypeSymbol? _javaObjectSymbol;
			private readonly INamedTypeSymbol? _androidActivitySymbol;
			private readonly INamedTypeSymbol? _androidFragmentSymbol;
			private readonly INamedTypeSymbol? _bindableAttributeSymbol;
			private readonly INamedTypeSymbol? _iFrameworkElementSymbol;
			private readonly INamedTypeSymbol? _frameworkElementSymbol;
			private readonly bool _isUnoSolution;
			private readonly string[] _analyzerSuppressions;

			public SerializationMethodsGenerator(GeneratorExecutionContext context)
			{
				_context = context;

				var comp = context.Compilation;

				_dependencyObjectSymbol = comp.GetTypeByMetadataName(XamlConstants.Types.DependencyObject);
				_unoViewgroupSymbol = comp.GetTypeByMetadataName("Uno.UI.UnoViewGroup");
				_iosViewSymbol = comp.GetTypeByMetadataName("UIKit.UIView");
				_macosViewSymbol = comp.GetTypeByMetadataName("AppKit.NSView");
				_androidViewSymbol = comp.GetTypeByMetadataName("Android.Views.View");
				_javaObjectSymbol = comp.GetTypeByMetadataName("Java.Lang.Object");
				_androidActivitySymbol = comp.GetTypeByMetadataName("Android.App.Activity");
				_androidFragmentSymbol = comp.GetTypeByMetadataName("AndroidX.Fragment.App.Fragment");
				_bindableAttributeSymbol = comp.GetTypeByMetadataName("Windows.UI.Xaml.Data.BindableAttribute");
				_iFrameworkElementSymbol = comp.GetTypeByMetadataName(XamlConstants.Types.IFrameworkElement);
				_frameworkElementSymbol = comp.GetTypeByMetadataName("Windows.UI.Xaml.FrameworkElement");
				_isUnoSolution = _context.GetMSBuildPropertyValue("_IsUnoUISolution") == "true";
				_analyzerSuppressions = context.GetMSBuildPropertyValue("XamlGeneratorAnalyzerSuppressionsProperty").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			}

#if NETFRAMEWORK
			public override void VisitNamedType(INamedTypeSymbol type)
			{
				_context.CancellationToken.ThrowIfCancellationRequested();

				foreach (var t in type.GetTypeMembers())
				{
					VisitNamedType(t);
				}

				ProcessType(type);
			}

			public override void VisitModule(IModuleSymbol symbol)
			{
				_context.CancellationToken.ThrowIfCancellationRequested();

				VisitNamespace(symbol.GlobalNamespace);
			}

			public override void VisitNamespace(INamespaceSymbol symbol)
			{
				_context.CancellationToken.ThrowIfCancellationRequested();

				foreach (var n in symbol.GetNamespaceMembers())
				{
					VisitNamespace(n);
				}

				foreach (var t in symbol.GetTypeMembers())
				{
					VisitNamedType(t);
				}
			}
#endif

			public void ProcessType(INamedTypeSymbol typeSymbol)
			{
				_context.CancellationToken.ThrowIfCancellationRequested();

				if (typeSymbol.TypeKind != TypeKind.Class)
				{
					return;
				}

				var isDependencyObject = typeSymbol.Interfaces.Any(t => SymbolEqualityComparer.Default.Equals(t, _dependencyObjectSymbol))
					&& (typeSymbol.BaseType?.GetAllInterfaces().None(t => SymbolEqualityComparer.Default.Equals(t, _dependencyObjectSymbol)) ?? true);

				if (isDependencyObject)
				{
					if (!_isUnoSolution)
					{
						if (typeSymbol.Is(_iosViewSymbol))
						{
							ReportDiagnostic(_context, Diagnostic.Create(_descriptor, typeSymbol.Locations[0], "UIKit.UIView"));
							return;
						}
						else if (typeSymbol.Is(_androidViewSymbol))
						{
							ReportDiagnostic(_context, Diagnostic.Create(_descriptor, typeSymbol.Locations[0], "Android.Views.View"));
							return;
						}
						else if (typeSymbol.Is(_macosViewSymbol))
						{
							ReportDiagnostic(_context, Diagnostic.Create(_descriptor, typeSymbol.Locations[0], "AppKit.NSView"));
							return;
						}
					}

					var builder = new IndentedStringBuilder();
					builder.AppendLineIndented("// <auto-generated>");
					builder.AppendLineIndented("// ******************************************************************");
					builder.AppendLineIndented("// This file has been generated by Uno.UI (DependencyObjectGenerator)");
					builder.AppendLineIndented("// ******************************************************************");
					builder.AppendLineIndented("// </auto-generated>");
					builder.AppendLine();
					builder.AppendLineIndented("#pragma warning disable 1591 // Ignore missing XML comment warnings");
					builder.AppendLineIndented($"using System;");
					builder.AppendLineIndented($"using System.Linq;");
					builder.AppendLineIndented($"using System.Collections.Generic;");
					builder.AppendLineIndented($"using System.Collections;");
					builder.AppendLineIndented($"using System.Diagnostics.CodeAnalysis;");
					builder.AppendLineIndented($"using Uno.Disposables;");
					builder.AppendLineIndented($"using System.Runtime.CompilerServices;");
					builder.AppendLineIndented($"using Uno.UI;");
					builder.AppendLineIndented($"using Uno.UI.Controls;");
					builder.AppendLineIndented($"using Uno.UI.DataBinding;");
					builder.AppendLineIndented($"using Windows.UI.Xaml;");
					builder.AppendLineIndented($"using Windows.UI.Xaml.Data;");
					builder.AppendLineIndented($"using Uno.Diagnostics.Eventing;");
					builder.AppendLineIndented("#if __MACOS__");
					builder.AppendLineIndented("using AppKit;");
					builder.AppendLineIndented("#endif");

					using (typeSymbol.ContainingNamespace.IsGlobalNamespace ? NullDisposable.Instance : builder.BlockInvariant($"namespace {typeSymbol.ContainingNamespace}"))
					{
						using (GenerateNestingContainers(builder, typeSymbol))
						{
							if (_bindableAttributeSymbol != null && typeSymbol.FindAttribute(_bindableAttributeSymbol) == null)
							{
								builder.AppendLineIndented(@"[global::Windows.UI.Xaml.Data.Bindable]");
							}

							AnalyzerSuppressionsGenerator.Generate(builder, _analyzerSuppressions);

							var internalDependencyObject = _isUnoSolution && !typeSymbol.IsSealed ? ", IDependencyObjectInternal" : "";

							using (builder.BlockInvariant($"partial class {typeSymbol.Name} : IDependencyObjectStoreProvider, IWeakReferenceProvider{internalDependencyObject}"))
							{
								GenerateDependencyObjectImplementation(typeSymbol, builder, hasDispatcherQueue: _dependencyObjectSymbol!.GetMembers("DispatcherQueue").Any());
								GenerateIBinderImplementation(typeSymbol, builder);
							}
						}
					}

					_context.AddSource(HashBuilder.BuildIDFromSymbol(typeSymbol), builder.ToString());
				}
			}

			private static IDisposable GenerateNestingContainers(IndentedStringBuilder builder, INamedTypeSymbol? typeSymbol)
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
				WriteViewDidMoveToWindow(typeSymbol, builder);

				WriteiOSMoveToSuperView(typeSymbol, builder);
				WriteMacOSViewWillMoveToSuperview(typeSymbol, builder);

				WriteDispose(typeSymbol, builder);
				WriteBinderImplementation(typeSymbol, builder);
			}

			private static void WriteToStringOverride(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var hasNoToString = typeSymbol
					.GetMethodsWithName("ToString")
					.None(m => IsNotDependencyObjectGeneratorSourceFile(m));

				if (hasNoToString)
				{
					builder.AppendIndented(@"public override string ToString() => GetType().FullName;");
				}
			}

			private void WriteiOSMoveToSuperView(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var isiosView = typeSymbol.Is(_iosViewSymbol);
				var hasNoWillMoveToSuperviewMethod = typeSymbol
					.GetMethodsWithName("WillMoveToSuperview")
					.None(m => IsNotDependencyObjectGeneratorSourceFile(m));

				var overridesWillMoveToSuperview = isiosView && hasNoWillMoveToSuperviewMethod;

				if (overridesWillMoveToSuperview)
				{
					builder.AppendMultiLineIndented(@"
						public override void WillMoveToSuperview(UIKit.UIView newsuper)
						{
							base.WillMoveToSuperview(newsuper);

							WillMoveToSuperviewPartial(newsuper);

							SyncBinder(newsuper, Window);
						}

						partial void WillMoveToSuperviewPartial(UIKit.UIView newsuper);
		
						private void SyncBinder(UIKit.UIView superview, UIKit.UIWindow window)
						{
							if(superview == null && window == null)
							{
								TemplatedParent = null;
							}
						}
					");
				}
				else
				{
					builder.AppendIndented($"// Skipped _iosViewSymbol: {typeSymbol.Is(_iosViewSymbol)}, hasNoWillMoveToSuperviewMethod: {hasNoWillMoveToSuperviewMethod}");
				}
			}

			private void WriteMacOSViewWillMoveToSuperview(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var isiosView = typeSymbol.Is(_macosViewSymbol);
				var hasNoWillMoveToSuperviewMethod = typeSymbol
					.GetMethodsWithName("ViewWillMoveToSuperview")
					.None(m => IsNotDependencyObjectGeneratorSourceFile(m));

				var overridesWillMoveToSuperview = isiosView && hasNoWillMoveToSuperviewMethod;

				if (overridesWillMoveToSuperview)
				{
					builder.AppendMultiLineIndented(@"
						public override void ViewWillMoveToSuperview(AppKit.NSView newsuper)
						{
							base.ViewWillMoveToSuperview(newsuper);

							WillMoveToSuperviewPartial(newsuper);

							SyncBinder(newsuper, Window);
						}

						partial void WillMoveToSuperviewPartial(AppKit.NSView newsuper);
		
						private void SyncBinder(AppKit.NSView superview, AppKit.NSWindow window)
						{
							if(superview == null && window == null)
							{
								TemplatedParent = null;
							}
						}
					");
				}
				else
				{
					builder.AppendIndented($"// Skipped _macosViewSymbol: {typeSymbol.Is(_macosViewSymbol)}, hasNoViewWillMoveToSuperviewMethod: {hasNoWillMoveToSuperviewMethod}");
					builder.AppendLine();
				}
			}

			private void WriteAndroidAttachedToWindow(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var isAndroidView = typeSymbol.Is(_androidViewSymbol);
				var isAndroidActivity = typeSymbol.Is(_androidActivitySymbol);
				var isAndroidFragment = typeSymbol.Is(_androidFragmentSymbol);
				var isUnoViewGroup = typeSymbol.Is(_unoViewgroupSymbol);
				var implementsIFrameworkElement = typeSymbol.Interfaces.Any(t => SymbolEqualityComparer.Default.Equals(t, _iFrameworkElementSymbol));
				var hasOverridesAttachedToWindowAndroid = isAndroidView &&
					typeSymbol
					.GetMethodsWithName("OnAttachedToWindow")
					.None(m => IsNotDependencyObjectGeneratorSourceFile(m));

				if (isAndroidView || isAndroidActivity || isAndroidFragment)
				{
					if (!isAndroidActivity && !isAndroidFragment)
					{
						WriteRegisterLoadActions(typeSymbol, builder);
					}

					builder.AppendMultiLineIndented($@"
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
				builder.AppendMultiLineIndented($@"
					// A list of actions to be executed on Load and Unload
					private List<(Action loaded, Action unloaded)> _loadActions = new List<(Action loaded, Action unloaded)>(2);

					/// <summary>
					/// Registers actions to be executed when the control is Loaded and Unloaded.
					/// </summary>
					/// <param name=""loaded""></param>
					/// <param name=""unloaded""></param>
					/// <returns></returns>
					/// <remarks>The loaded action may be executed immediately if the control is already loaded.</remarks>
					public IDisposable RegisterLoadActions(Action loaded, Action unloaded)
					{{
						var actions = (loaded, unloaded);

						_loadActions.Add(actions);

#if __ANDROID__
						if(this.IsLoaded())
#elif __IOS__ || __MACOS__
						if(Window != null)
#else
#error Unsupported platform
#endif
						{{
							loaded();
						}}

						return Disposable.Create(() => _loadActions.Remove(actions));
					}}
				");
			}

			private void WriteAttachToWindow(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var hasOverridesAttachedToWindowiOS = typeSymbol.Is(_iosViewSymbol) &&
									typeSymbol
									.GetMethodsWithName("MovedToWindow")
									.None(m => IsNotDependencyObjectGeneratorSourceFile(m));

				if (hasOverridesAttachedToWindowiOS)
				{
					WriteRegisterLoadActions(typeSymbol, builder);

					builder.AppendMultiLineIndented($@"
						public override void MovedToWindow()
						{{
							base.MovedToWindow();

							if(Window != null)
							{{
								_loadActions.ForEach(a => a.loaded());
								OnAttachedToWindowPartial();
							}}
							else
							{{
								_loadActions.ForEach(a => a.unloaded());
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
					builder.AppendIndented($@"// hasOverridesAttachedToWindowiOS=false");
				}
			}

			private void WriteViewDidMoveToWindow(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var hasOverridesAttachedToWindowiOS = typeSymbol.Is(_macosViewSymbol) &&
									typeSymbol
									.GetMethodsWithName("ViewDidMoveToWindow")
									.Where(m => IsNotDependencyObjectGeneratorSourceFile(m))
									.None();

				if (hasOverridesAttachedToWindowiOS)
				{
					WriteRegisterLoadActions(typeSymbol, builder);

					builder.AppendMultiLineIndented($@"
						public override void ViewDidMoveToWindow()
						{{
							base.ViewDidMoveToWindow();

							if(Window != null)
							{{
								_loadActions.ForEach(a => a.loaded());
								OnAttachedToWindowPartial();
							}}
							else
							{{
								_loadActions.ForEach(a => a.unloaded());
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
					builder.AppendIndented($@"// hasOverridesAttachedToWindowiOS=false");
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
					builder.AppendMultiLineIndented($@"
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

					public event Windows.Foundation.TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

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

					/// <summary>
					/// Obsolete method kept for binary compatibility
					/// </summary>
					[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
					[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
					public void ClearBindings()
					{{
						__Store.ClearBindings();
					}}

					/// <summary>
					/// Obsolete method kept for binary compatibility
					/// </summary>
					[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
					[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
					public void RestoreBindings()
					{{
						__Store.RestoreBindings();
					}}

					/// <summary>
					/// Obsolete method kept for binary compatibility
					/// </summary>
					[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
					[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
					public void ApplyCompiledBindings()
					{{
					}}

					private global::Uno.UI.DataBinding.ManagedWeakReference _selfWeakReference;
					global::Uno.UI.DataBinding.ManagedWeakReference IWeakReferenceProvider.WeakReference 
					{{
						get
						{{
							if(_selfWeakReference == null)
							{{
								_selfWeakReference = global::Uno.UI.DataBinding.WeakReferencePool.RentSelfWeakReference(this);
							}}
							
							return _selfWeakReference;
						}}
					}}
				";

				builder.AppendMultiLineIndented(content);
			}

			private void WriteDispose(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder)
			{
				var hasDispose = typeSymbol.Is(_iosViewSymbol) || typeSymbol.Is(_macosViewSymbol);

				if (hasDispose)
				{
					builder.AppendMultiLineIndented($@"
#if __IOS__ || __MACOS__
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

#if __IOS__
							var subviews = Subviews;

							if (subviews.Length > 0)
							{{
								BinderCollector.RequestCollect();
								foreach (var v in subviews)
								{{
									v.RemoveFromSuperview();
								}}
							}}
#elif __MACOS__
							// avoids the managed array (and items) allocation(s) since we do not need them
							if (this.GetSubviewsCount() > 0)
							{{
								BinderCollector.RequestCollect();

								// avoids multiple native calls to remove subviews
								Subviews = Array.Empty<NSView>();
							}}
#endif

							base.Dispose(disposing);

							_isDisposed = true;
						}}
						else
						{{
							GC.ReRegisterForFinalize(this);

#if !(NET6_0_OR_GREATER && __MACOS__)
							// net6.0-macos uses CoreCLR (not mono) and the notification mechanism is different
							// workaround for mono's https://github.com/xamarin/xamarin-macios/issues/15089
							NSObjectMemoryRepresentation.RemoveInFinalizerQueueFlag(this);
#endif
							Dispatcher.RunIdleAsync(_ => Dispose());
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
				string dataContextChangedInvokeArgument;
				if (typeSymbol.Is(_frameworkElementSymbol))
				{
					// We can pass 'this' safely to a parameter of type FrameworkElement.
					dataContextChangedInvokeArgument = "this";
				}
				else if (_frameworkElementSymbol.Is(typeSymbol))
				{
					// Example: Border -> FrameworkElement -> BindableView
					// If we have a BindableView, it may or may not be FrameworkElement.
					dataContextChangedInvokeArgument = "this as FrameworkElement";
				}
				else
				{
					// This can't be a FrameworkElement. Just pass null.
					// Passing `this as FrameworkElement` will produce a compile-time error.
					// error CS0039: Cannot convert type '{0}' to '{1}' via a reference conversion, boxing conversion, unboxing conversion, wrapping conversion, or null type conversion
					dataContextChangedInvokeArgument = "null";
				}

				builder.AppendMultiLineIndented($@"

#region DataContext DependencyProperty

					public object DataContext
					{{
						get => GetValue(DataContextProperty);
						set => SetValue(DataContextProperty, value);
					}}

					// Using a DependencyProperty as the backing store for DataContext.  This enables animation, styling, binding, etc...
					public static DependencyProperty DataContextProperty {{ get ; }} =
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
						DataContextChanged?.Invoke({dataContextChangedInvokeArgument}, new DataContextChangedEventArgs(DataContext));
					}}

#endregion

#region TemplatedParent DependencyProperty

					public DependencyObject TemplatedParent
					{{
						get => (DependencyObject)GetValue(TemplatedParentProperty);
						set => SetValue(TemplatedParentProperty, value);
					}}

					// Using a DependencyProperty as the backing store for TemplatedParent.  This enables animation, styling, binding, etc...
					public static DependencyProperty TemplatedParentProperty {{ get ; }} =
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
					.GetMethodsWithName("Equals")
					.None(m => IsNotDependencyObjectGeneratorSourceFile(m))
					&& (typeSymbol.BaseType?.GetMethodsWithName("Equals").None(m => m.IsSealed) ?? true);

				if (hasEqualityOverride && typeSymbol.Is(_androidViewSymbol))
				{
					builder.AppendMultiLineIndented($@"
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

			private void GenerateDependencyObjectImplementation(INamedTypeSymbol typeSymbol, IndentedStringBuilder builder, bool hasDispatcherQueue)
			{
				builder.AppendLineIndented(@"private DependencyObjectStore __storeBackingField;");
				builder.AppendLineIndented(@"public Windows.UI.Core.CoreDispatcher Dispatcher => Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher;");

				if (hasDispatcherQueue)
				{
					builder.AppendLineIndented(@"public global::Microsoft.UI.Dispatching.DispatcherQueue DispatcherQueue { get; } = global::Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();");
				}

				using (builder.BlockInvariant($"private DependencyObjectStore __Store"))
				{
					using (builder.BlockInvariant($"get"))
					{
						using (builder.BlockInvariant($"if(__storeBackingField == null)"))
						{
							builder.AppendLineIndented("__storeBackingField = new DependencyObjectStore(this, DataContextProperty, TemplatedParentProperty);");
							builder.AppendLineIndented("__InitializeBinder();");
						}

						builder.AppendLineIndented("return __storeBackingField;");
					}
				}
				builder.AppendLineIndented(@"public bool IsStoreInitialized => __storeBackingField != null;");

				builder.AppendLineIndented(@"DependencyObjectStore IDependencyObjectStoreProvider.Store => __Store;");

				builder.AppendLineIndented("public object GetValue(DependencyProperty dp) => __Store.GetValue(dp);");

				builder.AppendLineIndented("public void SetValue(DependencyProperty dp, object value) => __Store.SetValue(dp, value);");

				builder.AppendLineIndented("public void ClearValue(DependencyProperty dp) => __Store.ClearValue(dp);");

				builder.AppendLineIndented("public object ReadLocalValue(DependencyProperty dp) => __Store.ReadLocalValue(dp);");

				builder.AppendLineIndented("public object GetAnimationBaseValue(DependencyProperty dp) => __Store.GetAnimationBaseValue(dp);");

				builder.AppendLineIndented("public long RegisterPropertyChangedCallback(DependencyProperty dp, DependencyPropertyChangedCallback callback) => __Store.RegisterPropertyChangedCallback(dp, callback);");

				builder.AppendLineIndented("public void UnregisterPropertyChangedCallback(DependencyProperty dp, long token) => __Store.UnregisterPropertyChangedCallback(dp, token);");

				if (_isUnoSolution && !typeSymbol.IsSealed)
				{
					builder.AppendLineIndented("void IDependencyObjectInternal.OnPropertyChanged2(global::Windows.UI.Xaml.DependencyPropertyChangedEventArgs args) => OnPropertyChanged2(args);");

					if (typeSymbol.GetMethodsWithName("OnPropertyChanged2").None(m => m.Parameters.Length == 1))
					{
						builder.AppendLineIndented("internal virtual void OnPropertyChanged2(global::Windows.UI.Xaml.DependencyPropertyChangedEventArgs args) { }");
					}
				}
			}
		}

#if !NETFRAMEWORK
		private sealed class ClassSyntaxReceiver : ISyntaxContextReceiver
		{
			public HashSet<INamedTypeSymbol> NamedTypeSymbols { get; } = new(SymbolEqualityComparer.Default);

			public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
			{
				if (context.Node.IsKind(SyntaxKind.ClassDeclaration))
				{
					if (context.SemanticModel.GetDeclaredSymbol(context.Node) is INamedTypeSymbol symbol)
					{
						NamedTypeSymbols.Add(symbol);
					}
				}
			}
		}
#endif
	}
}
