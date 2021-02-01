﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
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
	public class DependencyPropertyGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
		}

		public void Execute(GeneratorExecutionContext context)
		{
			DependenciesInitializer.Init(context);

			if (PlatformHelper.IsValidPlatform(context))
			{
				var visitor = new SerializationMethodsGenerator(context);
				visitor.Visit(context.Compilation.SourceModule);
			}
		}

		private class SerializationMethodsGenerator : SymbolVisitor
		{
			private readonly GeneratorExecutionContext _context;
			private readonly INamedTypeSymbol _generatedDependencyPropertyAttributeSymbol;
			private readonly INamedTypeSymbol _dependencyPropertyChangedEventArgsSymbol;
			private readonly INamedTypeSymbol _dependencyObjectSymbol;

			public SerializationMethodsGenerator(GeneratorExecutionContext context)
			{
				_context = context;

				var comp = context.Compilation;

				_dependencyObjectSymbol = comp.GetTypeByMetadataName(XamlConstants.Types.DependencyObject)
					?? throw new Exception("Unable to find " + XamlConstants.Types.DependencyObject);
				_generatedDependencyPropertyAttributeSymbol = comp.GetTypeByMetadataName("Uno.UI.Xaml.GeneratedDependencyPropertyAttribute")
					?? throw new Exception("Unable to find Uno.UI.Xaml.GeneratedDependencyPropertyAttribute");
				_dependencyPropertyChangedEventArgsSymbol = comp.GetTypeByMetadataName("Windows.UI.Xaml.DependencyPropertyChangedEventArgs")
					?? throw new Exception("Unable to find Windows.UI.Xaml.DependencyPropertyChangedEventArgs");
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
				var isDependencyObject = typeSymbol.GetAllInterfaces().Any(t => SymbolEqualityComparer.Default.Equals(t, _dependencyObjectSymbol));

				if ((isDependencyObject || typeSymbol.IsStatic) && typeSymbol.TypeKind == TypeKind.Class)
				{
					var hasGeneratedProperties =
						typeSymbol.GetProperties().Any(p => p.FindAttribute(_generatedDependencyPropertyAttributeSymbol) != null)
						|| typeSymbol.GetFields().Any(p => p.FindAttribute(_generatedDependencyPropertyAttributeSymbol) != null);

					if (hasGeneratedProperties)
					{
						var builder = new IndentedStringBuilder();
						builder.AppendLineInvariant("// <auto-generated>");
						builder.AppendLineInvariant("// ******************************************************************");
						builder.AppendLineInvariant("// This file has been generated by Uno.UI (DependencyPropertyGenerator)");
						builder.AppendLineInvariant("// ******************************************************************");
						builder.AppendLineInvariant("// </auto-generated>");
						builder.AppendLine();
						builder.AppendLineInvariant("#pragma warning disable 1591 // Ignore missing XML comment warnings");
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

						var attachedPropertiesBackingFieldStatements = new Dictionary<INamedTypeSymbol, List<string>>();

						using (builder.BlockInvariant($"namespace {typeSymbol.ContainingNamespace}"))
						{
							using (GenerateNestingContainers(builder, typeSymbol))
							{
								using (builder.BlockInvariant($"{typeSymbol.GetAccessibilityAsCodeString()} partial class {typeSymbol.Name}"))
								{
									foreach (var memberSymbol in typeSymbol.GetMembers())
									{
										if (memberSymbol.FindAttribute(_generatedDependencyPropertyAttributeSymbol) is AttributeData attribute)
										{
											var isAttached = GetBooleanAttributeValue(attribute, "Attached", false);

											if (isAttached)
											{
												GenerateAttachedProperty(builder, typeSymbol, memberSymbol, attribute, attachedPropertiesBackingFieldStatements);
											}
											else
											{
												GenerateProperty(builder, typeSymbol, memberSymbol, attribute);
											}
										}
									}
								}
							}
						}

						foreach (var backingFieldType in attachedPropertiesBackingFieldStatements)
						{
							using (builder.BlockInvariant($"namespace {backingFieldType.Key.ContainingNamespace}"))
							{
								using (GenerateNestingContainers(builder, backingFieldType.Key))
								{
									using (builder.BlockInvariant($"partial class {backingFieldType.Key.Name}"))
									{
										foreach (var statement in backingFieldType.Value)
										{
											builder.AppendLineInvariant(statement);
										}
									}
								}
							}
						}

						_context.AddSource(HashBuilder.BuildIDFromSymbol(typeSymbol), builder.ToString());
					}
				}
			}

			private void GenerateAttachedProperty(IndentedStringBuilder builder, INamedTypeSymbol ownerType, ISymbol memberSymbol, AttributeData attribute, Dictionary<INamedTypeSymbol, List<string>> backingFieldStatements)
			{
				var propertyName = memberSymbol.Name.TrimEnd("Property", StringComparison.Ordinal);

				var getMethodSymbol = ownerType.GetMethods().FirstOrDefault(m => m.Name == "Get" + propertyName);
				var setMethodSymbol = ownerType.GetMethods().FirstOrDefault(m => m.Name == "Set" + propertyName);

				if (getMethodSymbol == null)
				{
					builder.AppendLineInvariant($"#error unable to find getter method for {propertyName} on {ownerType}");
					return;
				}

				var attachedBackingFieldOwner = GetAttributeValue(attribute, "AttachedBackingFieldOwner");
				var metadataOptions = GetAttributeValue(attribute, "Options")?.Value.Value?.ToString() ?? "0";
				var coerceCallback = GetBooleanAttributeValue(attribute, "CoerceCallback", false);
				var changedCallback = GetBooleanAttributeValue(attribute, "ChangedCallback", false);
				var localCache = GetBooleanAttributeValue(attribute, "LocalCache", true);
				var defaultValue = GetAttributeValue(attribute, "DefaultValue");
				var changedCallbackName = GetAttributeValue(attribute, "ChangedCallbackName")?.Value.Value?.ToString();

				var propertyTypeSymbol = getMethodSymbol.ReturnType;
				var propertyTargetSymbol = getMethodSymbol.Parameters.First().Type;
				var propertyOwnerType = getMethodSymbol.ContainingType;
				var propertyTypeName = propertyTypeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
				var propertyOwnerTypeName = propertyOwnerType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
				var propertyTargetName = propertyTargetSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

				var attachedBackingFieldOwnerSymbol = attachedBackingFieldOwner?.Value.Value as INamedTypeSymbol;
				var backingFieldOwnerTypeName = attachedBackingFieldOwnerSymbol != null
					? attachedBackingFieldOwnerSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)
					: "";
				var backingFieldName = $"__{propertyOwnerType.Name}_{propertyName}PropertyBackingField";

				ValidateInvocation(builder, memberSymbol, $"Create{propertyName}Property");
				ValidateInvocation(builder, getMethodSymbol, $"Get{propertyName}Value");
				ValidateInvocation(builder, setMethodSymbol, $"Set{propertyName}Value");

				builder.AppendLineInvariant($"");
				builder.AppendLineInvariant($"");
				builder.AppendLineInvariant($"#region {propertyName} Dependency Property");

				using (builder.BlockInvariant($"private static {propertyTypeName} Get{propertyName}Value({propertyTargetName} instance)"))
				{
					if (localCache)
					{
						if(!attachedBackingFieldOwner.HasValue)
						{
							builder.AppendLineInvariant($"#error local cache methods must have AttachedBackingFieldOwner set");
							return;
						}

						if (attachedBackingFieldOwnerSymbol != null)
						{
							if (!backingFieldStatements.TryGetValue(attachedBackingFieldOwnerSymbol, out var statementList))
							{
								statementList = backingFieldStatements[attachedBackingFieldOwnerSymbol] = new List<string>();
							}

							statementList.Add($"internal bool {backingFieldName}Set;");
							statementList.Add($"internal {propertyTypeName} {backingFieldName};");
						}

						using (builder.BlockInvariant($"if(instance is {backingFieldOwnerTypeName} backingFieldOwnerInstance)"))
						{
							using (builder.BlockInvariant($"if (!backingFieldOwnerInstance.{backingFieldName}Set)"))
							{
								builder.AppendLineInvariant($"backingFieldOwnerInstance.{backingFieldName} = ({propertyTypeName})instance.GetValue({propertyOwnerTypeName}.{propertyName}Property);");
								builder.AppendLineInvariant($"backingFieldOwnerInstance.{backingFieldName}Set = true;");
							}

							builder.AppendLineInvariant($"return backingFieldOwnerInstance.{backingFieldName};");
						}
						builder.AppendLineInvariant($"else");
						using (builder.BlockInvariant(""))
						{
							builder.AppendLineInvariant($"return ({propertyTypeName})instance.GetValue({propertyOwnerTypeName}.{propertyName}Property);");
						}
					}
					else
					{
						builder.AppendLineInvariant($"return instance.GetValue({propertyOwnerTypeName}.{propertyName}Property);");
					}
				}

				builder.AppendLineInvariant($"private static void Set{propertyName}Value({propertyTargetName} instance, {propertyTypeName} value) => instance.SetValue({propertyOwnerTypeName}.{propertyName}Property, value);");

				GeneratePropertyStorage(builder, propertyName);

				builder.AppendLineInvariant($"DependencyProperty.RegisterAttached(");

				BuildPropertyParameters(builder, propertyOwnerType, propertyOwnerTypeName, propertyName, propertyTypeName, metadataOptions, defaultValue);

				if (localCache)
				{
					using (builder.BlockInvariant($"\t\t, backingFieldUpdateCallback: (instance, newValue) => "))
					{
						using (builder.BlockInvariant($"if(instance is {backingFieldOwnerTypeName} backingFieldOwnerInstance)"))
						{
							builder.AppendLineInvariant($"backingFieldOwnerInstance.{backingFieldName} = ({propertyTypeName})instance.GetValue({propertyOwnerTypeName}.{propertyName}Property);");
							builder.AppendLineInvariant($"backingFieldOwnerInstance.{backingFieldName}Set = true;");
						}
					}
				}

				if (coerceCallback || propertyOwnerType.GetMethods().Any(m => m.Name == "Coerce" + propertyName))
				{
					builder.AppendLineInvariant($"\t\t, coerceValueCallback: (instance, baseValue) => Coerce{propertyName}(instance, ({propertyTypeName})baseValue)");
				}

				changedCallbackName ??= $"On{propertyName}Changed";
				var propertyChangedMethod = propertyOwnerType.GetMethods().FirstOrDefault(m => m.Name == changedCallbackName);
				if (changedCallback || propertyChangedMethod != null)
				{
					var isDPChangedEventArgsParam = SymbolEqualityComparer.Default.Equals(propertyChangedMethod?.Parameters.ElementAtOrDefault(1)?.Type, _dependencyPropertyChangedEventArgsSymbol);
					if (isDPChangedEventArgsParam)
					{
						builder.AppendLineInvariant($"\t\t, propertyChangedCallback: (instance, args) => {changedCallbackName}(instance, args)");
					}
					else
					{
						builder.AppendLineInvariant($"\t\t, propertyChangedCallback: (instance, args) => {changedCallbackName}(instance, ({propertyTypeName})args.OldValue, ({propertyTypeName})args.NewValue)");
					}
				}


				builder.AppendLineInvariant($"));");

				builder.AppendLineInvariant($"#endregion");
			}

			static KeyValuePair<string, TypedConstant>? GetAttributeValue(AttributeData attribute, string parameterName)
				=> attribute?.NamedArguments.FirstOrDefault(kvp => kvp.Key == parameterName);

			static bool GetBooleanAttributeValue(AttributeData attribute, string parameterName, bool defaultValue = true)
				=> attribute?.NamedArguments.FirstOrDefault(kvp => kvp.Key == parameterName).Value.Value is bool value ? value : defaultValue;

			private void GenerateProperty(IndentedStringBuilder builder, INamedTypeSymbol ownerType, ISymbol memberSymbol, AttributeData attribute)
			{
				var propertyName = memberSymbol.Name.TrimEnd("Property", StringComparison.Ordinal);

				var propertySymbol = ownerType.GetProperties().FirstOrDefault(m => m.Name == propertyName);

				if(propertySymbol == null)
				{
					builder.AppendLineInvariant($"#error unable to find property {propertyName} on {ownerType}");
					return;
				}

				var propertyTypeName = propertySymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
				var containingTypeName = propertySymbol.ContainingType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
				var changedCallbackName = GetAttributeValue(attribute, "ChangedCallbackName")?.Value.Value?.ToString();
				var metadataOptions = GetAttributeValue(attribute, "Options")?.Value.Value?.ToString() ?? "0";
				var coerceCallback = GetBooleanAttributeValue(attribute, "CoerceCallback", false);
				var changedCallback = GetBooleanAttributeValue(attribute, "ChangedCallback", false);
				var localCache = GetBooleanAttributeValue(attribute, "LocalCache", true);
				var defaultValue = GetAttributeValue(attribute, "DefaultValue");

				ValidateInvocation(builder, propertySymbol, $"Get{propertyName}Value", $"Set{propertyName}Value");
				ValidateInvocation(builder, memberSymbol, $"Create{propertyName}Property");

				builder.AppendLineInvariant($"");
				builder.AppendLineInvariant($"");
				builder.AppendLineInvariant($"#region {propertyName} Dependency Property");

				if (propertySymbol.GetMethod != null)
				{
					using (builder.BlockInvariant($"private {propertyTypeName} Get{propertyName}Value()"))
					{
						if (localCache)
						{
							using (builder.BlockInvariant($"if (!_{propertyName}PropertyBackingFieldSet)"))
							{
								builder.AppendLineInvariant($"_{propertyName}PropertyBackingField = ({propertyTypeName})GetValue({propertyName}Property);");
								builder.AppendLineInvariant($"_{propertyName}PropertyBackingFieldSet = true;");
							}

							builder.AppendLineInvariant($"return _{propertyName}PropertyBackingField;");
						}
						else
						{
							builder.AppendLineInvariant($"return ({propertyTypeName})GetValue({propertyName}Property);");
						}
					}
				}

				if (propertySymbol.SetMethod != null)
				{
					builder.AppendLineInvariant($"private void Set{propertyName}Value({propertyTypeName} value) => SetValue({propertyName}Property, value);");
				}

				if (localCache)
				{
					builder.AppendLineInvariant($"private bool _{propertyName}PropertyBackingFieldSet = false;");
					builder.AppendLineInvariant($"private {propertyTypeName} _{propertyName}PropertyBackingField;");
				}

				GeneratePropertyStorage(builder, propertyName);

				builder.AppendLineInvariant($"DependencyProperty.Register(");

				BuildPropertyParameters(builder, propertySymbol.ContainingType, containingTypeName, propertyName, propertyTypeName, metadataOptions, defaultValue);

				if (localCache)
				{
					// Use a explicit delegate to avoid C# delegate caching (the delegate is kept in the DP, no need to cache it in the class)
					builder.AppendLineInvariant($"\t\t, backingFieldUpdateCallback: On{propertyName}BackingFieldUpdate");
				}

				if (coerceCallback || propertySymbol.ContainingType.GetMethods().Any(m => m.Name == "Coerce" + propertyName))
				{
					builder.AppendLineInvariant($"\t\t, coerceValueCallback: (instance, baseValue) => (({containingTypeName})instance).Coerce{propertyName}(baseValue)");
				}

				changedCallbackName ??= $"On{propertyName}Changed";

				var propertyChangedMethod = propertySymbol.ContainingType.GetMethods().FirstOrDefault(m => m.Name == changedCallbackName);
				if (changedCallback || propertyChangedMethod != null)
				{
					var isDPChangedEventArgsParam = SymbolEqualityComparer.Default.Equals(propertyChangedMethod?.Parameters.FirstOrDefault()?.Type, _dependencyPropertyChangedEventArgsSymbol);
					if (isDPChangedEventArgsParam)
					{
						builder.AppendLineInvariant($"\t\t, propertyChangedCallback: (instance, args) => (({containingTypeName})instance).{changedCallbackName}(args)");
					}
					else
					{
						builder.AppendLineInvariant($"\t\t, propertyChangedCallback: (instance, args) => (({containingTypeName})instance).{changedCallbackName}(({propertyTypeName})args.OldValue, ({propertyTypeName})args.NewValue)");
					}
				}

				builder.AppendLineInvariant($"));");

				if (localCache)
				{
					using (builder.BlockInvariant($"private static void On{propertyName}BackingFieldUpdate(object instance, object newValue)"))
					{
						builder.AppendLineInvariant($"var typedInstance = instance as {containingTypeName};");
						builder.AppendLineInvariant($"typedInstance._{propertyName}PropertyBackingField = ({propertyTypeName})newValue;");
						builder.AppendLineInvariant($"typedInstance._{propertyName}PropertyBackingFieldSet = true;");
					}
				}

				builder.AppendLineInvariant($"#endregion");
			}

			private void ValidateInvocation(IndentedStringBuilder builder, ISymbol propertySymbol, params string[] invocations)
			{
				if (propertySymbol.Locations.FirstOrDefault() is Location location)
				{
					if (location.SourceTree != null)
					{
						var node = location.SourceTree.GetRoot().FindNode(location.SourceSpan);
						var syntaxNodeContent = node.ToString();

						if (!invocations.All(l => syntaxNodeContent.Contains(l, StringComparison.Ordinal)))
						{
							var invocationsMessage = string.Join(", ", invocations);
							builder.AppendLineInvariant("{0}", $"#error unable to find some of the following statements {invocationsMessage} in {propertySymbol}");
						}
					}
				}
			}

			private static void GeneratePropertyStorage(IndentedStringBuilder builder, string propertyName)
			{
				builder.AppendLineInvariant($"/// <summary>");
				builder.AppendLineInvariant($"/// Generated method used to create the <see cref=\"{propertyName}Property\" /> member value");
				builder.AppendLineInvariant($"/// </summary>");
				builder.AppendLineInvariant($"private static global::Windows.UI.Xaml.DependencyProperty Create{propertyName}Property() => ");
			}

			private static void BuildPropertyParameters(
				IndentedStringBuilder builder,
				INamedTypeSymbol ownerType,
				string containingTypeName,
				string propertyName,
				string propertyTypeName,
				string? metadataOptions,
				KeyValuePair<string, TypedConstant>? defaultValue)
			{
				builder.AppendLineInvariant($"\tname: \"{propertyName}\",");
				builder.AppendLineInvariant($"\tpropertyType: typeof({propertyTypeName}),");
				builder.AppendLineInvariant($"\townerType: typeof({containingTypeName}),");
				builder.AppendLineInvariant($"\ttypeMetadata: new global::Windows.UI.Xaml.FrameworkPropertyMetadata(");

				var defaultValueMethodName = $"Get{propertyName}DefaultValue()";
				if (defaultValue.HasValue && !string.IsNullOrEmpty(defaultValue.Value.Key))
				{
					if (ownerType.GetMethods().Any(m => m.Name == defaultValueMethodName))
					{
						builder.AppendLineInvariant($"#error The generated property {propertyName} cannot contains both a DefaultValue and the {defaultValueMethodName} method.");
					}

					var defaultValueString = defaultValue.Value.Value.Value switch
					{
						string s => $"\"{s}\"",
						double d when double.IsPositiveInfinity(d) => "double.PositiveInfinity",
						double d when double.IsNegativeInfinity(d) => "double.NegativInfinity",
						double d when double.IsNaN(d) => "double.NaN",
						double d => d.ToString(CultureInfo.InvariantCulture),
						float d when float.IsPositiveInfinity(d) => "float.PositiveInfinity",
						float d when float.IsNegativeInfinity(d) => "float.NegativInfinity",
						float d when float.IsNaN(d) => "float.NaN",
						float d => d.ToString(CultureInfo.InvariantCulture) + "f",
						bool d => d.ToString(CultureInfo.InvariantCulture).ToLowerInvariant(),
						var o => o?.ToString() ?? "null",
					};

					builder.AppendLineInvariant($"\t\tdefaultValue: ({propertyTypeName}){defaultValueString} /* {defaultValueMethodName}, {ownerType} */");
				}
				else
				{
					builder.AppendLineInvariant($"\t\tdefaultValue: Get{propertyName}DefaultValue()");
				}

				if (metadataOptions != "0")
				{
					builder.AppendLineInvariant($"\t\t, options: (global::Windows.UI.Xaml.FrameworkPropertyMetadataOptions){metadataOptions}");
				}
			}

			private IDisposable GenerateNestingContainers(IndentedStringBuilder builder, INamedTypeSymbol? typeSymbol)
			{
				var disposables = new List<IDisposable>();

				var currentSymbol = typeSymbol;

				while (currentSymbol?.ContainingType != null)
				{
					disposables.Add(builder.BlockInvariant($"partial class {typeSymbol?.ContainingType.Name}"));

					currentSymbol = currentSymbol?.ContainingType;
				}

				return new DisposableAction(() => disposables.ForEach(d => d.Dispose()));
			}
		}
	}
}
