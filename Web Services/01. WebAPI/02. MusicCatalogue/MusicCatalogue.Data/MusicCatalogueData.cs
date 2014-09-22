using System;
using System.Collections.Generic;
using MusicCatalogue.Data.Repositories;
using MusicCatalogue.Model;

namespace MusicCatalogue.Data
{
    public class MusicCatalogueData : IMusicCatalogueData
    {
        private IMusicCatalogueDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public MusicCatalogueData()
            : this(new MusicCatalogueDbContext())
        {
        }

        public MusicCatalogueData(IMusicCatalogueDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IGenericRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IGenericRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var repoType = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(repoType, this.dbContext));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}