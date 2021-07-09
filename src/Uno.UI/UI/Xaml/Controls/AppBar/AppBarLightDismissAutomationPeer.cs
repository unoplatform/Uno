using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectUI;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Controls
{
	internal class AppBarLightDismissAutomationPeer : FrameworkElementAutomationPeer, IInvokeProvider
	{
		public AppBarLightDismissAutomationPeer(AppBarLightDismiss owner) : base(owner)
		{

		}

		protected override object GetPatternCore(PatternInterface patternInterface)
		{
			if (patternInterface == PatternInterface.Invoke)
			{
				return this;
			}
			else
			{
				return base.GetPatternCore(patternInterface);
			}
		}

		protected override string GetClassNameCore()
		{
			return "AppBarLightDismiss";
		}

		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Button;
		}

		protected override string GetNameCore()
		{
			return DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_LIGHTDISMISS_NAME");
		}

		protected override string GetAutomationIdCore()
		{
			return "Light Dismiss";
		}

		public void Invoke()
		{
			var owner = Owner;
			if (owner is AppBarLightDismiss abld)
			{
				abld.AutomationClick();
			}
		}
	}
}
