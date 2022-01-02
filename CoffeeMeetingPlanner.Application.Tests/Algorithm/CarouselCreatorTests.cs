using CoffeeMeetingPlanner.Application.Algorithm;
using CoffeeMeetingPlanner.Application.Model;
using System.Collections.Generic;
using Xunit;

namespace CoffeeMeetingPlanner.Application.Tests.Algorithm
{
    public class CarouselCreatorTests
    {
        [Fact]
        public void CreateCarouselForEvenNumberOfAttendees()
        {
            // Arrange
            var carouselCreator = new CarouselCreator();
            var attendees = new List<Attendee>
            {
                new Attendee(1, "Jan"),
                new Attendee(2, "Piet")
            };

            // Act
            var carousel = carouselCreator.Create(attendees);

            // Assert
            Assert.IsType<CarouselForEvenNumberOfAttendees>(carousel);
        }

        [Fact]
        public void CreateCarouselForOddNumberOfAttendees()
        {
            // Arrange
            var carouselCreator = new CarouselCreator();
            var attendees = new List<Attendee>
            {
                new Attendee(1, "Jan"),
                new Attendee(2, "Piet"),
                new Attendee(3, "Klaas")
            };

            // Act
            var carousel = carouselCreator.Create(attendees);

            // Assert
            Assert.IsType<CarouselForOddNumberOfAttendees>(carousel);
        }
    }
}