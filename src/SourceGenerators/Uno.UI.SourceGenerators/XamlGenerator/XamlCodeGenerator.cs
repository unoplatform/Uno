﻿#nullable enable

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Text;
using Microsoft.CodeAnalysis;
using Uno.Roslyn;
using Uno.UI.SourceGenerators.Helpers;
using Uno.UI.SourceGenerators.Telemetry;

namespace Uno.UI.SourceGenerators.XamlGenerator
{
	[Generator]
	public partial class XamlCodeGenerator : ISourceGenerator
	{
		private readonly object _gate = new();

		public void Initialize(GeneratorInitializationContext context)
		{
		}

		public void Execute(GeneratorExecutionContext context)
		{
			// No initialization required for this one
			//if (!Process.GetCurrentProcess().ProcessName.Equals("omnisharp.exe", StringComparison.OrdinalIgnoreCase))
			//{
			//	Debugger.Launch();
			//}

			//
			// Lock the current generator instance, as it may be invoked concurrently
			// in the context of omnisharp when saving and editing fast enough, causing
			// corruption issues in the GenerationRunInfoManager.
			//
			lock (_gate)
			{
				if (PlatformHelper.IsValidPlatform(context))
				{
					var gen = new XamlCodeGeneration(context);
					var generatedTrees = gen.Generate();

					foreach (var tree in generatedTrees)
					{
						context.AddSource(tree.Key, tree.Value);
					}

					DumpXamlSourceGeneratorState(context, generatedTrees);
				}
			}
		}
	}
}
