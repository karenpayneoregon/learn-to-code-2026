using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace WorkingWithDatesAndTime.Classes;
internal class DateTimeUtilities
{
    public string GetDateFormat(string input)
    {
        
        string[] formats =
        [
            "M/d/yyyy", "MM/dd/yyyy",
            "d/M/yyyy", "dd/MM/yyyy",
            "yyyy/M/d", "yyyy/MM/dd",
            "M-d-yyyy", "MM-dd-yyyy",
            "d-M-yyyy", "dd-MM-yyyy",
            "yyyy-M-d", "yyyy-MM-dd",
            "M.d.yyyy", "MM.dd.yyyy",
            "d.M.yyyy", "dd.MM.yyyy",
            "yyyy.M.d", "yyyy.MM.dd",
            "M,d,yyyy", "MM,dd,yyyy",
            "d,M,yyyy", "dd,MM,yyyy",
            "yyyy,M,d", "yyyy,MM,dd",
            "M d yyyy", "MM dd yyyy",
            "d M yyyy", "dd MM yyyy",
            "yyyy M d", "yyyy MM dd",
            "d-MMM-yyyy", "d/MMM/yyyy", "d MMM yyyy", "d.MMM.yyyy",
            "d-MMM-y", "d/MMM/y", "d MMM y", "d.MMM.y",
            "dd-MMM-yyyy", "dd/MMM/yyyy", "dd MMM yyyy", "dd.MMM.yyyy",
            "MMM/dd/yyyy", "MMM-dd-yyyy", "MMM dd yyyy", "MMM.dd.yyyy", "MMM.dd.yyyy"
        ];

        DateTime dateValue;
        foreach ((int index, string format) in formats.Index())
        {
            
            if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                return $"Input: {input}, Format: {format}";
            }
            
        }
        
        return $"Input: {input}, Format: Unknown";
    }

}
