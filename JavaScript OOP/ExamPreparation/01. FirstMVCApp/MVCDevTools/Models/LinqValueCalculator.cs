using MVCDevTools.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDevTools.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        public decimal ProductsValue(IEnumerable<Product> products)
        {
            decimal productsSum = products.Sum(x => x.Price);
            return productsSum;
        }
    }
}