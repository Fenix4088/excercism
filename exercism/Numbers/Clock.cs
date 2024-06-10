namespace Exercism.Numbers;

public class Clock : IEquatable<Clock>
{
    private DateTime _time;
    private int _hours;
    private int _minutes;
    
    public Clock(int hours, int minutes)
    {
        _hours = hours;
        _minutes = minutes;
        _time = new DateTime(2024, 1, 1, 0, 0, 0).AddHours(hours).AddMinutes(minutes);
    }

    public string ToString() => _time.ToShortTimeString();

    public Clock Add(int minutesToAdd) => new Clock(_hours, _minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(_hours, _minutes - minutesToSubtract);

    public bool Equals(Clock? clock)
    {
        if (ReferenceEquals(this, clock)) return true;
        
        if (ReferenceEquals(this, null)) return false;

        return this.ToString() == clock.ToString();
    }
}