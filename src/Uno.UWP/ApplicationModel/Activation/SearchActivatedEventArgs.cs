#nullable disable

using System;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.ApplicationModel.Activation
{
	public sealed partial class SearchActivatedEventArgs : IActivatedEventArgs
	{
		public ActivationKind Kind
		{
			get;
		}

		public ApplicationExecutionState PreviousExecutionState
		{
			get;
		}

		public SplashScreen SplashScreen
		{
			get;
		}

		public int CurrentlyShownApplicationViewId
		{
			get;
		}

		public string Language
		{
			get;
		}

		public string QueryText
		{
			get;
		}

#if IS_UNSUPPORTED_UWP
		public SearchPaneQueryLinguisticDetails LinguisticDetails
		{
			get;
		}
		public ActivationViewSwitcher ViewSwitcher
		{
			get;
		}
#endif
	}
}
