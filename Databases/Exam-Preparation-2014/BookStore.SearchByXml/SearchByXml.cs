using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using MongoDB.Driver;

using BookStore.Data;
using BookStore.Model;

namespace BookStore.SearchByXml
{
    public class SearchByXml
    {
        private const string FileLocation = "../../reviews-queries.xml";
        private const string FileOutput = "../../review-search-results.xml";

        //private static void ProcessSearchQueries(IEnumerable<XNode> query, IBookStoreData dbContext, MongoDatabase mongoDb)
        //{
        //    var writerSettings = new XmlWriterSettings()
        //    {
        //        Indent = true,
        //        IndentChars = "\t"
        //    };

        //    using (var dataWriter = XmlWriter.Create(FileOutput, writerSettings))
        //    {
        //        dataWriter.WriteStartDocument();
        //        dataWriter.WriteStartElement("search-results");

        //        foreach (XElement element in query)
        //        {
        //            dataWriter.WriteStartElement("result-set");

        //            var currentQueryResults = ProcessSingleQuery(element, dbContext);

        //            WriteQueryResults(currentQueryResults, dataWriter);
        //            var logObject = new Log()
        //            {
        //                LogDate = DateTime.Now,
        //                LogQuery = element.ToString()
        //            };
        //            //mongoDb.GetCollection<Log>("logs").Insert(logObject);

        //            dataWriter.WriteEndElement();
        //        }

        //        dataWriter.WriteEndElement();
        //        dataWriter.WriteEndDocument();
        //    }
        //}

        //private static void WriteQueryResults(IEnumerable<Review> resultSet, XmlWriter writer)
        //{
        //    foreach (var result in resultSet)
        //    {
        //        writer.WriteStartElement("review");

        //        writer.WriteElementString("date", result.DateOfCreation.ToString());
        //        writer.WriteElementString("content", result.ReviewText);

        //        writer.WriteStartElement("book");

        //        writer.WriteElementString("title", result.Book.Title);

        //        if (result.Book.Authors.Count > 0)
        //        {
        //            StringBuilder authorsString = new StringBuilder();
        //            foreach (var author in result.Book.Authors)
        //            {
        //                authorsString.Append(author.Name + ", ");
        //            }

        //            authorsString.Remove(authorsString.Length - 2, 2);
        //            writer.WriteElementString("authors", authorsString.ToString());
        //        }

        //        if (result.Book.ISBN != null)
        //        {
        //            writer.WriteElementString("isbn", result.Book.ISBN);
        //        }

        //        if (result.Book.Website != null)
        //        {
        //            writer.WriteElementString("url", result.Book.Website);
        //        }

        //        writer.WriteEndElement();

        //        writer.WriteEndElement();
        //    }
        //}

        //private static IEnumerable<Review> ProcessSingleQuery(XElement query, IBookStoreData dbContext)
        //{
        //    var queryType = query.Attribute("type").Value;

        //    if (queryType == "by-period")
        //    {
        //        return ProcessPeriodQuery(query, dbContext);
        //    }
        //    else if (queryType == "by-author")
        //    {
        //        return ProcessAuthorQuery(query, dbContext);
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Query type must be valid.");
        //    }
        //}

        //private static IEnumerable<Review> ProcessAuthorQuery(XElement query, IBookStoreData dbContext)
        //{
        //    int authorNameCount = query.Descendants("author-name").Count();
        //    if (authorNameCount > 1)
        //    {
        //        throw new ArgumentException("Invalid number of author names in search query.");
        //    }

        //    string authorName = query.Descendants("author-name").FirstOrDefault().Value;

        //    var results = dbContext.Reviews
        //                           .Find(x => x.Author.Name == authorName)
        //                           .OrderBy(rev => rev.DateOfCreation)
        //                           .ThenBy(rev => rev.ReviewText)
        //                           .ToList();

        //    return results;
        //}

        //private static IEnumerable<Review> ProcessPeriodQuery(XElement query, IBookStoreData dbContext)
        //{
        //    int startDateDescendantsCount = query.Descendants("start-date").Count();
        //    int endDateDescendantsCount = query.Descendants("end-date").Count();

        //    if (startDateDescendantsCount > 1 || endDateDescendantsCount > 1)
        //    {
        //        throw new ArgumentException("Invalid number of date periods in search query.");
        //    }

        //    string startDateString = query.Descendants("start-date").FirstOrDefault().Value;
        //    string endDateString = query.Descendants("end-date").FirstOrDefault().Value;
        //    DateTime startDate = DateTime.Parse(startDateString);
        //    DateTime endDate = DateTime.Parse(endDateString);

        //    var results = dbContext.Reviews
        //                           .Find(rev => rev.DateOfCreation >= startDate && rev.DateOfCreation <= endDate)
        //                           .OrderBy(rev => rev.DateOfCreation)
        //                           .ThenBy(rev => rev.ReviewText)
        //                           .ToList();

        //    return results;
        //}

        public static void Main()
        {
            var writerSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t"
            };

            var xmlSearchQuery = XDocument.Load(FileLocation);
            var dbContext = new BookStoreData();
            var processorFactory = new QueryProcessorFactory(dbContext);
            var queryExtractor = new QueryExtractor(processorFactory);

            dbContext.Authors.GetAll().Count();

            var timer = new Stopwatch();
            timer.Start();
            using (var dataWriter = XmlWriter.Create(FileOutput, writerSettings))
            {
                XmlReviewReporter reviewer = new XmlReviewReporter(xmlSearchQuery, dataWriter, dbContext, queryExtractor);
                reviewer.ReportSearch();
            }
            timer.Stop();

            Console.WriteLine(timer.Elapsed);

            //var queries = xmlSearchQuery.Descendants("review-queries").Nodes();
            //var dbContext = new BookStoreData();
            //var mongoDb = LogDbContextFactory.GetDatabase();

            //Stopwatch timer = new Stopwatch();

            //dbContext.Authors.GetAll().Count();

            //timer.Start();
            //ProcessSearchQueries(queries, dbContext, mongoDb);
            //timer.Stop();
            //Console.WriteLine(timer.Elapsed);
        }
    }
}