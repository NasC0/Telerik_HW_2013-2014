using System.Collections.Generic;
using CompanyDb.Data;

namespace CompanyDb.ImportRandomData
{
    public class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        private const int MinStringLength = 10;
        private const int MaxStringLength = 50;
        
        public DepartmentDataGenerator(int dataCount, RandomGenerator generatorInstance, CompanyDbEntities dbContext)
            : base(dataCount, generatorInstance, dbContext)
        {
        }

        public void GenerateData()
        {
            var departmentNameHashset = new HashSet<string>();

            for (int i = 0; i < this.DataCount; i++)
            {
                string departmentName = this.Generator.GetRandomString(MinStringLength, MaxStringLength);

                while (departmentNameHashset.Contains(departmentName))
                {
                    departmentName = this.Generator.GetRandomString(MinStringLength, MaxStringLength);
                }
                
                departmentNameHashset.Add(departmentName);

                var currentDepartment = new Department()
                {
                    Name = departmentName
                };

                this.DbContext.Departments.Add(currentDepartment);

                if (i % 100 == 0)
                {
                    this.DbContext.SaveChanges();
                }
            }
        }
    }
}
