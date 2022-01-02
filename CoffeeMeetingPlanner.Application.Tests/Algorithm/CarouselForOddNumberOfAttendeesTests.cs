using CoffeeMeetingPlanner.Application.Algorithm;
using CoffeeMeetingPlanner.Application.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace CoffeeMeetingPlanner.Application.Tests.Algorithm
{
    public class CarouselForOddNumberOfAttendeesTests
    {
        [Fact]
        public void ConstructorPassZeroAttendees()
        {
            // Arrange, act & assert
            Assert.Throws<ArgumentException>(() => new CarouselForOddNumberOfAttendees(new List<Attendee>()));
        }

        [Fact]
        public void ConstructorPassOneAttendee()
        {
            // Arrange, act & assert
            Assert.Throws<ArgumentException>(() => new CarouselForOddNumberOfAttendees(new List<Attendee> { new Attendee(1, "Jan") }));
        }

        [Fact]
        public void ConstructorPassEvenNumberOfAttendees()
        {
            // Arrange, act & assert
            Assert.Throws<ArgumentException>(() => new CarouselForOddNumberOfAttendees(
                new List<Attendee> {
                    new Attendee(1, "Jan"),
                    new Attendee(2, "Piet")
                }));
        }

        [Fact]
        public void TestGenerationOfThisWeeksMeetingsResult()
        {
            // Arrange
            var jan = new Attendee(1, "Jan");
            var piet = new Attendee(2, "Piet");
            var klaas = new Attendee(3, "Klaas");
            var henk = new Attendee(4, "Henk");
            var theo = new Attendee(5, "Theo");
            var attendees = new List<Attendee> { jan, piet, klaas, henk, theo };
            var carousel = new CarouselForOddNumberOfAttendees(attendees);

            // Act
            var thisWeeksMeetings = carousel.GetThisWeeksMeetings();

            // Assert
            Assert.Equal(2, thisWeeksMeetings.Count);
            Assert.Equal(thisWeeksMeetings[0].FirstAttendee, piet);
            Assert.Equal(thisWeeksMeetings[0].SecondAttendee, henk);
            Assert.Equal(thisWeeksMeetings[1].FirstAttendee, klaas);
            Assert.Equal(thisWeeksMeetings[1].SecondAttendee, theo);
        }
    }
}
