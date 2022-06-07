using System;

class RemoteControlCar
{
    protected int meters = 0;
    protected int battery = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {meters} meters";
    }

    public string BatteryDisplay()
    {
        if (battery == 0)
        {
            return "Battery empty";
        }
        return $"Battery at {battery}%";
    }

    public void Drive()
    {
        if (battery == 0)
        {
            return;
        }
        battery--;
        meters += 20;
    }
}
