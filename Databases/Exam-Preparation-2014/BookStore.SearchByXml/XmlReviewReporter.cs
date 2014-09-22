using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

using BookStore.Data;
using BookStore.Model;

namespace BookStore.SearchByXml
{
    public class XmlReviewReporter : IReviewReporter
    {
        private XDocument xmlDocument;
        private IBookStoreData dbContext;
        private IQueryExtractor queryExtractor;
        private XmlWriter dataWriter;

        public XmlReviewReporter(XDocument xmlDocument, XmlWriter dataWriter, IBookStoreData dbContext, IQueryExtractor queryExtractor)
        {
            this.xmlDocument = xmlDocument;
            this.dbContext = dbContext;
            this.queryExtractor = queryExtractor;
            this.dataWriter = dataWriter;
        }

        public void ReportSearch()
        {
            var allQueries = this.xmlDocument.Descendants("review-queries").Elements();
            this.dataWriter.WriteStartDocument();
            this.dataWriter.WriteStartElement("search-results");

            foreach (XElement element in allQueries)
            {
                this.dataWriter.WriteStartElement("result-set");

                var currentQueryProcessor = this.queryExtractor.DetermineQuery(element);
                var currentQueryResults = currentQueryProcessor.Process();
                this.WriteQueryResults(currentQueryResults);

                this.dataWriter.WriteEndElement();
            }

            this.dataWriter.WriteEndElement();
            this.dataWriter.WriteEndDocument();
        }

        private void WriteQueryResults(IEnumerable<Review> resultSet)
        {
            foreach (var result in resultSet)
            {
                this.dataWriter.WriteStartElement("review");

                this.dataWriter.WriteElementString("date", result.DateOfCreation.ToString());
                this.dataWriter.WriteElementString("content", result.ReviewText);

                this.dataWriter.WriteStartElement("book");
                this.dataWriter.WriteElementString("title", result.Book.Title);

                if (result.Book.Authors.Count > 0)
                {
                    this.dataWriter.WriteElementString("authors", string.Join(", ", result.Book.Authors));
                }

                if (result.Book.ISBN != null)
                {
                    this.dataWriter.WriteElementString("isbn", result.Book.ISBN);
                }

                if (result.Book.Website != null)
                {
                    this.dataWriter.WriteElementString("url", result.Book.Website);
                }

                this.dataWriter.WriteEndElement();

                this.dataWriter.WriteEndElement();
            }
        }
    }
}
