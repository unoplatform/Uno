# How to use Uno.Material

This guide will walk you through the necessary steps to setup and to use the [`Uno.Material` package](https://www.nuget.org/packages/Uno.Material) in an Uno Platform application.

> [!TIP]
> The complete source code that goes along with this guide is available in the [unoplatform/Uno.Samples](https://github.com/unoplatform/Uno.Samples) GitHub repository - [UnoMaterialSample](https://github.com/unoplatform/Uno.Samples/tree/master/UI/UnoMaterialSample)

## Prerequisites

# [Visual Studio for Windows](#tab/tabid-vswin)

* [Visual Studio 2019 16.3 or later](http://www.visualstudio.com/downloads/)
  * **Universal Windows Platform** workload installed
  * **Mobile Development with .NET (Xamarin)** workload installed
  * **ASP**.**NET and web** workload installed
  * [Uno Platform Extension](https://marketplace.visualstudio.com/items?itemName=nventivecorp.uno-platform-addin) installed

# [VS Code](#tab/tabid-vscode)

* [**Visual Studio Code**](https://code.visualstudio.com/)

* [**Mono**](https://www.mono-project.com/download/stable/)

* **.NET Core SDK**
    * [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) (**version 3.1.8 (SDK 3.1.402)** or later)
    * [.NET Core 5.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/5.0) (**version 5.0 (SDK 5.0.100)** or later)

    > Use `dotnet --version` from the terminal to get the version installed.

# [Visual Studio for Mac](#tab/tabid-vsmac)

* [**Visual Studio for Mac 8.8**](https://visualstudio.microsoft.com/vs/mac/)
* [**Xcode**](https://apps.apple.com/us/app/xcode/id497799835?mt=12) 10.0 or higher
* An [**Apple ID**](https://support.apple.com/en-us/HT204316)
* **.NET Core SDK**
    * [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) (**version 3.1.8 (SDK 3.1.402)** or later)
    * [.NET Core 5.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/5.0) (**version 5.0 (SDK 5.0.100)** or later)
* [**GTK+3**](https://formulae.brew.sh/formula/gtk+3) for running the Skia/GTK projects

# [JetBrains Rider](#tab/tabid-rider)

* [**Rider Version 2020.2+**](https://www.jetbrains.com/rider/download/)
* [**Rider Xamarin Android Support Plugin**](https://plugins.jetbrains.com/plugin/12056-rider-xamarin-android-support/) (you may install it directly from Rider)

***

<br>

> [!TIP]
> For a step-by-step guide to installing the prerequisites for your preferred IDE and environment, consult the [Get Started guide](../get-started.md).

## Step-by-steps
### Section 1: Setup Uno.Material
1. Create a new Uno Platform application, following the instructions [here](../get-started.md).
1. Add NuGet package `Uno.Material` to each of project heads:

    > [!NOTE]
    > The project heads refer to the projects targeted to a specific platforms:
    > - UnoMaterialSample.Droid
    > - UnoMaterialSample.iOS
    > - UnoMaterialSample.macOS
    > - UnoMaterialSample.Skia.Gtk
    > - UnoMaterialSample.Skia.Tizen
    > - UnoMaterialSample.Skia.WPF
    > - UnoMaterialSample.UWP
    > - UnoMaterialSample.Wasm
    >
    > > The shared project is not part of this, and the `.Skia.WPF.Host` project is another exception.

    Here are some issues that you are likely to run into after complete the above step:
    - > NU1605: Detected package downgrade: Uno.UI from 3.6.0-dev.275 to 3.5.1. Reference the package directly from the project to select a different version.

        The app may not compile, crash at runtime, or behave strangely as a result of this.
        solution: You need to update the version of `Uno.WinUI` packages for all project heads that you are using to the higher version.
        > note: By `Uno.WinUI` (or `Uno.UI`) packages, it includes:
        > - Uno.WinUI
        > - Uno.WinUI.RemoteControl
        > - Uno.WinUI.WebAssembly
        > - Uno.WinUI.Skia.Gtk
        > - Uno.WinUI.Skia.Tizen
        > - Uno.WinUI.Skia.Wpf

    - When building the `.Droid` project, the project failed to build with:
        ```
        error : Could not find 1 Android X assemblies, make sure to install the following NuGet packages:
            - Xamarin.AndroidX.Lifecycle.LiveData
        You can also copy-and-paste the following snippet into your .csproj file:
            <PackageReference Include="Xamarin.AndroidX.Lifecycle.LiveData" Version="2.1.0" />
        ```
        The solution: Simply add the specific version of `Xamarin.AndroidX.Lifecycle.LiveData` to the `.Droid` project
1. Add the following code inside `App.xaml`:
    ```xml
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- Load WinUI resources -->
                <XamlControlsResources xmlns="using:Microsoft.UI.Xaml.Controls" />

                <!-- Load Material Color Palette -->
                <MaterialColors xmlns="using:Uno.Material" />

                <!-- Load the Material control resources -->
				<MaterialResources xmlns="using:Uno.Material" />

                <!-- Application's custom styles -->
                <!-- other ResourceDictionaries -->
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
    ```

### Section 2: Using Uno.Toolkit.UI library
1. Let's add a few controls with the Material style to `MainPage.xaml`:
    ```xml
    <Page x:Class="UnoMaterialSample.MainPage"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:toolkit="using:Uno.UI.Toolkit">

        <Grid toolkit:VisibleBoundsPadding.PaddingMask="Top" >
            <ScrollViewer>
                <StackPanel Margin="16,0" Spacing="8">
                    <!-- controls with material styles -->
                    <TextBlock Text="Hello, Material!" Style="{StaticResource MaterialHeadline2}" />
                    <TextBlock Text="text" Style="{StaticResource MaterialBody1}" />
                    <Button Content="button" Style="{StaticResource MaterialContainedButtonStyle}" />
                    <ComboBox ItemsSource="asd" Style="{StaticResource MaterialComboBoxStyle}" />
                    <DatePicker Style="{StaticResource MaterialDatePickerStyle}" />
                    <TextBox Text="input" Style="{StaticResource MaterialFilledTextBoxStyle}" />

                </StackPanel>
            </ScrollViewer>
        </Grid>
    </Page>
    ```
1. Now we'll add a few new controls that are defined in the Toolkit.UI package - `Card`, `ChipGroup`, `Chip`, and `Divider`:
    ```xml
    <Page ...
          xmlns:utu="using:Uno.Toolkit.UI">

        <Grid toolkit:VisibleBoundsPadding.PaddingMask="Top" >
            <ScrollViewer>
                <StackPanel Margin="16,0" Spacing="8">
                    <!-- controls with material styles -->
                    <!-- ... -->

                    <!-- material controls -->
                    <utu:Divider SubHeader="Uno.Material Controls:" Style="{StaticResource MaterialDividerStyle}" />
                    <utu:Card HeaderContent="Material Design"
                            SupportingContent="Material is a design system created by Google to help teams build high-quality digital experiences for Android, iOS, Flutter, and the web."
                            Style="{StaticResource MaterialOutlinedCardStyle}">
                        <utu:Card.HeaderContentTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding}" Margin="16,14,16,0" Style="{ThemeResource MaterialHeadline6}" />
                            </DataTemplate>
                        </utu:Card.HeaderContentTemplate>
                        <utu:Card.SupportingContentTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding}" Margin="16,0,16,14" Style="{ThemeResource MaterialBody2}" />
                            </DataTemplate>
                        </utu:Card.SupportingContentTemplate>
                    </utu:Card>
                    <utu:ChipGroup SelectionMode="Multiple" Style="{StaticResource MaterialFilledInputChipGroupStyle}">
                        <utu:Chip Content="Uno" />
                        <utu:Chip Content="Material" />
                        <utu:Chip Content="Controls" />
                    </utu:ChipGroup>
                </StackPanel>
            </ScrollViewer>
        </Grid>
    </Page>
    ```

> [!TIP]
> You can find the style names using these methods:
> - "Feature" section of Uno.Themes README [here](https://github.com/unoplatform/Uno.Themes#features)
> - Going through the [source code](https://github.com/unoplatform/Uno.Themes/tree/master/src/library/Uno.Material/Styles/Controls) of control styles
> - Check out the [Uno.Gallery web app](https://gallery.platform.uno/) (Click on the `<>` button to view xaml source)

### Section 3: Overriding Color Palette
1. Create the nested folders `Styles\` and then `Styles\Application\` under the `.Shared` project
1. Add a new Resource Dictionary `ColorPaletteOverride.xaml` under `Styles\Application\`
1. Replace the content of that res-dict with the source from [here](https://github.com/unoplatform/Uno.Themes/blob/master/src/library/Uno.Material/Styles/Application/ColorPalette.xaml)
1. Make a few changes to the color:
    > Here we are replacing the last 2 characters with 00, essentially dropping the blue-channel
    ```xml
    <!-- Light Theme -->
    <ResourceDictionary x:Key="Light">
        <Color x:Key="MaterialPrimaryColor">#5B4C00</Color>
        <Color x:Key="MaterialPrimaryVariantDarkColor">#353F00</Color>
        <Color x:Key="MaterialPrimaryVariantLightColor">#B6A800</Color>
        <Color x:Key="MaterialSecondaryColor">#67E500</Color>
        <Color x:Key="MaterialSecondaryVariantDarkColor">#2BB200</Color>
        <Color x:Key="MaterialSecondaryVariantLightColor">#9CFF00</Color>
        <Color x:Key="MaterialBackgroundColor">#FFFFFF</Color>
        <Color x:Key="MaterialSurfaceColor">#FFFFFF</Color>
        <Color x:Key="MaterialErrorColor">#F85900</Color>
        <Color x:Key="MaterialOnPrimaryColor">#FFFF00</Color>
        <Color x:Key="MaterialOnSecondaryColor">#000000</Color>
        <Color x:Key="MaterialOnBackgroundColor">#000000</Color>
        <Color x:Key="MaterialOnSurfaceColor">#000000</Color>
        <Color x:Key="MaterialOnErrorColor">#000000</Color>
        <Color x:Key="MaterialOverlayColor">#51000000</Color>

        <!-- ... -->
    </ResourceDictionary>

    <!-- Dark Theme -->
    <ResourceDictionary x:Key="Dark">
        <Color x:Key="MaterialPrimaryColor">#B6A800</Color>
        <Color x:Key="MaterialPrimaryVariantDarkColor">#353F00</Color>
        <Color x:Key="MaterialPrimaryVariantLightColor">#D4CB00</Color>
        <Color x:Key="MaterialSecondaryColor">#67E500</Color>
        <Color x:Key="MaterialSecondaryVariantDarkColor">#2BB200</Color>
        <Color x:Key="MaterialSecondaryVariantLightColor">#9CFF00</Color>
        <Color x:Key="MaterialBackgroundColor">#121212</Color>
        <Color x:Key="MaterialSurfaceColor">#121212</Color>
        <Color x:Key="MaterialErrorColor">#CF6600</Color>
        <Color x:Key="MaterialOnPrimaryColor">#0000FF</Color>
        <Color x:Key="MaterialOnSecondaryColor">#000000</Color>
        <Color x:Key="MaterialOnBackgroundColor">#FFFFFF</Color>
        <Color x:Key="MaterialOnSurfaceColor">#DEFFFFFF</Color>
        <Color x:Key="MaterialOnErrorColor">#000000</Color>
        <Color x:Key="MaterialOverlayColor">#51FFFFFF</Color>

        <!-- ... -->
    </ResourceDictionary>

    <!-- ... -->
    ```
    > You may also use this for picking colors: https://material.io/design/color/the-color-system.html#tools-for-picking-colors
1. In `App.xaml`, update the line that initializes the `MaterialColors` to include the new palette override:
    ```xml
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- ... -->

                <!-- Load Material Color Palette with OverrideSource -->
				<MaterialColors xmlns="using:Uno.Material"
								OverrideSource="ms-appx:///ColorPaletteOverride.xaml" />

                <!-- Load the Material control resources -->
				<MaterialResources xmlns="using:Uno.Material" />
                
                <!-- ... -->
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
    ```
1. Run the app, you should now see the controls using your new color scheme.

### Section 4: Fonts
By default, Uno.Material will attempt to apply a FontFamily with a name of `Roboto` to its controls. This FontFamily resource is given the key `MaterialFontFamily`. If there is no FontFamily with name `Roboto` loaded into your application, the default system font will be used. You can override this default behavior by providing an `OverrideSource` to the `<MaterialFonts />` initialization within your `App.xaml`.

1. Install your custom font following the steps [here](../features/custom-fonts.md)
1. Create the nested folders `Styles\` and then `Styles\Application\` under the `.Shared` project
1. Add a new Resource Dictionary `MaterialFontsOverride.xaml` under `Styles\Application\`
1. Add your custom font with the resource key `MaterialFontFamily`:
    ```xml
    <ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006">

        <FontFamily x:Key="MaterialFontFamily">ms-appx:///Assets/Fonts/Material/RobotoMono-VariableFont_wght.ttf#Roboto Mono</FontFamily>
        
    </ResourceDictionary>
    ```
1. In `App.xaml`, add the line that initializes the `MaterialFonts` to include the new font override:
    ```xml
    <Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <!-- ... -->

            <!-- Load Material Font with OverrideSource -->
            <MaterialFonts xmlns="using:Uno.Material"
                            OverrideSource="ms-appx:///MaterialFontsOverride.xaml" />
            
            <!-- Load the Material control resources -->
            <MaterialResources xmlns="using:Uno.Material" />

            <!-- ... -->
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
    </Application.Resources>
    ```
1. Run the app, you should now see the controls using your new FontFamily.


## Note
- Certain controls may require additional setup to setup and/or overriding color pallette. For details, see: [Uno.Material controls extra setup](../features/uno-material-controls-extra-setup.md)

## Get the complete code

See the completed sample on GitHub: [UnoMaterialSample](https://github.com/unoplatform/Uno.Samples/tree/master/UI/UnoMaterialSample)

## Additional Resources
- [Uno.Material](../features/uno-material.md) overview
- Uno.Material library repository: https://github.com/unoplatform/Uno.Themes
- Tools for picking colors: https://material.io/design/color/the-color-system.html#tools-for-picking-colors

<br>

***

[!include[getting-help](getting-help.md)]
