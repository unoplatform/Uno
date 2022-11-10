# Using the Skia+GTK head

Uno supports running applications using Gtk+3 shell, using a Skia backend rendering. Gtk3+ is used to create a shell for the application to be used on various operating systems, such as Linux, Windows and macOS.

Depending on the target platform, the UI rendering may be using OpenGL or software rendering.

Note that for Linux, the [framebuffer rendering](using-linux-framebuffer.md) head is also available.

## Get started with the Skia+GTK head
Follow the getting started guide [for Linux](../get-started-with-linux.md) or [Windows](../get-started-vs-2022.md)

You will also need to install the [GTK3 runtime](https://github.com/tschoonj/GTK-for-Windows-Runtime-Environment-Installer/releases) to run a GTK+3 based app on Windows.

Once done, you can create a new app using:
```
dotnet new unoapp -o MyApp
```

or by using the Visual Studio "project new" templates.

## Changing the rendering target

It may be required, depending on the environment, to use software rendering.

To do so, immediately before the line `host.Run()` in you `main.cs` file, add the following:
```
host.RenderSurfaceType = RenderSurfaceType.Software;
```

### Linux considerations
When running under Linux, GTK can use OpenGL for the UI rendering but some restrictions can apply depending on the environment and available hardware.

- When running under Wayland, to enable OpenGL acceleration, you may need to set the `GDK_BACKEND` environment variable to `x11` before running your application.
- When running under Wayland and running with OpenGL ES 3.3 or later (using glxinfo to confirm), you may need to set the `GDK_GL` environment variable to `gles` before running your application.

### Troubleshooting OpenGL integration
Enabling debug logging messages for the GTK Host can help diagnose the render surface type selection.

In your `App.xaml.cs` file, change the minimum log level to:
```csharp
builder.SetMinimumLevel(LogLevel.Debug);
```
Then change the logging level of the GTK Host to `Information` or `Debug`:
```csharp
builder.AddFilter("Uno.UI.Runtime.Skia", LogLevel.Information);
```
You may also need to initialize the logging system earlier than what is found in Uno.UI's default templates by calling this in `Main`:
```csharp
YourAppNamespace.App.ConfigureFilters(); // Enable tracing of the GTK host
```

## Upgrading to a later version of SkiaSharp

By default Uno comes with a set of **SkiaSharp** dependencies set by the **[Uno.UI.Runtime.Skia.Gtk](https://nuget.info/packages/Uno.UI.Runtime.Skia.Gtk)** package.

If you want to upgrade **SkiaSharp** to a later version, you'll need to specify all packages individually in your project as follows:

```xml
<ItemGroup>
   <PackagReference Include="SkiaSharp" Version="2.88.0" />
   <PackagReference Include="SkiaSharp.Harfbuzz" Version="2.88.0" />
   <PackagReference Include="SkiaSharp.NativeAssets.Linux" Version="2.88.0" />
   <PackageReference Update="SkiaSharp.NativeAssets.macOS" Version="2.88.0" />
</ItemGroup>
```
