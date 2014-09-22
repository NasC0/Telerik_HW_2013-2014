using System;
using System.Linq;
using CarsDb.Data;
namespace CarsDb.ImportFromJson
{
    public class ImportFromJson
    {
        private const string JsonFilesLocation = "../../../Data.Json.Files";

        static void Main()
        {
            var carsDbContext = new CarsData();
            carsDbContext.Cars.GetAll().Count();
            var jsonParser = new FileProcessor(JsonFilesLocation, carsDbContext);
            Console.WriteLine("Parser starting...");
            Console.WriteLine("It's pretty slow so please have patience.");
            jsonParser.Process();
        }
    }
}
