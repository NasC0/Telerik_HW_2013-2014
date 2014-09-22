using System;
using System.Diagnostics;
using System.Linq;

using TelerikAcademy.Database;
namespace TestDataMaterialisationPerformance
{
    public class TestMaterialisationPerformance
    {
        public static void Main()
        {
            var dbContext = new TelerikAcademyDb();
            
            var timer = new Stopwatch();
            dbContext.Employees.Count();

            timer.Start();
            var employeesToListEarly = dbContext.Employees
                                           .ToList()
                                           .Select(employee => employee.Address)
                                           .ToList()
                                           .Select(address => address.Town)
                                           .ToList()
                                           .Where(town => town.Name == "Sofia");

            timer.Stop();
            Console.WriteLine("Materialising the data too early takes {0}", timer.Elapsed);
            timer.Reset();
            timer.Start();

            var employeesToListLate = dbContext.Employees.Select(emploee => emploee.Address.Town).Where(town => town.Name == "Sofia");
            timer.Stop();
            Console.WriteLine("Materialising the data late takes {0}", timer.Elapsed);
        }
    }
}
