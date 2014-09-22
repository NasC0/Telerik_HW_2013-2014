using System.Data;
using System.Data.Entity;
using BookStore.Data.Migrations;
using BookStore.Model;

namespace BookStore.Data
{
    internal class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public BookStoreDbContext()
            : base("BookStoreConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Review> Reviews { get; set; }

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
