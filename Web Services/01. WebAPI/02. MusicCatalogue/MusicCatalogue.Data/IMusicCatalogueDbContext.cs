using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MusicCatalogue.Model;

namespace MusicCatalogue.Data
{
    public interface IMusicCatalogueDbContext
    {
        IDbSet<Artist> Artists { get; set; }

        IDbSet<Album> Albums { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
