using System.Data;
using System.Data.Entity;
using AtmDb.Data.Migrations;
using AtmDb.Model;

namespace AtmDb.Data
{
    internal class AtmDbContext : DbContext, IAtmDbContext
    {
        public AtmDbContext()
            : base("AtmDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDbContext, Configuration>());
        }

        public IDbSet<CardAccount> CardAccount { get; set; }

        public IDbSet<TransactionHistory> TransactionHistory { get; set; }

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
