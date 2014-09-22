using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDevTools.Models.Interfaces
{
    public interface IValueCalculator
    {
        decimal ProductsValue(IEnumerable<Product> products);
    }
}