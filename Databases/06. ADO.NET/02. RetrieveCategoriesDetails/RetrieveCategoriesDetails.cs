using System;
using System.Data.SqlClient;

namespace _02.RetrieveCategoriesDetails
{
    public class RetrieveCategoriesDetails
    {
        public static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " + 
                "Database=Northwind; " + "Integrated Security=true; "); 
            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand getCategoriesDescriptions = new SqlCommand("SELECT c.CategoryName, c.Description FROM Categories c", 
                    dbConnection);
                var reader = getCategoriesDescriptions.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0} - {1}", categoryName, description);
                    }
                }
            }
        }
    }
}
