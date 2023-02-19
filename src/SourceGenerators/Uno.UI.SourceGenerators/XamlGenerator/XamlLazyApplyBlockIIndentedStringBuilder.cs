﻿#nullable enable

using Uno;
using Uno.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace Uno.UI.SourceGenerators.XamlGenerator
{

	internal class XamlLazyApplyBlockIIndentedStringBuilder : IIndentedStringBuilder, IDisposable
	{
		private bool _applyOpened;
		private readonly string _closureName;
		private readonly IIndentedStringBuilder _source;
		private IDisposable? _applyDisposable;
		private readonly string? _applyPrefix;
		private readonly string? _delegateType;
		private readonly IDisposable? _parentDisposable;
		private readonly bool _exposeContext;

		public XamlLazyApplyBlockIIndentedStringBuilder(
			IIndentedStringBuilder source,
			string closureName, string? applyPrefix,
			string? delegateType,
			bool exposeContext,
			IDisposable? parentDisposable = null)
		{
			_closureName = closureName;
			_source = source;
			_applyPrefix = applyPrefix;
			_delegateType = delegateType;
			_parentDisposable = parentDisposable;
			_exposeContext = exposeContext;
		}

		private void TryWriteApply()
		{
			if (!_applyOpened)
			{
				_applyOpened = true;

				IDisposable blockDisposable;

				var delegateString = !_delegateType.IsNullOrEmpty() ? "(" + _delegateType + ")" : "";

				if (_applyPrefix != null)
				{
					blockDisposable = _source.BlockInvariant(".{0}_XamlApply({2}({1} => ", _applyPrefix, _closureName, delegateString);
				}
				else if (_exposeContext)
				{
					// This syntax is used to avoid closing on __that and __namescope when running in HotReload.
					blockDisposable = _source.BlockInvariant(".GenericApply(__that, __nameScope, {1}(({0}, __that, __nameScope) => ", _closureName, delegateString);
				}
				else
				{
					blockDisposable = _source.BlockInvariant(".GenericApply({1}(({0}) => ", _closureName, delegateString);
				}

				_applyDisposable = new DisposableAction(() =>
				{
					blockDisposable.Dispose();
					_source.AppendLineIndented("))");
				});
			}
		}
		public int CurrentLevel => _source.CurrentLevel;

		public void Append(string text)
		{
			TryWriteApply();
			_source.Append(text);
		}

		public void AppendLine()
		{
			TryWriteApply();
			_source.AppendLine();
		}

		public void AppendMultiLineIndented(string text)
		{
			TryWriteApply();
			_source.AppendMultiLineIndented(text);
		}

		public IDisposable Block(IFormatProvider formatProvider, string pattern, params object[] parameters)
		{
			TryWriteApply();
			return _source.Block(formatProvider, pattern, parameters);
		}

		public IDisposable Block(int count = 1)
		{
			TryWriteApply();
			return _source.Block(count);
		}

		public IDisposable Indent(int count = 1)
		{
			TryWriteApply();
			return _source.Indent(count);
		}

		public void AppendIndented(string text)
		{
			TryWriteApply();
			_source.AppendIndented(text);
		}

		public void AppendIndented(ReadOnlySpan<char> text)
		{
			TryWriteApply();
			_source.AppendIndented(text);
		}

		public void AppendFormatIndented(IFormatProvider formatProvider, string text, params object[] replacements)
		{
			TryWriteApply();
			_source.AppendFormatIndented(formatProvider, text, replacements);
		}

		public void Dispose()
		{
			_applyDisposable?.Dispose();
			_parentDisposable?.Dispose();
		}

		public override string ToString() => _source.ToString();
	}

}
