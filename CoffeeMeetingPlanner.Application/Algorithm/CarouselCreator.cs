using CoffeeMeetingPlanner.Application.Model;

namespace CoffeeMeetingPlanner.Application.Algorithm
{
    public class CarouselCreator
    {
        internal AttendeesCarouselBase Create(IList<Attendee> attendees)
        {
            return attendees.Count % 2 == 0
                ? new CarouselForEvenNumberOfAttendees(attendees)
                : new CarouselForOddNumberOfAttendees(attendees);
        }
    }
}