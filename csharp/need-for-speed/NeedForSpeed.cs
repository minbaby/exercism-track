using System;

class RemoteControlCar
{
    protected int speed;
    protected int batteryDrain;
    protected int battery = 100;

    protected int drivenDisantce = 0;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return battery == 0 || battery < batteryDrain;
    }


    public int DistanceDriven()
    {
        return drivenDisantce;
    }

    public void Drive()
    {
        if (BatteryDrained())
        {
            return;
        }

        battery = battery < batteryDrain ? 0 : battery - batteryDrain;

        drivenDisantce += speed;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    protected int distance;
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
        }

        return distance <= car.DistanceDriven();
    }
}
