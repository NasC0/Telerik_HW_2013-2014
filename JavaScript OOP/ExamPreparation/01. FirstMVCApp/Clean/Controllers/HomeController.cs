using Clean.Models;
using System;
using System.Web.Mvc;

namespace Clean.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //TODO: Sell it better
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            // TODO: Email reply to party organizer
            return View();
        }
    }
}