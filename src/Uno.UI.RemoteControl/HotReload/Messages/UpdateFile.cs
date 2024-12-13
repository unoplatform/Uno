﻿using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Uno.Extensions;
using Uno.UI.RemoteControl.Messaging.IdeChannel;

namespace Uno.UI.RemoteControl.HotReload.Messages;

public class UpdateFile : IMessage
{
	public const string Name = nameof(UpdateFile);

	/// <summary>
	/// ID of this file update request.
	/// </summary>
	[JsonProperty]
	public string RequestId { get; set; } = Guid.NewGuid().ToString();

	[JsonProperty]
	public string FilePath { get; set; } = string.Empty;

	/// <summary>
	/// The old text to replace in the file, or `null` to create a new file (only if <see cref="IsCreateDeleteAllowed"/> is true).
	/// </summary>
	[JsonProperty]
	public string? OldText { get; set; }

	/// <summary>
	/// The new text to replace in the file, or `null` to delete the file (only if <see cref="IsCreateDeleteAllowed"/> is true).
	/// </summary>
	[JsonProperty]
	public string? NewText { get; set; }

	/// <summary>
	/// Indicates if the file can be created or deleted.
	/// </summary>
	[JsonProperty]
	public bool IsCreateDeleteAllowed { get; set; }

	/// <summary>
	/// Disable the forced hot-reload requested on VS after the file has been modified.
	/// </summary>
	[JsonProperty]
	public bool IsForceHotReloadDisabled { get; set; }

	/// <summary>
	/// The delay to wait before forcing (**OR RETRYING**) a hot reload in Visual Studio.
	/// </summary>
	[JsonProperty]
	public TimeSpan? ForceHotReloadDelay { get; set; }

	/// <summary>
	/// Number of times to retry the hot reload in Visual Studio **if not changes are detected**.
	/// </summary>
	[JsonProperty]
	public int? ForceHotReloadAttempts { get; set; }

	[JsonIgnore]
	public string Scope => WellKnownScopes.HotReload;

	[JsonIgnore]
	string IMessage.Name => Name;

	/// <summary>
	/// LEGACY, indicates if valid for the legacy processor to handle it.
	/// </summary>
	/// <returns></returns>
	[MemberNotNullWhen(true, nameof(FilePath), nameof(OldText), nameof(NewText))]
	public bool IsValid()
		=> !FilePath.IsNullOrEmpty() &&
			OldText is not null &&
			NewText is not null;
}
