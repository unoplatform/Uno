﻿#if __WASM__

using System;
using Microsoft.UI.Xaml.Media;
using Uno.Xaml;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Media;

[TestClass]
[RunsOnUIThread]
public class Given_GeometryData
{
	[DataTestMethod]
	[DataRow("", FillRule.EvenOdd, "")]
	[DataRow("F0", FillRule.EvenOdd, "")]
	[DataRow("F1", FillRule.Nonzero, "")]
	[DataRow("  F1", FillRule.Nonzero, "")]
	[DataRow("  F 1", FillRule.Nonzero, "")]
	[DataRow("F1 M0 0", FillRule.Nonzero, " M0 0")]
	[DataRow("  F1 M0 0", FillRule.Nonzero, " M0 0")]
	[DataRow("  F  1  M0 0", FillRule.Nonzero, "  M0 0")]
	public void When_GeometryData_ParseData_Valid(string rawdata, FillRule rule, string data)
	{
		var result = GeometryData.ParseData(rawdata);

		Assert.AreEqual(rule, result.FillRule);
		Assert.AreEqual(data, result.Data);
	}

	[DataTestMethod]
	[DataRow("F")]
	[DataRow("F2")]
	[DataRow("FF")]
	[DataRow("F 2")]
	[DataRow("F M0 0")]
	public void When_GeometryData_ParseData_Invalid(string rawdata)
	{
		Assert.ThrowsException<XamlParseException>(() =>
			GeometryData.ParseData(rawdata)
		);
	}
}
#endif
