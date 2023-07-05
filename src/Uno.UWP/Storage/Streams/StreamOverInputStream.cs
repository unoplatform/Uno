using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Windows.Storage.Streams
{
	internal class StreamOverInputStream : Stream, IInputStreamWrapper
	{
		private readonly IInputStream _raStream;
		private readonly int _bufferSize;

		public StreamOverInputStream(IInputStream raStream, int bufferSize)
		{
			_raStream = raStream;
			_bufferSize = bufferSize;
		}

		IInputStream IInputStreamWrapper.FindStream() => _raStream;

		/// <inheritdoc />
		public override bool CanRead => true;

		/// <inheritdoc />
		public override bool CanSeek => false;

		/// <inheritdoc />
		public override bool CanWrite => false;

		/// <inheritdoc />
		public override long Length => throw new NotSupportedException("Cannot get Length of an input stream.");

		/// <inheritdoc />
		public override long Position
		{
			get => throw new NotSupportedException("Cannot Seek an input stream.");
			set => throw new NotSupportedException("Cannot get Position of an input stream.");
		}

		/// <inheritdoc />
		public override long Seek(long offset, SeekOrigin origin)
			=> throw new NotSupportedException("Cannot Seek an input stream.");

		/// <inheritdoc />
		public override void SetLength(long value)
			=> throw new NotSupportedException("Cannot SetLength of a input stream.");

		/// <inheritdoc />
		public override int Read(byte[] buffer, int offset, int count)
			=> ReadAsync(buffer, offset, count, CancellationToken.None).Result;

		/// <inheritdoc />
		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			=> _raStream.ReadAsync(buffer, offset, count, cancellationToken);

		/// <inheritdoc />
		public override void Write(byte[] buffer, int offset, int count)
			=> WriteAsync(buffer, offset, count, CancellationToken.None).Wait();

		/// <inheritdoc />
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			=> throw new NotSupportedException("Cannot Write an input stream.");

		/// <inheritdoc />
		public override void Flush() { }

		/// <inheritdoc />
		public override Task FlushAsync(CancellationToken cancellationToken) => Task.CompletedTask;
	}
}
