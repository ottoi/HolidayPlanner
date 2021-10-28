using HolidayPlanner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HolidayPlannerUnitTests
{
    [TestClass]
    public class HolidayPlannerUtilsTests
    {
        [TestMethod]
        public void CountNumberOfHolidays_WithoutPublicHolidays_ReturnsNumberOfHolidays()
        {
            // Arrange
            var startDate = new DateTime(2020, 10, 28);
            var endDate = startDate.AddDays(8);
            // Time period contains one sunday
            var timePeriod = new TimePeriod(startDate,endDate);
            var publicHolidays = new List<DateTime>();

            //Act
            var numberOfHolidays = HolidayPlannerUtils.CountNumberOfHolidays(timePeriod, publicHolidays);

            //Assert
            var expectedNumberOfHolidays = 8;
            Assert.AreEqual(expectedNumberOfHolidays, numberOfHolidays,$"Time period from {startDate} to {endDate} must contain {expectedNumberOfHolidays} when there is no public holidays.");
        }

        [TestMethod]
        public void GetLastDayOfHolidayPeriod_GivenStartDateIsAfterStartOfApril_ReturnsLastDayOfMarch2021()
        {
            // Arrange
            var date = new DateTime(2020, 4, 1);
            // Time period contains one sunday
            var timePeriod = new TimePeriod(date, date.AddDays(8));

            //Act
            var lastDayOfHolidayPeriod = HolidayPlannerUtils.GetLastDayOfHolidayPeriod(timePeriod);

            //Assert
            var expectedLastDayOfHolidayPeriod = new DateTime(2021, 3, 31);
            Assert.AreEqual(expectedLastDayOfHolidayPeriod, lastDayOfHolidayPeriod, $"Last day of the holiday period must be the last of march {expectedLastDayOfHolidayPeriod} because holiday period is from 1st of April to the 31st of March ");
        }

        [TestMethod]
        public void GetLastDayOfHolidayPeriod_GivenStartDateIsBeforeStartOfApril_ReturnsLastDayOfMarch2020()
        {
            // Arrange
            var date = new DateTime(2020, 3, 31);
            // Time period contains one sunday
            var timePeriod = new TimePeriod(date, date.AddDays(8));

            //Act
            var lastDayOfHolidayPeriod = HolidayPlannerUtils.GetLastDayOfHolidayPeriod(timePeriod);

            //Assert
            var expectedLastDayOfHolidayPeriod = new DateTime(2020, 3, 31);
            Assert.AreEqual(expectedLastDayOfHolidayPeriod, lastDayOfHolidayPeriod, $"Last day of the holiday period must be the last of march {expectedLastDayOfHolidayPeriod} because holiday period is from 1st of April to the 31st of March ");
        }
    }
}
