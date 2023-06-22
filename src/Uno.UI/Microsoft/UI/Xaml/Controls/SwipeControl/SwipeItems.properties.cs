// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

// DO NOT EDIT! This file was generated by CustomTasks.DependencyPropertyCodeGen

// Imported in uno on 2021/03/21 from commit 307bd99682cccaa128483036b764c0b7c862d666
// https://github.com/microsoft/microsoft-ui-xaml/blob/307bd99682cccaa128483036b764c0b7c862d666/dev/Generated/SwipeItems.properties.cpp

using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class SwipeItems
	{
		public static DependencyProperty ModeProperty { get; } = DependencyProperty.Register(
			"Mode", typeof(SwipeMode), typeof(SwipeItems), new FrameworkPropertyMetadata(default(SwipeMode), OnModePropertyChanged));

		public SwipeMode Mode
		{
			get => (SwipeMode)GetValue(ModeProperty);
			set => SetValue(ModeProperty, value);
		}

		//GlobalDependencyProperty SwipeItemsProperties.s_ModeProperty{ null };

		//SwipeItemsProperties.SwipeItemsProperties()
		//{
		//    EnsureProperties();
		//}

		//void SwipeItemsProperties.EnsureProperties()
		//{
		//    if (!s_ModeProperty)
		//    {
		//        s_ModeProperty =
		//            InitializeDependencyProperty(
		//                "Mode",
		//                winrt.name_of<winrt.SwipeMode>(),
		//                winrt.name_of<winrt.SwipeItems>(),
		//                false /* isAttached */,
		//                ValueHelper<winrt.SwipeMode>.BoxValueIfNecessary(winrt.SwipeMode.Reveal),
		//                winrt.PropertyChangedCallback(&OnModePropertyChanged));
		//    }
		//}

		//void SwipeItemsProperties.ClearProperties()
		//{
		//    s_ModeProperty = null;
		//}

		private static void OnModePropertyChanged(
			DependencyObject sender,
			DependencyPropertyChangedEventArgs args)
		{
			var owner = sender as SwipeItems;
			owner.OnPropertyChanged(args);
		}

		//void SwipeItemsProperties.Mode(winrt.SwipeMode & value)
		//{
		//    [[gsl.suppress(con)]]
		//    {
		//    (SwipeItems)(this).SetValue(s_ModeProperty, ValueHelper<winrt.SwipeMode>.BoxValueIfNecessary(value));
		//    }
		//}

		//winrt.SwipeMode SwipeItemsProperties.Mode()
		//{
		//    return ValueHelper<winrt.SwipeMode>.CastOrUnbox((SwipeItems)(this).GetValue(s_ModeProperty));
		//}
	}
}
