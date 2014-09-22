using System;
using System.Collections.Generic;
using Exam.Data.Repositories;

namespace Exam.Data
{
    public class ExamData : IExamData
    {
        private IDbContext context;
        private IDictionary<Type, object> repositories;

        public ExamData()
            : this(new ExamDbContext())
        {
        }

        public ExamData(IDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
