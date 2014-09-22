using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CarsDb.Model;

namespace CarsDb.XmlQueries
{
    public interface IQueryExtractor
    {
        IQueryable<Car> ExtractQuery(XElement query);
    }
}
