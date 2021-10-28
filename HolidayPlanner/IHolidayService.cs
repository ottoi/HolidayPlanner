using System;
using System.Collections.Generic;

namespace HolidayPlanner
{
    public interface IHolidayService
    {
        public IEnumerable<DateTime> GetPublicHolidays();
    }
}