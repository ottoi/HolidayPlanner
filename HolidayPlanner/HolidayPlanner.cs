using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils = HolidayPlanner.HolidayPlannerUtils;
namespace HolidayPlanner
{
    public class HolidayPlanner
    {
        private IHolidayService _holidayService;
        private const int maxTimeSpan = 50;

        public HolidayPlanner(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        public int GetNumberOfHolidays(TimePeriod timePeriod)
        {
            if ( timePeriod.NumberOfDays > maxTimeSpan)
            {
                throw new ArgumentException($"Given time period is more than {maxTimeSpan} days");
            }
            var lastDayOfHolidayPeriod = Utils.GetLastDayOfHolidayPeriod(timePeriod);
            if(timePeriod.IsInTimePeriod(lastDayOfHolidayPeriod))
            {
                throw new ArgumentException("Given time period is not in the holiday period");
            };

            var publicHolidays = _holidayService.GetPublicHolidays();
            return Utils.CountNumberOfHolidays(timePeriod, publicHolidays);
        }      
    }
}
