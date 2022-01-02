using CoffeeMeetingPlanner.Application.Model;
using System;
using Xunit;

namespace CoffeeMeetingPlanner.Application.Tests.Model
{
    public class AttendeeTests
    {
        [Fact]
        public void ConstructorTestHappyFlow()
        {
            // Arrange
            var number = 1;
            var name = "Jan";

            // Act
            var attendee = new Attendee(number, name);

            // Assert
            Assert.Equal(number, attendee.Number);
            Assert.Equal(name, attendee.Name);
        }

        [Fact]
        public void ConstructorPassEmptyStringAsName()
        {
            // Arrange
            var number = 1;
            var name = string.Empty;

            // Act & assert
            Assert.Throws<ArgumentException>(() => new Attendee(number, name));
        }
    }
}
