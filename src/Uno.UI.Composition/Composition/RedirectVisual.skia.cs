﻿#nullable enable

using SkiaSharp;
using Uno.UI.Composition;

namespace Microsoft.UI.Composition
{
	public partial class RedirectVisual : ContainerVisual
	{
		internal override void Paint(in PaintingSession session)
		{
			base.Paint(in session);
			Source?.Paint(session);
		}

		internal override bool CanPaint => Source?.CanPaint ?? false;
		internal override bool RequiresRepaintOnEveryFrame => Source?.RequiresRepaintOnEveryFrame ?? false;
	}
}
