using System;
using System.Data.SqlClient;

namespace _03.GetCategoriesAndProducts
{
    public class GetCategoriesAndProducts
    {
        public static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " + 
                "Database=Northwind; " + "Integrated Security=true;");
            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand getCategoriesAndProducts = new SqlCommand("SELECT c.CategoryName, p.ProductName " +
                                                                     "FROM Categories c " +
                                                                        "JOIN Products p " +
                                                                            "ON p.CategoryID = c.CategoryID " +
                                                                     "ORDER BY c.CategoryName",
                                                                     dbConnection);

                var reader = getCategoriesAndProducts.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];

                        Console.WriteLine("{0} - {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}
