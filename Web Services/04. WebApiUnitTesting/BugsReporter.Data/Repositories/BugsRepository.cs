using System.Data.Entity;
using System.Linq;

using BugsReporter.Models;

namespace BugsReporter.Data.Repositories
{
    public class BugsRepository : IBugsRepository
    {
        private IBugsDbContext dbContext;

        public BugsRepository()
            : this(new BugsDbContext())
        {
        }

        public BugsRepository(IBugsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Bug> GetAll()
        {
            return this.dbContext.Bugs;
        }

        public Bug Find(object id)
        {
            var idAsInteger = (id as int?);
            var resultBug = this.dbContext.Bugs.Find(idAsInteger);
            return resultBug;
        }

        public void Add(Bug entity)
        {
            this.SetState(entity, EntityState.Added);
        }

        public Bug Update(Bug entity)
        {
            this.SetState(entity, EntityState.Modified);
            return entity;
        }

        public Bug Delete(Bug entity)
        {
            this.SetState(entity, EntityState.Deleted);
            return entity;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private void SetState(Bug entity, EntityState state)
        {
            this.dbContext.Bugs.Attach(entity);
            this.dbContext.Entry(entity).State = state;
        }
    }
}
