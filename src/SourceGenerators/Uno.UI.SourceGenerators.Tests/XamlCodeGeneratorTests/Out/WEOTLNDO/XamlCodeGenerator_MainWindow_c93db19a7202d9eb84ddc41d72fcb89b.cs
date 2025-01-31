﻿// <autogenerated />
#pragma warning disable CS0114
#pragma warning disable CS0108
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.UI;
using Uno.UI.Xaml;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Shapes;
using Windows.UI.Text;
using Uno.Extensions;
using Uno;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using MyProject;

#if __ANDROID__
using _View = Android.Views.View;
#elif __IOS__
using _View = UIKit.UIView;
#elif __MACOS__
using _View = AppKit.NSView;
#else
using _View = Microsoft.UI.Xaml.UIElement;
#endif

namespace TestRepro
{
	partial class MainWindow : global::Microsoft.UI.Xaml.Window
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_MainWindow_c93db19a7202d9eb84ddc41d72fcb89b = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_MainWindow_c93db19a7202d9eb84ddc41d72fcb89b = "ms-appx:///TestProject/";
		private global::Microsoft.UI.Xaml.NameScope __nameScope = new global::Microsoft.UI.Xaml.NameScope();
		private void InitializeComponent()
		{
			var __that = this;
			// Source 0\MainWindow.xaml (Line 1:2)
			;
			
			this
			.MainWindow_c93db19a7202d9eb84ddc41d72fcb89b_XamlApply((MainWindow_c93db19a7202d9eb84ddc41d72fcb89bXamlApplyExtensions.XamlApplyHandler0)(__p1 => 
			{
			// Source 0\MainWindow.xaml (Line 1:2)
			
			// WARNING Property __p1.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Window, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.MainWindow_c93db19a7202d9eb84ddc41d72fcb89b_XamlApply((MainWindow_c93db19a7202d9eb84ddc41d72fcb89bXamlApplyExtensions.XamlApplyHandler0)(__p1 => 
			{
			// Class TestRepro.MainWindow
			var Closed_Handler = new __MainWindow_c93db19a7202d9eb84ddc41d72fcb89b_TestReproMainWindow.ApplyMethod_1_Closed_Handler((this as global::Uno.UI.DataBinding.IWeakReferenceProvider).WeakReference);
			/* second level */ __p1.Closed += Closed_Handler.Invoke;
			}
			))
			;
			if (__that.Content != null)
			{
				NameScope.SetNameScope(__that.Content, __nameScope);
			}
			OnInitializeCompleted();

		}
		partial void OnInitializeCompleted();
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		[global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdate]
		private class __MainWindow_c93db19a7202d9eb84ddc41d72fcb89b_TestReproMainWindow
		{
				public class ApplyMethod_1_Closed_Handler(global::Uno.UI.DataBinding.ManagedWeakReference target)
				{
					public void Invoke(object sender, global::Microsoft.UI.Xaml.WindowEventArgs args)
					{
						(target.Target as global::TestRepro.MainWindow)?.Window_Closed(sender, args);
					}
				}

		}
	}
}
namespace MyProject
{
	static class MainWindow_c93db19a7202d9eb84ddc41d72fcb89bXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Microsoft.UI.Xaml.Window instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Window MainWindow_c93db19a7202d9eb84ddc41d72fcb89b_XamlApply(this global::Microsoft.UI.Xaml.Window instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
