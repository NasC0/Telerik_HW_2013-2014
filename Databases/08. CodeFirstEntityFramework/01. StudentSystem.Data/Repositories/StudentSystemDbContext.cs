using System.Data.Entity;
using StudentSystem.Data.Migrations;
using StudentSystem.Model;

namespace StudentSystem.Data.Repositories
{
<<<<<<< HEAD
    public class StudentSystemDbContext : DbContext, IStudentSystemDbContext
    {
        internal StudentSystemDbContext()
=======
    internal class StudentSystemDbContext : DbContext, IStudentSystemDbContext
    {
        public StudentSystemDbContext()
>>>>>>> origin/master
            : base ("StudentSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
