using System;
using System.Collections.Generic;

public class WeatherStation
{
    private Reading reading;
    private List<DateTime> recordDates = new List<DateTime>();
    private List<decimal> temperatures = new List<decimal>();

    public void AcceptReading(Reading reading)
    {
        this.reading = reading;
        recordDates.Add(DateTime.Now);
        temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        reading = new Reading();
        recordDates.Clear();
        temperatures.Clear();
    }

    public decimal LatestTemperature => reading.Temperature;

    public decimal LatestPressure => reading.Pressure;

    public decimal LatestRainfall => reading.Rainfall;

    public bool HasHistory => recordDates.Count > 1;

    public Outlook ShortTermOutlook
    {
        get
        {
            if (reading.Equals(new Reading()))
            {
                throw new ArgumentException();
            }

            return reading.Temperature switch
            {
                < 30 when reading.Pressure < 10m => Outlook.Cool,
                <= 50 => Outlook.Warm,
                _ => Outlook.Good
            };
        }
    }

    public Outlook LongTermOutlook
    {
        get
        {
            switch (reading.WindDirection)
            {
                case WindDirection.Southerly:
                case WindDirection.Easterly when reading.Temperature > 20:
                    return Outlook.Good;
                case WindDirection.Northerly:
                    return Outlook.Cool;
                case WindDirection.Easterly when reading.Temperature <= 20:
                    return Outlook.Warm;
                case WindDirection.Westerly:
                    return Outlook.Rainy;
                case WindDirection.Unknown:
                default:
                    throw new ArgumentException();
            }
        }
    }

    public State RunSelfTest() => reading.Equals(new Reading()) ? State.Bad : State.Good;
}

/*** Please do not modify this struct ***/
public struct Reading
{
    public decimal Temperature { get; }
    public decimal Pressure { get; }
    public decimal Rainfall { get; }
    public WindDirection WindDirection { get; }

    public Reading(decimal temperature, decimal pressure,
        decimal rainfall, WindDirection windDirection)
    {
        Temperature = temperature;
        Pressure = pressure;
        Rainfall = rainfall;
        WindDirection = windDirection;
    }
}

/*** Please do not modify this enum ***/
public enum State
{
    Good,
    Bad
}

/*** Please do not modify this enum ***/
public enum Outlook
{
    Cool,
    Rainy,
    Warm,
    Good
}

/*** Please do not modify this enum ***/
public enum WindDirection
{
    Unknown, // default
    Northerly,
    Easterly,
    Southerly,
    Westerly
}