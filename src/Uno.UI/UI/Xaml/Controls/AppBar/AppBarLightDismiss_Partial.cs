using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Automation.Peers;

namespace Windows.UI.Xaml.Controls
{
	internal partial class AppBarLightDismiss : Grid
	{
		public void AutomationClick()
		{
			//HRESULT hr = S_OK;
			//ctl::ComPtr<IApplicationBarService> spApplicationBarService;
			//IFC(DXamlCore::GetCurrent()->GetApplicationBarService(spApplicationBarService));
			//IFC(spApplicationBarService->CloseAllNonStickyAppBars());
		}

		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new AppBarLightDismissAutomationPeer(this);
		}

	}
}
