﻿Set-PSDebug -Trace 1

$ErrorActionPreference = 'Stop'

function Assert-ExitCodeIsZero()
{
    if ($LASTEXITCODE -ne 0)
    {
        throw "Exit code must be zero."
	}
}

$default = @('/ds', '/p:UseDotNetNativeToolchain=false', '/p:PackageCertificateKeyFile=')
$msbuild = vswhere -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe

$debug = $default + '/p:Configuration=Debug' + '/r'
$release = $default + '/p:Configuration=Release' + '/r'

## Configurations are split to work around UWP not building with .NET new
$dotnetBuildConfigurations =
@(
    @("Mobile", "-f:net7.0-android", ""), # workaround for https://github.com/xamarin/xamarin-android/issues/7473
    @("Mobile", "-f:net7.0-ios", ""),
    @("Mobile", "-f:net7.0-maccatalyst", ""),
    # @("Mobile", "-f:net7.0-macos", ""), # workaround for https://github.com/xamarin/xamarin-macios/issues/16401
    @("Wasm", "", ""),
    @("Skia.Gtk", "", ""),
    @("Skia.Linux.FrameBuffer", "", ""),
    @("Skia.WPF", "", "")
)

# Debug Config
dotnet new unoapp-uwp-net6 -n UnoAppAll

pushd UnoAppAll

for($i = 0; $i -lt $dotnetBuildConfigurations.Length; $i++)
{
    $platform=$dotnetBuildConfigurations[$i][0];
    & dotnet build -c Debug $default $dotnetBuildConfigurations[$i][1] $dotnetBuildConfigurations[$i][2] "UnoAppAll.$platform\UnoAppAll.$platform.csproj"
    Assert-ExitCodeIsZero
}

& $msbuild $debug "UnoAppAll.UWP\UnoAppAll.UWP.csproj"
Assert-ExitCodeIsZero

for($i = 0; $i -lt $dotnetBuildConfigurations.Length; $i++)
{
    $platform=$dotnetBuildConfigurations[$i][0];
    & dotnet build -c Release $default $dotnetBuildConfigurations[$i][1] $dotnetBuildConfigurations[$i][2] "UnoAppAll.$platform\UnoAppAll.$platform.csproj"
    Assert-ExitCodeIsZero
}

& $msbuild $debug "UnoAppAll.UWP\UnoAppAll.UWP.csproj"
Assert-ExitCodeIsZero

popd

$dotnetBuildNet6Configurations =
@(
    @("Mobile", "-f:net7.0-android", ""),
    @("Mobile", "-f:net7.0-ios", ""),
    @("Mobile", "-f:net7.0-maccatalyst", ""),
    # @("Mobile", "-f:net6.0-macos", ""),  # workaround for https://github.com/xamarin/xamarin-macios/issues/16401
    @("Wasm", "", ""),
    @("Server", "", ""),
    @("Skia.Gtk", "", ""),
    @("Skia.Linux.FrameBuffer", "", ""),
    @("Skia.WPF", "", "")
)

# WinUI - Default
dotnet new unoapp-winui -n UnoAppWinUI

pushd UnoAppWinUI
for($i = 0; $i -lt $dotnetBuildNet6Configurations.Length; $i++)
{
    $platform=$dotnetBuildNet6Configurations[$i][0];
    & dotnet build -c Debug $default $dotnetBuildNet6Configurations[$i][1] $dotnetBuildNet6Configurations[$i][2] "UnoAppWinUI.$platform\UnoAppWinUI.$platform.csproj"
    Assert-ExitCodeIsZero
}

# Server project build (merge with above loop when .App folder is removed)
& dotnet build -c Debug $default "UnoAppWinUI.Server\UnoAppWinUI.Server.csproj"

 # Build with msbuild because of https://github.com/microsoft/WindowsAppSDK/issues/1652
 # force targetframeworks until we can get WinAppSDK to build with `dotnet build`
 & $msbuild $debug "/p:Platform=x86" "/p:TargetFrameworks=net7.0-windows10.0.19041;TargetFramework=net7.0-windows10.0.19041" "UnoAppWinUI.Windows\UnoAppWinUI.Windows.csproj"
Assert-ExitCodeIsZero

popd

# XAML Trimming build smoke test
# See https://github.com/unoplatform/uno/issues/9632
# dotnet new unoapp-uwp-net6 -n MyAppXamlTrim
# 
# dotnet publish -c Debug -r win-x64 -p:PublishTrimmed=true -p:SelfContained=true -p:UnoXamlResourcesTrimming=true MyAppXamlTrim\MyAppXamlTrim.Skia.Gtk\MyAppXamlTrim.Skia.Gtk.csproj
# Assert-ExitCodeIsZero
# 
# dotnet run -c Debug --project src\Uno.XamlTrimmingValidator\Uno.XamlTrimmingValidator.csproj -- --hints-file=build\assets\MyAppXamlTrim-hints.txt --target-assembly=MyAppXamlTrim\MyAppXamlTrim.Skia.Gtk\bin\Debug\net6.0\win-x64\publish\Uno.UI.dll
# Assert-ExitCodeIsZero
# 
# & dotnet build -c Debug MyAppXamlTrim\MyAppXamlTrim.Wasm\MyAppXamlTrim.Wasm.csproj /p:UnoXamlResourcesTrimming=true
# Assert-ExitCodeIsZero

# Uno Library
dotnet new unolib -n MyUnoLib
# Mobile is removed for now, until we can get net7 supported by msbuild/VS 17.4
& $msbuild $debug /t:pack MyUnoLib\MyUnoLib.csproj "/p:TargetFrameworks=`"net7.0-windows10.0.19041;net7.0`""
Assert-ExitCodeIsZero

# Uno Cross-Runtime Library
dotnet new unolib-crossruntime -n MyCrossRuntimeLib
& $msbuild $debug /t:Pack MyCrossRuntimeLib\MyCrossRuntimeLib.sln
Assert-ExitCodeIsZero

#
# Uno Library with assets, Validate assets count
#
dotnet new unolib -n MyUnoLib2
mkdir MyUnoLib2\Assets
echo "Test file" > MyUnoLib2\Assets\MyTestAsset01.txt

# Mobile is removed for now, until we can get net7 supported by msbuild/VS 17.4
& $msbuild $debug /t:pack /p:IncludeContentInPack=false MyUnoLib2\MyUnoLib2.csproj -bl "/p:TargetFrameworks=`"net7.0-windows10.0.19041;net7.0`""
Assert-ExitCodeIsZero

mv MyUnoLib2\Bin\Debug\MyUnoLib2.1.0.0.nupkg MyUnoLib2\Bin\Debug\MyUnoLib2.1.0.0.zip
Expand-Archive -LiteralPath MyUnoLib2\Bin\Debug\MyUnoLib2.1.0.0.zip -DestinationPath MyUnoLib2Extract

$assetsCount = Get-ChildItem MyUnoLib2Extract\ -Filter MyTestAsset01.txt -Recurse -File | Measure-Object | %{$_.Count}

#if ($assetsCount -ne 6) # Restore when mobile validation is available
if ($assetsCount -ne 2)
{
    throw "Not enough assets in the package."
}
