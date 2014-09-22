using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BookStore.Data;
using BookStore.Model;

namespace BookStore.SearchByXml
{
    internal class DatePeriodQueryProcessor : QueryProcessor, IQueryProcessor
    {
        public DatePeriodQueryProcessor(XElement query, IBookStoreData dbContext)
            : base(query, dbContext)
        {
        }

        public override IEnumerable<Review> Process()
        {
            int startDateDescendantsCount = this.Query.Descendants("start-date").Count();
            int endDateDescendantsCount = this.Query.Descendants("end-date").Count();

            if (startDateDescendantsCount > 1 || endDateDescendantsCount > 1)
            {
                throw new ArgumentException("Invalid number of date periods in search query.");
            }

            string startDateString = this.Query.Descendants("start-date").FirstOrDefault().Value;
            string endDateString = this.Query.Descendants("end-date").FirstOrDefault().Value;
            DateTime startDate = DateTime.Parse(startDateString);
            DateTime endDate = DateTime.Parse(endDateString);

            var results = this.DbContext.Reviews
                              .Find(rev => rev.DateOfCreation >= startDate && rev.DateOfCreation <= endDate)
                              .OrderBy(rev => rev.DateOfCreation)
                              .ThenBy(rev => rev.ReviewText)
                              .ToList();

            return results;
        }
    }
}