﻿#nullable enable

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Uno.Extensions;
using Uno.UI.SourceGenerators.XamlGenerator;

namespace Uno.Roslyn
{
	internal class RoslynMetadataHelper
	{
		private readonly Func<string, ITypeSymbol?> _findTypeByFullName;
		private readonly Func<INamedTypeSymbol, IPropertySymbol?> _findContentProperty;
		private readonly Func<INamedTypeSymbol?, string, bool> _isAttachedProperty;
		private readonly Func<INamedTypeSymbol, string, INamedTypeSymbol> _getAttachedPropertyType;
		private readonly Func<INamedTypeSymbol, bool> _isTypeImplemented;
		private readonly Func<INamedTypeSymbol?, string, INamedTypeSymbol?>? _findPropertyTypeByOwnerSymbol;
		private readonly Func<INamedTypeSymbol, string[]>? _findLocalizableDeclaredProperties;
		private readonly Func<INamedTypeSymbol?, string, IEventSymbol?>? _findEventType;

		public Compilation Compilation { get; }

		public string AssemblyName => Compilation.AssemblyName!;

		public RoslynMetadataHelper(GeneratorExecutionContext context)
		{
			Compilation = context.Compilation;

			_findTypeByFullName = Funcs.Create<string, ITypeSymbol?>(SourceFindTypeByFullName).AsLockedMemoized();
			_findContentProperty = Funcs.Create<INamedTypeSymbol, IPropertySymbol?>(SourceFindContentProperty).AsLockedMemoized();
			_isAttachedProperty = Funcs.Create<INamedTypeSymbol?, string, bool>(SourceIsAttachedProperty).AsLockedMemoized();
			_getAttachedPropertyType = Funcs.Create<INamedTypeSymbol, string, INamedTypeSymbol>(SourceGetAttachedPropertyType).AsLockedMemoized();
			_isTypeImplemented = Funcs.Create<INamedTypeSymbol, bool>(SourceIsTypeImplemented).AsLockedMemoized();
			_findPropertyTypeByOwnerSymbol = Funcs.Create<INamedTypeSymbol?, string, INamedTypeSymbol?>(SourceFindPropertyTypeByOwnerSymbol).AsLockedMemoized();
			_findLocalizableDeclaredProperties = Funcs.Create<INamedTypeSymbol, string[]>(SourceFindLocalizableDeclaredProperties).AsLockedMemoized();
			_findEventType = Funcs.Create<INamedTypeSymbol?, string, IEventSymbol?>(SourceFindEventType).AsLockedMemoized();
		}

		private static void ThrowOnErrorSymbol(ISymbol symbol)
		{
			if (symbol is IErrorTypeSymbol errorTypeSymbol)
			{
				var candidates = string.Join(";", errorTypeSymbol.CandidateSymbols);
				var location = symbol.Locations.FirstOrDefault()?.ToString() ?? "Unknown";

				throw new InvalidOperationException(
					$"Unable to resolve {symbol} (Reason: {errorTypeSymbol.CandidateReason}, Location:{location}, Candidates: {candidates})"
				);
			}
		}

		public ITypeSymbol? FindTypeByFullName(string fullName)
		{
			return _findTypeByFullName(fullName);
		}

		private ITypeSymbol? SourceFindTypeByFullName(string fullName)
		{
			var symbol = Compilation.GetTypeByMetadataName(fullName);

			if (symbol?.Kind == SymbolKind.ErrorType)
			{
				symbol = null;
			}

			return symbol;
		}

		public IPropertySymbol? FindContentProperty(INamedTypeSymbol elementType)
		{
			return _findContentProperty(elementType);
		}

		private static IPropertySymbol? SourceFindContentProperty(INamedTypeSymbol elementType)
		{
			var data = elementType
				.GetAllAttributes()
				.FirstOrDefault(t => t.AttributeClass?.GetFullyQualifiedTypeExcludingGlobal() == XamlConstants.Types.ContentPropertyAttribute);
			if (data != null)
			{
				var nameProperty = data.NamedArguments.Where(f => f.Key == "Name").FirstOrDefault();
				if (nameProperty.Value.Value != null)
				{
					var name = nameProperty.Value.Value.ToString() ?? "";
					return elementType.GetPropertyWithName(name);
				}
			}
			return null;
		}

		public bool IsAttachedProperty(INamedTypeSymbol? declaringType, string name)
			=> _isAttachedProperty(declaringType, name);

