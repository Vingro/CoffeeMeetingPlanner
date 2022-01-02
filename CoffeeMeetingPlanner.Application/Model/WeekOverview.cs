namespace CoffeeMeetingPlanner.Application.Model
{
    public class WeekOverview
    {
        internal WeekOverview(int weekNumber, IList<Meeting> meetings)
        {
            ArgumentNullException.ThrowIfNull(meetings, nameof(meetings));

            WeekNumber = weekNumber;
            Meetings = meetings;
        }

        public int WeekNumber { get; }
        public IList<Meeting> Meetings { get; }
    }
}
