using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarsDb.Data;
using CarsDb.Model;
using Newtonsoft.Json.Linq;

namespace CarsDb.ImportFromJson
{
    public class JsonParser : IJsonParser
    {
        private CarsData dbContext;
        private string jsonPath;

        public JsonParser(CarsData dbContext, string jsonPath)
        {
            this.dbContext = dbContext;
            this.jsonPath = jsonPath;
        }

        public void ParseJson()
        {
            string jsonString = string.Empty;
            using (StreamReader reader = new StreamReader(this.jsonPath))
            {
                jsonString = reader.ReadToEnd();
            }

            int index = 1;
            var cars = JArray.Parse(jsonString);
            foreach (var car in cars)
            {
                int carYear = int.Parse(car["Year"].ToString());
                int transmissionType = int.Parse(car["TransmissionType"].ToString());
                string manufacturerName = car["ManufacturerName"].ToString();
                string carModel = car["Model"].ToString();
                decimal carPrice = decimal.Parse(car["Price"].ToString());
                string dealerName = car["Dealer"]["Name"].ToString();
                string cityName = car["Dealer"]["City"].ToString();

                var manufacturer = this.dbContext.Manufacturers.Find(x => x.Name == manufacturerName).FirstOrDefault();
                if (manufacturer == null)
                {
                    manufacturer = new Manufacturer()
                    {
                        Name = manufacturerName
                    };

                    dbContext.Manufacturers.Add(manufacturer);
                }

                var dealer = this.dbContext.Dealers.Find(x => x.Name == dealerName).FirstOrDefault();
                if (dealer == null)
                {
                    dealer = new Dealer()
                    {
                        Name = dealerName
                    };

                    dbContext.Dealers.Add(dealer);
                }

                var city = this.dbContext.Cities.Find(x => x.Name == cityName).FirstOrDefault();
                if (city == null)
                {
                    city = new City()
                    {
                        Name = cityName
                    };

                    dbContext.Cities.Add(city);
                }

                if (!city.Dealers.Any(x => x.Name == dealerName))
                {
                    city.Dealers.Add(dealer);
                }


                var currentCar = new Car()
                {
                    Model = carModel,
                    Price = carPrice,
                    YearOfCreation = carYear,
                    TransmissionType = (TransmissionType)transmissionType,
                    Dealer = dealer,
                    Manufacturer = manufacturer
                };

                this.dbContext.Cars.Add(currentCar);

                Console.Write('.');
                index++;
                this.dbContext.SaveChanges();
                if (index % 100 == 0)
                {
                    this.dbContext = new CarsData();
                }
            }
            Console.WriteLine();
        }
    }
}
