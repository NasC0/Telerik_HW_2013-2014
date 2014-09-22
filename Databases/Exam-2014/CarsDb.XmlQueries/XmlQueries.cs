using CarsDb.Data;
namespace CarsDb.XmlQueries
{
    public class XmlQueries
    {
        private const string FileLocation = "../../../Queries.xml"; 
        private const string ResultsLocation = "../../../QueryResults/";

        public static void Main()
        {
            var dbContext = new CarsData();
            var queryExtractor = new QueryExtractor(dbContext);
            var queryProcessor = new QueryProcessor(dbContext, FileLocation, queryExtractor, ResultsLocation);
            queryProcessor.Process();
        }
    }
}
