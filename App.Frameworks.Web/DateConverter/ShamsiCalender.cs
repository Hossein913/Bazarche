using System.Diagnostics;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Frameworks.Web.DateConverter
{
    public static class ShamsiCalender
    {

        public static string ToPersianNumericDate(this DateTime dateTime)
        {
                PersianCalendar persianCalendar = new PersianCalendar();
                int year = persianCalendar.GetYear(dateTime);
                int month = persianCalendar.GetMonth(dateTime);
                int day = persianCalendar.GetDayOfMonth(dateTime);

                return $"{year}/{month:00}/{day:00}";
        }
        public static string? ToPersianNumericDate(this DateTime? dateTime)
        {
            if (dateTime != null)
            {
                DateTime notNullDateTime = Convert.ToDateTime(dateTime);
                return notNullDateTime.ToPersianNumericDate();
            }
            else
            {
                return null; 
            }
        }

        public static string ToPersianAlfabeticDate(this DateTime dateTime)
        {
                PersianCalendar persianCalendar = new PersianCalendar();
                int year = persianCalendar.GetYear(dateTime);
                int month = persianCalendar.GetMonth(dateTime);
                int day = persianCalendar.GetDayOfMonth(dateTime);
                string[] monthName = new string[]{"تعریف نشده","فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن","اسفند" };

            return $"{year} {monthName[month]} {day:00}";

        }
        public static string? ToPersianAlfabeticDate(this DateTime? dateTime)
        {
            if (dateTime != null)
            {
                DateTime notNullDateTime = Convert.ToDateTime(dateTime);
                return notNullDateTime.ToPersianAlfabeticDate();
            }
            else
            {
                return null;
            }
        }

        public static DateTime ToGregorianDateTime(this PersianDateTime persianDate)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime gregorianDate = persianCalendar.ToDateTime(persianDate.year, persianDate.month, persianDate.day, persianDate.Hour, 0, 0, 0);
            return gregorianDate;
        }

        public static DateTime ToGregorianDate(this PersianDate persianDate)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime gregorianDate = persianCalendar.ToDateTime(persianDate.year, persianDate.month, persianDate.day, 0, 0, 0, 0);
            return gregorianDate;
        }
        


        public static PersianDate ToPersianDate(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            return new PersianDate(year, month, day);
        }

        public static PersianDate ToPersianDate(this DateTime? dateTime)
        {
            if (dateTime != null)
            {
                DateTime notNullDateTime = Convert.ToDateTime(dateTime);
                return notNullDateTime.ToPersianDate();
            }
            else
            {
                return new PersianDate();
            }
        }
    }



    public static class ConvertTo
    {
        public static DateTime GregorianDate(string stringPersianDate)
        {
            string[] strings = stringPersianDate.Split('/');
            int year = int.Parse(strings[0]);
            int month = int.Parse(strings[1]);
            int day = int.Parse(strings[2]);
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            return gregorianDate;
        }
    }

        public class PersianDateTime
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int Hour { get; set; }

        public override string ToString()
        {
             return $"{year}/{month:00}/{day:00} - {Hour:00}";
        }
    }

    public class PersianDate
    {
        public PersianDate()
        {
            year = 1000;
            month = 01;
            day = 01;
        }
        public PersianDate(int year = 1000, int month = 1, int day = 1)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
        public PersianDate(string date)
        {


        }

        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }

        public override string ToString()
        {
            return $"{year}/{month:00}/{day:00}";
        }
    }


}