		private static bool SourceIsAttachedProperty(INamedTypeSymbol? type, string name)
		{
			do
			{
				var property = type.GetPropertyWithName(name);
				if (property?.GetMethod?.IsStatic ?? false)
				{
					return true;
				}

				var setMethod = type?.GetFirstMethodWithName("Set" + name);
				if (setMethod is { IsStatic: true, Parameters.Length: 2 })
				{
					return true;
				}

				type = type?.BaseType;
				if (type == null || type.SpecialType == SpecialType.System_Object)
				{
					return false;
				}

			} while (true);
		}

		public INamedTypeSymbol GetAttachedPropertyType(INamedTypeSymbol type, string propertyName)
			=> _getAttachedPropertyType(type, propertyName);

		private static INamedTypeSymbol SourceGetAttachedPropertyType(INamedTypeSymbol? type, string name)
		{
			do
			{
				var setMethod = type?.GetFirstMethodWithName("Set" + name);

				if (setMethod != null && setMethod.IsStatic && setMethod.Parameters.Length == 2)
				{
					return (setMethod.Parameters[1].Type as INamedTypeSymbol)!;
				}
				type = type?.BaseType;

				if (type == null || type.SpecialType == SpecialType.System_Object)
				{
					throw new InvalidOperationException($"No valid setter found for attached property {name}");
				}

			} while (true);
		}

		public ITypeSymbol GetTypeByFullName(string fullName)
		{
			var symbol = FindTypeByFullName(fullName);

			if (symbol == null)
			{
				throw new InvalidOperationException($"Unable to find type {fullName}");
			}

			return symbol;
		}

		public bool IsTypeImplemented(INamedTypeSymbol type) => _isTypeImplemented(type);

		private static bool SourceIsTypeImplemented(INamedTypeSymbol type)
			=> type.GetAttributes().None(a => a.AttributeClass?.GetFullyQualifiedTypeExcludingGlobal() == XamlConstants.Types.NotImplementedAttribute);

		public INamedTypeSymbol? FindPropertyTypeByOwnerSymbol(INamedTypeSymbol? type, string propertyName) => _findPropertyTypeByOwnerSymbol!(type, propertyName);

		private INamedTypeSymbol? SourceFindPropertyTypeByOwnerSymbol(INamedTypeSymbol? type, string propertyName)
		{
			if (type != null && !string.IsNullOrEmpty(propertyName))
			{
				do
				{
					ThrowOnErrorSymbol(type);

					var resolvedType = type;

					var property = resolvedType.GetPropertyWithName(propertyName);
					var setMethod = resolvedType.GetFirstMethodWithName("Set" + propertyName);

					if (property != null)
					{
						if (property.Type.OriginalDefinition is { SpecialType: SpecialType.System_Nullable_T })
						{
							//TODO
							return (property.Type as INamedTypeSymbol)?.TypeArguments[0] as INamedTypeSymbol;
						}
						else
						{
							return property.Type as INamedTypeSymbol;
						}
					}
					else
					{
						if (setMethod != null)
						{
							return setMethod.Parameters.ElementAt(1).Type as INamedTypeSymbol;
						}
						else
						{
							var baseType = type.BaseType;

							if (baseType == null || baseType.SpecialType == SpecialType.System_Object)
							{
								return null;
							}

							type = baseType;
						}
					}
				} while (true);
			}
			else
			{
				return null;
			}
		}

		public string[] FindLocalizableDeclaredProperties(INamedTypeSymbol type) => _findLocalizableDeclaredProperties!(type);

		private string[] SourceFindLocalizableDeclaredProperties(INamedTypeSymbol type)
		{
			return type.GetProperties()
				.Where(p => !p.IsReadOnly &&
					p.DeclaredAccessibility == Accessibility.Public &&
					XamlFileGenerator.IsLocalizablePropertyType(p.Type as INamedTypeSymbol)
				)
				.Select(p => p.Name)
				.ToArray();
		}

		public IEventSymbol? FindEventType(INamedTypeSymbol? ownerType, string eventName)
			=> _findEventType!(ownerType, eventName);

		private IEventSymbol? SourceFindEventType(INamedTypeSymbol? ownerType, string eventName)
		{
			if (ownerType != null)
			{
				ThrowOnErrorSymbol(ownerType);

				do
				{
					foreach (var member in ownerType.GetMembers(eventName).OfType<IEventSymbol>())
					{
						return member;
					}

					ownerType = ownerType.BaseType;

					if (ownerType == null)
					{
						break;
					}

				} while (ownerType.SpecialType != SpecialType.System_Object);
			}

			return null;
		}
	}
}
