using System;

class MathExpression
{
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());

        decimal nSquared = n * n;
        decimal topMiddle = 1 / (m * p);
        decimal top = nSquared + topMiddle + 1337;
        decimal bottom = n - (128.523123123M * p);
        decimal mMod = m % 180;
        decimal sin = (decimal)Math.Sin((double)mMod);
        decimal topAndBottom = top / bottom;
        decimal result = topAndBottom + sin;
        Console.WriteLine("{0:0.000000}", result);
    }
}
