using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using Exam.Data.Migrations;
using Exam.Models;

namespace Exam.Data
{
    public class ExamDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public ExamDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExamDbContext, Configuration>());
        }

        public static ExamDbContext Create()
        {
            return new ExamDbContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
