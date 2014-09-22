/* 13. Create a program that assigns null values to an integer and to double variables. Try to print them on the console, try to add some values or the null literal to them and see the result. */

using System;

class TestNullVariables
{
    static void Main()
    {
        int? nullableInt = null;
        double? nullableDouble = null;

        Console.WriteLine(nullableInt);
        Console.WriteLine(nullableDouble);

        // If you try to initialize non-nullable type to nullable type, the application won't compile
        // int nonNullableInt = nullableInt;
        // double nonNullableDouble = nullableDouble;

        // However, you can cast the non-nullable to nullable type
        nullableInt = 5;
        nullableDouble = 2.3;
        
        int nonNullableInt = (int)nullableInt;
        double nonNullableDouble = (double)nullableDouble;

        Console.WriteLine(nonNullableInt);
        Console.WriteLine(nonNullableDouble);

        // If the nullable type literal is indeed null, the application will compile but will throw an unhandled exception
        nullableInt = null;
        nullableDouble = null;

        //nonNullableInt = (int)nullableInt;
        //nonNullableDouble = (double)nullableDouble;
    }
}
