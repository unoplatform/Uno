﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Uno.UI.RemoteControl.HotReload.Messages;
using Uno.UI.RemoteControl.Messaging.IdeChannel;

namespace Uno.UI.RemoteControl.Host
{
	public interface IServerProcessor : IDisposable
	{
		string Scope { get; }

		/// <summary>
		/// Processes a frame from the Client
		/// </summary>
		/// <param name="frame">The frame received from the client.</param>
		Task ProcessFrame(Frame frame);

		/// <summary>
		/// Processes a message from the IDE
		/// </summary>
		/// <param name="message">The message received from the IDE.</param>
		/// <param name="ct">The cancellation token.</param>
		Task ProcessIdeMessage(IdeMessage message, CancellationToken ct);
	}

	[System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
	public sealed class ServerProcessorAttribute : Attribute
	{
		readonly Type processor;

		// This is a positional argument
		public ServerProcessorAttribute(Type processor) => this.processor = processor;

		public Type ProcessorType
			=> processor;
	}
}
