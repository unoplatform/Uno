---
uid: Uno.Tutorials.Localization
---

# How to localize text resources

This guide will walk you through the necessary steps to localize an Uno Platform application.

> [!TIP]
> The complete source code that goes along with this guide is available in the [unoplatform/Uno.Samples](https://github.com/unoplatform/Uno.Samples) GitHub repository - [Localization](https://github.com/unoplatform/Uno.Samples/tree/master/UI/LocalizationSamples/Localization)

> [!TIP]
> For a step-by-step guide to installing the prerequisites for your preferred IDE and environment, consult the [Get Started guide](../get-started.md).

## Step-by-steps
1. Create a new Uno Platform application, following the instructions [here](../get-started.md).
1. Modify the content of `MainPage`:

    - In `MainPage.xaml`, replace the content of the page:
        ```xml
        <Page x:Class="UnoLocalization.MainPage"
              xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
              xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
              xmlns:toolkit="using:Uno.UI.Toolkit">

            <StackPanel toolkit:VisibleBoundsPadding.PaddingMask="Top">
                <TextBlock x:Uid="MainPage_IntroText" Text="Hello, world!" Margin="20" FontSize="30" />
                <TextBlock x:Name="CodeBehindText" Text="This text will be replaced" />
            </StackPanel>
        </Page>
        ```
        > Note:
        > - The [`x:Name`](https://docs.microsoft.com/en-us/windows/uwp/xaml-platform/x-name-attribute) is used to make the element accessible from the code-behind with that same name.
        > - The [`x:Uid`](https://docs.microsoft.com/en-us/windows/uwp/xaml-platform/x-uid-directive) is used for localization.
        To localize a property, you need to add a string resource in each resource file using its `x:Uid` followed by a dot (`.`) and then the property name. eg: `MainPage_IntroText.Text`
        More on this in the resource steps that follow.
    - In `MainPage.xaml.cs`, add an `Page.Loaded` handler to change the text for `CodeBehindText`:
        ```cs
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += (s, e) => CodeBehindText.Text = Windows.ApplicationModel.Resources.ResourceLoader
                .GetForViewIndependentUse()
                .GetString("MainPage_CodeBehindString");
        }
        ```
1. Create a new resource file for localization in French in the `UnoLocalization.Shared` project:
    1. Add a new folder `fr` under the `Strings` folder by:
    Right-click on `String` > Add > New Folder
    1. Add a new resource file `Resources.resw` under the `fr` folder by:
    Right-click on `fr` > Add > New Item ... > Visual C# > Xaml > Resources File
1. Add the localization strings for both English and French:

    Open both `Strings\en\Resources.resw` and `Strings\fr\Resources.resw`, and add these:

    |Name|Value in `en\Resources.resw`|Value in `fr\Resources.resw`|
    |-|-|-|
    |MainPage_IntroText.Text|`Hello Uno`|`Bonjour Uno`|
    |MainPage_CodeBehindString|`String from code-behind`|`Texte provenant du code-behind`|
    > [!NOTE]
    > Make sure to hit Ctrl+S for both files, to save the changes.

    > [!IMPORTANT]
    > The `ResourceLoader` will search for resources in the current language, then the default language. The default language is defined by the MSBuild property `DefaultLanguage`, which defaults to `en`.

1. You can now try to run the app.

    The "Hello World" text should be replaced with "Hello Uno", or "Bonjour Uno" if the targeted environment is on French culture.
    Now, if you change the language of the targeted PC or the mobile device AND restart the app, that text should also change accordingly.

    You can also set the starting culture to see the result, without having to modify the system language:
    - `App.cs` or `App.xaml.cs`:
        ```cs
        public App()
        {
            InitializeLogging();
            ChangeStartingLanguage();

            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        private void ChangeStartingLanguage()
        {
            var culture = new System.Globalization.CultureInfo("fr");

            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = culture.TwoLetterISOLanguageName;
        }
        ```

## Get the complete code

See the completed sample on GitHub: [LocalizationSamples/Localization](https://github.com/unoplatform/Uno.Samples/tree/master/UI/LocalizationSamples/Localization)

## Additional Resources
https://docs.microsoft.com/en-us/windows/uwp/design/globalizing/globalizing-portal

<br>

***

## Help! I'm having trouble

> [!TIP]
> If you ran into difficulties with any part of this guide, you can:
>
> * Ask for help on our [Discord channel](https://www.platform.uno/discord) - #uno-platform
> * Ask a question on [GitHub Discussions](https://github.com/unoplatform/uno/discussions) with the 'uno-platform' tag
