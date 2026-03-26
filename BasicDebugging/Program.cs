using BasicDebugging.Classes;
using BasicDebugging.Classes.Core;
using Spectre.Console;

namespace BasicDebugging;
internal partial class Program
{
    static void Main(string[] args)
    {
        SpectreConsoleHelpers.PinkPill(Justify.Left, "Learning debugging...");
        //Samples.Switch();

        //var taxpayers = Samples.GetTaxpayers();
        Samples.LoopTaxpayers();

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
