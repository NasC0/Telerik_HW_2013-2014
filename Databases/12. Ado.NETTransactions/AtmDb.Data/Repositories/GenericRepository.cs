using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AtmDb.Data;
using StudentSystem.Data.Repositories;

namespace AtmDb.ConsoleClient.Repositories
{
    class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IAtmDbContext dbContext;

        public GenericRepository(IAtmDbContext atmDbContext)
        {
            this.dbContext = atmDbContext;
        }

        public GenericRepository()
            : this(new AtmDbContext())
        {
        }

        public IQueryable<T> GetAll()
        {
            return this.dbContext.Set<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.GetAll().Where(expression);
        }

        public void Add(T entry)
        {
            this.SetState(entry, EntityState.Added);
        }

        public T Remove(T entry)
        {
            this.SetState(entry, EntityState.Deleted);
            return entry;
        }

        public void Update(T entry)
        {
            this.SetState(entry, EntityState.Modified);
        }

        public void Detach(T entry)
        {
            this.SetState(entry, EntityState.Detached);
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private void SetState(T entry, EntityState state)
        {
            this.dbContext.Set<T>().Attach(entry);
            this.dbContext.Entry(entry).State = state;
        }
    }
}
