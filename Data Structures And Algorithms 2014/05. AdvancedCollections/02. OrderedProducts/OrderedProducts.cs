using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
namespace OrderedProducts
{
    public class OrderedProducts
    {
        private const int MinNameLength = 5;
        private const int MaxNameLength = 20;
        private const int MinCharCode = 97;
        private const int MaxCharCode = 123;
        private const int MinPrice = 5;
        private const int MaxPrice = 200000;

        private static Random randomGenerator = new Random();

        private static string GenerateRandomName()
        {
            StringBuilder randomName = new StringBuilder();
            int nameLength = randomGenerator.Next(MinNameLength, MaxNameLength);

            for (int i = 0; i < nameLength; i++)
            {
                int charCode = randomGenerator.Next(MinCharCode, MaxCharCode);
                char currentChar = (char)charCode;

                if (charCode % 2 == 0)
                {
                    currentChar = Char.ToUpper(currentChar);
                }

                randomName.Append(currentChar);
            }

            return randomName.ToString();
        }

        private static int GenerateRandomPrice()
        {
            return randomGenerator.Next(MinPrice, MaxPrice);
        }

        public static void Main()
        {
            var productBag = new OrderedBag<Product>();

            Stopwatch timer = new Stopwatch();

            Console.Write("500,000 products additions take: ");
            timer.Start();

            for (int i = 0; i < 500000; i++)
            {
                Product randomProduct = new Product(GenerateRandomName(), GenerateRandomPrice());
                productBag.Add(randomProduct);
            }

            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            timer.Reset();

            Console.Write("10,000 product searches take: ");
            timer.Start();

            for (int i = 0; i < 10000; i++)
            {
                int minPriceRange = GenerateRandomPrice();
                int maxPriceRange = minPriceRange + GenerateRandomPrice();
                var resultCollection = productBag.Range(new Product("", minPriceRange), true, new Product("", maxPriceRange), true).Take(20);
            }

            timer.Stop();
            Console.WriteLine(timer.Elapsed);
        }
    }
}
