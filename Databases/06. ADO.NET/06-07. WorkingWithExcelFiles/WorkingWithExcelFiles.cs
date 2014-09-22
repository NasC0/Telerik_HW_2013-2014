// If you get an Assembly Exception, download this: http://www.microsoft.com/en-us/download/confirmation.aspx?id=23734

using System;
using System.Data.OleDb;

namespace _06_07.WorkingWithExcelFiles
{
    public class WorkingWithExcelFiles
    {
        public const string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=..\\..\\Scores.xlsx; Extended Properties=\"Excel 12.0; HDR=Yes;\"";

        public static void AddToTable(string name, double score, OleDbConnection connection)
        {
            string query = String.Format("INSERT INTO [Sheet1$] (Name, Score) VALUES('{0}', {1})", name, score);
            var executeCommand = new OleDbCommand(query, connection);
            executeCommand.ExecuteNonQuery();
        }

        public static void Main()
        {
            OleDbConnection excelConnection = new OleDbConnection(ConnectionString);
            excelConnection.Open();

            using (excelConnection)
            {
                AddToTable("Pesho Peshev", 15, excelConnection);

                OleDbCommand getAllEntries = new OleDbCommand("SELECT * FROM [Sheet1$]", excelConnection);
                var dataReader = getAllEntries.ExecuteReader();

                using (dataReader)
                {
                    while (dataReader.Read())
                    {
                        string name = (string)dataReader[0];
                        double score = (double)dataReader[1];
                        Console.WriteLine("{0} - {1}", name, score);
                    }
                }
            }
        }
    }
}
