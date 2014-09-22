using System;
using System.IO;
using CarsDb.Data;

namespace CarsDb.ImportFromJson
{
    public class FileProcessor : IFileProcessor
    {
        private string filesLocation;
        private CarsData dbContext;

        public FileProcessor(string filesLocation, CarsData dbContext)
        {
            this.filesLocation = filesLocation;
            this.dbContext = dbContext;
        }

        public void Process()
        {
            try
            {
                var jsonFilesInFolder = Directory.GetFiles(this.filesLocation);
                foreach (var path in jsonFilesInFolder)
                {
                    this.dbContext = new CarsData();
                    IJsonParser parser = new JsonParser(this.dbContext, path);
                    Console.WriteLine("Parsing {0}", path);
                    parser.ParseJson();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
