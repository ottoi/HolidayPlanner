using System;

namespace HolidayPlanner
{
    public class TimePeriod
    {
        public TimePeriod(DateTime startDate, DateTime endDate)
        {
            if (StartDate > EndDate)
            {
                throw new ArgumentException("Start day must be before end date");
            }
            StartDate = startDate;
            EndDate = endDate;
            
        }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public double NumberOfDays { get => EndDate.Subtract(StartDate).TotalDays; }

        public bool IsInTimePeriod(DateTime date)
        {
            return StartDate >= date && date <= EndDate;
        }

        
    }
}
