using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BookStore.Data;
using BookStore.Model;

namespace BookStore.SearchByXml
{
    internal class AuthorQueryProcessor : QueryProcessor, IQueryProcessor
    {
        public AuthorQueryProcessor(XElement query, IBookStoreData dbContext)
            : base(query, dbContext)
        {
        }

        public override IEnumerable<Review> Process()
        {
            int authorNameCount = this.Query.Descendants("author-name").Count();
            if (authorNameCount > 1)
            {
                throw new ArgumentException("Invalid number of author names in search query.");
            }

            string authorName = this.Query.Descendants("author-name").FirstOrDefault().Value;

            var results = this.DbContext.Reviews
                              .Find(x => x.Author.Name == authorName)
                              .OrderBy(rev => rev.DateOfCreation)
                              .ThenBy(rev => rev.ReviewText)
                              .ToList();

            return results;
        }
    }
}