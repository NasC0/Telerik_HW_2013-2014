using System;
using System.Diagnostics;
using System.Linq;

using TelerikAcademy.Database;

namespace _01.TestNPlusOneQueriesPerformance
{
    public class NPlusOnePerformance
    {
        public static void Main()
        {
            var dbContext = new TelerikAcademyDb();

            var timer = new Stopwatch();

            dbContext.Employees.Count();
            timer.Start();

            foreach (var employee in dbContext.Employees)
            {
                Console.WriteLine("{0} {1} - {2} - {3}", 
                    employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }

            timer.Stop();
            var timeWithInclude = timer.Elapsed;
            Console.WriteLine("-------------------------------");
            timer.Reset();

            timer.Start();
            var employeesIncludingRelatedTables = dbContext.Employees.Select(employee => new
            {
                Name = employee.FirstName + " " + employee.LastName,
                Department = employee.Department.Name,
                Town = employee.Address.Town.Name
            });

            foreach (var employee in employeesIncludingRelatedTables)
            {
                Console.WriteLine("{0} - {1} - {2}",
                    employee.Name, employee.Department, employee.Town);
            }

            timer.Stop();
            Console.WriteLine("Employee joining without Projection takes {0}", timeWithInclude);
            Console.WriteLine("Employee joining with Projection takes {0}", timer.Elapsed);
        }
    }
}
