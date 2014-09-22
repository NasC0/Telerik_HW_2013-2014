using System;
using System.Xml;

namespace OlderAlbumsXPath
{
    public class OlderAlbumsXPath
    {
        private const string ReadFileLocation = "../../../catalogue.xml";
        private const int YearRange = 5;

        public static void Main()
        {
            var musicDocument = new XmlDocument();
            musicDocument.Load(ReadFileLocation);
            var currentYear = DateTime.Now.Year - YearRange;
            string query = string.Format("/catalogue/album[year > {0}]/price", currentYear);

            var listAlbums = musicDocument.SelectNodes(query);

            foreach (XmlElement pair in listAlbums)
            {
                Console.WriteLine(pair.InnerText);
            }
        }
    }
}
