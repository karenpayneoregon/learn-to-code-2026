using BasicDebugging.Classes;
using BasicDebugging.Classes.Core;
using Spectre.Console;

namespace BasicDebugging;
internal partial class Program
{
    static void Main(string[] args)
    {
        Samples.Switch();

        var taxpayers = Samples.GetTaxpayers();
        Samples.LoopTaxPayers();

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
