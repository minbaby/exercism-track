using System;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return isTrangle(side1, side2, side3)
            && !IsEquilateral(side1, side2, side3)
            && !IsIsosceles(side1, side2, side3);
    }

    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        return isTrangle(side1, side2, side3)
            && (side1 == side2 || side1 == side3 || side2 == side3);
    }

    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        return isTrangle(side1, side2, side3)
                && side1 == side2 && side2 == side3;
    }


    private static bool isTrangle(double side1, double side2, double side3)
    {
        return SideGt0(side1, side2, side3) && AAndBGtC(side1, side2, side3);
    }

    private static bool SideGt0(double side1, double side2, double side3)
    {
        return side1 > 0 && side2 > 0 && side3 > 0;
    }

    private static bool AAndBGtC(double side1, double side2, double side3)
    {
        return side1 + side2 > side3
                && side1 + side3 > side2
                && side2 + side3 > side1;
    }
}