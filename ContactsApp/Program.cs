using ContactsApp.Classes;
using ContactsApp.Classes.Core;
using Spectre.Console;

namespace ContactsApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Task.Delay(0);
        PersonOperations.WithDebugView();
        await PersonOperations.DisplayPeople();
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
