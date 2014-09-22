<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using StudentSystem.Data.Repositories;
using StudentSystem.Model;

=======
﻿
using System;
using System.Collections.Generic;
using StudentSystem.Data.Repositories;
using StudentSystem.Model;
>>>>>>> origin/master
namespace StudentSystem.Data
{
    public class StudentSystemData : IStudentSystemData
    {
        private IStudentSystemDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public StudentSystemData(IStudentSystemDbContext context)
        {
            this.dbContext = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public StudentSystemData()
            : this(new StudentSystemDbContext())
        {
        }

        public IGenericRepository<Student> Students
        {
            get
            {
                return this.GetRepository<Student>();
            }
        }

        public IGenericRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IGenericRepository<Homework> Homeworks
        {
            get
            {
                return this.GetRepository<Homework>();
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var repoType = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(repoType, this.dbContext));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
