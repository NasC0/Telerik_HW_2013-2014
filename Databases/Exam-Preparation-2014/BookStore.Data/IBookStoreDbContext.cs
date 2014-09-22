using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BookStore.Model;

namespace BookStore.Data
{
    public interface IBookStoreDbContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        DbContextTransaction BeginTransaction();

        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
    }
}
