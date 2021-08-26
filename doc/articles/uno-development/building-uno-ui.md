# Building Uno.UI

This article explains how to build Uno.UI locally, for instance if you wish to contribute a bugfix or new feature.

## Prerequisites

- Visual Studio 2019 (16.6 or later) or 2022 (17.0 Preview 2 or later)
    - `Mobile Development with .NET` (Xamarin) development
    - `Visual Studio extensions development` (for the VSIX projects)
    - `ASP.NET and Web Development`
    - `.NET Core cross-platform development`
    - `UWP Development`, install all recent UWP SDKs, starting from 10.0.14393 (or above or equal to `TargetPlatformVersion` line [in this file](https://github.com/unoplatform/uno/blob/master/src/Uno.CrossTargetting.props))
- Install (**Tools** / **Android** / **Android SDK manager**) all Android SDKs starting from 7.1 (or the Android versions `TargetFrameworks` [list used here](https://github.com/unoplatform/uno/blob/master/src/Uno.UI.BindingHelper.Android/Uno.UI.BindingHelper.Android.csproj))

## Building Uno.UI for a single target platform

This is the **recommended** approach to building the Uno.UI solution. It will build a single set of binaries for a particular platform (eg Android, iOS, WebAssembly, etc). 

Building for a single target platform is considerably faster, much less RAM-intensive, and generally more reliable.

It involves two things - setting an override for the target framework that will be picked up by the (normally multi-targeted) projects inside the Uno solution; and opening a preconfigured [solution filter](https://docs.microsoft.com/en-us/visualstudio/ide/filtered-solutions) which will only load the projects needed for the current platform.

The step by step process is:

1. Clone the Uno.UI repository locally, and ensure using a short target path, e.g. _D:\uno_ etc.  
This is due to limitations in the legacy .NET versions used by Xamarin projects. This issue has been addressed in .NET 5, and will come to the rest of the projects in the future.
1. Make sure you don't have the Uno.UI solution open in any Visual Studio instances. (Visual Studio may crash or behave inconsistently if it's open when the target override is changed.)
1. Make a copy of the [src/crosstargeting_override.props.sample](https://github.com/unoplatform/uno/blob/master/src/crosstargeting_override.props.sample) file and name this copy `src/crosstargeting_override.props`.
1. In `crosstargeting_override.props`, uncomment the line `<UnoTargetFrameworkOverride>netstandard2.0</UnoTargetFrameworkOverride>`
1. Set the build target inside ``<UnoTargetFrameworkOverride></UnoTargetFrameworkOverride>`` to the identifier for the target platform you wish to build for. (Identifiers for each platform are listed in the file.) Save the file.
1. If you are debugging for `net6.0-XX` targets (`ios`, `android`, `maccatalyst` or `macos`)
   - Ensure that you are running VS 2022 Preview 2 or later
   - Replace the contents of the `global.json` file with the contents of `global-net6.json`
1. In the `src` folder, look for the solution filter (`.slnf` file) corresponding to the target platform override you've set, which will be named `Uno.UI-[Platform]-only.slnf`, and open it.
1. To confirm that everything works:
   - For iOS/Android/macOS you can right-click on the `Uno.UI` project in the Solution Explorer and 'Build'. 
   - For WebAssembly and Skia you can right-click on the `Uno.UI.Runtime.WebAssembly` or `Uno.UI.Runtime.Skia.[Gtk|Wpf]` project in the Solution Explorer and 'Build'.

Once you've built successfully, for the next steps, [consult the guide here](debugging-uno-ui.md) for debugging Uno.UI.

If you've followed the steps above, you have your environment set up with the listed prerequisites, and you still encounter errors when you try to build the solution, you can reach out to the core team on Uno's [Discord channel #uno-platform](https://discord.gg/eBHZSKG).

### Windows and long paths issues
If the build tells you that `LongPath` is not enabled, you may enable it on Windows 10 by using :
```bash
reg ADD HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem /v LongPathsEnabled /t REG_DWORD /d 1
```
If for some reason you cannot modify the registry, you can disable this warning by adding `<UnoUIDisableLongPathWarning>false</UnoUIDisableLongPathWarning>` to the project.

Note that long paths may be required when building Uno, and invalid paths errors may arise.

## Building Uno.UI for all available targets

It's recommended to build using the single-target approach, but it's also possible to build for all targets at once, if you wish.

1. If you've previously followed the single-target steps, comment out the `<UnoTargetFrameworkOverride />` line in your `crosstargeting_override.props` file.
2. Open the [Uno.UI.sln](https://github.com/unoplatform/uno/blob/master/src/Uno.UI.sln)
3. Select the `Uno.UI` project
4. Build

Inside Visual Studio, the number of platforms is restricted to limit the compilation time.

## Building Uno.UI for macOS using Visual Studio for Mac

See [instructions here](building-uno-macos.md) for building Uno.UI for the macOS platform.

## Other build-related topics 

### Using the Package Diff tool

Refer to the [guidelines for breaking changes](../contributing/guidelines/breaking-changes.md) document.

### Updating the Nuget packages used by the Uno.UI solution
The versions used are centralized in the [Directory.Build.targets](https://github.com/unoplatform/uno/blob/master/src/Directory.Build.targets) file, and all the
locations where `<PackageReference />` are used.

When updating the versions of nuget packages, make sure to update all the .nuspec files in the [Build folder](https://github.com/unoplatform/uno/tree/master/build).

### Running the SyncGenerator tool

Uno Platform uses a tool which synchronizes all WinRT and WinUI APIs with the type implementations already present in Uno. This ensures that all APIs are present for consumers of Uno, even if some are not implemented.

The synchronization process takes the APIs provided by the WinMD files referenced by the `Uno.UWPSyncGenerator.Reference` project and generates stubbed classes for types in the `Generated` folders of Uno.UI, Uno.Foundation and Uno.WinRT projects. If the generated classes have been partially implemented in Uno (in the non-Generated folders), the tool will automatically skip those implemented methods.

The tool needs to be run on Windows because of its dependency on the Windows SDK WinMD files.

To run the synchronization tool:
- Open a `Developer Command Prompt for Visual Studio` (2019 or 2022)
- Go the the `uno\build` folder (not the `uno\src\build` folder)
- Run the `run-api-sync-tool.cmd` script; make sure to follow the instructions

Note that as of Uno 3.10, the tool is manually run for the UWP part of the build and automatically run as part of the CI during the WinUI part of the build.