---
uid: Uno.Development.NetVersionSupport
---

# .NET version support

This page lists supported .NET versions and [C# language versions](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version) for different target platforms.

### Table of supported versions

| Platform                                   | Default .NET version | Default C# version |  Max .NET version | Max C# version |
|--------------------------------------------|:--------------------:|:------------------:|:-----------------:|:--------------:|
| WebAssembly                                | .NET 6               | 10                 | .NET 7            | 11             |
| Skia (Gtk, Framebufffer, WPF)              | .NET 6               | 10                 | .NET 7            | 11             |
| WinAppSDK                                  | .NET 6               | 10                 | .NET 7            | 11             |
| iOS, macOS, Android, Catalyst (.NET Core)  | .NET 6               | 10                 | .NET 7            | 11             |
| iOS, macOS, Android (Xamarin)              | .NET Standard 2.1    | 8                  | .NET Standard 2.1 | 8              |
| UWP                                        | .NET Standard 2.0    | 7.3                | .NET Standard 2.0 | 7.3            |

### Notes

For Xamarin.Android, Xamarin.iOS, and Xamarin.macOS, the supported versions depend on the version of Xamarin installed, which is generally tied to the Visual Studio version if you are using Visual Studio.

You can force a higher version of C# using `LangVersion` in the platform `csproj` (eg `<LangVersion>9.0</LangVersion>`), but some language features may not work properly, such as those that depend on compiler-checked types (eg array slicing, `init`-only properties) or on runtime support (eg default interface implementations).
