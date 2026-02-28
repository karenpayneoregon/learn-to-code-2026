using IComparerIEqualityComparerApp.Classes;
using IComparerIEqualityComparerApp.Classes.Core;
using Spectre.Console;

namespace IComparerIEqualityComparerApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        Operations.DistinctPeople();
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
