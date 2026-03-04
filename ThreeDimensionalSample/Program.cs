using Spectre.Console;
using ThreeDimensionalSample.Classes.Core;

namespace ThreeDimensionalSample;
internal partial class Program
{
    static void Main(string[] args)
    {

        var console = AnsiConsole.Create(new AnsiConsoleSettings
        {
            Out = new AnsiConsoleOutput(Console.Out),
            Interactive = InteractionSupport.No
        });

        int[,,] cube =
        {
            {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            },
            {
                {10,11,12},
                {13,14,15},
                {16,17,18}
            },
            {
                {19,20,21},
                {22,23,24},
                {25,26,27}
            }
        };

        int xLen = cube.GetLength(0);
        int yLen = cube.GetLength(1);
        int zLen = cube.GetLength(2);

        for (int x = 0; x < xLen; x++)
        {
            var table = new Table()
                .Border(TableBorder.Rounded)
                .Title($"[cyan]Layer {x}[/]");

            for (int z = 0; z < zLen; z++)
                table.AddColumn($"Z{z}");

            for (int y = 0; y < yLen; y++)
            {
                var row = new string[zLen];
                for (int z = 0; z < zLen; z++)
                    row[z] = cube[x, y, z].ToString();

                table.AddRow(row);
            }

            console.Write(table);
            console.WriteLine();
        }
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
