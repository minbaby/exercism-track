using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        return balance switch
        {
            < 0 => 3.213f,
            < 1000 => 0.5f,
            >= 1000 and < 5000 => 1.621f,
            _ => 2.475f,
        };


        // switch (balance)
        // {
        //     case decimal val when val < 0:
        //         return 3.213f;
        //     case decimal val when val < 1000:
        //         return 0.5f;
        //     case decimal val when val >= 1000 && val < 5000:
        //         return 1.621f;
        //     case decimal val when val >= 5000:
        //         return 2.475f;
        // }

        // return 0f;
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (decimal)InterestRate(balance) / 100.0m;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var tmp = balance;

        var years = 0;
        do
        {
            tmp = AnnualBalanceUpdate(tmp);
            years++;
        } while (tmp < targetBalance);

        return years;
    }
}
