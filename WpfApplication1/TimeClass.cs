using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class TimeClass
    {

        public TimeClass()
        {
            daysOfWeek = new Dictionary<DayOfWeek, int>();
            monthsOfYear = new Dictionary<int, string>();
            hoursOfDayString = new Dictionary<int, String>();
            hoursOfDayInt = new Dictionary<int, int>();
            daysInFrench = new Dictionary<DayOfWeek, string>();
            InitDaysAndMonths();
            InitHoursOfDay(DateTime.Today);
        }

        public Dictionary<DayOfWeek, int> daysOfWeek;
        public Dictionary<int, String> monthsOfYear;
        public Dictionary<int, String> hoursOfDayString;
        public Dictionary<int, int> hoursOfDayInt;
        public Dictionary<DayOfWeek,String> daysInFrench;
        private void InitDaysAndMonths()
        {
            daysOfWeek.Add(DayOfWeek.Sunday, 1);
            daysOfWeek.Add(DayOfWeek.Monday, 2);
            daysOfWeek.Add(DayOfWeek.Tuesday, 3);
            daysOfWeek.Add(DayOfWeek.Wednesday, 4);
            daysOfWeek.Add(DayOfWeek.Thursday, 5);
            daysOfWeek.Add(DayOfWeek.Friday, 6);
            daysOfWeek.Add(DayOfWeek.Saturday, 7);

            /// days in french
            daysInFrench.Add(DayOfWeek.Sunday, "Dimanche");
            daysInFrench.Add(DayOfWeek.Monday, "Lundi");
            daysInFrench.Add(DayOfWeek.Tuesday, "Mardi");
            daysInFrench.Add(DayOfWeek.Wednesday, "Mercredi");
            daysInFrench.Add(DayOfWeek.Thursday, "Jeudi");
            daysInFrench.Add(DayOfWeek.Friday, "Vendredi");
            daysInFrench.Add(DayOfWeek.Saturday, "Samedi");
            ///
            monthsOfYear.Add(1, "Janvier");
            monthsOfYear.Add(2, "Fevrier");
            monthsOfYear.Add(3, "Mars");
            monthsOfYear.Add(4, "Avril");
            monthsOfYear.Add(5, "May");
            monthsOfYear.Add(6, "Juin");
            monthsOfYear.Add(7, "Juillet");
            monthsOfYear.Add(8, "Aout");
            monthsOfYear.Add(9, "Septembre");
            monthsOfYear.Add(10, "Octobre");
            monthsOfYear.Add(11, "Novembre");
            monthsOfYear.Add(12, "Decembre");
        }

        private void InitHoursOfDay(DateTime t)
        {
            DateTime copyTime = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
            for (int i = 1; i <= 24; i++)
            {
                hoursOfDayString.Add(i, copyTime.ToString("HH:mm"));
                hoursOfDayInt.Add(copyTime.Hour, i);
                copyTime = copyTime.AddHours(1);
            }
        }
        public static DateTime StringToDateTime(DateTime day, String Hour,String Minute)
        {
            return new DateTime(day.Year, day.Month, day.Day, int.Parse(Hour), int.Parse(Minute),0);
        }
    }
}
