using System.ComponentModel;
using Uno.UI.Xaml;

#if XAMARIN_ANDROID
#elif XAMARIN_IOS
using NativeView = UIKit.UIView;
#else
using NativeView = System.Object;
#endif

namespace Windows.UI.Xaml.Controls;

/// <summary>
/// Defines an area within which you can explicitly position child objects, using coordinates that are relative to the Canvas area.
/// </summary>
public partial class Canvas : Panel
{
	/// <summary>
	/// Initializes a new instance of the Canvas class.
	/// </summary>
	public Canvas()
	{
		InitializePartial();
	}

	partial void InitializePartial();
	
	#region Left

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static double GetLeft(DependencyObject obj) => GetLeftValue(obj);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void SetLeft(DependencyObject obj, double value) => SetLeftValue(obj, value);

	/// <summary>
	/// Gets the value of the Canvas.Left XAML attached property for the target element.
	/// </summary>
	/// <param name="element">The object from which the property value is read.</param>
	/// <returns>The Canvas.Left XAML attached property value of the specified object.</returns>
	public static double GetLeft(UIElement element) => GetLeftValue(element);
	
	/// <summary>
	/// Sets the value of the Canvas.Left XAML attached property for a target element.
	/// </summary>
	/// <param name="element">The object to which the property value is written.</param>
	/// <param name="length">The value to set.</param>
	public static void SetLeft(UIElement element, double length) => SetLeftValue((DependencyObject)element, length);

	/// <summary>
	/// Identifies the Canvas.Left XAML attached property.
	/// </summary>
	[GeneratedDependencyProperty(DefaultValue = 0.0d, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, Options = FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsArrange)]
	public static DependencyProperty LeftProperty { get; } = CreateLeftProperty();

	private static void OnLeftChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is IFrameworkElement { Parent: IFrameworkElement parent })
		{
			parent.InvalidateArrange();
		}

#if __WASM__
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties && dependencyObject is UIElement element)
		{
			element.UpdateDOMXamlProperty("Canvas.Left", args.NewValue);
		}
#endif
	}

	#endregion

	#region Top

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static double GetTop(DependencyObject obj) => GetTopValue(obj);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void SetTop(DependencyObject obj, double value) => SetTopValue(obj, value);
	
	/// <summary>
	/// Gets the value of the Canvas.Top XAML attached property for the target element.
	/// </summary>
	/// <param name="element">The object from which the property value is read.</param>
	/// <returns>The Canvas.Top XAML attached property value of the specified object.</returns>
	public static double GetTop(UIElement element) => GetTopValue(element);

	/// <summary>
	/// Sets the value of the Canvas.Top XAML attached property for a target element.
	/// </summary>
	/// <param name="element">The object to which the property value is written.</param>
	/// <param name="length">The value to set.</param>
	public static void SetTop(UIElement element, double length) => SetTopValue(element, length);

	/// <summary>
	/// Identifies the Canvas.Top XAML attached property.
	/// </summary>
	[GeneratedDependencyProperty(DefaultValue = 0.0d, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, Options = FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsArrange)]
	public static DependencyProperty TopProperty { get; } = CreateTopProperty();

	private static void OnTopChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is IFrameworkElement { Parent: IFrameworkElement parent })
		{
			parent.InvalidateArrange();
		}

#if __WASM__
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties && dependencyObject is UIElement element)
		{
			element.UpdateDOMXamlProperty("Canvas.Top", args.NewValue);
		}
#endif
	}

	#endregion

	#region ZIndex

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static double GetZIndex(DependencyObject obj) => GetZIndexValue(obj);

	/// <summary>
	/// Identifies the Canvas.Top XAML attached property.
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="value"></param>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void SetZIndex(DependencyObject obj, double value) => SetZIndexValue(obj, value);
	
	/// <summary>
	/// Gets the value of the Canvas.ZIndex XAML attached property for the target element.
	/// </summary>
	/// <param name="element">The object from which the property value is read.</param>
	/// <returns>The Canvas.ZIndex XAML attached property value of the requested object.</returns>
	public static int GetZIndex(UIElement element) => (int)GetZIndex(element);

	/// <summary>
	/// Sets the value of the Canvas.ZIndex XAML attached property for a target element.
	/// </summary>
	/// <param name="element">The object to which the property value is written.</param>
	/// <param name="value">The value to set.</param>
	public static void SetZIndex(UIElement element, int value) => SetZIndex(element, value);

	/// <summary>
	/// Identifies the Canvas.ZIndex XAML attached property.
	/// </summary>
	[GeneratedDependencyProperty(DefaultValue = 0.0d, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, Options = FrameworkPropertyMetadataOptions.AutoConvert)]
	public static DependencyProperty ZIndexProperty { get; } = CreateZIndexProperty();

	private static void OnZIndexChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
#if !__WASM__
		(dependencyObject as IFrameworkElement)?.InvalidateArrange();
#endif
		if (dependencyObject is UIElement element)
		{
			var zindex = args.NewValue is double d ? (double?)d : null;
			OnZIndexChangedPartial(element, zindex);
		}
	}

	static partial void OnZIndexChangedPartial(UIElement element, double? zindex);

	#endregion
}
