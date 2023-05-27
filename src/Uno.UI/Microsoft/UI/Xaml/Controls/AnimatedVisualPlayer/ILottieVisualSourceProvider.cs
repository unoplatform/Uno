using System;

// Keep this using in place until UWP support is dropped.
using Microsoft.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls
{
	public interface ILottieVisualSourceProvider
	{
		Microsoft.UI.Xaml.Controls.IAnimatedVisualSource CreateFromLottieAsset(Uri sourceFile);
		Microsoft.UI.Xaml.Controls.IThemableAnimatedVisualSource CreateTheamableFromLottieAsset(Uri sourceFile);
		public bool TryCreateThemableFromAnimatedVisualSource(Microsoft.UI.Xaml.Controls.IAnimatedVisualSource animatedVisualSource, out IThemableAnimatedVisualSource themableAnimatedVisualSource);
	}
}
