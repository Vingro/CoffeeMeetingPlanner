namespace CoffeeMeetingPlanner.Application.Model
{
    public class Meeting
    {
        internal Meeting(Attendee firstAttendee, Attendee secondAttendee)
        {
            ArgumentNullException.ThrowIfNull(firstAttendee, nameof(firstAttendee));
            ArgumentNullException.ThrowIfNull(secondAttendee, nameof(secondAttendee));

            FirstAttendee = firstAttendee;
            SecondAttendee = secondAttendee;
        }

        public Attendee FirstAttendee { get; }
        public Attendee SecondAttendee { get; }
    }
}
