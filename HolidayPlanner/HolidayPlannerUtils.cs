using System;
using System.Collections.Generic;
using System.Linq;
namespace HolidayPlanner
{
    public static class HolidayPlannerUtils
    {
        /// <summary>
        /// Gets the last day of the holiday period by using the start date of the time period.
        /// Holiday period is from 1st of April to the 31st of March.
        /// </summary>
        /// <param name="timePeriod"></param>
        /// <returns>The last day of the holiday period</returns>
        public static DateTime GetLastDayOfHolidayPeriod(TimePeriod timePeriod)
        {
            var lastDayOfHolidayPeriod = timePeriod.StartDate.Month switch
            {
                > 3 and <= 12 => new DateTime(timePeriod.StartDate.Year + 1 , 3, 31),
                _ => new DateTime(timePeriod.StartDate.Year, 3, 31)
            };
            return lastDayOfHolidayPeriod;
        }

        public static  bool IsConsumingHoliday(DateTime date)
        {
            return !(date.DayOfWeek == DayOfWeek.Sunday);
        }

        public static int CountNumberOfHolidays(TimePeriod timePeriod, IEnumerable<DateTime> publicHolidays)
        {
            var date = timePeriod.StartDate;
            var numberOfHolidays = 0;
            while (date <= timePeriod.EndDate)
            {
                if (!publicHolidays.Contains(date) && IsConsumingHoliday(date))
                {
                    numberOfHolidays++;
                }
                date = date.AddDays(1);
            }
            return numberOfHolidays;
        }
    }
}
