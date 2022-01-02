using CoffeeMeetingPlanner.Application.Model;

namespace CoffeeMeetingPlanner.Application.Algorithm
{
    internal class CarouselForEvenNumberOfAttendees
        : AttendeesCarouselBase
    {
        protected override Attendee FixedPosition { get; set; }

        internal CarouselForEvenNumberOfAttendees(IList<Attendee> attendees)
        {
            var numberOfAttendees = attendees.Count;

            if (numberOfAttendees <= 1)
            {
                throw new ArgumentException("There are not enough attendees to plan meetings", nameof(attendees));
            }
            if (numberOfAttendees % 2 != 0)
            {
                throw new ArgumentException("The amount of attendees in the collection is not an even number", nameof(attendees));
            }

            var halfOfAttendees = numberOfAttendees / 2;
            FixedPosition = attendees[0];
            attendees.RemoveAt(0);

            AttendeesLeft = attendees.Take(halfOfAttendees).ToList();
            AttendeesRight = attendees.Skip(halfOfAttendees).Take(halfOfAttendees - 1).ToList();
            NumberOfWeeksToPlanFor = numberOfAttendees - 1;
        }

        /// <summary>
        /// Rotate the attendees in the left and right group by one position, clockwise.
        /// </summary>
        internal override void Rotate()
        {
            // Move the first attendee from the left group to the first spot in the right group.
            // Identically, move the last attendee from the right group to the last spot in the left group.
            // The fixed position remains the same.
            AttendeesRight.Insert(0, AttendeesLeft.First());
            AttendeesLeft.RemoveAt(0);

            AttendeesLeft.Add(AttendeesRight.Last());
            AttendeesRight.RemoveAt(AttendeesRight.Count - 1);
        }

        /// <summary>
        /// Get the couples for this week's meeting.
        /// </summary>
        /// <returns>A list containing the couples for this week's meeting.</returns>
        internal override IList<Meeting> GetThisWeeksMeetings()
        {
            var list = new List<Meeting>
            {
                new Meeting(AttendeesLeft.First(), FixedPosition)
            };

            for (var i = 1; i < AttendeesLeft.Count; i++)
            {
                list.Add(new Meeting(AttendeesLeft[i], AttendeesRight[i - 1]));
            }

            return list;
        }
    }
}
