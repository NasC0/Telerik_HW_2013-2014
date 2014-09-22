/* 03. Write a method that from a given array of students finds all students 
 * whose first name is before its last name alphabetically. Use LINQ query operators. */

namespace _03.LINQStudentNameOrdering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LINQStudentNameOrdering
    {

        static void Main()
        {
            var studentsArray = new[]
            {
                new { FirstName = "Thomas", LastName = "Jefferson" },
                new { FirstName = "James", LastName = "Thompson" }
            };

            var resultList = studentsArray.Where(x => x.FirstName.CompareTo(x.LastName) == -1);

            foreach (var result in resultList)
            {
                Console.WriteLine(result);
            }
        }
    }
}
