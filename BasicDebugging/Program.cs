using BasicDebugging.Classes;
using BasicDebugging.Classes.Core;
using DebuggerLibrary;
using Spectre.Console;

namespace BasicDebugging;
internal partial class Program
{
    static void Main(string[] args)
    {
        SpectreConsoleHelpers.PinkPill(Justify.Left, "Learning debugging...");

        //Samples.Switch();
        
        Samples.HitCount();

        /*
         * for 'function breakpoint' GetSeasonColor in DebuggerLibrary/SeasonHelper.cs
         */
        Console.WriteLine($"\n{SeasonHelper.GetCurrentSeason()} " +
                          $"color is {SeasonHelper.GetSeasonColor()}");
        
        //var taxpayers = Samples.GetTaxpayers();
        //Samples.LoopTaxpayers();

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
