#if !(__IOS__ || __ANDROID__ || __MACOS__)
#nullable enable
using System;
using System.Reflection;
using System.Xml;
using Uno.Foundation.Logging;

namespace Windows.ApplicationModel;

public partial class Package
{
	private const string PackageManifestName = "Package.appxmanifest";

	private static Assembly? _entryAssembly;

	partial void InitializePlatform()
	{
	}

	internal static bool IsManifestInitialized { get; private set; }

	private bool GetInnerIsDevelopmentMode() => false;

	private DateTimeOffset GetInstallDate() => DateTimeOffset.Now;

	private string GetInstalledPath()
	{
		if (_entryAssembly?.Location is { Length: > 0 } location)
		{
			return global::System.IO.Path.GetDirectoryName(location) ?? "";
		}
		else if (AppContext.BaseDirectory is { Length: > 0 } baseDirectory)
		{
			return global::System.IO.Path.GetDirectoryName(baseDirectory) ?? "";
		}

		return Environment.CurrentDirectory;
	}

	public string DisplayName { get; private set; } = "";

	public Uri Logo { get; private set; } = new Uri("ms-appx://logo", UriKind.RelativeOrAbsolute);

	internal static void SetEntryAssembly(Assembly entryAssembly)
	{
		_entryAssembly = entryAssembly;
		Current.Id.Name = entryAssembly.GetName().Name; // Set the package name to the entry assembly name by default.
		Current.ParsePackageManifest();
		IsManifestInitialized = true;
	}

	private void ParsePackageManifest()
	{
		if (_entryAssembly is null)
		{
			return;
		}

		var manifest = _entryAssembly.GetManifestResourceStream(PackageManifestName);

		if (manifest is not null)
		{
			try
			{
				var doc = new XmlDocument();
				doc.Load(manifest);

				var nsmgr = new XmlNamespaceManager(doc.NameTable);
				nsmgr.AddNamespace("d", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");

				DisplayName = doc.SelectSingleNode("/d:Package/d:Properties/d:DisplayName", nsmgr)?.InnerText ?? "";

				var logoUri = doc.SelectSingleNode("/d:Package/d:Properties/d:Logo", nsmgr)?.InnerText ?? "";
				if (Uri.TryCreate(logoUri, UriKind.RelativeOrAbsolute, out var logo))
				{
					Logo = logo;
				}

				var idNode = doc.SelectSingleNode("/d:Package/d:Identity", nsmgr);
				if (idNode is not null)
				{
					Id.Name = idNode.Attributes?.GetNamedItem("Name")?.Value ?? "";

					var versionString = idNode.Attributes?.GetNamedItem("Version")?.Value ?? "";
					if (Version.TryParse(versionString, out var version))
					{
						Id.Version = new PackageVersion(version);
					}

					Id.Publisher = idNode.Attributes?.GetNamedItem("Publisher")?.Value ?? "";
				}
			}
			catch (Exception ex)
			{
				if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Error))
				{
					this.Log().Error($"Failed to read manifest [{PackageManifestName}]", ex);
				}
			}
		}
		else
		{
			if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
			{
				this.Log().Debug($"Skipping manifest reading, unable to find [{PackageManifestName}]");
			}
		}
	}
}
#endif
