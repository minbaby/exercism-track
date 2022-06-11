using System;

class WeighingMachine
{
    // TODO: define the 'Precision' property
    public int Precision;

    private double _weight;
    // TODO: define the 'Weight' property
    public double Weight
    {
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            else
                _weight = value;
        }
        get
        {
            return _weight;
        }
    }

    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get
        {
            return $"{(_weight - TareAdjustment).ToString($"F{Precision}")} kg";
        }
    }

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment = 5;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
