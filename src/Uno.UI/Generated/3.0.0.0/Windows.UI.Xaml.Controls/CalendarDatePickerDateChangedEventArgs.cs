#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Controls
{
	#if false || __IOS__ || NET461 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class CalendarDatePickerDateChangedEventArgs 
	{
#if false || __IOS__ || NET461 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public  global::System.DateTimeOffset? NewDate
		{
			get
			{
				throw new global::System.NotImplementedException("The member DateTimeOffset? CalendarDatePickerDateChangedEventArgs.NewDate is not implemented in Uno.");
			}
		}
#endif
#if false || __IOS__ || NET461 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public  global::System.DateTimeOffset? OldDate
		{
			get
			{
				throw new global::System.NotImplementedException("The member DateTimeOffset? CalendarDatePickerDateChangedEventArgs.OldDate is not implemented in Uno.");
			}
		}
#endif
		// Forced skipping of method Windows.UI.Xaml.Controls.CalendarDatePickerDateChangedEventArgs.NewDate.get
		// Forced skipping of method Windows.UI.Xaml.Controls.CalendarDatePickerDateChangedEventArgs.OldDate.get
	}
}
