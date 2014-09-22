using System.Linq;

namespace GenerateNorthwindDBContext
{
    public static class CRUDCustomers
    {
        private static NorthwindEntities dbContext;

		public static void Initialize(NorthwindEntities northwindDbContext)
        {
            dbContext = northwindDbContext;
        }

        public static void AddCustomer(Customer customerToAdd)
        {
            using (dbContext)
            {
                dbContext.Customers.Add(customerToAdd);
                dbContext.SaveChanges();
            }
        }

        public static void AddCustomer(string companyName, string contactName = null, string contactTitle = null,
            string address = null, string city = null, string region = null, string postalCode = null, 
            string country = null, string phone = null, string fax = null)
        {
            Customer customerToAdd = new Customer()
            {
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            using (dbContext)
            {
                dbContext.Customers.Add(customerToAdd);
                dbContext.SaveChanges();
            }
        }

        public static void RemoveCustomer(Customer customerToRemove)
        {
            using (dbContext)
            {
                dbContext.Customers.Remove(customerToRemove);
                dbContext.SaveChanges();
            }
        }

        public static void RemoveCustomer(string customerID)
        {
            using (dbContext)
            {
                var customerToRemove = dbContext.Customers.FirstOrDefault(c => c.CustomerID == customerID);
                dbContext.Customers.Remove(customerToRemove);
                dbContext.SaveChanges();
            }
        }

        public static void ChangeCustomerName(Customer customerToChange, Customer customerToReplaceWith)
        {
            using (dbContext)
            {
                var originalCustomer = dbContext.Customers.FirstOrDefault(c => c.CustomerID == customerToChange.CustomerID);   
                originalCustomer = customerToReplaceWith;
                dbContext.SaveChanges();
            }
        }
    }
}
