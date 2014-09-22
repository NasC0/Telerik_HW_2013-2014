using System.Collections.Generic;
using System.Linq;
using Moq;
using BugsReporter.Data;
using BugsReporter.Data.Repositories;
using BugsReporter.Models;
using System;

namespace BugsReporter.Services.Tests.BugsControllerTests
{
    public static class SetupBugsControllerMocks
    {
        public static List<Bug> Bugs
        {
            get
            {
                return new List<Bug>()
                {
                    new Bug()
                    {
                        BugID = 1,
                        Text = "First mock bug",
                        LogDate = DateTime.Parse("21.09.2014"),
                        Status = Status.Assigned
                    },
                    new Bug()
                    {
                        BugID = 2,
                        Text = "Second mock bug",
                        LogDate = DateTime.Parse("20.09.2014")
                    },
                    new Bug()
                    {
                        BugID = 3,
                        Text = "Third mock bug",
                        LogDate = DateTime.Parse("20.09.2014")
                    }
                };
            }
        }

        public static IBugsData GetMockedIBugsData()
        {
            var mockedRepo = new Mock<IBugsRepository>();
            mockedRepo.Setup(repo => repo.Add(It.IsAny<Bug>()))
                      .Callback((Bug bug) => 
                          bug.BugID = 4);

            mockedRepo.Setup(repo => repo.GetAll())
                      .Returns(Bugs.AsQueryable());

            mockedRepo.Setup(repo => repo.Find(It.IsAny<int>()))
                      .Returns(Bugs[0]);

            mockedRepo.Setup(repo => repo.Delete(It.IsAny<Bug>()))
                      .Returns(Bugs[0]);

            mockedRepo.Setup(repo => repo.Update(It.IsAny<Bug>()))
                      .Returns(Bugs[0]);

            mockedRepo.Setup(repo => repo.SaveChanges());

            var mockedRepoObject = mockedRepo.Object;

            var mockedData = new Mock<IBugsData>();
            mockedData.SetupGet(data => data.Bugs).Returns(mockedRepoObject);

            return mockedData.Object;
        }
    }
}