using System;

namespace HolidayPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            var holidayService = new DummyHolidayService();

            var holidayPlanner = new HolidayPlanner(holidayService);
            var timePeriod = new TimePeriod(new DateTime(2020,12,15), new DateTime(2020,12,30));

            Console.WriteLine($"There is {holidayPlanner.GetNumberOfHolidays(timePeriod)} holidays in time period from {timePeriod.StartDate} to {timePeriod.EndDate}");
        }
    }
}
