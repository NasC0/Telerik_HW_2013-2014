using StudentSystem.Data.Repositories;
using StudentSystem.Model;

namespace StudentSystem.Data
{
    public interface IStudentSystemData
    {
        IGenericRepository<Student> Students { get; }
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<Homework> Homeworks { get; }

        int SaveChanges();
    }
}
