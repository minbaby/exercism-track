using System;
using System.Collections.Generic;
using System.Linq;

// TODO implement the IRemoteControlCar interface
public interface IRemoteControlCar : IComparable<IRemoteControlCar>
{
    public int DistanceTravelled { get; }

    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(IRemoteControlCar other)
    {
        if (other is not ProductionRemoteControlCar)
        {
            throw new ArgumentOutOfRangeException();
        }

        return NumberOfVictories.CompareTo((other as ProductionRemoteControlCar).NumberOfVictories);
    }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public int CompareTo(IRemoteControlCar other)
    {
        return DistanceTravelled.CompareTo(other.DistanceTravelled);
    }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        return (new[] { prc1, prc2 }).OrderBy(f => f.NumberOfVictories).ToList();
    }
}
