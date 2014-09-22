using System;
using System.Data.SqlClient;

namespace _01.RetrieveCategoriesRows
{
    public class RetrieveRows
    {
        public static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " +
                "Database=Northwind; " + "Integrated Security=true;");
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand getCategoriesRows = new SqlCommand("SELECT COUNT(*) FROM Categories", dbConnection);
                int rowNumber = (int)getCategoriesRows.ExecuteScalar();
                Console.WriteLine("The number of rows in the Categories table is: {0}", rowNumber);
            }
        }
    }
}
