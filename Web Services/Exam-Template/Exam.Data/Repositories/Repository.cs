using System.Data.Entity;

using System.Linq;

namespace Exam.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IDbContext context;

        public Repository()
            : this(new ExamDbContext())
        {
        }

        public Repository(IDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>();
        }

        public T Find(object id)
        {
            return this.context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.context.Set<T>().Attach(entity);
            }

            entry.State = state;
        }
    }
}
