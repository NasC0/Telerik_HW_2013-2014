using System.Data.Entity;
using Bookstore.Data.Migrations;
using Bookstore.Model;

namespace Bookstore.Data
{
    public class BooksDbContext : DbContext, IBookstoreDbContext
    {
        public BooksDbContext()
            : base("Bookstore")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BooksDbContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Review> Reviews { get; set; }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
