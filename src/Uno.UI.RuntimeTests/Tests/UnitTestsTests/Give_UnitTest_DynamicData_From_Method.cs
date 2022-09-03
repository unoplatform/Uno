﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Uno.UI.RuntimeTests.Tests.UnitTestsTests
{
	[TestClass]
	public class Give_UnitTest_DynamicData_From_Method : IDisposable
	{
		static int TestSucces_Count;

		[DataTestMethod]
		[DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
		public void When_Get_Arguments_From_Method(int a, int b, int expected)
		{
			var actual = a + b;
			Assert.AreEqual(expected, actual);
			TestSucces_Count++;
		}

		public static IEnumerable<object[]> GetData()
		{
			yield return new object[] { 1, 1, 2 };
			yield return new object[] { 12, 30, 42 };
			yield return new object[] { 14, 1, 15 };
		}

		public void Dispose() =>
			Assert.Equals(TestSucces_Count, 3);
	}
}
