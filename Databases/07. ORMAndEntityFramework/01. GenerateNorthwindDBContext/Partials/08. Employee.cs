using System.Data.Linq;

namespace GenerateNorthwindDBContext
{
    public partial class Employee
    {
        private EntitySet<Territory> employeeTerritories = new EntitySet<Territory>();

        public EntitySet<Territory> EmployeeTerritories
        {
            get
            {
                var resultSet = new EntitySet<Territory>();
                resultSet.AddRange(this.Territories);
                return resultSet;
            }
        }
    }
}
