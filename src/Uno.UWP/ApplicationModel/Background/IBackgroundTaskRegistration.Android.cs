﻿
#if __ANDROID__

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.ApplicationModel.Background
{
	public partial interface IBackgroundTaskRegistration
	{
		void Unregister(bool cancelTask);
	}
}

#endif 
