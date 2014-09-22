using System;
using System.Diagnostics;

public class HigherMathematicalOperationsFloatingPointNumbers
{
    static void Main()
    {
        Stopwatch stopWatch = new Stopwatch();

        float floatingPoint = 1.0f;
        double doubleFloat = 1.0d;
        decimal decimalFloat = 1.0m;

        // Test Math.Sqrt
        #region Square root

        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            Math.Sqrt(floatingPoint);
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Float sqrt for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            Math.Sqrt(doubleFloat);
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Double sqrt for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            Math.Sqrt((double)decimalFloat);
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Decimal sqrt for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();
        #endregion

        Console.WriteLine();

        // Test Math.Log
        #region Natural Logarithm

        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            Math.Log(floatingPoint);
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Float log for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            Math.Log(doubleFloat);
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Double log for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            Math.Log((double)decimalFloat);
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Decimal log for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();
        #endregion

        Console.WriteLine();

        // Test Math.Sin
        #region Sinus

        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            Math.Sin(floatingPoint);
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Float sinus for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            Math.Sin(doubleFloat);
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Double sinus for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            Math.Sin((double)decimalFloat);
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Decimal sinus for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();
        #endregion
    }
}
