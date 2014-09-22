using System;
using System.Collections.Generic;
using CompanyDb.Data;

namespace CompanyDb.ImportRandomData
{
    public class RandomDataEntryPoint
    {
        private const int DepartmentsCount = 100;
        private const int EmployeesCount = 5000;
        private const int ProjectsCount = 1000;
        private const int ReportsCount = 250000;

        private static Random randomGenerator = new Random();

        public static void Main()
        {
            CompanyDbEntities dbEntities = new CompanyDbEntities();
            var generatorInstance = new RandomGenerator(randomGenerator);
            var generatorsList = new List<IDataGenerator>();
            generatorsList.Add(new DepartmentDataGenerator(DepartmentsCount, generatorInstance, dbEntities));
            generatorsList.Add(new EmployeeDataGenerator(EmployeesCount, generatorInstance, dbEntities));
            generatorsList.Add(new ProjectDataGenerator(ProjectsCount, generatorInstance, dbEntities));
            generatorsList.Add(new ReportsDataGenerator(ReportsCount, generatorInstance, dbEntities));

            Console.WriteLine("Starting random data fill");
            Console.WriteLine("The procedure takes some time so please be patient.");
            dbEntities.Configuration.AutoDetectChangesEnabled = false;
            foreach (var generator in generatorsList)
            {
                generator.GenerateData();
                dbEntities.SaveChanges();
            }

            dbEntities.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
