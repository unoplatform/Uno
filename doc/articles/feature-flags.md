# Configuring Uno's behavior globally

Uno provides a set of feature flags that can be set early in an app's startup to control its behavior. Some of these flags are for backward compatibility, some of them provide fine-grained customizability of a particular feature, and some of them allow to toggle between more 'WinUI-like' and more 'native-like' behavior in a particular context.

# Legacy Clipping
Historically, Uno has been relying on the default platform's behavior for clipping, which is quite different from UWP compositing behavior.

By default, this mode is enabled for the time being, as it is quite disrupting.

Use `Uno.UI.FeatureConfiguration.UIElement.UseLegacyClipping` to control this mode.
Additionally, `Uno.UI.FeatureConfiguration.UIElement.ShowClippingBounds` can be used to show the clipping boundaries to determine if the behavior of the clipping is appropriate.

# UWP Styles default

By default, Uno favors the default UWP XAML styles over the native styles for Button, Slider, ComboBox, etc...

This can be changed using `Uno.UI.FeatureConfiguration.Style.UseUWPDefaultStyles`.

## Disabling accessibility text scaling

By default, Uno automatically enables accessibility text scaling on iOS and Android devices however to have more control an option has been added to disable text scaling. 

Use `Uno.UI.FeatureConfiguration.Font.IgnoreTextScaleFactor` to control this.

## Giving a maximum text scaling value

By default, Android has a limit of 200% for the text scaling which is not the case for iOS.

Use `Uno.UI.FeatureConfiguration.Font.MaximumTextScaleFactor` to control this. 

## Popups

In older versions of Uno Platforms, the `Popup.IsLightDismissEnabled` dependency property defaulted to `true`. In UWP/WinUI and Uno 4.1 and newer, it correctly defaults to `false`. If your code depended on the old behavior, you can set the `Uno.UI.FeatureConfiguration.Popup.EnableLightDismissByDefault` property to `true` to override this.

## MessageDialog

By default, `MessageDialog` in Uno Platform targets displays using `ContentDialog` on WebAssembly and Skia, whereas it uses native dialog UI on Android, iOS and macOS. The native dialogs are familiar to the users of the target platform, whereas the `ContentDialog` version offers the same UI on all targets. The  `WinRTFeatureConfiguration.MessageDialog.UseNativeDialog` flag allows you to either disable or enable the use of native dialog UI. The default value of the flag depends on the target platform and changing the value of the flag on Skia has no effect (only `ContentDialog` version is available there):

| Feature        | Android | iOS | macOS | WASM | Skia |
|----------------|---------|-----|-------|------| --- |
| Default value of `UseNativeDialog`     | `true` | `true` |  `true`   | `false` | `false` |
| Native version available     | ✅ | ✅ |  ✅   | ✅(*) | ❌ |
| `ContentDialog` version available     | ✅ | ✅ |  ✅   | ✅ | ✅ |

(*) Native WebAssembly implementation uses `alert()` and is very limited.

When `ContentDialog` version is used, it uses the default `ContentDialog` style. If you want to customize the UI, you can declare your own `Style` on the application resource level and then set the `StyleOverride` flag to the resource key:

```xaml
<Application.Resources>
    <Style x:Key="CustomMessageDialogStyle" TargetType="ContentDialog">
    ...
    </Style>
</Application.Resources>
```

```c#
WinRTFeatureConfiguration.MessageDialog.StyleOverride = "CustomMessageDialogStyle";
```
