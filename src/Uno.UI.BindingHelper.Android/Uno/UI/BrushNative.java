package Uno.UI;

import android.graphics.*;
import android.graphics.drawable.*;
import android.graphics.drawable.shapes.*;

public final class BrushNative
{
	private BrushNative() {
	}

	public static void buildBackgroundCornerRadius(
		PaintDrawable drawable,
		Path maskingPath,
		Paint fillPaint,
		boolean antiAlias,
		float width,
		float height)
	{
		drawable.setShape(new PathShape(maskingPath, width, height));

		Paint paint = drawable.getPaint();
		paint.setAntiAlias(antiAlias);
		paint.setColor(fillPaint.getColor());
		paint.setShader(fillPaint.getShader());
	}

	
	public static void resetPaintForStroke(Paint paint)
	{
		paint.reset();
		paint.setAntiAlias(true);
		paint.setStyle(Paint.Style.STROKE);
	}

	public static void resetPaintForFill(Paint paint)
	{
		paint.reset();
		paint.setAntiAlias(true);
		paint.setStyle(Paint.Style.FILL);
	}
}
