#pragma warning disable CS0169

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace Uno.UI.Controls;

// this represent the memory layout of the managed NSObject class
// part of the workaround for https://github.com/xamarin/xamarin-macios/issues/15089
[StructLayout(LayoutKind.Sequential)]
class NSObjectMemoryRepresentation
{
	NativeHandle handle;
	IntPtr classHandle;
	public byte flags;

	public const byte InFinalizerQueue = 16; // see NSObject2.cs

	static public void RemoveInFinalizerQueueFlag(NSObject obj)
	{
		// once re-registered, the object is not anymore in the finalizer queue
		// workaround for https://github.com/xamarin/xamarin-macios/issues/15089
		var poker = Unsafe.As<NSObjectMemoryRepresentation>(obj);
		poker.flags = (byte)(poker.flags & ~InFinalizerQueue);
	}
}
