using MusicCatalogue.Data.Repositories;

using MusicCatalogue.Model;

namespace MusicCatalogue.Data
{
    public interface IMusicCatalogueData
    {
        IGenericRepository<Artist> Artists { get; }
        IGenericRepository<Album> Albums { get; }
        IGenericRepository<Song> Songs { get; }

        int SaveChanges();
    }
}
