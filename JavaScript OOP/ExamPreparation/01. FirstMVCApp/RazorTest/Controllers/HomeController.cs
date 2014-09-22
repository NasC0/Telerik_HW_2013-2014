using RazorTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorTest.Controllers
{
    public class HomeController : Controller
    {
        private Product myProduct = new Product
        {
            ProductId = 1,
            Name = "My Product",
            Description = "Some random shit",
            Category = "Random shit",
            Price = 999.99m
        };

        // GET: Home
        public ActionResult Index()
        {
            return View(this.myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(this.myProduct);
        }
    }
}