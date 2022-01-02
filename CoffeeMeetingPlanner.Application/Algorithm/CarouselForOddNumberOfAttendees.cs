using CoffeeMeetingPlanner.Application.Model;

namespace CoffeeMeetingPlanner.Application.Algorithm
{
    internal class CarouselForOddNumberOfAttendees
        : AttendeesCarouselBase
    {
        protected override Attendee FixedPosition { get; set; }

        internal CarouselForOddNumberOfAttendees(IList<Attendee> attendees)
        {
            var numberOfAttendees = attendees.Count;

            if (numberOfAttendees <= 1)
            {
                throw new ArgumentException("There are not enough attendees to plan meetings", nameof(attendees));
            }
            if (numberOfAttendees % 2 == 0)
            {
                throw new ArgumentException("The amount of attendees in the collection is not an odd number", nameof(attendees));
            }

            FixedPosition = attendees[0];
            attendees.RemoveAt(0);
            var halfOfAttendees = numberOfAttendees / 2;

            AttendeesLeft = attendees.Take(halfOfAttendees).ToList();
            AttendeesRight = attendees.Skip(halfOfAttendees).Take(halfOfAttendees).ToList();
            NumberOfWeeksToPlanFor = numberOfAttendees;
        }

        /// <summary>
        /// Rotate the attendees in the left and right group by one position, clockwise.
        /// </summary>
        internal override void Rotate()
        {
            // Move the attendee in the fixed position to the first spot in the right group.
            // Move the first attendee from the left group to the fixed position.
            // Also, move the last attendee from the right group to the last spot in the left group.
            AttendeesRight.Insert(0, FixedPosition);
            FixedPosition = AttendeesLeft.First();
            AttendeesLeft.RemoveAt(0);

            AttendeesLeft.Add(AttendeesRight.Last());
            AttendeesRight.RemoveAt(AttendeesRight.Count - 1);
        }

        /// <summary>
        /// Get the couples for this week's meeting. Because of this being an odd number of attendees,
        /// the fixed position will not be a part of this week's meeting.
        /// </summary>
        /// <returns>A list containing the couples for this week's meeting.</returns>
        internal override IList<Meeting> GetThisWeeksMeetings()
        {
            var list = new List<Meeting>();

            for (var i = 0; i < AttendeesLeft.Count; i++)
            {
                list.Add(new Meeting(AttendeesLeft[i], AttendeesRight[i]));
            }

            return list;
        }
    }
}
