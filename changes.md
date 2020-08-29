# About this file
This file tracks significant changes to the project setup that are not easily recognizable from file diffs (e.g., project creation wizard operations).

# Changes
1. Create a *[global.json file](https://docs.microsoft.com/en-us/dotnet/core/tools/global-json?tabs=netcore3x)* to fix .NET Core SDK version.

    ```powershell
    dotnet new globaljson --sdk-version $(dotnet --version)
    ```

2. Created a *[nuget.config file](https://docs.microsoft.com/en-us/nuget/reference/nuget-config-file)* to fix package sources.

    ```powershell
    dotnet new nugetconfig
    ```

3. Created new .NET Core project for a Class library (Protobuf Pre-Compiler).

    ```powershell
    dotnet new classlib --language C`# --name pre-compiler --framework netcoreapp3.1 --output pre-compiler
    ```

4. Created new .NET Core solution (Protobuf Tools).

    ```powershell
    dotnet new sln --name protobuf-tools
    ```

5. Added `pre-compiler` project to `protobuf-tools` solution.

    ```powershell
    dotnet sln add pre-compiler
    ```

6. Created new xUnit test project (tests for Protobuf Pre-Compiler).

    ```powershell
    dotnet new xunit --name pre-compiler.tests --framework netcoreapp3.1 --output pre-compiler.tests
    ```

7. Added `pre-compiler.tests` project to `protobuf-tools` solution.

    ```powershell
    dotnet sln add pre-compiler.tests
    ```

8. Added SonarAnalyzer for static code analysis to `pre-compiler` project. Further package additions do not need to be tracked here.

    ```powershell
    dotnet add pre-compiler package SonarAnalyzer.CSharp --version 8.12.0.21095
    ```

9. Created a *[manifest file](https://docs.microsoft.com/en-us/dotnet/core/tools/local-tools-how-to-use)* for .NET Core local tools.

    ```powershell
    dotnet new tool-manifest
    ```

10. Installed [`dotnet-grpc`](https://docs.microsoft.com/en-us/aspnet/core/grpc/dotnet-grpc?view=aspnetcore-3.1) tool to manage protobuf references.

    ```powershell
    dotnet tool install dotnet-grpc
    ```

11. Added `pre-compiler` project as a dependency of its test project `pre-compiler.tests`.

    ```powershell
    dotnet add pre-compiler.tests reference pre-compiler
    ```

