using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dumpify;

namespace IComparerIEqualityComparerApp.Classes.Configuration;
internal class DumpSetup
{
    public static void Configure()
    {
        DumpConfig.Default.ColorConfig.LabelValueColor = System.Drawing.Color.Yellow;
        DumpConfig.Default.ColorConfig.TypeNameColor = System.Drawing.Color.DeepPink;
        DumpConfig.Default.ColorConfig.PropertyNameColor = System.Drawing.Color.LightGreen;
        DumpConfig.Default.ColorConfig.PropertyValueColor = System.Drawing.Color.White;
        DumpConfig.Default.ColorConfig.NullValueColor = System.Drawing.Color.Gray;
        DumpConfig.Default.ColorConfig.MetadataInfoColor = System.Drawing.Color.DarkGray;
        DumpConfig.Default.ColorConfig.MetadataErrorColor = System.Drawing.Color.Red;

        DumpConfig.Default.TableConfig.ShowTableHeaders = false;
    }
}
