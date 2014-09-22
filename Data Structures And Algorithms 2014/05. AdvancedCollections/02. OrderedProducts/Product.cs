using System;
namespace OrderedProducts
{
    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + ((Name != null) ? this.Name.GetHashCode() : 0);
                result = result * 23 + this.Price.GetHashCode();
                return result;
            }
        }

        public override bool Equals(object obj)
        {
            var objAsProduct = obj as Product;

            if (objAsProduct != null)
            {
                if (this.Price == objAsProduct.Price)
                {
                    return true;
                }
            }
            
            return false;
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
