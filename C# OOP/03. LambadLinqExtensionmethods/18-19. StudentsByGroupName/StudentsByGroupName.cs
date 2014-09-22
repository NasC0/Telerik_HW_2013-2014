/* Task 18. Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ. */

/* Task 19. Rewrite the previous using extension methods. */

namespace _18_19.StudentsByGroupName
{
    using System;
    using System.Linq;

    class StudentsByGroupName
    {
        static void Main()
        {
            var studentList = new[]
            {
                new { Name = "Georgi Petrov", GroupName = "Mathematics" },
                new { Name = "Alexander Ivanov", GroupName = "Informatics" },
                new { Name = "Simeon Gaidarov", GroupName = "Mathematics" },
                new { Name = "JKlkjwa aldjk", GroupName = "Informatics" }
            };

            #region Task 18.

            Console.WriteLine("Task 18: Group Students by GroupName; LINQ\n");

            var groupedStudentsLinq = from student in studentList
                                      group student by student.GroupName
                                      into grp select grp;

            foreach (var entry in groupedStudentsLinq)
            {
                foreach (var student in entry)
                {
                    Console.WriteLine("{0} - {1}", student.Name, student.GroupName);
                }
            }

            #endregion

            #region Task 19.

            Console.WriteLine("\nTask 19: Group Students by GroupName; Lambda\n");

            var groupedStudentsLambda = studentList.GroupBy(x => x.GroupName);

            foreach (var entry in groupedStudentsLambda)
            {
                foreach (var student in entry)
                {
                    Console.WriteLine("{0} - {1}", student.Name, student.GroupName);
                }
            }

            #endregion
        }
    }
}
