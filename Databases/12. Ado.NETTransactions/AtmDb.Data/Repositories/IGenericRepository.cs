using System;
using System.Linq;
using System.Linq.Expressions;

namespace StudentSystem.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        void Add(T entry);

        T Remove(T entry);

        void Update(T entry);

        void Detach(T entry);

        void SaveChanges();
    }
}
