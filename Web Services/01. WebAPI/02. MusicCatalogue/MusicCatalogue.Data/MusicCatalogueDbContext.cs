using System.Data.Entity;
using MusicCatalogue.Data.Migrations;

using MusicCatalogue.Model;

namespace MusicCatalogue.Data
{
    public class MusicCatalogueDbContext : DbContext, IMusicCatalogueDbContext
    {
        public MusicCatalogueDbContext()
            : base("MusicCatalogueConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicCatalogueDbContext, Configuration>());
        }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
