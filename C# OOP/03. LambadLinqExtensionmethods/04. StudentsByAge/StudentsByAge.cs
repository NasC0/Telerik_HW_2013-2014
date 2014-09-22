/* 04. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. */

/* 05. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the 
 * students by first name and last name in descending order. Rewrite the same with LINQ. */

namespace _04.StudentsByAge
{
    using System;
    using System.Linq;

    class StudentsByAge
    {
        static void Main()
        {

            #region Task 4
            Console.WriteLine("Task 4:\n");

            var studentList = new[] 
            {
                new { FirstName = "Buggs", LastName = "Bunny", Age = 22 },
                new { FirstName = "Arnod", LastName = "Schwarzenegger", Age = 70 },
                new { FirstName = "Test", LastName = "Test", Age = 16 },
                new { FirstName = "Lambda", LastName = "Sucks", Age = 18 }
            };

            var resultList = studentList.Where(x => x.Age >= 18 && x.Age <= 24).Select(x => new { FirstName = x.FirstName, LastName = x.LastName });

            foreach (var result in resultList)
            {
                Console.WriteLine("{0} {1}", result.FirstName, result.LastName);
            }

            Console.WriteLine("\nEnd Task 4\n");
            #endregion

            #region Task 5
            Console.WriteLine("\nTask 5\n");

            // Ordering with lambda expression
            var lambdaOrdering = studentList.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

            foreach (var entry in lambdaOrdering)
            {
                Console.WriteLine("{0} {1}", entry.FirstName, entry.LastName);
            }

            Console.WriteLine();

            // Ordering with LINQ expression
            var linqOrdering = from student in studentList
                               orderby student.FirstName descending, student.LastName descending
                               select student;

            foreach (var student in linqOrdering)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }

            Console.WriteLine("\nEnd task 5\n");
            #endregion
        }
    }
}
