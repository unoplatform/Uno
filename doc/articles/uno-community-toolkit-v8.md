---
uid: Uno.Development.CommunityToolkit.v8
---

# How to use Windows Community Toolkit - Version 8.x

This tutorial will walk you through adding and implementing the `SettingsCard` control but the same steps can be followed for **other\*** Windows Community Toolkit controls version 8.x.

**\* See the [non-Windows platform compatibility](xref:Uno.Development.CommunityToolkit#non-windows-platform-compatibility) section for more details.**

> [!NOTE]
> The complete source code that goes along with this guide is available in the [unoplatform/Uno.Samples](https://github.com/unoplatform/Uno.Samples) GitHub repository - [`SettingsCard` Sample](https://github.com/unoplatform/Uno.Samples/tree/master/UI/WindowsCommunityToolkit/Version-8.x/UnoWCTSettingsCardSample)

## Prerequisites

For a step-by-step guide to installing the prerequisites for your preferred IDE and environment, consult the [Get Started guide](xref:Uno.GetStarted).

> [!TIP]
> If you are unsure of the version of the Windows Community Toolkit to use between v7 and v8, make sure to read the details about the Windows Community Toolkit [migration guide](xref:Uno.Development.CommunityToolkit).

## NuGet Packages

Uno Platform is now supported out of the box by the Windows Community Toolkit and Windows Community Toolkit Labs starting with version 8.x.

> [!IMPORTANT]
> If you are already using Windows Community Toolkit version 7.x in your Uno Platform project and want to update to version 8.x, note that Uno Platform has its [own fork](https://github.com/unoplatform/Uno.WindowsCommunityToolkit) of the Windows Community Toolkit for [version 7.x](xref:Uno.Development.CommunityToolkit.v7).
>
> In your project, these Windows Community Toolkit Uno packages were referenced behind a conditional to allow for use on Windows, Android, iOS, mac Catalyst, Linux, and WebAssembly.
>
> Conditional references are no longer necessary with version 8.x, you can remove the Uno Windows Community Toolkit references and all `Condition` statements around the packages.

## Referencing the Windows Community Toolkit

When using the Uno Platform solution templates, add the following to your application:

1. Install the NuGet package(s) reference(s) that you need

    ### [Single Project Template [WinUI / WinAppSDK]](#tab/singleproj)

    1. Edit your project file `PROJECT_NAME.csproj` and add the needed reference(s):

        ```xml
        <ItemGroup>
          <PackageReference Include="CommunityToolkit.WinUI.Controls.SettingsControls" />
          <!-- Add more community toolkit references here -->
        </ItemGroup>
        ```

    1. Edit `Directory.Packages.props` and add the needed reference(s):

        ```xml
        <ItemGroup>
          <PackageVersion Include="CommunityToolkit.WinUI.Controls.SettingsControls" Version="8.1.240916" />
          <!-- Add more community toolkit references here -->
        </ItemGroup>
        ```

    > [!NOTE]
    > Windows Community Toolkit version 8.x requires an update to Windows SDK **10.0.22621** and above, along with [Microsoft.WindowsAppSDK](https://www.nuget.org/packages/Microsoft.WindowsAppSDK) updated to the latest matching version.
    >
    > To override these versions within a single project structure, you can set the properties in the `Directory.Build.props` file or directly in your project's `csproj` file. For more detailed information, please see the [implicit packages details](xref:Uno.Features.Uno.Sdk#implicit-packages).
    >
    > For example, in `PROJECT_NAME.csproj`:
    >
    > ```xml
    > <TargetFrameworks>
    >   <!-- Code for other TargetFrameworks omitted for brevity -->
    >   net8.0-windows10.0.22621;
    > </TargetFrameworks>
    > ```
    >
    > ```xml
    > <PropertyGroup>
    >   <WindowsSdkPackageVersion>10.0.22621.38</WindowsSdkPackageVersion>
    >   <WinAppSdkVersion>1.5.240607001</WinAppSdkVersion>
    > </PropertyGroup>
    > ```

    ### [Multi-Head Project Template (Legacy) [WinUI / WinAppSDK]](#tab/multihead-winui)

    Edit your project file `PROJECT_NAME.csproj` and add the needed reference(s):

    ```xml
    <ItemGroup>
      <PackageReference Include="CommunityToolkit.WinUI.Controls.SettingsControls" Version="8.1.240916" />
      <!-- Add more community toolkit references here -->
    </ItemGroup>
    ```

    > [!NOTE]
    > Windows Community Toolkit version 8.x requires an update to Windows SDK **10.0.22621** and above, along with [Microsoft.WindowsAppSDK](https://www.nuget.org/packages/Microsoft.WindowsAppSDK) updated to the latest matching version.

    ### [Multi-Head Project Template (Legacy) [UWP]](#tab/multihead-uwp)

    Edit your project file `PROJECT_NAME.csproj` and add the needed reference(s):

    ```xml
    <ItemGroup>
      <PackageReference Include="CommunityToolkit.Uwp.Controls.SettingsControls" Version="8.1.240916" />
      <!-- Add more community toolkit references here -->
    </ItemGroup>
    ```

    > [!NOTE]
    > Windows Community Toolkit version 8.x requires an update to Windows SDK **10.0.22621** and above, along with [Microsoft.WindowsAppSDK](https://www.nuget.org/packages/Microsoft.WindowsAppSDK) updated to the latest matching version.

    ### [Shared Project (.shproj) Template (Legacy) [WinUI / WinAppSDK]](#tab/shproj-winui)

    1. Select the following projects for installation and add the needed reference(s) to each of them:
        - `PROJECT_NAME.Windows.csproj`
        - `PROJECT_NAME.Wasm.csproj`
        - `PROJECT_NAME.Mobile.csproj` (or `PROJECT_NAME.iOS.csproj`, `PROJECT_NAME.Droid.csproj`, and `PROJECT_NAME.macOS.csproj` if you have an existing project)
        - `PROJECT_NAME.Skia.Gtk.csproj`
        - `PROJECT_NAME.Skia.WPF.csproj`

        ```xml
        <ItemGroup>
          <PackageReference Include="CommunityToolkit.WinUI.Controls.SettingsControls" Version="8.1.240916" />
          <!-- Add more uno community toolkit references here -->
        </ItemGroup>
        ```

    > [!NOTE]
    > Windows Community Toolkit version 8.x requires an update to Windows SDK **10.0.22621** and above, along with [Microsoft.WindowsAppSDK](https://www.nuget.org/packages/Microsoft.WindowsAppSDK) updated to the latest matching version.

    ### [Shared Project (.shproj) Template (Legacy) [UWP]](#tab/shproj-uwp)

    1. Select the following projects for installation and add the needed reference(s) to each of them:
        - `PROJECT_NAME.UWP.csproj`
        - `PROJECT_NAME.Wasm.csproj`
        - `PROJECT_NAME.Mobile.csproj` (or `PROJECT_NAME.iOS.csproj`, `PROJECT_NAME.Droid.csproj`, and `PROJECT_NAME.macOS.csproj` if you have an existing project)
        - `PROJECT_NAME.Skia.Gtk.csproj`
        - `PROJECT_NAME.Skia.WPF.csproj`

        ```xml
        <ItemGroup>
          <PackageReference Include="CommunityToolkit.Uwp.Controls.SettingsControls" Version="8.1.240916" />
          <!-- Add more uno community toolkit references here -->
        </ItemGroup>
        ```

    > [!NOTE]
    > Windows Community Toolkit version 8.x requires an update to Windows SDK **10.0.22621** and above, along with [Microsoft.WindowsAppSDK](https://www.nuget.org/packages/Microsoft.WindowsAppSDK) updated to the latest matching version.

    ---

1. Add the related needed namespace(s)

    > [!NOTE]
    > In WCT version 8.x, the namespaces between UWP and WinAppSDK were merged.

    ### WinUI / WinAppSDK / UWP

      In XAML:  
        ```xmlns:controls="using:CommunityToolkit.WinUI.Controls"```

      In C#:  
        ```using CommunityToolkit.WinUI.Controls;```

## Example with the SettingsCard Control

SettingsCard is a control that can be used to display settings in your experience. It uses the default styling found in Windows 11 and is easy to use, meets all accessibility standards and will make your settings page look great!

You can set the `Header`, `HeaderIcon`, `Description`, and `Content` properties to create an easy to use experience, like so:

```xml
<controls:SettingsCard Description="This is a default card, with the Header, HeaderIcon, Description and Content set."
                       Header="This is the Header">
  <controls:SettingsCard.HeaderIcon>
    <FontIcon Glyph="&#xE799;"
              FontFamily="{ThemeResource SymbolThemeFontFamily}" />
  </controls:SettingsCard.HeaderIcon>
  <ComboBox SelectedIndex="0">
    <ComboBoxItem>Option 1</ComboBoxItem>
    <ComboBoxItem>Option 2</ComboBoxItem>
    <ComboBoxItem>Option 3</ComboBoxItem>
  </ComboBox>
</controls:SettingsCard>
```

### See a working sample with more examples

![settingscard-full-sample](Assets/settingscard-full-sample.gif)

A complete working sample, along with additional examples, is available on GitHub: [Uno Windows Community Toolkit SettingsCard Sample](https://github.com/unoplatform/Uno.Samples/tree/master/UI/WindowsCommunityToolkit/Version-8.x/UnoWCTSettingsCardSample)

## Using Non-UI Elements from the CommunityToolkit: Converters

The CommunityToolkit is providing some ready-to-use Converters for e.g. x:Bind in Xaml, whithout having to write already existing basic Converters yourself.
[List of CommunityToolkit Converters | Windows Toolkit Documentation](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/windows/converters/)

The implementation of those are quite similar to the example of the SettingsControl above, but there are small adjustments to be done to use them:

1. Import of the Package

   Change this:

   ```CommunityToolkit.WinUI.Controls.SettingsControls```

   to Converters namespace:

   ```CommunityToolkit.WinUI.Converters```

   while the Version will stay the same as above.

1. Add the related needed namespace(s)

    > [!NOTE]
    > In WCT version 8.x, the namespaces between UWP and WinAppSDK were merged.

    ### WinUI / WinAppSDK / UWP

      In XAML:  
        ```xmlns:converters="using:CommunityToolkit.WinUI.Converters"```

      In C#:  
        ```using CommunityToolkit.WinUI.Converters;```

      In case you are developing a App that's using C# Markup and you want to use the Converters, you can now switch to [C#-Markup Converters](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Markup/Converters.html) Documentation for future Usage Guide, the general Import is done from here on.

1. Xaml Definition

Important Difference to the previous seen SettingsCard Control Example, a Non-UI Converter has to be imported to the Page.Ressources Section to StaticRessources like this for using it, since there is no single Namespace per Converter like on the Controls:

### [Example StringToVisibilityConverter](#tab/string-visible-conv)

StringToVisibilityConverter is a Converter that has to be bound to a String typed Property and will return a Visibility State.

```
<Page.Resources>
  <converters:StringVisibilityConverter x:Key="YourStringVisibilityConverter"/>
</Page.Resources>
```

Somewhere in your Page Content:

```xml
  <TextBox x:Name="tbName"
           Text="{Binding Name, Mode=TwoWay}" 
           PlaceholderText="Enter your name:"/>
  <Button x:Name="StartButton"
          Content="Start a cool simple Game!"
          AutomationProperties.AutomationId="StartAGameButton"
          Command="{Binding GoToStart}"
          HorizontalAlignment="Center"
          Visibility="{x:Bind tbName.Text, Converter={StaticResource StringVisibilityConverter}, Mode=OneWay}"/>
```

### [Example BoolToObjectConverter](#tab/bool-obj-conv)

BoolToObjectConverter is a Converter that has to be bound to a Boolean typed Property and can return any Object you will give to it.
You only have to tell it what to return on True or False. If you would like to use it for switching color on validation:

```
BoolToObjectConverter x:Key="BoolToColorConverter" TrueValue="{ThemeResource SystemFillColorSuccessBackgroundBrush}"
                                                   FalseValue="{ThemeResource SystemFillColorCriticalBackgroundBrush}"/>
```

> [!NOTE]
> The used ThemeResource Brushes can be found in the WinUI Gallery for example.
> Feel free to use your own Colors e.g. from ColorPaletteOverrides

Somewhere in your Page Content:

```xml
  <TextBox x:Name="tbName"
           Text="{Binding Name, Mode=TwoWay}" 
           PlaceholderText="Enter your name:"
           BackgroundColor="{x:Bind tbName.Text, Converter={StaticResource BoolToColorConverter},Mode=OneWay}/>
  <Button x:Name="StartButton"
          Content="Start a cool simple Game!"
          AutomationProperties.AutomationId="StartAGameButton"
          Command="{Binding GoToStart}"
          HorizontalAlignment="Center"/>
```
    
---

[!include[getting-help](includes/getting-help.md)]
