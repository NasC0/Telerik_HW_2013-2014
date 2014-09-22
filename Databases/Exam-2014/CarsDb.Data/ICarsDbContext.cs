using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CarsDb.Model;

namespace CarsDb.Data
{
    public interface ICarsDbContext
    {
        IDbSet<Car> Cars { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Dealer> Dealers { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        DbContextTransaction BeginTransaction();

        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);

        DbContextConfiguration Configuration { get; }
    }
}
