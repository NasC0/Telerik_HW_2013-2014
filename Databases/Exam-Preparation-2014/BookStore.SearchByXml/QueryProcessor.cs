using System;
using System.Collections.Generic;
using System.Xml.Linq;

using BookStore.Data;
using BookStore.Model;

namespace BookStore.SearchByXml
{
    internal abstract class QueryProcessor : IQueryProcessor
    {
        private XElement query;
        private IBookStoreData dbContext;

        public QueryProcessor(XElement query, IBookStoreData dbContext)
        {
            this.Query = query;
            this.DbContext = dbContext;
        }

        protected XElement Query
        {
            get
            {
                return this.query;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Query element must be initialized.");
                }

                this.query = value;
            }
        }

        protected IBookStoreData DbContext
        {
            get
            {
                return this.dbContext;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Database context must be initialized.");
                }

                this.dbContext = value;
            }
        }

        public abstract IEnumerable<Review> Process();
    }
}
