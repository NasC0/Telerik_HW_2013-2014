using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Bookstore.Model;

namespace Bookstore.Data
{
    public interface IBookstoreDbContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
