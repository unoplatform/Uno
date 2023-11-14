---
uid: Uno.GetStarted.vs2022
---

# Get Started with Visual Studio 2022

This getting started will guide you through the creation of an Uno Platform application using C# and .NET. You can choose to use XAML or C# Markup to declare the UI of your application.

> [!TIP] 
> This guide covers development on Windows using Visual Studio 2022. If you want to use another environment or IDE, see our [general getting started](get-started.md).

## Install Visual Studio with Workloads
To create Uno Platform applications you will need [**Visual Studio 2022 17.7 or later**](https://visualstudio.microsoft.com/vs/):

1. **ASP.NET and web development** workload installed (for WebAssembly development)

    ![Visual Studio Installer - ASP.NET and web development workload](Assets/quick-start/vs-install-web.png)

1. **.NET Multi-platform App UI development** workload installed (for iOS, Android, Mac Catalyst development).

    ![Visual Studio Installer - .NET Multi-platform App UI development workload](Assets/quick-start/vs-install-dotnet-mobile.png)

1. **.NET desktop development** workload installed (for Gtk, Wpf, and Linux Framebuffer development)

    ![Visual Studio Installer - .NET desktop development workload](Assets/quick-start/vs-install-dotnet.png)    

> [!IMPORTANT] 
> Uno Platform 5.0 [does not support Xamarin projects anymore](xref:Uno.Development.MigratingToUno5). To build Xamarin-based projects in Visual Studio 2022, in Visual Studio's installer `Individual components` tab, search for Xamarin and select `Xamarin` and `Xamarin Remoted Simulator`. See [this section on migrating Xamarin projects](migrating-from-xamarin-to-net6.md) to .NET 6.

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
   
    ![Visual Studio - Configure your new project](getting-started/wizard/assets/intro.jpg)

1. You can optionally choose to customize your app based on the sections on the left side:
    - [**Framework**](xref:Uno.GettingStarted.UsingWizard#1-framework) allows to choose which `TargetFramework` your app will use. [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) is a commonly appropriate choice.
    - [**Platforms**](xref:Uno.GettingStarted.UsingWizard#2-platforms) provides a list of platforms your application will support. You still can [add additional platforms](xref:Uno.Guides.AddAdditionalPlatforms) later.
    - [**Presentation**](xref:Uno.GettingStarted.UsingWizard#3-presentation) gives a choice about using MVVM (e.g. [MVVM Toolkit](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)) or [Uno Platform's MVUX and Feeds](xref:Overview.Reactive.Concept)
    - [**Markup**](xref:Uno.GettingStarted.UsingWizard#4-markup) allows to choose between XAML and [C# Markup](Reference.Markup.GettingStarted) for defining your UI
    - [**Theme**](xref:Uno.GettingStarted.UsingWizard#5-theme) gives the ability to change between [Fluent](xref:uno.themes.fluent.getstarted) and [Material](xref:uno.themes.material.getstarted)
    - [**Extensions**](xref:Uno.GettingStarted.UsingWizard#6-extensions) allows to choose for [additional Uno.Extensions](xref:Overview.Features) to kickstart your app faster
    - [**Features**](xref:Uno.GettingStarted.UsingWizard#7-features) provides support for WebAssembly PWA and optional [VS Code support](xref:Uno.GetStarted.vscode) files
    - [**Authentication**](xref:Uno.GettingStarted.UsingWizard#8-authentication) provides support for authenticating suers with Azure AD, Web or Identity Server based authentication
    - [**Application**](xref:Uno.GettingStarted.UsingWizard#9-application) sets the App ID for relevant platforms, used when publishing on various app stores.
    - [**Testing**](xref:Uno.GettingStarted.UsingWizard#10-testing) provides Unit Testing and [UI Testing projects](https://github.com/unoplatform/Uno.UITest)
    - [**CI Pipeline**](xref:Uno.GettingStarted.UsingWizard#11-ci-pipeline) provides a GitHub Actions workflow or Azure Pipelines files necessary to build your app on every commit

    > [!TIP]
    > For a detailed overview of the Uno Platform project template wizard and all its options, see [this](xref:Uno.GettingStarted.UsingWizard).
    
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
    - Right-click on the `MyApp.Mobile` project, select **Set as startup project**
        > [!NOTE]
        > For information about connecting Visual Studio to a Mac build host to build iOS apps, see [Pairing to a Mac for .NET iOS development](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/windows/connecting-to-mac/). Catalyst apps are not supported in Visual Studio 2022 on Windows, you can use [VS Code Remote SSH](xref:Uno.GetStarted.vscode) to enable this scenario.

    - In the "Debug toolbar" drop-down, select framework `net7.0-ios`:

      ![Visual Studio - "Debug toolbar" drop-down selecting the "net7.0-ios" framework](Assets/quick-start/net7-ios-debug.png)
      
    - Select:
      - An active device, if your IDE is connected to a macOS Host
      - A [local device using Hot Restart](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/deploy-test/hot-restart), to debug your application without connecting to a mac
      
        > [!NOTE] 
        > If no iOS devices are available, a Visual Studio 17.7+ issue requires unloading/reloading the project. Right-click on the `.Mobile` project and select **Unload Project** then **Load project**.

1. To debug the **Android** platform:
    - Right click on the `MyApp.Mobile` project, select **Set as startup project**
    - In the **Debug toolbar** drop down, select framework `net7.0-android`
    - Select an active device in the "Device" sub-menu
        > [!NOTE] 
        > If no android devices are available, a Visual Studio 17.7+ issue requires unloading/reloading the project. Right-click on the `.Mobile` project and select **Unload Project** then **Load project**.

You're all set, and don't forget to take a look at our [Hot Reload feature](xref:Uno.Features.HotReload)! You can now head to [our tutorials](getting-started-tutorial-1.md) on how to work on your Uno Platform app.

> [!IMPORTANT]
> Take a [look at our article](xref:Build.Solution.TargetFramework-override) in order to ensure that your solution is building and showing intellisense as fast as possible, and to avoid [this Visual Studio issue](https://developercommunity.visualstudio.com/t/Building-a-cross-targeted-project-with-m/651372?space=8&q=building-a-cross-targeted-project-with-many-target) (help the community by upvoting it!) where multi-targeted project libraries always build their full set of targets.

## Troubleshooting Installation Issues

You may encounter installation and/or post-installation Visual Studio issues for which workarounds exist. Please see [Common Issues](xref:Uno.GetStarted.Wizard) we have documented.

[!include[getting-help](getting-help.md)]

## Further reading
- [Special considerations for the WinAppSDK project](features/winapp-sdk-specifics.md)
