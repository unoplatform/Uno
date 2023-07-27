﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using CoreAnimation;

namespace Uno.UI.Extensions
{
	internal static class Matrix3x2Extensions
	{
		public static CATransform3D ToTransform3D(this Matrix3x2 matrix)
			=> new CATransform3D
			{
				// Note: The transformation X and Y (M31 and M32) are on the fourth row of 4x4 transform matrix.
				// Note2: As we cannot assume that there is no marshaling on each value we set, we set only the
				//		  needed values for an affine transform (3x2).

				M11 = matrix.M11,
				M12 = matrix.M12, // m13 = 0, m14 = 0,
				M21 = matrix.M21,
				M22 = matrix.M22, // m23 = 0, m24 = 0,
				/*m31 = 0, m32 = 0,*/
				M33 = 1, // m34 = 0,
				M41 = matrix.M31,
				M42 = matrix.M32,
				/*m43 = 0,*/
				M44 = 1
			};
	}
}
