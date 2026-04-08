using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDatesAndTime.Classes;
internal class MockedData
{
    /// <summary>
    /// Provides a predefined list of date strings in various formats, 
    /// including valid, invalid, and edge-case examples.
    /// </summary>
    /// <remarks>
    /// This property is used for testing and demonstration purposes, 
    /// allowing the application to process and analyze different date string formats.
    /// </remarks>
    public static List<string> DateStrings => 
        [
            "3/5/2024", // M/d/yyyy
            "03/05/2024", // MM/dd/yyyy
            "5/3/2024", // d/M/yyyy
            "05/03/2024", // dd/MM/yyyy
            "2024/3/5", // yyyy/M/d
            "2024/03/05", // yyyy/MM/dd

            // --- Valid: Dash formats ---
            "3-5-2024", // M-d-yyyy
            "03-05-2024", // MM-dd-yyyy
            "5-3-2024", // d-M-yyyy
            "05-03-2024", // dd-MM-yyyy
            "2024-3-5", // yyyy-M-d
            "2024-03-05", // yyyy-MM-dd

            // --- Valid: Dot formats ---
            "3.5.2024", // M.d.yyyy
            "03.05.2024", // MM.dd.yyyy
            "5.3.2024", // d.M.yyyy
            "05.03.2024", // dd.MM.yyyy
            "2024.3.5", // yyyy.M.d
            "2024.03.05", // yyyy.MM.dd

            // --- Valid: Space formats ---
            "3 5 2024", // M d yyyy
            "03 05 2024", // MM dd yyyy
            "5 3 2024", // d M yyyy
            "05 03 2024", // dd MM yyyy
            "2024 3 5", // yyyy M d
            "2024 03 05", // yyyy MM dd

            // --- Valid: Comma formats ---
            "3,5,2024", // M,d,yyyy
            "03,05,2024", // MM,dd,yyyy
            "5,3,2024", // d,M,yyyy
            "05,03,2024", // dd,MM,yyyy
            "2024,3,5", // yyyy,M,d
            "2024,03,05", // yyyy,MM,dd

            // --- Valid: Month name formats ---
            "5-Jan-2024", // d-MMM-yyyy
            "5/Jan/2024", // d/MMM/yyyy
            "5 Jan 2024", // d MMM yyyy
            "5.Jan.2024", // d.MMM.yyyy
            "05-Jan-2024", // dd-MMM-yyyy
            "05/Jan/2024", // dd/MMM/yyyy
            "05 Jan 2024", // dd MMM yyyy
            "05.Jan.2024", // dd.MMM.yyyy
            "Jan/05/2024", // MMM/dd/yyyy
            "Jan-05-2024", // MMM-dd-yyyy
            "Jan 05 2024", // MMM dd yyyy
            "Jan.05.2024", // MMM.dd.yyyy

            // --- Valid: Short year ---
            "5-Jan-4", // d-MMM-y
            "5 Jan 4", // d MMM y

            // --- Invalid: Completely wrong ---
            "not a date",
            "",
            "   ",

            // --- Invalid: Bad numbers ---
            "32/01/2024", // invalid day
            "13/32/2024", // invalid month/day combo
            "2024/13/01", // invalid month
            "2024-00-10", // invalid month
            "2024-02-30", // invalid day for Feb

            // --- Invalid: Wrong separators ---
            "2024|03|05",
            "05*03*2024",

            // --- Invalid: Partial dates ---
            "2024-03",
            "03/2024",
            "2024",

            // --- Invalid: Mixed formats ---
            "2024/03-05",
            "Jan/2024/05",

            // --- Edge cases ---
            "2/29/2024", // valid leap year
            "2/29/2023", // invalid (not leap year)
            "02-29-2024", // valid
            "02-29-2023", // invalid

            // --- Case sensitivity check ---
            "5-jan-2024", // fails (InvariantCulture expects proper casing)
            "5-JAN-2024"
        ];
}
