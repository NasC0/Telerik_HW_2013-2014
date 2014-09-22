using System;
using System.Linq;

namespace UsersAndGroups
{
    public class UsersAndGroups
    {
        public static void AddUserToAdmins(UsersDBEntities dbContext, string username, string password)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var adminGroup = dbContext.Groups.FirstOrDefault(g => g.Name == "Admins");
                    if (adminGroup == null)
                    {
                        dbContext.Groups.Add(new Group()
                        {
                            Name = "Admins"
                        });
                    }

                    User newUser = new User()
                    {
                        Username = username,
                        Password = password,
                        Group = adminGroup
                    };

                    dbContext.Users.Add(newUser);
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
            }
        }

        public static void Main()
        {
            using (var dbContext = new UsersDBEntities())
            {
                AddUserToAdmins(dbContext, "kickass", "dwawdasda");
            }
        }
    }
}
