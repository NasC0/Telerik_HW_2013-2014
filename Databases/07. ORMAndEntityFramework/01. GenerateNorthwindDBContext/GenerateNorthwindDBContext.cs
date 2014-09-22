using System;
using System.Collections.Generic;
using System.Linq;

namespace GenerateNorthwindDBContext
{
    public class GenerateNorthwindDBContext
    {
        private const int ShippingYear = 1997;
        private const string ShippingCountry = "Canada";

        #region Task3.
        // Task 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        public static IQueryable<Customer> OrdersShippedToCanada(NorthwindEntities dbContext)
        {
            var customersCollection = dbContext.Orders
                                               .Where(o => o.ShipCountry == ShippingCountry && 
                                                   o.OrderDate.Value.Year == ShippingYear)
                                               .Select(o => o.Customer)
                                               .Distinct();

            return customersCollection;
        }
        #endregion

        #region Task4.
        // Task 04. Implement previous by using native SQL query and executing it through the DbContext.
        public static List<string> OrdersShippedToCanadaNativeSql(NorthwindEntities dbContext)
        {
            string query = "SELECT DISTINCT c.ContactName " +
                           "FROM Customers c " +
                                "JOIN Orders o " +
                                    "ON o.CustomerID = c.CustomerID " +
                           "WHERE YEAR(o.OrderDate) = {0} " +
                                "AND o.ShipCountry = {1}";

            string[] parameters = new string[]
            {
                ShippingYear.ToString(),
                ShippingCountry
            };

            var resultingCustomers = dbContext.Database.SqlQuery<string>(query, parameters);
            return resultingCustomers.ToList();
        }
        #endregion

        #region Task5.
        // Task 05. Write a method that finds all the sales by specified region and period (start / end dates).
        public static IQueryable<Order> SalesByRegionAndPeriod(NorthwindEntities dbContext, string region, DateTime startDate, DateTime endDate)
        {
            var ordersCollection = dbContext.Orders
                                            .Where(o => o.ShipRegion == region &&
                                                        o.OrderDate.Value >= startDate &&
                                                        o.OrderDate.Value <= endDate);

            return ordersCollection;
        }
        #endregion

        #region Task9.

        public static void AddOrders(NorthwindEntities dbContext, params Order[] orders)
        {
            using (var currentTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var order in orders)
                    {
                        dbContext.Orders.Add(order);
                    }

                    dbContext.SaveChanges();
                    currentTransaction.Commit();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    currentTransaction.Rollback();
                }
            }
        }

        #endregion

        #region Task10.
        // Task 10. Create a stored procedures in the Northwind database for finding the total incomes 
        // for given supplier name and period (start date, end date). 
        // Implement a C# method that calls the stored procedure and returns the retuned record set.
        public static Nullable<decimal> GetTotalIncome(NorthwindEntities dbContext, string supplier, DateTime startDate, DateTime endDate)
        {
            var result = dbContext.GetTotalIncome(supplier, startDate, endDate);
            return result.FirstOrDefault();
        }
        #endregion

        public static void Main()
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                #region Task3.
                // Task 03.
                var customerCollection = OrdersShippedToCanada(dbContext);
                foreach (var customer in customerCollection)
                {
                    Console.WriteLine(customer.ContactName);
                }
                #endregion

                Console.WriteLine("---------------------");

                #region Task4.
                // Task 04.
                var customerCollectonNativeSql = OrdersShippedToCanadaNativeSql(dbContext);
                foreach (var customer in customerCollection)
                {
                    Console.WriteLine(customer.ContactName);
                }
                #endregion

                Console.WriteLine("---------------------");

                #region Task5.
                // Task 05.
                string region = "RJ";
                DateTime startDate = new DateTime(1995, 01, 01);
                DateTime endDate = new DateTime(1998, 12, 31);
                var sales = SalesByRegionAndPeriod(dbContext, region, startDate, endDate);
                foreach (var sale in sales)
                {
                    Console.WriteLine(sale.CustomerID);
                }
                #endregion

                Console.WriteLine("---------------------");

                #region Task7.
                NorthwindEntities firstDbContext = new NorthwindEntities();
                NorthwindEntities secondDbContext = new NorthwindEntities();

                var firstDbCustomer = firstDbContext.Customers.FirstOrDefault();
                var secondDbCustomer = secondDbContext.Customers.FirstOrDefault();

                firstDbCustomer.ContactName = "Misho";
                secondDbCustomer.ContactName = "Pesho";

                firstDbContext.SaveChanges();
                secondDbContext.SaveChanges();
                #endregion

                #region Task9.
                Order firstOrder = new Order()
                {
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    ShipName = "Santa Maria"
                };

                Order secondOrder = new Order()
                {
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    ShipName = "Santa Monica"
                };

                AddOrders(dbContext, firstOrder, secondOrder);
                #endregion

                #region Task10.
                DateTime startDateTotalIncome = new DateTime(1900, 08, 08);
                var totalIncome = GetTotalIncome(dbContext, "Exotic Liquids", startDateTotalIncome, DateTime.Now);
                Console.WriteLine("Exotic Liquids total income: {0}", totalIncome);
                #endregion
            }
        }
    }
}
