#nullable enable

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Uno.Extensions;
using Uno.Roslyn;
using Uno.UI.SourceGenerators.Helpers;

#if NETFRAMEWORK
using Uno.SourceGeneration;
#endif

namespace Uno.UI.SourceGenerators.RemoteControl
{
	[Generator]
	public class RemoteControlGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
			DependenciesInitializer.Init();
		}

		public void Execute(GeneratorExecutionContext context)
		{
			if (
				!DesignTimeHelper.IsDesignTime(context)
				&& context.GetMSBuildPropertyValue("Configuration") == "Debug"
				&& IsRemoteControlClientInstalled(context)
				&& PlatformHelper.IsApplication(context))
			{
				var sb = new IndentedStringBuilder();

				sb.AppendLineIndented("// <auto-generated>");
				sb.AppendLineIndented("// ***************************************************************************************");
				sb.AppendLineIndented("// This file has been generated by the package Uno.UI.RemoteControl - for Xaml Hot Reload.");
				sb.AppendLineIndented("// Documentation: https://platform.uno/docs/articles/features/working-with-xaml-hot-reload.html");
				sb.AppendLineIndented("// ***************************************************************************************");
				sb.AppendLineIndented("// </auto-generated>");
				sb.AppendLineIndented("// <autogenerated />");
				sb.AppendLineIndented("#pragma warning disable // Ignore code analysis warnings");

				sb.AppendLineIndented("");

				BuildEndPointAttribute(context, sb);
				BuildSearchPaths(context, sb);
				BuildServerProcessorsPaths(context, sb);

				context.AddSource("RemoteControl", sb.ToStringAndFree());
			}
		}

		private void BuildServerProcessorsPaths(GeneratorExecutionContext context, IndentedStringBuilder sb)
		{
			sb.AppendLineIndented($"[assembly: global::Uno.UI.RemoteControl.ServerProcessorsConfigurationAttribute(" +
				$"@\"{context.GetMSBuildPropertyValue("UnoRemoteControlProcessorsPath")}\"" +
				$")]");
		}

		private static bool IsRemoteControlClientInstalled(GeneratorExecutionContext context)
			=> context.Compilation.GetTypeByMetadataName("Uno.UI.RemoteControl.RemoteControlClient") != null;

		private static void BuildSearchPaths(GeneratorExecutionContext context, IndentedStringBuilder sb)
		{
			sb.AppendLineIndented($"[assembly: global::Uno.UI.RemoteControl.ProjectConfigurationAttribute(");
			sb.AppendLineIndented($"@\"{context.GetMSBuildPropertyValue("MSBuildProjectFullPath")}\",\n");

			var msBuildProjectDirectory = context.GetMSBuildPropertyValue("MSBuildProjectDirectory");
			var sources = new[] {
					"Page",
					"ApplicationDefinition",
					"ProjectReference",
				};

			IEnumerable<string> BuildSearchPath(string s)
				=> context
					.GetMSBuildItemsWithAdditionalFiles(s)
					.Select(v => Path.IsPathRooted(v.Identity) ? v.Identity : Path.Combine(msBuildProjectDirectory, v.Identity));

			var xamlPaths = from item in sources.SelectMany(BuildSearchPath)
							select Path.GetDirectoryName(item);

			var distictPaths = string.Join(",\n", xamlPaths.Distinct().Select(p => $"@\"{p}\""));

			sb.AppendLineIndented($"new string[]{{{distictPaths}}}");

			sb.AppendLineIndented(")]");
		}


		private static void BuildEndPointAttribute(GeneratorExecutionContext context, IndentedStringBuilder sb)
		{
			var unoRemoteControlPort = context.GetMSBuildPropertyValue("UnoRemoteControlPort");

			if (string.IsNullOrEmpty(unoRemoteControlPort))
			{
				unoRemoteControlPort = "0";
			}

			var unoRemoteControlHost = context.GetMSBuildPropertyValue("UnoRemoteControlHost");

			if (string.IsNullOrEmpty(unoRemoteControlHost))
			{
				var addresses = NetworkInterface.GetAllNetworkInterfaces()
					.SelectMany(x => x.GetIPProperties().UnicastAddresses)
					.Where(x => !IPAddress.IsLoopback(x.Address));
					//This is not supported on linux yet: .Where(x => x.DuplicateAddressDetectionState == DuplicateAddressDetectionState.Preferred);

				foreach (var addressInfo in addresses)
				{
					var address = addressInfo.Address;

					string addressStr;
					if(address.AddressFamily == AddressFamily.InterNetworkV6)
					{
						address.ScopeId = 0; // remove annoying "%xx" on IPv6 addresses
						addressStr = $"[{address}]";
					}
					else
					{
						addressStr = address.ToString();
					}
					sb.AppendLineIndented($"[assembly: global::Uno.UI.RemoteControl.ServerEndpointAttribute(\"{addressStr}\", {unoRemoteControlPort})]");
				}
			}
			else
			{
				sb.AppendLineIndented($"[assembly: global::Uno.UI.RemoteControl.ServerEndpointAttribute(\"{unoRemoteControlHost}\", {unoRemoteControlPort})]");
			}
		}
	}
}

