using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var res = phoneNumber.Split("-");
        return (res[0]== "212", res[1] == "555", res[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        throw new NotImplementedException($"Please implement the (static) PhoneNumber.IsFake() method");
    }
}
