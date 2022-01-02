using CoffeeMeetingPlanner.Application.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace CoffeeMeetingPlanner.Application.Tests.Model
{
    public class WeekOverviewTests
    {
        [Fact]
        public void ConstructorTestHappyFlow()
        {
            // Arrange
            var weekNumber = 1;
            var meetings = new List<Meeting>();

            // Act
            var weekOverview = new WeekOverview(weekNumber, meetings);

            // Assert
            Assert.Equal(weekNumber, weekOverview.WeekNumber);
            Assert.Equal(meetings, weekOverview.Meetings);
        }

        [Fact]
        public void ConstructorPassNullAsCollection()
        {
            // Arrange
            var weekNumber = 1;

            // Act & assert
            Assert.Throws<ArgumentNullException>(() => new WeekOverview(weekNumber, null!));
        }
    }
}
