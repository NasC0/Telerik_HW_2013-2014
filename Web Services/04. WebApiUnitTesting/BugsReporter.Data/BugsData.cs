using BugsReporter.Data.Repositories;

namespace BugsReporter.Data
{
    public class BugsData : IBugsData
    {
        private IBugsDbContext dbContext;
        private IBugsRepository bugs;

        public BugsData()
            : this(new BugsDbContext())
        {
        }

        public BugsData(IBugsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IBugsRepository Bugs
        {
            get
            {
                if (this.bugs == null)
                {
                    this.bugs = new BugsRepository(this.dbContext);
                }

                return this.bugs;
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }
    }
}
