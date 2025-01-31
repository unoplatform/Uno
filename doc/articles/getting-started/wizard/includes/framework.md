This setting lets you choose the .NET version to target. The default is .NET 8.0, but you can change it to .NET 9.0 Preview!

- #### .NET 8.0

    [.NET 8.0](https://learn.microsoft.com/dotnet/core/whats-new/dotnet-8) is provided as a LTS (Long Term Support) version. This version adds significant performance improvements, as well as other general enhancements. This is the default (for both blank and recommended presets) and the recommended option for new projects

    ```dotnetcli
    dotnet new unoapp -tfm 8.0
    ```

- #### .NET 9.0 Preview

    [.NET 9.0](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview) is provided as an STS (Standard Term Support) version. This is a preview version to be released at the end of 2024.

    ```dotnetcli
    dotnet new unoapp -tfm 9.0
    ```
