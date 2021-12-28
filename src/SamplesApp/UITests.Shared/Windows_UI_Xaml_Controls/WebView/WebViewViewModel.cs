﻿using Windows.UI.Core;
using Uno.UI.Samples.UITests.Helpers;

namespace SamplesApp.Windows_UI_Xaml_Controls.WebView
{
	internal class WebViewViewModel : ViewModelBase
	{
		private const string SampleHtml = @"
<!DOCTYPE html>
<html>
	<head>
		<title>Uno Samples</title>
	</head>
	<body>
		<p>Welcome to <a href=""https://platform.uno/"">Uno Platform</a>'s samples!</p>
	</body>
</html>";

		public WebViewViewModel(CoreDispatcher dispatcher) : base(dispatcher)
		{
		}

		public string InitialSourceString => SampleHtml;

		public string InitialUri => "http://www.google.com";

		public string AlertHtml => @"
<html>
	<head>
		<title>Spamming alert</title>
	</head>
	<body>
		<h1>This page spam alert each 5 seconds.</h1>
		<script>
		let count = 0;
		function timer() {
			count++;
			alert('Spamming alert #' + count);
			console.log(""Spamming alert #"" + count);
			setTimeout(timer, 5000)
		}
		timer()
		</script>
	</body>
</html>";
	}
}
