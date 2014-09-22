using System;
using System.Linq;
using System.Web.Http.Results;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using BugsReporter.Models;
using BugsReporter.Services.Controllers;
using BugsReporter.Data;
using Moq;
using BugsReporter.Data.Repositories;

namespace BugsReporter.Services.Tests.BugsControllerTests
{
    [TestClass]
    public class GetTests
    {
        private static IBugsData mockedData = SetupBugsControllerMocks.GetMockedIBugsData();

        [TestMethod]
        public void GetAll_ShouldReturnBugsCollection()
        {
            var bugsCollection = SetupBugsControllerMocks.Bugs;
            var controller = new BugsController(mockedData);

            var bugs = controller.Get() as OkNegotiatedContentResult<IQueryable<Bug>>;

            CollectionAssert.AreEqual(bugsCollection, bugs.Content.ToList());
        }

        [TestMethod]
        public void GetByID_WithFirstId_ShouldReturnFirstBugInCollection()
        {
            var expectedBug = SetupBugsControllerMocks.Bugs[0];
            var controller = new BugsController(mockedData);

            var actualBug = controller.Get(1) as OkNegotiatedContentResult<Bug>;

            Assert.AreEqual(expectedBug, actualBug.Content);
        }

        [TestMethod]
        public void GetByID_WithInvalidID_ShouldReturnBadRequest()
        {
            var mockedRepo = new Mock<IBugsRepository>();
            mockedRepo.Setup(repo => repo.Find(It.IsAny<int>()))
                      .Returns<Bug>(null);

            var mockedData = new Mock<IBugsData>();
            mockedData.SetupGet(data => data.Bugs).Returns(mockedRepo.Object);
            var mockedDataObject = mockedData.Object;
            var bugsController = new BugsController(mockedDataObject);

            var foundBugs = bugsController.Get(10) as BadRequestErrorMessageResult;

            Assert.IsNotNull(foundBugs);
            Assert.IsTrue(foundBugs.Message == "Invalid id.");
        }

        [TestMethod]
        public void GetByDate_WithDateTimeNow_ShoultReturnNone()
        {
            var currentDateTime = DateTime.Now;
            var controller = new BugsController(mockedData);

            var bugs = controller.Get(currentDateTime) as OkNegotiatedContentResult<IQueryable<Bug>>;

            Assert.IsTrue(bugs.Content.Count() == 0);
        }

        [TestMethod]
        public void GetByDate_WithDateForSingleEntity_ShouldReturnFirstEntity()
        {
            var dateTime = DateTime.Parse("21.09.2014");
            var allBugs = SetupBugsControllerMocks.Bugs;
            var controller = new BugsController(mockedData);

            var bugs = controller.Get(dateTime) as OkNegotiatedContentResult<IQueryable<Bug>>;

            Assert.IsTrue(bugs.Content.Count() == 1);
            Assert.AreEqual(allBugs[0], bugs.Content.FirstOrDefault());
        }

        [TestMethod]
        public void GetByStatus_WithPendingStatus_ShouldReturnTheLastTwoEntries()
        {
            var allBugs = SetupBugsControllerMocks.Bugs.Where(bug => bug.Status == Status.Pending).ToList();
            var controller = new BugsController(mockedData);

            var bugs = controller.Get("pending") as OkNegotiatedContentResult<IQueryable<Bug>>;

            CollectionAssert.AreEqual(allBugs, bugs.Content.ToList());
        }

        [TestMethod]
        public void GetByStatus_WithAssignedStatus_ShouldReturnTheFirstEntry()
        {
            var assignedBug = SetupBugsControllerMocks.Bugs.FirstOrDefault(bug => bug.Status == Status.Assigned);
            var controller = new BugsController(mockedData);

            var bugs = controller.Get("assigned") as OkNegotiatedContentResult<IQueryable<Bug>>;

            Assert.IsTrue(bugs.Content.Count() == 1);
            Assert.IsTrue(bugs.Content.FirstOrDefault().Status == Status.Assigned);
            Assert.AreEqual(assignedBug, bugs.Content.FirstOrDefault());
        }

        [TestMethod]
        public void GetByStatus_WithInvalidStatus_ShouldReturnBadRequest()
        {
            var invalidStatus = "asdasda";
            var controller = new BugsController(mockedData);

            var badRequest = controller.Get(invalidStatus) as BadRequestErrorMessageResult;

            Assert.IsNotNull(badRequest);
            Assert.IsTrue(badRequest.Message == "Invalid status.");
        }
    }
}
