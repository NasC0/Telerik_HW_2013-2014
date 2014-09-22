using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using BugsReporter.Models;

namespace BugsReporter.Data
{
    public interface IBugsDbContext
    {
        IDbSet<Bug> Bugs { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
