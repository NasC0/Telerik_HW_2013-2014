using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _08.FindProductsByName
{
    public class FindProductsByName
    {
        public const string DbConnectionString = "Server=.; Database=Northwind; Integrated Security=true;";

        public static List<Product> FindProductsByNameCriteria(SqlConnection dbConnection, string searchCriteria)
        {
            SqlCommand findProducts = new SqlCommand("SELECT * FROM Products " +
                                                     "WHERE ProductName LIKE @searchCriteria ", dbConnection);
            findProducts.Parameters.AddWithValue("@searchCriteria", searchCriteria);

            var reader = findProducts.ExecuteReader();
            var productsList = new List<Product>();

            if (!reader.HasRows)
            {
                return productsList;
            }

            using (reader)
            {
                while (reader.Read())
                {
                    int productID = (int)reader["ProductID"];
                    string productName = (string)reader["ProductName"];
                    int supplierID = (int)reader["SupplierID"];
                    int categoryID = (int)reader["CategoryID"];
                    string quantity = (string)reader["QuantityPerUnit"];
                    decimal price = (decimal)reader["UnitPrice"];
                    int stock = (short)reader["UnitsInStock"];
                    int unitsOrder = (short)reader["UnitsOnOrder"];
                    int reorderLevel = (short)reader["ReorderLevel"];
                    bool isDiscontinuet = (bool)reader["Discontinued"];

                    Product currentProduct = new Product()
                    {
                        ID = productID,
                        Name = productName,
                        SupplierID = supplierID,
                        CategoryID = categoryID,
                        Quantity = quantity,
                        Price = price,
                        InStock = stock,
                        OnOrder = unitsOrder,
                        ReorderLevel = reorderLevel,
                        IsDiscontinued = isDiscontinuet
                    };

                    productsList.Add(currentProduct);
                }
            }

            return productsList;
        }

        public static void Main()
        {
            Console.Write("Please enter a name search criteria: ");
            string searchCriteria = Console.ReadLine();

            SqlConnection dbConnection = new SqlConnection(DbConnectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                string seearchCriteriaForSql = '%' + searchCriteria + '%';
                var productsList = FindProductsByNameCriteria(dbConnection, seearchCriteriaForSql);

                foreach (var product in productsList)
                {
                    Console.WriteLine(product);
                    Console.WriteLine();
                }
            }
        }
    }
}
