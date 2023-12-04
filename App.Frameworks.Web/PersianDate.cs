using System.Diagnostics;
using System.Globalization;

namespace App.Frameworks.Web
{
    public static class PersianDate
    {
        public static string ToPersianDate(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            return $"{year}/{month:00}/{day:00}";
        }

        public static DateTime ToGregorianDate(this PersianDateTime persianDate)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime gregorianDate = persianCalendar.ToDateTime(persianDate.year, persianDate.month, persianDate.day, persianDate.Hour, 0, 0, 0);
            return gregorianDate;
        }

    }

    public struct PersianDateTime
    {
        public short year { get; set; }
        public short month { get; set; }
        public short day { get; set; }
        public short Hour { get; set; }
    }
}