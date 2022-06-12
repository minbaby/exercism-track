// 这个题目，我其实没有看懂，现在只是让单测通过了。
// 看了一眼其他的答案，他用了接口，直接隐藏了实现细节，这样外部就不可以调用访问了
public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public ITelemetry Telemetry;


    public RemoteControlCar()
    {
        Telemetry = new RemoteControlCarTelemetry(this);
    }

    public interface ITelemetry
    {
        void ShowSponsor(string sponsorName);
        void SetSpeed(decimal amount, string unitsString);
        void Calibrate();
        bool SelfTest();
    }

    // TODO encapsulate the methods suffixed with "_Telemetry" in their own class
    // dropping the suffix from the method name
    private class RemoteControlCarTelemetry : ITelemetry
    {
        private RemoteControlCar remoteControlCar;
        public RemoteControlCarTelemetry(RemoteControlCar remoteControlCar)
        {
            this.remoteControlCar = remoteControlCar;
        }

        public void Calibrate()
        {

        }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string sponsorName)
        {
            remoteControlCar.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            remoteControlCar.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;

    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }

    protected enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    protected struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
}


