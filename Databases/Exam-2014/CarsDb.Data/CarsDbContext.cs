using System.Data;
using System.Data.Entity;
using CarsDb.Data.Migrations;
using CarsDb.Model;

namespace CarsDb.Data
{
    internal class CarsDbContext : DbContext, ICarsDbContext
    {
        public CarsDbContext()
            : base("CarsDbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<City> Cities { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public DbContextTransaction BeginTransaction()
        {
            return this.Database.BeginTransaction();
        }

        public DbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return this.Database.BeginTransaction(isolationLevel);
        }
    }
}
