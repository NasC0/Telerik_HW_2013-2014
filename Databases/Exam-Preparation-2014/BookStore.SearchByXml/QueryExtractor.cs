using System;
using System.Xml.Linq;

namespace BookStore.SearchByXml
{
    public class QueryExtractor : IQueryExtractor
    {
        private QueryProcessorFactory processorFactory;

        public QueryExtractor(QueryProcessorFactory processorFactory)
        {
            this.processorFactory = processorFactory;
        }

        public IQueryProcessor DetermineQuery(XElement query)
        {
            var queryType = query.Attribute("type").Value;
            if (queryType == "by-period")
            {
                return this.processorFactory.GetDatePeriodQueryProcessor(query);
            }
            else if (queryType == "by-author")
            {
                return this.processorFactory.GetAuthorQueryProcessor(query);
            }
            else
            {
                throw new ArgumentException("Invalid query type.");
            }
        }
    }
}
