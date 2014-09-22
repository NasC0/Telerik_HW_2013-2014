using System;
using System.Diagnostics;

namespace CompanyArticles
{
    public class CompanyArticles
    {
        private const string Barcode = "1231231asda";
        private const string Vendor = "Nestle";
        private const string Title = "Nesquik";
        private const int MinPrice = 5;
        private const int MaxPrice = 3000000;

        private static Random randomGenerator = new Random();

        public static int GetRandomPrice()
        {
            return randomGenerator.Next(MinPrice, MaxPrice);
        }

        public static void Main()
        {
            ArticleData articleCollection = new ArticleData();
            Stopwatch timer = new Stopwatch();

            timer.Start();
            for (var i = 0; i < 1500000; i++)
            {
                Article currentArticle = new Article(Barcode, Vendor, Title, GetRandomPrice());
                articleCollection.Add(currentArticle);
            }

            timer.Stop();
            Console.WriteLine("Adding 1,500,000 records took: {0}", timer.Elapsed);
            timer.Reset();

            int minPriceRange = GetRandomPrice();
            int maxPriceRange = minPriceRange + GetRandomPrice();

            timer.Start();
            var result = articleCollection.ArticlesInPriceRange(minPriceRange, maxPriceRange);
            timer.Stop();

            Console.WriteLine("Searching for products in the price range [{0}...{1}] took {2}", minPriceRange, maxPriceRange, timer.Elapsed);
            Console.WriteLine("The search returned {0} items", result.Count);
        }
    }
}
