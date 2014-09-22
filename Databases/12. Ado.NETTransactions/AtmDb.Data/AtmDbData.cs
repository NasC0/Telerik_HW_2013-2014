using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using AtmDb.ConsoleClient.Repositories;
using AtmDb.Model;
using StudentSystem.Data.Repositories;

namespace AtmDb.Data
{
    public class AtmDbData : IAtmDbData
    {
        private IAtmDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public AtmDbData(IAtmDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public AtmDbData()
            : this(new AtmDbContext())
        {
        }

        public IGenericRepository<CardAccount> CardAccounts
        {
            get
            {
                return this.GetRepository<CardAccount>();
            }
        }

        public IGenericRepository<TransactionHistory> TransactionHistory
        {
            get
            {
                return this.GetRepository<TransactionHistory>();
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