/* Task 17. Write a program to return the string with maximum length from an array of strings. Use LINQ. */

namespace _17.StringWithMaxLength
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StringWithMaxLength
    {
        static void Main()
        {
            List<string> stringList = new List<string>()
            {
                "A",
                "AB",
                "ABC",
                "ABCD"
            };

            var maxStringEntry = from entry in stringList
                                 where entry.Length == stringList.Max(x => x.Length)
                                 select entry;

            foreach (var entry in maxStringEntry)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
