using Bookstore.Data.Repositories;
using Bookstore.Model;

namespace Bookstore.Data
{
    public interface IBookstoreData
    {
        IGenericRepository<Book> Books { get; }
        IGenericRepository<Author> Authors { get; }
        IGenericRepository<Review> Reviews { get; }

        int SaveChanges();
    }
}
