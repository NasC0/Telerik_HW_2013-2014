using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using BugsReporter.Data.Migrations;
using BugsReporter.Models;

namespace BugsReporter.Data
{
    public class BugsDbContext : DbContext, IBugsDbContext
    {
        public BugsDbContext()
            : base("BugsReporter")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugsDbContext, Configuration>());
        }

        public virtual IDbSet<Bug> Bugs { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry<T>(entity);
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
