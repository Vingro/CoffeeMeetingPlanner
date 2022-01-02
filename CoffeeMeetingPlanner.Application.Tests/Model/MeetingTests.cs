using CoffeeMeetingPlanner.Application.Model;
using System;
using Xunit;

namespace CoffeeMeetingPlanner.Application.Tests.Model
{
    public class MeetingTests
    {
        [Fact]
        public void ConstructorTestHappyFlow()
        {
            // Arrange
            var firstAttendee = new Attendee(1, "Jan");
            var secondAttendee = new Attendee(2, "Piet");

            // Act
            var meeting = new Meeting(firstAttendee, secondAttendee);

            // Assert
            Assert.Equal(firstAttendee, meeting.FirstAttendee);
            Assert.Equal(secondAttendee, meeting.SecondAttendee);
        }

        [Fact]
        public void ConstructorFirstAttendeeNull()
        {
            // Arrange
            var secondAttendee = new Attendee(2, "Piet");

            // Act & assert
            Assert.Throws<ArgumentNullException>(() => new Meeting(null!, secondAttendee));
        }

        [Fact]
        public void ConstructorSecondAttendeeNull()
        {
            // Arrange
            var firstAttendee = new Attendee(1, "Jan");

            // Act & assert
            Assert.Throws<ArgumentNullException>(() => new Meeting(firstAttendee, null!));
        }
    }
}
