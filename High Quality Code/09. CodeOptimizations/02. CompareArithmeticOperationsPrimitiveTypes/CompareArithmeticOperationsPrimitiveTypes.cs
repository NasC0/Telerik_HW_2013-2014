using System;
using System.Diagnostics;
public class CompareArithmeticOperationsPrimitiveTypes
{
    static void Main()
    {
        Stopwatch stopWatch = new Stopwatch();

        int integer = 1;
        long longInt = 1;
        float floatingPoint = 1.0f;
        double doubleFloatingPoint = 1.0d;
        decimal decimalFloatingPoint = 1.0m;

        // Test addition
        #region Addition
        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            integer += 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Integer addition for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            longInt += 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Long addition for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();
    
        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            floatingPoint += 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Float addition for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            doubleFloatingPoint += 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Double addition for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            decimalFloatingPoint += 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Decimal addition for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();
        #endregion

        Console.WriteLine();

        // Test subtraction
        #region Subtraction

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            integer -= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Integer subtraction for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            longInt -= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Long subtraction for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            floatingPoint -= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Float subtraction for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            doubleFloatingPoint -= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Double subtraction for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            decimalFloatingPoint -= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Decimal subtraction for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();
        #endregion

        Console.WriteLine();

        // Test incrementation
        #region Incremenattion

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            integer++;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Integer incrementation for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            longInt++;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Long incrementation for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            floatingPoint++;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Float incrementation for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            doubleFloatingPoint++;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Double incrementation for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            decimalFloatingPoint++;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Decimal incrementation for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();
        #endregion

        Console.WriteLine();

        // Test multiplication
        #region Multiplication

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            integer *= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Integer multiplication for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            longInt *= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Long multiplication for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            floatingPoint *= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Float multiplication for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            doubleFloatingPoint *= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Double multiplication for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            decimalFloatingPoint *= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Decimal multiplication for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        #endregion

        Console.WriteLine();

        // Test division
        #region Division

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            integer /= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Integer division for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            longInt /= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Long division for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            floatingPoint /= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Float division for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            doubleFloatingPoint /= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Double division for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            decimalFloatingPoint /= 1;
        }

        stopWatch.Stop();
        Console.WriteLine(String.Format("Decimal division for 1000000 operations: {0}", stopWatch.Elapsed));

        stopWatch.Reset();

        #endregion
    }
}
