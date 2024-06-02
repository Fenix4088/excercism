namespace Exercism;

public class SpaceAge
{
    private readonly double _seconds;

    private double  Age => this._seconds / 31556952;

    public SpaceAge(int seconds)
    {
        this._seconds = seconds;
    }


    private double CalcPeriod(double orbitalPeriod) => Math.Round(Age / orbitalPeriod, 2);

    public double OnEarth()
    {
        return Age;
    }

    public double OnMercury() => Math.Round(Age / 0.2408467, 2, MidpointRounding.ToZero);

    public double OnVenus() => CalcPeriod(0.61519726);

    public double OnMars() => CalcPeriod(1.8808158);

    public double OnJupiter() => CalcPeriod(11.862615);

    public double OnSaturn() => CalcPeriod(29.447498);

    public double OnUranus() => CalcPeriod(84.016846);

    public double OnNeptune() => CalcPeriod(164.79132);
}