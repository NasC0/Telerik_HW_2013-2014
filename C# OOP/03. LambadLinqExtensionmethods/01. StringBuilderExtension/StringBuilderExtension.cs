/* 01. Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder 
 * and has the same functionality as Substring in the class String. */

namespace StringBuilderExtension
{

    using System;
    using System.Text;

    class StringBuilderExtension
    {
        static void Main()
        {
            StringBuilder testBuilder = new StringBuilder("This is a test");
            StringBuilder subString = testBuilder.Substring(4);
            Console.WriteLine(subString);
            StringBuilder bla = testBuilder.Substring(4, testBuilder.Length - 4);
            Console.WriteLine(testBuilder.Length - 4);
            Console.WriteLine(bla);
        }
    }
}
