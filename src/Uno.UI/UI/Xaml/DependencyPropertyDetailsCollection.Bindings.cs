﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.UI.Xaml.Data;
using Uno.Collections;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;

namespace Microsoft.UI.Xaml
{
	/// <summary>
	/// A <see cref="DependencyPropertyDetails"/> collection
	/// </summary>
	partial class DependencyPropertyDetailsCollection
	{
		private List<BindingExpression> _bindings;
		private List<BindingExpression> _templateBindings;

		private bool _bindingsSuspended;

		/// <summary>
		/// Applies the specified templated parent on the current <see cref="TemplateBinding"/> instances
		/// </summary>
		/// <param name="templatedParent"></param>
		internal void ApplyTemplatedParent(FrameworkElement templatedParent)
		{
			if (_templateBindings is not null)
			{
				for (int i = 0; i < _templateBindings.Count; i++)
				{
					ApplyBinding(_templateBindings[i], templatedParent);
				}
			}
		}

		public bool HasBindings =>
			_bindings is { Count: > 0 } || _templateBindings is { Count: > 0 };

		/// <summary>
		/// Applies the specified datacontext on the current <see cref="Binding"/> instances
		/// </summary>
		public void ApplyDataContext(object dataContext)
		{
			if (_bindings is not null)
			{
				for (int i = 0; i < _bindings.Count; i++)
				{
					ApplyBinding(_bindings[i], dataContext);
				}
			}
		}

		/// <summary>
		/// Applies the <see cref="Binding"/> instances which have a <see cref="Binding.CompiledSource"/> set.
		/// </summary>
		internal void ApplyCompiledBindings()
		{
			if (_bindings is not null)
			{
				for (int i = 0; i < _bindings.Count; i++)
				{
					_bindings[i].ApplyCompiledSource();
				}
			}
		}

		/// <summary>
		/// Applies the <see cref="Binding"/> instances which contain an ElementName property
		/// </summary>
		internal void ApplyElementNameBindings()
		{
			if (_bindings is not null)
			{
				for (int i = 0; i < _bindings.Count; i++)
				{
					_bindings[i].ApplyElementName();
				}
			}
		}

		/// <summary>
		/// Suspends the <see cref="Binding"/> instances from reacting to DataContext changes
		/// </summary>
		internal void SuspendBindings()
		{
			if (!_bindingsSuspended)
			{
				_bindingsSuspended = true;

				if (_bindings is not null)
				{
					for (int i = 0; i < _bindings.Count; i++)
					{
						_bindings[i].SuspendBinding();
					}
				}
			}
		}

		/// <summary>
		/// Resumes the <see cref="Binding"/> instances for reacting to DataContext changes
		/// </summary>
		internal void ResumeBindings()
		{
			if (_bindingsSuspended)
			{
				_bindingsSuspended = false;

				if (_bindings is not null)
				{
					for (int i = 0; i < _bindings.Count; i++)
					{
						_bindings[i].ResumeBinding();
					}
				}

				var value = DataContextPropertyDetails.GetEffectiveValue();
				if (value == DependencyProperty.UnsetValue)
				{
					// If we get UnsetValue, it means this is DefaultValue precedence that's not stored in DependencyPropertyDetails.
					// In this case, we know for sure that DataContext's default value is null.
					value = null;
				}

				ApplyDataContext(value);
			}
		}

		/// <summary>
		/// Gets the DataContext <see cref="Binding"/> instance, if any
		/// </summary>
		/// <returns></returns>
		internal BindingExpression FindDataContextBinding() => DataContextPropertyDetails.GetBinding();

		/// <summary>
		/// Sets the specified <paramref name="binding"/> on the <paramref name="target"/> instance.
		/// </summary>
		internal void SetBinding(DependencyProperty dependencyProperty, Binding binding, ManagedWeakReference target)
		{
			if (GetPropertyDetails(dependencyProperty) is DependencyPropertyDetails details)
			{
				// Clear previous binding, to avoid erroneously pushing two-way value to it
				details.ClearBinding();

				var bindingExpression =
					new BindingExpression(
						viewReference: target,
						targetPropertyDetails: details,
						binding: binding
					);

				details.SetBinding(bindingExpression);

				if (Equals(binding.RelativeSource, RelativeSource.TemplatedParent))
				{
					(_templateBindings ??= new()).Add(bindingExpression);

					var templatedParent = TemplatedParentPropertyDetails.GetEffectiveValue();
					if (templatedParent == DependencyProperty.UnsetValue)
					{
						// If we get UnsetValue, it means this is DefaultValue precedence that's not stored in DependencyPropertyDetails.
						// In this case, we know for sure that TemplatedParent's default value is null.
						templatedParent = null;
					}

					ApplyBinding(bindingExpression, templatedParent);
				}
				else
				{
					(_bindings ??= new()).Add(bindingExpression);

					if (bindingExpression.TargetPropertyDetails.Property.UniqueId == DataContextPropertyDetails.Property.UniqueId)
					{
						bindingExpression.DataContext = details.GetInheritedValue();
					}
					else
					{
						var value = DataContextPropertyDetails.GetEffectiveValue();
						if (value == DependencyProperty.UnsetValue)
						{
							// If we get UnsetValue, it means this is DefaultValue precedence that's not stored in DependencyPropertyDetails.
							// In this case, we know for sure that DataContext's default value is null.
							value = null;
						}

						ApplyBinding(bindingExpression, value);
					}
				}
			}
		}

