using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CarsDb.Data.Repositories;
using CarsDb.Model;

namespace CarsDb.Data
{
    public class CarsData : ICarsData
    {
        private ICarsDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public CarsData(ICarsDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public CarsData()
            : this(new CarsDbContext())
        {
        }

        public IGenericRepository<Car> Cars
        {
            get
            {
                return this.GetRepository<Car>();
            }
        }

        public IGenericRepository<Dealer> Dealers
        {
            get
            {
                return this.GetRepository<Dealer>();
            }
        }

        public IGenericRepository<Manufacturer> Manufacturers
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IGenericRepository<City> Cities
        {
            get
            {
                return this.GetRepository<City>();
            }
        }

        public DbContextConfiguration Configuration
        {
            get
            {
                return this.dbContext.Configuration;
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
