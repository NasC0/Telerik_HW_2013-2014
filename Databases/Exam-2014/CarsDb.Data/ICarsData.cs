using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CarsDb.Data.Repositories;
using CarsDb.Model;

namespace CarsDb.Data
{
    public interface ICarsData
    {
        IGenericRepository<Car> Cars { get; }

        IGenericRepository<Dealer> Dealers { get; }

        IGenericRepository<Manufacturer> Manufacturers { get; }

        IGenericRepository<City> Cities { get; }

        DbContextConfiguration Configuration { get; }

        int SaveChanges();

        DbContextTransaction BeginTransaction();

        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
    }
}
