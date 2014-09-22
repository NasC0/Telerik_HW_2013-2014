using System;
using System.Collections.Generic;
using System.Xml;

namespace ExtractAuthors
{
    public class ExtractAuthors
    {
        private const string FileLocation = "../../../catalogue.xml";

        public static void Main()
        {
            XmlDocument musicCatalogue = new XmlDocument();
            musicCatalogue.Load(FileLocation);

            XmlNode rootNode = musicCatalogue.DocumentElement;

            var artistDictionary = new Dictionary<string, int>();
            foreach (XmlNode albumNode in rootNode.ChildNodes)
            {
                var artistName = albumNode["artist"].InnerText;
                if (!artistDictionary.ContainsKey(artistName))
                {
                    artistDictionary[artistName] = 0;
                }

                artistDictionary[artistName]++;
            }

            foreach (var artist in artistDictionary)
            {
                Console.WriteLine("{0} has {1} album(s) in the catalogue", artist.Key, artist.Value);
            }
        }
    }
}
