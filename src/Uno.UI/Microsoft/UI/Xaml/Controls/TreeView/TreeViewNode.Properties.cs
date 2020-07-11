﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

// MUX reference de78834

using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class TreeViewNode
	{
		public object Content
		{
			get { return (object)GetValue(ContentProperty); }
			set { SetValue(ContentProperty, value); }
		}

		public int Depth
		{
			get { return (int)GetValue(DepthProperty); }
			private set { SetValue(DepthProperty, value); }
		}

		public bool HasChildren
		{
			get { return (bool)GetValue(HasChildrenProperty); }
			private set { SetValue(HasChildrenProperty, value); }
		}

		public bool IsExpanded
		{
			get { return (bool)GetValue(IsExpandedProperty); }
			set { SetValue(IsExpandedProperty, value); }
		}

		public static readonly DependencyProperty ContentProperty =
			DependencyProperty.Register(nameof(Content), typeof(object), typeof(TreeViewNode), new PropertyMetadata(null));

		public static readonly DependencyProperty DepthProperty =
			DependencyProperty.Register(nameof(Depth), typeof(int), typeof(TreeViewNode), new PropertyMetadata(-1));

		public static readonly DependencyProperty HasChildrenProperty =
			DependencyProperty.Register(nameof(HasChildren), typeof(bool), typeof(TreeViewNode), new PropertyMetadata(false, OnHasChildrenPropertyChanged));

		public static readonly DependencyProperty IsExpandedProperty =
			DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(TreeViewNode), new PropertyMetadata(false, OnIsExpandedPropertyChanged));

		private static void OnHasChildrenPropertyChanged(
			DependencyObject sender,
			DependencyPropertyChangedEventArgs args)
		{
			var owner = (TreeViewNode)sender;
			owner.OnPropertyChanged(args);
		}

		private static void OnIsExpandedPropertyChanged(
			DependencyObject sender,
			DependencyPropertyChangedEventArgs args)
		{
			var owner = (TreeViewNode)sender;
			owner.OnPropertyChanged(args);
		}
	}
}
