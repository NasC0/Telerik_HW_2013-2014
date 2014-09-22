using System.Linq;

namespace BugsReporter.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T Find(object id);

        void Add(T entity);

        T Update(T entity);

        T Delete(T entity);

        void SaveChanges();
    }
}
