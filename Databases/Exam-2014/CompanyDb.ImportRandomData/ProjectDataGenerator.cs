using System;
using System.Collections.Generic;
using System.Linq;
using CompanyDb.Data;

namespace CompanyDb.ImportRandomData
{
    public class ProjectDataGenerator : DataGenerator, IDataGenerator
    {
        private const int MinStringLength = 5;
        private const int MaxStringLength = 50;
        private const int MinEmployees = 2;
        private const int MaxEmployees = 20;

        public ProjectDataGenerator(int dataCount, RandomGenerator generatorInstance, CompanyDbEntities dbContext)
            : base(dataCount, generatorInstance, dbContext)
        {
        }

        public void GenerateData()
        {
            var employeeIDs = this.DbContext.Employees.Select(emp => emp.EmployeeID).ToList();
            int employeeIDsCount = employeeIDs.Count - 1;

            for (int i = 0; i < this.DataCount; i++)
            {
                string projectName = this.Generator.GetRandomString(MinStringLength, MaxStringLength);
                int employeesCount = this.Generator.GetRandomNumber(MinEmployees, MaxEmployees);

                var currentProject = new Project()
                {
                    Name = projectName
                };
                this.DbContext.Projects.Add(currentProject);
                var employeeIDSet = new HashSet<int>();

                while (employeeIDSet.Count < employeesCount)
                {
                    var currentEmployeeID = employeeIDs[this.Generator.GetRandomNumber(0, employeeIDsCount)];
                    while (employeeIDSet.Contains(currentEmployeeID))
                    {
                        currentEmployeeID = employeeIDs[this.Generator.GetRandomNumber(0, employeeIDsCount)];
                    }

                    employeeIDSet.Add(currentEmployeeID);

                    var minDate = this.Generator.GetRandomDateRange();
                    var maxDate = this.Generator.GetRandomDateRange(minDate);

                    var employeesProjects = new EmployeesProject()
                    {
                        Project = currentProject,
                        EmployeeID = currentEmployeeID,
                        StartDate = minDate,
                        EndDate = maxDate
                    };

                    this.DbContext.EmployeesProjects.Add(employeesProjects);
                }

                if (i % 100 == 0)
                {
                    this.DbContext.SaveChanges();
                }
            }
        }
    }
}
