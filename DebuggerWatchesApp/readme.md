# About

Example of a simple [watch window](https://learn.microsoft.com/en-us/visualstudio/debugger/watch-and-quickwatch-windows?view=visualstudio) for the Visual Studio debugger. 

- The watch here is on `DataConnections.Instance.MainConnection`
- Code to change `MainConnection` in appsettings.json is in [ConsoleConfigurationLibrary](https://www.nuget.org/packages/ConsoleConfigurationLibrary/1.0.0.13) NuGet package.
- `Debugger.Break();` is used to break into the debugger when the app runs.

## Prepare

Add a watch on `DataConnections.Instance.MainConnection` in the Visual Studio watch window 1.