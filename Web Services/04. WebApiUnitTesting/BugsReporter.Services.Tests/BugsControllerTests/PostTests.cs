using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using BugsReporter.Data;
using BugsReporter.Data.Repositories;
using BugsReporter.Models;
using BugsReporter.Services.Controllers;
using BugsReporter.Services.Models;
using System.ComponentModel.DataAnnotations;

namespace BugsReporter.Services.Tests.BugsControllerTests
{
    [TestClass]
    public class PostTests
    {
        private static IBugsData mockedData = SetupBugsControllerMocks.GetMockedIBugsData();

        [TestMethod]
        public void PostBug_WithValidModel_ShouldReturnCreated()
        {
            var bugToAdd = new BugInputModel()
            {
                Text = "Test add bug"
            };

            var bugsController = new BugsController(mockedData);
            SetupControllerForTests(bugsController);

            var postResult = bugsController.Post(bugToAdd) as CreatedNegotiatedContentResult<Bug>;

            Assert.IsNotNull(postResult);
            Assert.IsTrue(postResult.Content.BugID == 4);
            Assert.IsTrue(postResult.Content.Status == Status.Pending);
            Assert.IsTrue(postResult.Content.Text == "Test add bug");
        }

        private void SetupControllerForTests(ApiController controller)
        {
            string serverUrl = "http://localhost";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }
    }
}