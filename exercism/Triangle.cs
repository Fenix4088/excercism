namespace Exercism;

using System;

public static class Triangle
{
    private static bool IsTriangle(double side1, double side2, double side3) => side1 <= side2 + side3  && side2 <= side1 + side3 && side3 <= side2 + side1 && side1 + side2 + side3 != 0 ;

    private static bool CompareDoubles(double num1, double num2) => num1.CompareTo(num2) == 0;

    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (!IsTriangle(side1, side2, side3)) return false;
        
        return !CompareDoubles(side1, side2) && !CompareDoubles(side1, side3) && !CompareDoubles(side2, side3);
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        if (!IsTriangle(side1, side2, side3)) return false;

        return CompareDoubles(side1, side2) || CompareDoubles(side1, side3) || CompareDoubles(side2, side3);
    }

    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        if (!IsTriangle(side1, side2, side3)) return false;
        
        return CompareDoubles(side1, side2) && CompareDoubles(side1, side3);
    }
}