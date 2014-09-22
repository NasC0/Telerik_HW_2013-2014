using System.Data;
using System.Data.Entity;
using AtmDb.Model;
using StudentSystem.Data.Repositories;

namespace AtmDb.Data
{
    public interface IAtmDbData
    {
        IGenericRepository<CardAccount> CardAccounts { get; }

        IGenericRepository<TransactionHistory> TransactionHistory { get; }

        int SaveChanges();

        DbContextTransaction BeginTransaction();

        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
    }
}
