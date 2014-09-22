using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using BookStore.Data.Repositories;
using BookStore.Model;

namespace BookStore.Data
{
    public class BookStoreData : IBookStoreData
    {
        private IBookStoreDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public BookStoreData(IBookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public BookStoreData()
            : this(new BookStoreDbContext())
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

        public DbContextTransaction BeginTransaction()
        {
            return this.dbContext.BeginTransaction();
        }

        public DbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return this.dbContext.BeginTransaction(isolationLevel);
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
