using System;
using System.Data.SqlClient;

namespace _04.AddProductsToNorthwindDB
{
    public class AddProducts
    {
        public static int AddProduct(SqlConnection dbConnection, string ProductName, int SupplierID, 
            int CategoryID, string Quantity, decimal Price, short UnitsInStock,
            short UnitsOnOrder, short ReorderLevel, byte Discontinued)
        {
            SqlCommand insertProductCommand = new SqlCommand("INSERT INTO Products " +
                                                             "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                                                             "VALUES(@Name, @Supplier, @Category, @Quantity, @Price, @Stock, @Order, @Reorder, @Discontinued)",
                dbConnection);

            insertProductCommand.Parameters.AddWithValue("@Name", ProductName);
            insertProductCommand.Parameters.AddWithValue("@Supplier", SupplierID);
            insertProductCommand.Parameters.AddWithValue("@Category", CategoryID);
            insertProductCommand.Parameters.AddWithValue("@Quantity", Quantity);
            insertProductCommand.Parameters.AddWithValue("@Price", Price);
            insertProductCommand.Parameters.AddWithValue("@Stock", UnitsInStock);
            insertProductCommand.Parameters.AddWithValue("@Order", UnitsOnOrder);
            insertProductCommand.Parameters.AddWithValue("@Reorder", ReorderLevel);
            insertProductCommand.Parameters.AddWithValue("@Discontinued", Discontinued);

            insertProductCommand.ExecuteNonQuery();

            SqlCommand getNewID = new SqlCommand("SELECT @@Identity", dbConnection);
            int newProductID = (int)(decimal)getNewID.ExecuteScalar();

            return newProductID;
        }

        public static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " + 
                "Database=Northwind; " + "Integrated Security=true; ");
            dbConnection.Open();

            using (dbConnection)
            {
                int newProductID = AddProduct(dbConnection, "Zagorka", 1, 1, "400 bottles", 1.25m, 400, 10, 10, 0);
                Console.WriteLine(newProductID);
            }
        }
    }
}
