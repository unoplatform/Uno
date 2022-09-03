﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Xml;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Mono.Cecil;

namespace Uno.UI.Tasks.LinkerHintsGenerator
{
	/// <summary>
	/// A task used to merge linker definition files and embed the result in an assembly
	/// </summary>
	public class LinkerDefinitionMergerTask_v0 : Microsoft.Build.Utilities.Task
	{
		private const MessageImportance DefaultLogMessageLevel

#if DEBUG
			= MessageImportance.High;
#else
			= MessageImportance.Low;
#endif

		[Required]
		public Microsoft.Build.Framework.ITaskItem[]? DefinitionFiles { get; set; }

		[Required]
		public string TargetAssembly { get; set; } = "";

		[Required]
		public string TargetResourceName { get; set; } = "";

		[Required]
		public Microsoft.Build.Framework.ITaskItem[]? ReferencePath { get; set; }


		public override bool Execute()
		{
			// Debugger.Launch();

			if (DefinitionFiles != null)
			{
				var doc = new XmlDocument();

				var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

				var root = doc.DocumentElement;
				doc.InsertBefore(xmlDeclaration, root);

				var linkerNode = doc.CreateElement(string.Empty, "linker", string.Empty);
				doc.AppendChild(linkerNode);

				foreach (var definition in DefinitionFiles)
				{
					Log.LogMessage(DefaultLogMessageLevel, $"Merging substitution file {definition}");

					var defDoc = new XmlDocument();
					defDoc.Load(definition.ItemSpec);

					linkerNode.InnerXml += defDoc.DocumentElement.InnerXml;
				}

				var outputPath = Path.GetTempFileName();
				doc.Save(outputPath);

				Log.LogMessage(DefaultLogMessageLevel, $"Writing substitution file to {TargetAssembly}");

				var resolver = new DefaultAssemblyResolver();
				foreach(var path in BuildReferencesPaths())
				{
					resolver.AddSearchDirectory(path);
				}

				using (var asm = AssemblyDefinition.ReadAssembly(TargetAssembly, new ReaderParameters() { AssemblyResolver = resolver, ReadSymbols = true, ReadWrite = true } ))
                {
                    // Clean existing resources with the same name
                    var existingResources = asm.MainModule.Resources
                        .OfType<EmbeddedResource>()
                        .Where(r => r.Name.EndsWith(TargetResourceName, StringComparison.OrdinalIgnoreCase))
                        .ToArray();

                    foreach(var existingResource in existingResources)
                    {
                        asm.MainModule.Resources.Remove(existingResource);
                    }

                    // Add the new merged content
                    asm.MainModule.Resources.Add(new EmbeddedResource(TargetResourceName, ManifestResourceAttributes.Public, File.ReadAllBytes(outputPath)));

					asm.Write(new WriterParameters() { WriteSymbols = true });
				}

				WaitForUnlockedFile(TargetAssembly);
				WaitForUnlockedFile(Path.ChangeExtension(TargetAssembly, "pdb"));
			}

			return true;
		}

		private string[] BuildReferencesPaths() => ReferencePath
				.Select(p => Path.GetDirectoryName(p.ItemSpec))
				.Distinct()
				.ToArray();

		private void WaitForUnlockedFile(string filePath)
		{
			var sw = Stopwatch.StartNew();

			while (sw.Elapsed < TimeSpan.FromSeconds(5))
			{
				try
				{
					File.OpenWrite(filePath).Dispose();

					break;
				}
				catch
				{
					Log.LogMessage(MessageImportance.Low, $"Waiting for availability for {TargetAssembly}");
				}

				Thread.Sleep(100);
			}
		}
	}
}