		private void ApplyBinding(BindingExpression binding, object dataContext)
		{
			if (Equals(binding.ParentBinding.RelativeSource, RelativeSource.TemplatedParent))
			{
				binding.DataContext = dataContext;
			}
			else if (Equals(binding.ParentBinding.RelativeSource, RelativeSource.Self))
			{
				binding.DataContext = Owner;
			}
			else
			{
				var isDataContextBinding = binding.TargetPropertyDetails.Property.UniqueId == DataContextPropertyDetails.Property.UniqueId;

				if (!isDataContextBinding)
				{
					binding.DataContext = dataContext;
				}
			}
		}

		/// <summary>
		/// Sets the source value for the the specified <paramref name="property"/>
		/// </summary>
		internal void SetSourceValue(DependencyProperty property, object value)
		{
			if (GetPropertyDetails(property) is DependencyPropertyDetails details)
			{
				SetSourceValue(details, value);
			}
		}

		/// <summary>
		/// Sets the source value for the the specified <paramref name="details"/> 
		/// </summary>
		internal void SetSourceValue(DependencyPropertyDetails details, object value)
		{
			details.SetSourceValue(value);

			if (this.Log().IsEnabled(Uno.Foundation.Logging.LogLevel.Debug))
			{
				this.Log().DebugFormat("Set binding value [{0}].", details.Property.Name);
			}
		}

		/// <summary>
		/// Gets the last known defined <see cref="BindingExpression"/> for the specified <paramref name="dependencyProperty"/>
		/// </summary>
		/// <param name="dependencyProperty"></param>
		/// <returns></returns>
		internal BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
		{
			if (GetPropertyDetails(dependencyProperty) is DependencyPropertyDetails details)
			{
				return details.GetBinding();
			}

			return null;
		}

		internal bool IsPropertyTemplateBound(DependencyProperty dependencyProperty)
		{
			foreach (var templateBinding in _templateBindings)
			{
				if (templateBinding.TargetPropertyDetails.Property == dependencyProperty)
				{
					return true;
				}
			}

			return false;
		}

		internal void UpdateBindingExpressions()
		{
			foreach (var binding in _bindings)
			{
				UpdateBindingPropertiesFromThemeResources(binding.ParentBinding);
			}

			foreach (var binding in _templateBindings)
			{
				UpdateBindingPropertiesFromThemeResources(binding.ParentBinding);
			}
		}

		private static void UpdateBindingPropertiesFromThemeResources(Binding binding)
		{
			if (binding.TargetNullValueThemeResource is { } targetNullValueThemeResourceKey)
			{
				binding.TargetNullValue = (object)ResourceResolverSingleton.Instance.ResolveResourceStatic(targetNullValueThemeResourceKey, typeof(object), context: binding.ParseContext);
			}

			if (binding.FallbackValueThemeResource is { } fallbackValueThemeResourceKey)
			{
				binding.FallbackValue = (object)ResourceResolverSingleton.Instance.ResolveResourceStatic(fallbackValueThemeResourceKey, typeof(object), context: binding.ParseContext);
			}
		}

		internal void OnThemeChanged()
		{
			foreach (var binding in _bindings)
			{
				RefreshBindingValueIfNecessary(binding);
			}

			foreach (var binding in _templateBindings)
			{
				RefreshBindingValueIfNecessary(binding);
			}
		}

		private void RefreshBindingValueIfNecessary(BindingExpression binding)
		{
			if (binding.ParentBinding.TargetNullValueThemeResource is not null ||
				binding.ParentBinding.FallbackValueThemeResource is not null)
			{
				// Note: This may refresh the binding more than really necessary.
				// For example, if TargetNullValue is set to a theme resource, but the binding is not null
				// In this case, a change to TargetNullValue should probably not refresh the binding.
				// Another case is when the ThemeResource evaluates the same between light/dark themes.
				// For now, it's not necessary.
				binding.RefreshTarget();
			}
		}
	}
}
