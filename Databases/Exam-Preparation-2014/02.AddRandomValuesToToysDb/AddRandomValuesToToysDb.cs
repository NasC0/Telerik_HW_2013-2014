using System;
using System.Collections.Generic;
using System.Text;

namespace AddRandomValuesToToysDb
{
    public class AddRandomValuesToToysDb
    {
        private const int ManufacturersCount = 100;
        private const int CategoriesCount = 10001;
        private const int AgeRangesCount = 101;
        private const int ToysCount = 1000000;
        private const int MinCharCode = 97;
        private const int MaxCharCode = 123;
        private const int NamesLength = 10;
        private const int MinAge = 3;
        private const int MaxAge = 90;

        private static readonly Random randomGenerator = new Random();
        private static readonly List<string> toyTypeList = new List<string>
        {
            "puzzle", "plush", "action-figure", "doll", "car", "nerf-gun"
        };

        private static readonly List<string> toyColors = new List<string>
        {
            "green", "blue", "orange", "teal", "white", "black", "gray", "red", "yellow"
        };

        public static void SeedRandomData(ToysDbEntities dbContext)
        {
            SeedRandomManufacturers(dbContext);
            SeedRandomCategories(dbContext);
            SeedRandomAgeRanges(dbContext);
            SeedRandomToys(dbContext);
        }

        private static void SeedRandomManufacturers(ToysDbEntities dbContext)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("INSERT INTO Manufacturers (Name, Country) VALUES ");

            for (int i = 0; i < ManufacturersCount; i++)
            {
                string manufacturerName = GetRandomString(NamesLength);
                string country = GetRandomString(NamesLength);
                query.AppendFormat("('{0}', '{1}'), ", manufacturerName, country);
            }
            query.Remove(query.Length - 2, 2);

            dbContext.Database.ExecuteSqlCommand(query.ToString());
        }

        private static void SeedRandomCategories(ToysDbEntities dbContext)
        {
            dbContext.Categories.Add(new Category()
            {
                Name = "Boys"
            });
            dbContext.SaveChanges();

            StringBuilder query = new StringBuilder();
            string startingQuery = "INSERT INTO Categories (Name) VALUES ";
            query.AppendLine(startingQuery);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    string categoryName = GetRandomString(NamesLength);
                    query.AppendFormat("('{0}'), ", categoryName);
                }

                query.Remove(query.Length - 2, 2);
                dbContext.Database.ExecuteSqlCommand(query.ToString());
                query.Clear();
                query.AppendLine(startingQuery);
            }
        }

        private static void SeedRandomAgeRanges(ToysDbEntities dbContext)
        {
            dbContext.AgeRanges.Add(new AgeRanx()
            {
                FromAge = 5,
                ToAge = 10
            });

            dbContext.SaveChanges();
            StringBuilder query = new StringBuilder();
            query.AppendLine("INSERT INTO AgeRanges (FromAge, ToAge) VALUES ");

            for (int i = 0; i < AgeRangesCount; i++)
            {
                int minAge = randomGenerator.Next(MinAge, MaxAge);
                int maxAge = randomGenerator.Next(MinAge, MaxAge);
                maxAge += minAge;
                query.AppendFormat("({0}, {1}), ", minAge, maxAge);
            }

            query.Remove(query.Length - 2, 2);
            dbContext.Database.ExecuteSqlCommand(query.ToString());
        }

        private static void SeedRandomToys(ToysDbEntities dbContext)
        {
            StringBuilder query = new StringBuilder();
            string startingQuery = "INSERT INTO Toys (Name, Type, CategoryID, ManufacturerID, Price, Color, AgeRangeID) VALUES ";
            query.AppendLine(startingQuery);
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    string name = GetRandomString(NamesLength);
                    int toyTypeId = randomGenerator.Next(0, toyTypeList.Count);
                    string type = toyTypeList[toyTypeId];
                    int categoryId = randomGenerator.Next(1, CategoriesCount);
                    int manufacturerID = randomGenerator.Next(1, ManufacturersCount);
                    decimal price = randomGenerator.Next(2, 1001);
                    int colorId = randomGenerator.Next(0, toyColors.Count);
                    string color = toyColors[colorId];
                    int ageRangeId = randomGenerator.Next(1, AgeRangesCount);

                    query.AppendFormat("('{0}', '{1}', {2}, {3}, {4}, '{5}', {6}), ",
                        name, type, categoryId, manufacturerID, price, color, ageRangeId);
                }

                query.Remove(query.Length - 2, 2);
                dbContext.Database.ExecuteSqlCommand(query.ToString());
                query.Clear();
                query.AppendLine(startingQuery);
            }
        }

        private static string GetRandomString(int length)
        {
            StringBuilder randomString = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int charCode = randomGenerator.Next(MinCharCode, MaxCharCode);
                char convertedChar = (char)charCode;

                if (charCode % 2 == 0)
                {
                    convertedChar = Char.ToUpper(convertedChar);
                }

                randomString.Append(convertedChar);
            }

            return randomString.ToString();
        }

        public static void Main()
        {
            var dbContext = new ToysDbEntities();
            SeedRandomData(dbContext);
        }
    }
}
