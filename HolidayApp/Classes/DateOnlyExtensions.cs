using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;

namespace HolidayApp.Classes;
public static class DateOnlyExtensions
{
    public static bool IsHoliday(this DateOnly day)
    {
        var date = day.ToDateTime(TimeOnly.Parse("00:00 AM"));
        var workingDayCultureInfo = new WorkingDayCultureInfo();
        return workingDayCultureInfo.IsHoliday(date);
    }

    public static bool IsWorkingDay(this DateOnly day)
    {
        var date = day.ToDateTime(TimeOnly.Parse("00:00 AM"));
        var workingDayCultureInfo = new WorkingDayCultureInfo();
        return workingDayCultureInfo.IsWorkingDay(date);
    }

    public static DateOnly AddWorkingDays(this DateOnly day, int workingDays)
    {
        var date = day.ToDateTime(TimeOnly.Parse("00:00 AM"));
        var newDate = date.AddWorkingDays(workingDays, new WorkingDayCultureInfo());
        return DateOnly.FromDateTime(newDate);
    }
    public static IDictionary<DateOnly, Holiday> AllYearHolidays(this DateOnly day)
    {
        IDictionary<DateTime, Holiday>? x = day
            .ToDateTime(TimeOnly.Parse("00:00 AM"))
            .AllYearHolidays(new WorkingDayCultureInfo());
        return x.ToDictionary(kvp => DateOnly.FromDateTime(kvp.Key), kvp => kvp.Value);
    }


}
