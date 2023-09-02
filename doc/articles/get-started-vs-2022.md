---
uid: Uno.GetStarted.vs2022
---

# Get Started on Visual Studio 2022

This getting started will guide you through the creation of an Uno Platform App using C# and .NET, based in the WinUI 3 XAML.

> [!TIP] 
> This guide covers development on Windows using Visual Studio. If you want to use another environment or IDE, see our [general getting started](get-started.md).

> [!IMPORTANT] 
> To use Xamarin (as opposed to .NET 7 Mobile) with Visual Studio 2019, [follow this guide](get-started-vs.md).

## Prerequisites
To create Uno Platform applications you will need [**Visual Studio 2022 17.4 or later**](https://visualstudio.microsoft.com/vs/):

1. **ASP.NET and web development** workload installed (for WebAssembly development)

    ![Visual Studio Installer - ASP.NET and web development workload](Assets/quick-start/vs-install-web.png)

1. **.NET Multi-platform App UI development** workload installed (for iOS, Android, Mac Catalyst development).

    ![Visual Studio Installer - .NET Multi-platform App UI development workload](Assets/quick-start/vs-install-dotnet-mobile.png)

1. **.NET desktop development** workload installed (for Gtk, Wpf, and Linux Framebuffer development)

    ![Visual Studio Installer - .NET desktop development workload](Assets/quick-start/vs-install-dotnet.png)    

> [!IMPORTANT] 
> To build Xamarin-based projects in Visual Studio 2022, in Visual Studio's installer `Individual components` tab, search for Xamarin and select `Xamarin` and `Xamarin Remoted Simulator`. See [this section on migrating Xamarin projects](migrating-from-xamarin-to-net6.md) to .NET 6.

> [!NOTE]
> For information about connecting Visual Studio to a Mac build host to build iOS apps, see [Pairing to a Mac for Xamarin.iOS development](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/windows/connecting-to-mac/).

[!include[getting-help](use-uno-check-inline-windows.md)]

## Install the Solution Templates

1. Launch Visual Studio 2022, then click `Continue without code`. Click `Extensions` -> `Manage Extensions` from the Menu Bar.

    ![Visual Studio - "Extensions" drop-down selecting "Manage Extensions"](Assets/tutorial01/manage-extensions.png)

2. In the Extension Manager expand the **Online** node and search for `Uno`, install the `Uno Platform` extension or download it from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=unoplatform.uno-platform-addin-2022), then restart Visual Studio.

    ![Extension Manager - Uno Platform extension](Assets/tutorial01/uno-extensions.PNG)

## Create an application

To create an Uno Platform app:
1. Create a new C# solution using the **Uno Platform App** template, from Visual Studio's **Start Page**, then click the **Next** button

    ![Visual Studio - Get started - Selecting `create a new project` option](Assets/tutorial01/newproject1.PNG)
    ![Visual Studio - Create a new project - Selecting `Uno Platform App` option](Assets/tutorial01/newproject2.PNG)

1. Configure your new project by providing a project name and a location, then click the **Create** button

    ![Visual Studio - Configure project name and location](Assets/tutorial01/configure-new-unoplatform-app.PNG)

1. Choose the base template to build your application
   
    ![Visual Studio - Configure your new project](Assets/quick-start/vsix-new-project-options.png)

1. You can optionally choose to customize your app based on the sections on the left side:
    - **Framework** allows to choose which `TargetFramework` your app will use. [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) is a commonly appropriate choice.
    - **Platforms** provides a list of platforms your application will support. You still can [add additional platforms](xref:Uno.Guides.AddAdditionalPlatforms) later.
    - **Presentation** gives a choice about using MVVM (e.g. [MVVM Toolkit](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)) or [Uno Platform's MVUX and Feeds](xref:Overview.Reactive.Concept)
    - **Projects** gives the ability to add a Server project for APIs and hosting for the WebAssembly project
    - **Testing** provides Unit Testing and [UI Testing projects](https://github.com/unoplatform/Uno.UITest)
    - **Features** provides support for WebAssembly PWA and optional [VS Code support](xref:Uno.GetStarted.vscode) files
    - **Extensions** allows to choose for [additional Uno.Extensions](xref:Overview.Features) to kickstart your app faster
    - **Application** sets the App ID for relevant platforms, used when publishing on various app stores.
    - **Theme** gives the ability to change between [Fluent](xref:uno.themes.fluent.getstarted) and [Material](xref:uno.themes.material.getstarted)
    
1. Click the create button

1. Wait for the projects to be created, and their dependencies to be restored

1. A banner at the top of the editor may ask to reload projects, click **Reload projects**:
    ![Visual Studio - A banner indicating to reload projects](Assets/quick-start/vs2022-project-reload.png)

1. To debug the **Windows** head:
    - Right-click on the `MyApp.Windows` project, select **Set as startup project**
    - Select the `Debug|x86` configuration
    - Press the `MyApp.Windows` button to deploy the app
    - If you've not enabled Developer Mode, the Settings app should open to the appropriate page. Turn on Developer Mode and accept the disclaimer.
1. To run the **WebAssembly** (Wasm) head:
    - Right click on the `MyApp.Wasm` project, select **Set as startup project**
    - Press the `MyApp.Wasm` button to deploy the app
    - To run/debug your WebAssembly app on a mobile device, you can utilize the Dev Tunnels feature of Visual Studio 2022 - see [Microsoft Learn documentation](https://learn.microsoft.com/aspnet/core/test/dev-tunnels) to get started
1. To run the ASP.NET Hosted **WebAssembly** (Server) head:
    - Right click on the `MyApp.Server` project, select **Set as startup project**
    - Press the `MyApp.Server` button to deploy the app
1. To debug for **iOS**:
    - Right click on the `MyApp.Mobile` project, select **Set as startup project**
    - In the "Debug toolbar" drop-down, select framework `net7.0-ios`:

      ![Visual Studio - "Debug toolbar" drop-down selecting the "net7.0-ios" framework](Assets/quick-start/net7-ios-debug.png)
      
    - Select:
      - An active device, if your IDE is connected to a macOS Host
      - A [local device using Hot Restart](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/deploy-test/hot-restart), to debug your application without connecting to a mac
1. To debug the **Android** platform:
    - Right click on the `MyApp.Mobile` project, select **Set as startup project**
    - In the **Debug toolbar** drop down, select framework `net7.0-android`
    - Select an active device in the "Device" sub-menu

You're all set! You can now head to [our tutorials](getting-started-tutorial-1.md) on how to work on your Uno Platform app.

> [!NOTE] 
> Debugging either the macOS and macCatalyst targets is not supported from Visual Studio on Windows.

## Troubleshooting Installation Issues

You may encounter installation and/or post-installation Visual Studio issues for which workarounds exist. Please see [Common Issues](https://platform.uno/docs/articles/get-started-wizard.html) we have documented.

[!include[getting-help](getting-help.md)]

## Further reading
- [Special considerations for the WinAppSDK project](features/winapp-sdk-specifics.md)
