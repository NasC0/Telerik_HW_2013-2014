using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CarsDb.Model;

namespace CarsDb.XmlQueries
{
    public class XmlQueryWriter : IQueryWriter
    {
        private IEnumerable<Car> resultSet;
        private string outputFileLocation;

        public XmlQueryWriter(IEnumerable<Car> resultSet, string outputFileLocation)
        {
            this.resultSet = resultSet;
            this.outputFileLocation = outputFileLocation;
        }

        public void WriteQuery()
        {
            var writerSettins = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t"
            };

            using (var dataWriter = XmlWriter.Create(outputFileLocation, writerSettins))
            {
                dataWriter.WriteStartDocument();
                dataWriter.WriteStartElement("Cars");
                dataWriter.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                dataWriter.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
                var listCollection = this.resultSet.ToList();
                foreach (var result in listCollection)
                {
                    this.WriteCar(dataWriter, result);
                }

                dataWriter.WriteEndElement();
                dataWriter.WriteEndDocument();
            }
        }

        private void WriteCar(XmlWriter writer, Car car)
        {
            writer.WriteStartElement("Car");
            writer.WriteAttributeString("Manufacturer", car.Manufacturer.Name);
            writer.WriteAttributeString("Model", car.Model);
            writer.WriteAttributeString("Year", car.YearOfCreation.ToString());
            writer.WriteAttributeString("Price", car.Price.ToString());

            var transmissionType = car.TransmissionType == TransmissionType.Automatic ? "automatic" : "manual";
            writer.WriteElementString("TransmissionType", transmissionType);
            writer.WriteStartElement("Dealer");
            writer.WriteAttributeString("Name", car.Dealer.Name);

            writer.WriteStartElement("Citiies");

            foreach (var city in car.Dealer.Cities)
            {
                writer.WriteElementString("City", city.Name);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
