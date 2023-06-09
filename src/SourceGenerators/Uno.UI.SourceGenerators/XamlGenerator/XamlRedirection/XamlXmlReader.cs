﻿extern alias __uno;

using System;
using System.Xml;

namespace Uno.UI.SourceGenerators.XamlGenerator.XamlRedirection
{
	internal class XamlXmlReader : IDisposable
	{
		private __uno::Uno.Xaml.XamlXmlReader _unoReader;

		public XamlXmlReader(XmlReader document, XamlSchemaContext context, XamlXmlReaderSettings settings, __uno::Uno.Xaml.IsIncluded isIncluded)
		{
			_unoReader = new __uno::Uno.Xaml.XamlXmlReader(document, context.UnoInner, settings.UnoInner, isIncluded);
		}

		public bool DisableCaching => _unoReader.DisableCaching;

		public XamlNodeType NodeType => Convert(_unoReader.NodeType);

		private XamlNodeType Convert(__uno::Uno.Xaml.XamlNodeType source)
			=> source switch
			{
				__uno::Uno.Xaml.XamlNodeType.StartObject => XamlNodeType.StartObject,
				__uno::Uno.Xaml.XamlNodeType.GetObject => XamlNodeType.GetObject,
				__uno::Uno.Xaml.XamlNodeType.EndObject => XamlNodeType.EndObject,
				__uno::Uno.Xaml.XamlNodeType.StartMember => XamlNodeType.StartMember,
				__uno::Uno.Xaml.XamlNodeType.EndMember => XamlNodeType.EndMember,
				__uno::Uno.Xaml.XamlNodeType.Value => XamlNodeType.Value,
				__uno::Uno.Xaml.XamlNodeType.NamespaceDeclaration => XamlNodeType.NamespaceDeclaration,
				_ => XamlNodeType.None,
			};

		public object Value => _unoReader.Value;

		public XamlType Type => XamlType.FromType(_unoReader.Type);

		public int LineNumber => _unoReader.LineNumber;

		public int LinePosition => _unoReader.LinePosition;

		public XamlMember Member => XamlMember.FromMember(_unoReader.Member);

		public NamespaceDeclaration Namespace
			=> new NamespaceDeclaration(_unoReader.Namespace);

		public void Dispose() => ((IDisposable)_unoReader).Dispose();

		internal bool Read() => _unoReader.Read();

		internal bool PreserveWhitespace => _unoReader.PreserveWhitespace;
	}
}
