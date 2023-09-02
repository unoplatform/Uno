﻿#nullable enable

using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Windows.Foundation;
using Windows.Storage.Streams;
using Uno;

namespace Windows.Storage.Streams
{
	public sealed partial class RandomAccessStreamOverStream : IRandomAccessStream, IInputStream, IOutputStream, IDisposable, IStreamWrapper
	{
		private readonly Stream _stream;
		private readonly bool _disallowDispose;

		internal RandomAccessStreamOverStream(Stream stream, bool disallowDispose = false)
		{
			_stream = stream;
			_disallowDispose = disallowDispose;
		}

		Stream IStreamWrapper.FindStream() => _stream;

		/// <inheritdoc />
		public bool CanRead => _stream.CanRead;

		/// <inheritdoc />
		public bool CanWrite => _stream.CanWrite;

		/// <inheritdoc />
		public ulong Position => (ulong)_stream.Position;

		/// <inheritdoc />
		public ulong Size
		{
			get => (ulong)_stream.Length;
			set => _stream.SetLength((long)value);
		}

		public IInputStream GetInputStreamAt(ulong position)
		{
			Seek(position);
			return this;
		}

		public IOutputStream GetOutputStreamAt(ulong position)
		{
			Seek(position);
			return this;
		}

		public void Seek(ulong position)
			=> _stream.Seek((long)position, SeekOrigin.Begin);

		/// <inheritdoc />
		public IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
			=> _stream.ReadAsyncOperation(buffer, count, options);

		/// <inheritdoc />
		public IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
			=> _stream.WriteAsyncOperation(buffer);

		/// <inheritdoc />
		public IAsyncOperation<bool> FlushAsync()
			=> _stream.FlushAsyncOperation();

		/// <inheritdoc />
		public IRandomAccessStream CloneStream()
		{
			if (_stream is MemoryStream memStream)
			{
				var bytes = memStream.ToArray();
				return new MemoryStream(bytes).AsRandomAccessStream();
			}

			var previousPosition = _stream.Position;
			try
			{
				var memoryStream = new MemoryStream((int)Size);
				_stream.Position = 0;
				_stream.CopyTo(memoryStream);
				memoryStream.Position = 0;
				return memoryStream.AsRandomAccessStream();
			}
			finally
			{
				_stream.Position = previousPosition;
			}
		}

		/// <inheritdoc />
		public void Dispose()
		{
			if (_disallowDispose)
			{
				return;
			}

			_stream.Dispose();
		}
	}
}
