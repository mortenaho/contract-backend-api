using System.Globalization;

namespace Common;

public static class DateConverter
{
    public static string ToPersianDate(this string date)
    {
        var now = Convert.ToDateTime(date);
        PersianCalendar pc = new PersianCalendar();
        CultureInfo persianCulture = new CultureInfo("fa-IR");
        
        persianCulture.DateTimeFormat.Calendar = pc;
        persianCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
        
       return now.ToString("yyyy/MM/dd", persianCulture);
    }
    public static string ToPersianDate(this DateTime date)
    {
        PersianCalendar pc = new PersianCalendar();
        CultureInfo persianCulture = new CultureInfo("fa-IR");
        persianCulture.DateTimeFormat.Calendar = pc;
        persianCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
        return date.ToString("yyyy/MM/dd", persianCulture);
    }
}