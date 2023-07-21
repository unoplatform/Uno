﻿using System;
using Uno.Extensions;
using UIKit;

namespace Uno.UI.Views.Controls
{
	public interface IDataTemplateSelectorStrategy
	{
		Func<UIView> SelectTemplateFactory(object item);
	}

	public partial class StrategyBasedDataTemplateSelectorControl : DataTemplateSelectorControl
	{
		#region CurrentStrategy Property

		IDataTemplateSelectorStrategy _currentStrategy;

		public IDataTemplateSelectorStrategy CurrentStrategy
		{
			get
			{
				return _currentStrategy;
			}
			set
			{
				_currentStrategy = value;
				OnCurrentStrategyChanged();
			}
		}

		void OnCurrentStrategyChanged()
		{
			ContentTemplate = SelectTemplateFactory(Content);
		}

		#endregion

		protected override Func<UIView> SelectTemplateFactory(object item)
		{
			return CurrentStrategy.SelectOrDefault(s => s.SelectTemplateFactory(item));
		}
	}
}
