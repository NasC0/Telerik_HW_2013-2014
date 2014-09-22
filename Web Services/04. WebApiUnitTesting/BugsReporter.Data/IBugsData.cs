using BugsReporter.Data.Repositories;

namespace BugsReporter.Data
{
    public interface IBugsData
    {
        IBugsRepository Bugs { get; }

        int SaveChanges();
    }
}
