#if !(__IOS__ || __ANDROID__ || __MACOS__)
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Email.DataProvider;
using Windows.Storage;

namespace Windows.ApplicationModel
{
	public partial class Package
	{
		private const string PackageManifestName = "Package.appxmanifest";
		private static Assembly? _entryAssembly;
		private string _displayName = "";
		private string _logo = "ms-appx://logo";
		private bool? _manifestParsed;

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

		public string DisplayName
		{
			get
			{
				TryParsePackageManifest();
				return _displayName;
			}
		}

		public Uri? Logo =>
				TryParsePackageManifest() && !string.IsNullOrWhiteSpace(_logo) ? new Uri(_logo, UriKind.RelativeOrAbsolute) : default;

		internal static void SetEntryAssembly(Assembly entryAssembly)
		{
			_entryAssembly = entryAssembly;
		}

		private bool TryParsePackageManifest()
		{
			if (_entryAssembly != null &&
				!_manifestParsed.HasValue)
			{
				var manifest = _entryAssembly.GetManifestResourceStream(PackageManifestName);

				if (manifest != null)
				{
					try
					{
						var doc = new XmlDocument();
						doc.Load(manifest);

						var nsmgr = new XmlNamespaceManager(doc.NameTable);
						nsmgr.AddNamespace("d", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");

						_displayName = doc.SelectSingleNode("/d:Package/d:Properties/d:DisplayName", nsmgr)?.InnerText ?? "";
						_logo = doc.SelectSingleNode("/d:Package/d:Properties/d:Logo", nsmgr)?.InnerText ?? "";
						_manifestParsed = true;
					}
					catch (Exception ex)
					{
						_manifestParsed = false;
						if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Error))
						{
							this.Log().Error($"Failed to read manifest [{PackageManifestName}]", ex);
						}
					}
				}
				else
				{
					_manifestParsed = false;
					if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
					{
						this.Log().Debug($"Skipping manifest reading, unable to find [{PackageManifestName}]");
					}
				}
			}

			return _manifestParsed ?? false;
		}
	}
}
#endif
