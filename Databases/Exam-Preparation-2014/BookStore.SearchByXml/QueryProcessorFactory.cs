using System.Xml.Linq;

using BookStore.Data;

namespace BookStore.SearchByXml
{
    public class QueryProcessorFactory
    {
        private IBookStoreData dbContext;

        public QueryProcessorFactory()
            : this(new BookStoreData())
        {
        }

        public QueryProcessorFactory(IBookStoreData dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryProcessor GetAuthorQueryProcessor(XElement query)
        {
            return new AuthorQueryProcessor(query, this.dbContext);
        }

        public IQueryProcessor GetDatePeriodQueryProcessor(XElement query)
        {
            return new DatePeriodQueryProcessor(query, this.dbContext);
        }
    }
}
