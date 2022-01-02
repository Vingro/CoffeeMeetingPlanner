using CoffeeMeetingPlanner.Application.Algorithm;
using CoffeeMeetingPlanner.Application.Model;

namespace CoffeeMeetingPlanner.Application
{
    public class MeetingPlanningService
    {
        private readonly CarouselCreator _carouselCreator;
        private const int StartWeekNumber = 1;

        public MeetingPlanningService(CarouselCreator carouselCreator)
        {
            _carouselCreator = carouselCreator;
        }

        /// <summary>
        /// Get an overview of all the weeks with their meeting couples.
        /// See <see href="https://nrich.maths.org/1443" /> for the algorithm used.
        /// </summary>
        /// <param name="attendees">The attendees to the 1-on-1 meetings.</param>
        /// <returns>A list of <see cref="WeekOverview">WeekOverview</see> objects containing
        /// all the meeting couples.</returns>
        public IList<WeekOverview> GetWeeklyMeetings(IList<Attendee> attendees)
        {
            ArgumentNullException.ThrowIfNull(attendees, nameof(attendees));

            var carousel = _carouselCreator.Create(attendees);

            var count = StartWeekNumber;
            var result = new List<WeekOverview>();

            while (count <= carousel.NumberOfWeeksToPlanFor)
            {
                var thisWeeksMeetings = carousel.GetThisWeeksMeetings();
                result.Add(new WeekOverview(count, thisWeeksMeetings));

                carousel.Rotate();

                count++;
            }

            return result;
        }
    }
}
