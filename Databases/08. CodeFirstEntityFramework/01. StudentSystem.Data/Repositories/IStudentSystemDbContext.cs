using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using StudentSystem.Model;
namespace StudentSystem.Data.Repositories
{
    public interface IStudentSystemDbContext
    {
        IDbSet<Student> Students { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<TEntity > Set<TEntity>() where TEntity : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
