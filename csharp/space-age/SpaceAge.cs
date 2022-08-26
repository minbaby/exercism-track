using System;

public class SpaceAge
{
    private const double EARTH_SECONDS = 31557600.0;

    private const double EARTH_DASY = 365.25;

    private int seconds;
    public SpaceAge(int seconds)
    {
        this.seconds = seconds;
    }

    public double OnEarth()
    {
        return seconds / EARTH_SECONDS;
    }

    public double OnMercury()
    {
        return OnEarth() / 0.2408467;
    }

    public double OnVenus()
    {
        return OnEarth() / 0.61519726;
    }

    public double OnMars()
    {
        return OnEarth() / 1.8808158;
    }

    public double OnJupiter()
    {
        return OnEarth() / 11.862615;
    }

    public double OnSaturn()
    {
        return OnEarth() / 29.447498;
    }

    public double OnUranus()
    {
        return OnEarth() / 84.016846;
    }

    public double OnNeptune()
    {
        return OnEarth() / 164.79132;
    }
}