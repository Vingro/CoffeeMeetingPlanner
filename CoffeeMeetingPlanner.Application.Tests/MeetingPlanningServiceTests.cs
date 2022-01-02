using CoffeeMeetingPlanner.Application.Algorithm;
using CoffeeMeetingPlanner.Application.Model;
using System.Collections.Generic;
using Xunit;

namespace CoffeeMeetingPlanner.Application.Tests
{
    public class MeetingPlanningServiceTests
    {
        [Fact]
        public void TestPlanningOfMeetingsWith2Attendees()
        {
            // Arrange
            var jan = new Attendee(1, "Jan");
            var piet = new Attendee(2, "Piet");

            var attendees = new List<Attendee> { jan, piet };
            var service = new MeetingPlanningService(new CarouselCreator());

            // Act
            var result = service.GetWeeklyMeetings(attendees);

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal(1, result[0].WeekNumber);
            Assert.Equal(1, result[0].Meetings.Count);
            Assert.Equal(piet, result[0].Meetings[0].FirstAttendee);
            Assert.Equal(jan, result[0].Meetings[0].SecondAttendee);
        }

        [Fact]
        public void TestPlanningOfMeetingsWith3Attendees()
        {
            // Arrange
            var jan = new Attendee(1, "Jan");
            var piet = new Attendee(2, "Piet");
            var klaas = new Attendee(3, "Klaas");

            var attendees = new List<Attendee> { jan, piet, klaas };
            var service = new MeetingPlanningService(new CarouselCreator());

            // Act
            var result = service.GetWeeklyMeetings(attendees);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0].WeekNumber);
            Assert.Equal(1, result[0].Meetings.Count);
            Assert.Equal(piet, result[0].Meetings[0].FirstAttendee);
            Assert.Equal(klaas, result[0].Meetings[0].SecondAttendee);

            Assert.Equal(2, result[1].WeekNumber);
            Assert.Equal(1, result[1].Meetings.Count);
            Assert.Equal(klaas, result[1].Meetings[0].FirstAttendee);
            Assert.Equal(jan, result[1].Meetings[0].SecondAttendee);

            Assert.Equal(3, result[2].WeekNumber);
            Assert.Equal(1, result[2].Meetings.Count);
            Assert.Equal(jan, result[2].Meetings[0].FirstAttendee);
            Assert.Equal(piet, result[2].Meetings[0].SecondAttendee);
        }
    }
}
