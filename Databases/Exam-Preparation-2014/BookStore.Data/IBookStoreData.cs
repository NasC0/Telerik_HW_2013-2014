using System.Data;
using System.Data.Entity;
using BookStore.Data.Repositories;
using BookStore.Model;

namespace BookStore.Data
{
    public interface IBookStoreData
    {
        IGenericRepository<Book> Books { get; }

        IGenericRepository<Author> Authors { get; }

        IGenericRepository<Review> Reviews { get; }

        int SaveChanges();

        DbContextTransaction BeginTransaction();

        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
    }
}
