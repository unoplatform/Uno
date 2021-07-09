using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectUI
{
	internal struct AppBarStatus
	{
		public bool IsTopOpen { get; set; }
		public bool IsTopSticky { get; set; }
		public float TopWidth { get; set; }
		public float TopHeight { get; set; }
		public bool IsBottomOpen { get; set; }
		public bool IsBottomSticky { get; set; }
		public float BottomWidth { get; set; }
		public float BottomHeight { get; set; }
	}
}
