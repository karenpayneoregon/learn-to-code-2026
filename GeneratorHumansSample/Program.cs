using System.Diagnostics;
using BogusLibrary.Classes;

namespace GeneratorHumansSample;

internal class Program
{
    static void Main(string[] args)
    {
        var humans = HumanGenerator.Create(20);

        Debugger.Break();
        
        Console.ReadLine();
    }
}
