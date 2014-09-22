using System;
using System.Linq;
using System.Xml.Linq;

namespace ExtractSongsLinqToXml
{
    public class ExtractSongsLinqToXml
    {
        private const string FileLocation = "../../../catalogue.xml";

        public static void Main()
        {
            XDocument musicCatalogue = XDocument.Load(FileLocation);
            var songsList = musicCatalogue.Descendants("title").Select(x => x.Value);

            foreach (var song in songsList)
            {
                Console.WriteLine(song);
            }
        }
    }
}
