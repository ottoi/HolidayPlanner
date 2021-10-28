using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlanner
{
    public class DummyHolidayService : IHolidayService
    {
        public IEnumerable<DateTime> GetPublicHolidays()
        {
            var publicHolidays = new List<DateTime>();
            var dateStrings = new string[] { "2020-1-1", "2020-1-6", "2020-4-10", "2020-4-13", "2020-5-1", "2020-5-21", "2020-6-19", "2020-12-24", "2020-12-25", "2021-1-1", "2021-1-6", "2021-4-2", "2021-4-5", "2021-5-13", "2021-6-20", "2021-12-6", "2021-12-24" };
            foreach(var dateString in dateStrings)
            {
                publicHolidays.Add(DateTime.Parse(dateString));
            }
            return publicHolidays;
        }
    }
}
