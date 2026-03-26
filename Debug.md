
## Get started with breakpoints in the Visual Studio debugger

Breakpoints are one of the most important debugging techniques in your developer's toolbox. You set breakpoints wherever you want to pause debugger execution. For example, you might want to see the state of code variables or look at the call stack at a certain breakpoint.

[Set breakpoints in source code](https://learn.microsoft.com/en-us/visualstudio/debugger/get-started-with-breakpoints?view=visualstudio#BKMK_Overview)


## Local window

The `Locals window` in `Visual Studio` is a debugging tool that displays variables, their values, and data types for the current execution scope (typically the current function or method). It is accessible while debugging by navigating to `Debug > Windows > Locals`

### Key Features & Usage:

- **Visibility**: Only available while the debugger is running (after pressing F5 or attaching to a process).
- **Automatic Context**: Updates automatically as you step through code (F10/F11), highlighting variables that have changed value.

## Pin data tips

If you frequently hover over data tips while debugging, you may want to pin the data tip for the variable to give yourself quick access. The variable stays pinned even after restarting. To pin the data tip, click the pin icon while hovering over it. You can pin multiple variables.

[Work with data tips](https://learn.microsoft.com/en-us/visualstudio/debugger/view-data-values-in-data-tips-in-the-code-editor?view=visualstudio#work-with-data-tips)

## Keyboard Shortcuts

| Commands                    | Keyboard Shortcuts  | Command ID                     |
|:---------------------------|:-------------------------------------|:----------------------------|--|
| Break at function          | Ctrl+B                               | Debug.BreakatFunction          |
| Break all                  | Ctrl+Alt+Break                       | Debug.BreakAll                 |
| Delete all breakpoints     | Ctrl+Shift+F9                        | Debug.DeleteAllBreakpoints     |
| Exceptions                 | Ctrl+Alt+E                           | Debug.Exceptions               |
| Quick watch                | Ctrl+Alt+Q or Shift+F9               | Debug.QuickWatch               |
| Restart                    | Ctrl+Shift+F5                        | Debug.Restart                  |
| Run to cursor              | Ctrl+F10                             | Debug.RunToCursor              |
| Set next statement         | Ctrl+Shift+F10                       | Debug.SetNextStatement         |
| Start                      | F5                                   | Debug.Start                    |
| Start without debugging    | Ctrl+F5                              | Debug.StartWithoutDebugging    |
| Step into                  | F11                                  | Debug.StepInto                 |
| Step out                   | Shift+F11                            | Debug.StepOut                  |
| Step over                  | F10                                  | Debug.StepOver                 |
| Stop debugging             | Shift+F5                             | Debug.StopDebugging            |
| Toggle breakpoint          |       F9                              | Debug.ToggleBreakpoint         |

## Skip method

For methods or entire assemblies you never want to step into (such as third-party libraries or trivial utility functions), you can configure Visual Studio to ignore them by default:

`[DebuggerStepThrough]` Attribute: In C# code, you can add the `[DebuggerStepThrough]` attribute to a method or property. The debugger will automatically step over this code.