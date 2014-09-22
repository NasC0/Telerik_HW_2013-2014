using System.Xml.Linq;
using CarsDb.Data;

namespace CarsDb.XmlQueries
{
    public class QueryProcessor : IQueryProcessor
    {
        private ICarsData dbContext;
        private string queryLocation;
        private IQueryExtractor extractor;
        private string outputFileLocation;

        public QueryProcessor(ICarsData dbContext, string queryLocation, IQueryExtractor extractor, string outputFileLocation)
        {
            this.dbContext = dbContext;
            this.queryLocation = queryLocation;
            this.extractor = extractor;
            this.outputFileLocation = outputFileLocation;
        }

        public void Process()
        {
            var queryDocument = XDocument.Load(this.queryLocation);
            var allQueries = queryDocument.Descendants("Queries").Elements();
            foreach (var query in allQueries)
            {
                var currentOutputFilePath = this.outputFileLocation + query.Attribute("OutputFileName").Value;
                var filteredCars = this.extractor.ExtractQuery(query);
                var queryWriter = new XmlQueryWriter(filteredCars, currentOutputFilePath);
                queryWriter.WriteQuery();
            }
        }
    }
}
