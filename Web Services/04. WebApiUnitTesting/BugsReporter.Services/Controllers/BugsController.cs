using System;
using System.Linq;
using System.Web.Http;

using BugsReporter.Data;
using BugsReporter.Models;
using BugsReporter.Services.Models;

namespace BugsReporter.Services.Controllers
{
    public class BugsController : ApiController
    {
        private IBugsData dataContext;

        public BugsController()
            : this(new BugsData())
        {
        }

        public BugsController(IBugsData dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var allBugs = this.dataContext.Bugs.GetAll();
            return Ok(allBugs);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var bug = this.dataContext.Bugs.Find(id);
            if (bug == null)
            {
                return BadRequest("Invalid id.");
            }

            return Ok(bug);
        }

        [HttpGet]
        public IHttpActionResult Get(DateTime date)
        {
            var bugs = this.dataContext.Bugs.GetAll().Where(bug => bug.LogDate >= date);
            return Ok(bugs);
        }

        [HttpGet]
        public IHttpActionResult Get(string status)
        {
            Status parsedStatus;
            try
            {
                parsedStatus = this.GetStatusFromString(status);   
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);    
            }

            var bugs = this.dataContext.Bugs.GetAll().Where(bug => bug.Status == parsedStatus);
            return Ok(bugs);
        }

        [HttpPost]
        public IHttpActionResult Post(BugInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var bugToAdd = new Bug()
            {
                Text = model.Text
            };

            this.dataContext.Bugs.Add(bugToAdd);
            this.dataContext.SaveChanges();

            var url = Url.Link("DefaultApi", new { id = bugToAdd.BugID });

            return Created(url, bugToAdd);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, BugStatusChangeModel status)
        {
            if (status == null)
            {
                return BadRequest("You must enter a valid model.");
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var parsedStatus = this.GetStatusFromString(status.Status);
            var bugToEdit = this.dataContext.Bugs.Find(id);
            if (bugToEdit == null)
            {
                return BadRequest("Invalid id.");
            }

            bugToEdit.Status = parsedStatus;
            this.dataContext.Bugs.Update(bugToEdit);
            this.dataContext.SaveChanges();

            return Ok();
        }

        private Status GetStatusFromString(string status)
        {
            Status parsedStatus = Status.Pending;
            switch (status.ToLower())
            {
                case "pending":
                    parsedStatus = Status.Pending;
                    break;
                case "assigned":
                    parsedStatus = Status.Assigned;
                    break;
                case "for-testing":
                    parsedStatus = Status.ForTesting;
                    break;
                case "fixed":
                    parsedStatus = Status.Fixed;
                    break;
                default:
                    throw new ArgumentException("Invalid status.");
            }

            return parsedStatus;
        }
    }
}
