﻿
using System;
namespace CompanyArticles
{
    public class Article : IComparable<Article>
    {
        public Article(string barcode, string vendor, string title, decimal price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("Barcode: {0}, Vendor: {1}, Title: {2}, Price: {3}",
                this.Barcode, this.Vendor, this.Title, this.Price);
        }
    }
}
