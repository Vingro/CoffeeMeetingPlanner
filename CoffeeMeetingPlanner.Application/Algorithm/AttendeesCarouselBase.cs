using CoffeeMeetingPlanner.Application.Model;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CoffeeMeetingPlanner.Application.Tests")]
namespace CoffeeMeetingPlanner.Application.Algorithm
{
    /// <summary>
    /// Representing a rotating polygon shape to support planning meetings for all attendees.
    /// </summary>
    internal abstract class AttendeesCarouselBase
    {
        /// <summary>
        /// The first half of the attendees (the left part of the polygon).
        /// </summary>
        protected IList<Attendee> AttendeesLeft { get; set; } = new List<Attendee>();

        /// <summary>
        /// The second half of the attendees (the right part of the polygon).
        /// </summary>
        protected IList<Attendee> AttendeesRight { get; set; } = new List<Attendee>();

        /// <summary>
        /// A separate attendee position used for planning and rotation.
        /// </summary>
        protected abstract Attendee FixedPosition { get; set; }

        /// <summary>
        /// The number of weeks the meetings need to be planned for, based on the number
        /// of attendees.
        /// </summary>
        protected internal int NumberOfWeeksToPlanFor { get; protected set; }

        /// <summary>
        /// Rotate the attendees clockwise with the help of <see cref="AttendeesLeft"/>, 
        /// <see cref="AttendeesRight"/> and if necessary <see cref="FixedPosition"/>.
        /// </summary>
        internal abstract void Rotate();

        /// <summary>
        /// Retrieve the meetings for the current state.
        /// </summary>
        /// <returns>A list of meetings for the current state (week).</returns>
        internal abstract IList<Meeting> GetThisWeeksMeetings();
    }
}
