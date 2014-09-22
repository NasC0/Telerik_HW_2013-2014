using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AtmDb.Model;

namespace AtmDb.Data
{
    public interface IAtmDbContext
    {
        IDbSet<CardAccount> CardAccount { get; set; }

        IDbSet<TransactionHistory> TransactionHistory { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        DbContextTransaction BeginTransaction();

        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
    }
}
