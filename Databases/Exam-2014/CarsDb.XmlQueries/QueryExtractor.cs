using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using CarsDb.Data;
using CarsDb.Model;

namespace CarsDb.XmlQueries
{
    public class QueryExtractor : IQueryExtractor
    {
        private ICarsData dbContext;

        public QueryExtractor(ICarsData dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Car> ExtractQuery(XElement query)
        {
            var orderBy = query.Element("OrderBy").Value;
            var whereClaueses = query.Element("WhereClauses").Elements();
            var whereClausesList = new List<WhereClauseProperties>();
            foreach (var whereClause in whereClaueses)
            {
                var currentClause = new WhereClauseProperties()
                {
                    PropertyName = whereClause.Attribute("PropertyName").Value,
                    Type = this.TypeExtractor(whereClause),
                    Value = whereClause.Value
                };

                whereClausesList.Add(currentClause);
            }

            var filteredCollection = this.FilterCollections(whereClausesList);
            var orderedCollection = this.OrderByValue(filteredCollection, orderBy);

            return orderedCollection;
        }

        private QueryType TypeExtractor(XElement query)
        {
            var queryType = query.Attribute("Type").Value;
            if (queryType == "Equals")
            {
                return QueryType.Equals;
            }
            else if (queryType == "GreaterThan")
            {
                return QueryType.GreaterThan;
            }
            else if (queryType == "LessThan")
            {
                return QueryType.LessThan;
            }
            else if (queryType == "Contains")
            {
                return QueryType.Contains;
            }
            else
            {
                throw new ArgumentException("Unknown query type.");
            }
        }

        private IQueryable<Car> FilterCollections(List<WhereClauseProperties> whereClauses)
        {
            var carsCollection = this.dbContext.Cars.GetAll();
            foreach (var clause in whereClauses)
            {
                carsCollection = this.FilterByPropertyName(clause, carsCollection);
                var carsCllectionToList = carsCollection.ToList();
            }

            return carsCollection;
        }

        private IQueryable<Car> FilterByPropertyName(WhereClauseProperties whereClause, IQueryable<Car> cars)
        {
            if (whereClause.PropertyName == "Id")
            {
                int id = int.Parse(whereClause.Value);
                if (whereClause.Type == QueryType.Equals)
                {
                    return cars.Where(car => car.CarID == id);
                }
                else if (whereClause.Type == QueryType.GreaterThan)
                {
                    return cars.Where(car => car.CarID > id);
                }
                else
                {
                    return cars.Where(car => car.CarID < id);
                }
            }
            else if (whereClause.PropertyName == "Year")
            {
                int year = int.Parse(whereClause.Value);
                if (whereClause.Type == QueryType.Equals)
                {
                    return cars.Where(car => car.YearOfCreation == year);
                }
                else if (whereClause.Type == QueryType.GreaterThan)
                {
                    return cars.Where(car => car.YearOfCreation > year);
                }
                else
                {
                    return cars.Where(car => car.YearOfCreation < year);
                }
            }
            else if (whereClause.PropertyName == "Price")
            {
                decimal price = decimal.Parse(whereClause.Value);
                if (whereClause.Type == QueryType.Equals)
                {
                    return cars.Where(car => car.Price == price);
                }
                else if (whereClause.Type == QueryType.GreaterThan)
                {
                    return cars.Where(car => car.Price > price);
                }
                else
                {
                    return cars.Where(car => car.Price < price);
                }
            }
            else if (whereClause.PropertyName == "Model")
            {
                string modelName = whereClause.Value;
                if (whereClause.Type == QueryType.Equals)
                {
                    return cars.Where(car => car.Model == modelName);
                }
                else
                {
                    return cars.Where(car => car.Model.Contains(modelName));
                }
            }
            else if (whereClause.PropertyName == "Manufacturer")
            {
                string manufacturer = whereClause.Value;
                if (whereClause.Type == QueryType.Equals)
                {
                    return cars.Where(car => car.Manufacturer.Name == manufacturer);
                }
                else
                {
                    return cars.Where(car => car.Manufacturer.Name.Contains(manufacturer));
                }
            }
            else if (whereClause.PropertyName == "Dealer")
            {
                string dealer = whereClause.Value;
                if (whereClause.Type == QueryType.Equals)
                {
                    return cars.Where(car => car.Dealer.Name == dealer);
                }
                else
                {
                    return cars.Where(car => car.Dealer.Name.Contains(dealer));
                }
            }
            else if (whereClause.PropertyName == "City")
            {
                string city = whereClause.Value;
                if (whereClause.Type == QueryType.Equals)
                {
                    return cars.Where(car => car.Dealer.Cities.Any(carCity => carCity.Name.Contains(city)));
                }
                else
                {
                    return cars.Where(car => car.Dealer.Cities.Any(carCity => carCity.Name == city));
                }
            }
            else
            {
                throw new ArgumentException("Invalid query supplied.");
            }
        }

        private IQueryable<Car> OrderByValue(IQueryable<Car> carCollection, string orderByProperty)
        {
            if (orderByProperty == "Id")
            {
                return carCollection.OrderBy(car => car.CarID);
            }
            else if (orderByProperty == "Year")
            {
                return carCollection.OrderBy(car => car.YearOfCreation);
            }
            else if (orderByProperty == "Model")
            {
                return carCollection.OrderBy(car => car.Model);
            }
            else if (orderByProperty == "Price")
            {
                return carCollection.OrderBy(car => car.Price);
            }
            else if (orderByProperty == "Manufactuer")
            {
                return carCollection.OrderBy(car => car.Manufacturer.Name);
            }
            else if (orderByProperty == "Dealer")
            {
                return carCollection.OrderBy(car => car.Dealer.Name);
            }
            else
            {
                throw new ArgumentException("Invalid order query.");
            }
        }
    }
}
