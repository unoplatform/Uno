﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Uno.Sdk.Models;

namespace Uno.Sdk.Services;

public class NuGetApiClient : IDisposable
{
	private HttpClient Client { get; } = new HttpClient
	{
		BaseAddress = new Uri("https://api.nuget.org")
	};

	public string GetVersion(string packageId, bool preview, string? minimumVersion = null)
	{
		var task = GetVersionAsync(packageId, preview, minimumVersion);
		task.Wait();
		return task.Result;
	}

	internal record VersionsResponse(string[] Versions);

	private async Task<IEnumerable<NuGetVersion>> GetPackageVersions(string packageId)
	{
		var response = await Client.GetFromJsonAsync<VersionsResponse>($"/v3-flatcontainer/{packageId.ToLower(CultureInfo.InvariantCulture)}/index.json");
		var versions = response?.Versions ?? [];

		var output = new List<NuGetVersion>();
		foreach (var version in versions)
		{
			if (NuGetVersion.TryParse(version, out var nugetVersion))
			{
				output.Add(nugetVersion);
			}
		}

		return output;
	}

	private async Task<string> GetVersionAsync(string packageId, bool preview, string? minimumVersionString = null)
	{
		var versions = await GetPackageVersions(packageId);
		versions = versions.Where(x => x.IsPreview == preview);

		if (NuGetVersion.TryParse(minimumVersionString, out var minimumVersion))
		{
			versions = versions.Where(x => minimumVersion.Version <= x.Version);
		}

		if (!versions.Any())
		{
			return string.Empty;
		}

		return versions.OrderByDescending(x => x).First().OriginalVersion;
	}

	public void Dispose()
	{
		Client.Dispose();
	}
}
