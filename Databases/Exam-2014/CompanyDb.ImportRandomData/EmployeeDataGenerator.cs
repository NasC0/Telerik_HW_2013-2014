using System;
using System.Linq;
using System.Text;
using CompanyDb.Data;

namespace CompanyDb.ImportRandomData
{
    public class EmployeeDataGenerator : DataGenerator, IDataGenerator
    {
        private const int MinStringLength = 5;
        private const int MaxStringLength = 20;
        private const int MinSalary = 50000;
        private const int MaxSalary = 200000;

        public EmployeeDataGenerator(int dataCount, RandomGenerator generatorInstance, CompanyDbEntities dbContext)
            : base(dataCount, generatorInstance, dbContext)
        {
        }

        public void GenerateData()
        {
            var departmentIDs = this.DbContext.Departments.Select(dep => dep.DepartmentID).ToList();
            StringBuilder queryBuilder = new StringBuilder();
            string originalQuery = "INSERT INTO Employees (FirstName, LastName, Salary, DepartmentID, ManagerID) VALUES ";
            queryBuilder.AppendLine(originalQuery);

            for (int i = 1; i < this.DataCount + 1; i++)
            {
                string firstName = this.Generator.GetRandomString(MinStringLength, MaxStringLength);
                string lastName = this.Generator.GetRandomString(MinStringLength, MaxStringLength);
                int departmentID = departmentIDs[this.Generator.GetRandomNumber(0, departmentIDs.Count - 1)];
                int salary = this.Generator.GetRandomNumber(MinSalary, MaxSalary);
                int managerChance = this.Generator.GetRandomNumber(0, 100);
                Nullable<int> managerID = null;

                if (managerChance <= 95 && i != 0)
                {
                    managerID = i - 1;
                }

                if (managerID == null)
                {
                    queryBuilder.AppendFormat("('{0}', '{1}', {2}, {3}, {4}), ", firstName, lastName, salary, departmentID, "NULL");
                }
                else
                {
                    queryBuilder.AppendFormat("('{0}', '{1}', {2}, {3}, {4}), ", firstName, lastName, salary, departmentID, managerID); 
                }

                if (i % 1000 == 0)
                {
                    queryBuilder.Remove(queryBuilder.Length - 2, 2);
                    var queryString = queryBuilder.ToString();
                    this.DbContext.Database.ExecuteSqlCommand(queryBuilder.ToString());
                    queryBuilder.Clear();
                    queryBuilder.AppendLine(originalQuery);
                }
            }
        }
    }
}
