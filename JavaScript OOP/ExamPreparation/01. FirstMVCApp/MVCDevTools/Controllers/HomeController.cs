using MVCDevTools.Infrastructure;
using MVCDevTools.Models;
using MVCDevTools.Models.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDevTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calculator;

        private Product[] products = new Product[]
        {
            new Product() { Name = "Kayak", Category = "Watersports", Price = 275m },
            new Product() { Name = "Lifejacked", Category = "Watersports", Price = 48.95m },
            new Product() { Name = "Football", Category = "Football", Price = 19.50m },
            new Product() { Name = "Corner Flag", Category = "Football", Price = 34.95m }
        };

        public HomeController(IValueCalculator calculator)
        {
            this.calculator = calculator;
        }

        // GET: Home
        public ActionResult Index()
        {
            ShoppingCart productCart = new ShoppingCart(this.calculator) { Products = this.products };
            var totalProductValue = productCart.CalculateProductTotal();
            return View(totalProductValue);
        }
    }
}