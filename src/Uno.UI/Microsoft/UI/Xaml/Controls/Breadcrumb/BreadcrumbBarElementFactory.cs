#nullable disable

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// MUX Reference BreadcrumbBarElementFactory.cpp, commit 085fbf9

using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal partial class BreadcrumbElementFactory : ElementFactory
{
	private IElementFactoryShim? m_itemTemplateWrapper = null;

	public BreadcrumbElementFactory()
	{
	}

	internal void UserElementFactory(object? newValue)
	{
		m_itemTemplateWrapper = newValue as IElementFactoryShim;
		if (m_itemTemplateWrapper == null)
		{
			// ItemTemplate set does not implement IElementFactoryShim. We also want to support DataTemplate.
			if (newValue is DataTemplate dataTemplate)
			{
				m_itemTemplateWrapper = new ItemTemplateWrapper(dataTemplate);
			}
		}
	}

	protected override UIElement GetElementCore(ElementFactoryGetArgs args)
	{
		object GetNewContent(IElementFactoryShim? itemTemplateWrapper)
		{
			if (args.Data is BreadcrumbBarItem)
			{
				return args.Data;
			}

			if (itemTemplateWrapper != null)
			{
				return itemTemplateWrapper.GetElement(args);
			}
			return args.Data;
		}

		var newContent = GetNewContent(m_itemTemplateWrapper);

		// Element is already a BreadcrumbBarItem, so we just return it.
		if (newContent is BreadcrumbBarItem breadcrumbItem)
		{
			// When the list has not changed the returned item is still a BreadcrumbBarItem but the
			// item is not reset, so we set the content here
			breadcrumbItem.Content = args.Data;
			return breadcrumbItem;
		}

		var newBreadcrumbBarItem = new BreadcrumbBarItem();
		newBreadcrumbBarItem.Content = args.Data;

		// If a user provided item template exists, we pass the template down
		// to the ContentPresenter of the BreadcrumbBarItem.
		if (m_itemTemplateWrapper is ItemTemplateWrapper itemTemplateWrapper)
		{
			newBreadcrumbBarItem.ContentTemplate = itemTemplateWrapper.Template;
		}

		return newBreadcrumbBarItem;
	}

	protected override void RecycleElementCore(ElementFactoryRecycleArgs args)
	{
		if (args.Element is { } element)
		{
			bool isEllipsisDropDownItem = false; // Use of isEllipsisDropDownItem is workaround for
												 // crashing bug when attempting to show ellipsis dropdown after clicking one of its items.

			if (element is BreadcrumbBarItem breadcrumbItem)
			{
				var breadcrumbItemImpl = breadcrumbItem;
				breadcrumbItemImpl.ResetVisualProperties();

				isEllipsisDropDownItem = breadcrumbItemImpl.IsEllipsisDropDownItem();
			}

			if (m_itemTemplateWrapper != null && isEllipsisDropDownItem)
			{
				m_itemTemplateWrapper.RecycleElement(args);
			}
		}
	}
}
