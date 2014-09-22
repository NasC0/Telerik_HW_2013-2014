using MVCDevTools.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDevTools.Models
{
    public class ShoppingCart
    {
        private IValueCalculator calc;

        public ShoppingCart(IValueCalculator calc)
        {
            this.Calc = calc;
        }

        public IValueCalculator Calc
        {
            get
            {
                return this.calc;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Calculator value cannot be null.");
                }

                this.calc = value;
            }
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return this.Calc.ProductsValue(this.Products);
        }
    }
}