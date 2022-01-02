namespace CoffeeMeetingPlanner.Application.Model
{
    public class Attendee
    {
        public Attendee(int number, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("No (valid) name given", nameof(name));
            }

            Number = number;
            Name = name;
        }

        public int Number { get; }
        public string Name { get; }
    }
}
