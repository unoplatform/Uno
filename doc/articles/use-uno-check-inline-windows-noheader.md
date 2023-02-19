1. Open a command-line prompt, Windows Terminal if you have it installed, or else Command Prompt or Windows Powershell from the Start menu.

1. a. Install the tool by running the following command from the command prompt:
    ```
    dotnet tool install -g uno.check
    ```
   b. To update the tool, if you already have an existing one:
    ```
    dotnet tool update -g uno.check
    ```
1. Run the tool from the command prompt with the following command:
    ```
    uno-check
    ```
1. Follow the instructions indicated by the tool

> [!NOTE]
> When using a Visual Studio Preview version, you will need to run `uno-check --pre`.