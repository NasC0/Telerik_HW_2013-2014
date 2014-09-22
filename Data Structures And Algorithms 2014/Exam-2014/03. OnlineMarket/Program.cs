using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

namespace OnlineMarket
{
    public class Product : IComparable<Product>
    {
        private string name;
        private decimal price;
        private string type;

        public Product(string name, decimal price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Name must be between 3 and 20 symbols");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value >= 5000m)
                {
                    throw new ArgumentException();
                }

                this.price = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Type must be between 3 and 20 symbols");
                }

                this.type = value;
            }
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price.ToString("G29"));
        }
    }

    public class OnlineMarket
    {
        private static HashSet<string> namesAdded = new HashSet<string>();
        private static OrderedBag<Product> productsByPrice = new OrderedBag<Product>();
        private static MultiDictionary<string, Product> productsByType = new MultiDictionary<string, Product>(true);

        private static void AddProduct(string[] productInfo)
        {
            string productName = productInfo[1];
            decimal price = decimal.Parse(productInfo[2]);
            string productType = productInfo[3];

            if (namesAdded.Contains(productName))
            {
                Console.WriteLine("Error: Product {0} already exists", productName);
                return;
            }
            else
            {
                var product = new Product(productName, price, productType);
                namesAdded.Add(productName);
                productsByPrice.Add(product);
                productsByType.Add(productType, product);
                Console.WriteLine("Ok: Product {0} added successfully", productName);
            }
        }

        private static void FilterProduct(string[] filterComand)
        {
            if (filterComand[2].ToLower() == "type")
            {
                FilterByType(filterComand[3]);
            }
            else if (filterComand[2].ToLower() == "price")
            {
                if (filterComand.Length > 5)
                {
                    var minPrice = decimal.Parse(filterComand[4]);
                    var maxPrice = decimal.Parse(filterComand[6]);
                    FilterByFullPrice(minPrice, maxPrice);
                }
                else
                {
                    if (filterComand[3].ToLower() == "from")
                    {
                        var minPrice = decimal.Parse(filterComand[4]);
                        FilterByMinPrice(minPrice);
                    }
                    else
                    {
                        var maxPrice = decimal.Parse(filterComand[4]);
                        FilterByMaxPrice(maxPrice);
                    }
                }
            }
        }

        private static void FilterByType(string type)
        {
            if (!productsByType.ContainsKey(type))
            {
                Console.WriteLine("Error: Type {0} does not exists", type);
                return;
            }

            var filteredItems = productsByType[type]
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ThenBy(p => p.Type)
                .Take(10);

            if (filteredItems.Count() == 0)
            {
                Console.WriteLine("Ok:");
            }
            else
            {
                Console.WriteLine("Ok: {0}", string.Join(", ", filteredItems));
            }
        }

        private static void FilterByFullPrice(decimal minValue, decimal maxValue)
        {
            var minProduct = new Product("random", minValue, "dawdasd");
            var maxProduct = new Product("random", maxValue, "awdasd");
            var filteredProducts = productsByPrice.Range(minProduct, true, maxProduct, true)
                                                  .OrderBy(p => p.Price)
                                                  .ThenBy(p => p.Name)
                                                  .ThenBy(p => p.Type)
                                                  .Take(10);

            if (filteredProducts.Count() > 0)
            {
                Console.WriteLine("Ok: {0}", string.Join(", ", filteredProducts));
            }
            else
            {
                Console.WriteLine("Ok:");
            }
        }

        private static void FilterByMinPrice(decimal minValue)
        {
            var minProduct = new Product("random", minValue, "dawda");
            var filteredProducts = productsByPrice.RangeFrom(minProduct, true)
                                                  .OrderBy(p => p.Price)
                                                  .ThenBy(p => p.Name)
                                                  .ThenBy(p => p.Type)
                                                  .Take(10);

            if (filteredProducts.Count() > 0)
            {
                Console.WriteLine("Ok: {0}", string.Join(", ", filteredProducts));
            }
            else
            {
                Console.WriteLine("Ok:");
            }
        }

        private static void FilterByMaxPrice(decimal maxValue)
        {
            var maxProduct = new Product("random", maxValue, "dawda");
            var filteredProducts = productsByPrice.RangeTo(maxProduct, true)
                                                  .OrderBy(p => p.Price)
                                                  .ThenBy(p => p.Name)
                                                  .ThenBy(p => p.Type)
                                                  .Take(10);

            if (filteredProducts.Count() > 0)
            {
                Console.WriteLine("Ok: {0}", string.Join(", ", filteredProducts));
            }
            else
            {
                Console.WriteLine("Ok: ");
            }
        }

        public static void Main()
        {
            string currentCommand = Console.ReadLine();

            while (currentCommand != "end")
            {
                var splitCommand = currentCommand.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitCommand[0].ToLower() == "add")
                {
                    AddProduct(splitCommand);
                }
                else if (splitCommand[0].ToLower() == "filter")
                {
                    FilterProduct(splitCommand);
                }

                currentCommand = Console.ReadLine();
            }
        }
    }
}