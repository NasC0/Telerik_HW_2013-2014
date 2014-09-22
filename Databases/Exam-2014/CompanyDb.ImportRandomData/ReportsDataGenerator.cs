using System;
using System.Linq;
using CompanyDb.Data;

namespace CompanyDb.ImportRandomData
{
    class ReportsDataGenerator : DataGenerator, IDataGenerator
    {
        private const int MinReportsCount = 40;
        private const int MaxReportsCount = 50;

        public ReportsDataGenerator(int dataCount, RandomGenerator generatorInstance, CompanyDbEntities dbContext)
            : base(dataCount, generatorInstance, dbContext)
        {
        }

        public void GenerateData()
        {
            var employeeIDs = this.DbContext.Employees.Select(emp => emp.EmployeeID).ToList();
            int employeeIndex = 0;

            for (int i = 0; i < this.DataCount;)
            {
                int currentEmployeeID = 0;
                try
                {
                    currentEmployeeID = employeeIDs[employeeIndex];
                }
                catch (Exception ex)
                {
                    break;
                }

                var reportsCount = this.Generator.GetRandomNumber(MinReportsCount, MaxReportsCount);
                for (int j = 0; j < reportsCount; j++)
                {
                    var report = new Report()
                    {
                        EmployeeID = currentEmployeeID,
                        StartWork = this.Generator.GetRandomDateRange()
                    };

                    this.DbContext.Reports.Add(report);
                }

                this.DbContext.SaveChanges();
                i += reportsCount;
                employeeIndex++;
            }
        }
    }
}
