#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.UI.Xaml.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Controls
{
	internal interface IApplicationBarService
	{
		void ClearCaches();

		void RegisterApplicationBar(AppBar pApplicationBar, AppBarMode mode);

        void UnregisterApplicationBar(AppBar pApplicationBar);

        void OnBoundsChanged(bool inputPaneChange = false);

        void OpenApplicationBar(AppBar pAppBar, AppBarMode mode);

        void CloseApplicationBar(AppBar pAppBar, AppBarMode mode);

        void HandleApplicationBarClosedDisplayModeChange(AppBar pAppBar, AppBarMode mode);

		bool CloseAllNonStickyAppBars();

        void UpdateDismissLayer();

        void ToggleApplicationBars();

        void SaveCurrentFocusedElement(AppBar pAppBar);

        void FocusSavedElement(AppBar pApplicationBar);

		TabStopProcessingResult ProcessTabStopOverride(
			DependencyObject? pFocusedElement,
			DependencyObject? pCandidateTabStopElement,
			bool isBackward);

        void FocusApplicationBar(
			AppBar pAppBar,
			FocusState focusState);

        void SetFocusReturnState(FocusState focusState);

        void ResetFocusReturnState();

		AppBarStatus GetAppBarStatus();

        void ProcessToggleApplicationBarsFromMouseRightTapped();

        void GetTopAndBottomAppBars(
			out AppBar? ppTopAppBar,
			out AppBar? ppBottomAppBar);

        void GetTopAndBottomOpenAppBars(
			out AppBar? ppTopAppBar,
			out AppBar? ppBottomAppBar,
			out bool pIsAnyLightDismiss);

		DependencyObject? GetFirstFocusableElementFromAppBars(
			AppBar? pTopAppBar,
			AppBar? pBottomAppBar,
			AppBarTabPriority tabPriority,
			bool startFromEnd);
	}
}
