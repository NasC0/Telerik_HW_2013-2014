using System;
using System.Collections.Generic;
using Bookstore.Data.Repositories;
using Bookstore.Model;

namespace Bookstore.Data
{
    public class BookstoreData : IBookstoreData
    {
        private IBookstoreDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public BookstoreData(IBookstoreDbContext bookstoreDbContext)
        {
            this.dbContext = bookstoreDbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public BookstoreData()
            : this(new BooksDbContext())
        {
        }

        public IGenericRepository<Book> Books
        {
            get
            {
                return this.GetRepository<Book>();
            }
        }

        public IGenericRepository<Author> Authors
        {
            get
            {
                return this.GetRepository<Author>();
            }
        }

        public IGenericRepository<Review> Reviews
        {
            get
            {
                return this.GetRepository<Review>();
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var repoType = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(repoType, this.dbContext));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
