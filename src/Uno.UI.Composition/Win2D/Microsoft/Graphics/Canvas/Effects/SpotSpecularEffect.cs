﻿#nullable enable

using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Windows.Graphics.Effects;
using Windows.Graphics.Effects.Interop;
using Windows.UI;

namespace Microsoft.Graphics.Canvas.Effects;

[Guid("EDAE421E-7654-4A37-9DB8-71ACC1BEB3C1")]
internal class SpotSpecularEffect : ICanvasEffect
{
	private string _name = "SpotSpecularEffect";
	private Guid _id = new Guid("EDAE421E-7654-4A37-9DB8-71ACC1BEB3C1");

	public string Name
	{
		get => _name;
		set => _name = value;
	}

	public CanvasBufferPrecision? BufferPrecision { get; set; }

	public bool CacheOutput { get; set; }

	public Vector3 LightPosition { get; set; }

	public Vector3 LightTarget { get; set; }

	public float Focus { get; set; } = 1.0f;

	public float LimitingConeAngle { get; set; } = MathF.PI / 2.0f;

	public float SpecularExponent { get; set; } = 1.0f;

	public float SpecularAmount { get; set; } = 1.0f;

	public Color LightColor { get; set; } = Colors.White;

	public IGraphicsEffectSource? Source { get; set; }

	public Guid GetEffectId() => _id;

	public void GetNamedPropertyMapping(string name, out uint index, out GraphicsEffectPropertyMapping mapping)
	{
		switch (name)
		{
			case nameof(LightPosition):
				{
					index = 0;
					mapping = GraphicsEffectPropertyMapping.Direct;
					break;
				}
			case nameof(LightTarget):
				{
					index = 1;
					mapping = GraphicsEffectPropertyMapping.Direct;
					break;
				}
			case nameof(Focus):
				{
					index = 2;
					mapping = GraphicsEffectPropertyMapping.Direct;
					break;
				}
			case nameof(LimitingConeAngle):
				{
					index = 3;
					mapping = GraphicsEffectPropertyMapping.RadiansToDegrees;
					break;
				}
			case nameof(SpecularExponent):
				{
					index = 4;
					mapping = GraphicsEffectPropertyMapping.Direct;
					break;
				}
			case nameof(SpecularAmount):
				{
					index = 5;
					mapping = GraphicsEffectPropertyMapping.Direct;
					break;
				}
			case nameof(LightColor):
				{
					index = 6;
					mapping = GraphicsEffectPropertyMapping.ColorToVector3;
					break;
				}
			default:
				{
					index = 0xFF;
					mapping = (GraphicsEffectPropertyMapping)0xFF;
					break;
				}
		}
	}

	public object? GetProperty(uint index) => index switch
	{
		0 => LightPosition,
		1 => LightTarget,
		2 => Focus,
		3 => LimitingConeAngle,
		4 => SpecularExponent,
		5 => SpecularAmount,
		6 => LightColor,
		_ => null,
	};

	public uint GetPropertyCount() => 7;

	public IGraphicsEffectSource? GetSource(uint index) => index switch
	{
		0 => Source,
		_ => null
	};

	public uint GetSourceCount() => 1;

	public void Dispose() { }
}
