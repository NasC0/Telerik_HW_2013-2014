using System;
using System.Collections.Generic;
using System.Xml;

namespace ExtractAuthorsWithXpath
{
    public class ExtractAuthorsWithXpath
    {
        private const string FileLocation = "../../../catalogue.xml";

        public static void Main()
        {
            var catalogueDoc = new XmlDocument();
            catalogueDoc.Load(FileLocation);
            string xPathQuery = "/catalogue/album/artist";

            XmlNodeList artistsList = catalogueDoc.SelectNodes(xPathQuery);
            Dictionary<string, int> artistDictionary = new Dictionary<string, int>();

            foreach (XmlElement artist in artistsList)
            {
                string artistName = artist.InnerText;

                if (!artistDictionary.ContainsKey(artistName))
                {
                    artistDictionary[artistName] = 0;
                }

                artistDictionary[artistName]++;
            }

            foreach (var artistPair in artistDictionary)
            {
                Console.WriteLine("{0} has {1} album(s) in the catalagoue.", artistPair.Key, artistPair.Value);
            }
        }
    }
}
