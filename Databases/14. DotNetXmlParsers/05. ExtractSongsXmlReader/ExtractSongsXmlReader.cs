using System;
using System.Collections.Generic;
using System.Xml;

namespace ExtractSongsXmlReader
{
    public class ExtractSongsXmlReader
    {
        private const string FileLocation = "../../../catalogue.xml";

        public static void Main()
        {
            List<string> songList = new List<string>();

            using (XmlReader dataReader = XmlReader.Create(FileLocation))
            {
                bool saveNextValue = false;
                bool skipNextElementName = false;
                while (dataReader.Read())
                {
                    if (dataReader.NodeType == XmlNodeType.Element && dataReader.Name == "title")
                    {
                        string songTitle = dataReader.ReadElementString();
                        songList.Add(songTitle);
                    }
                }
            }

            foreach (var song in songList)
            {
                Console.WriteLine(song);
            }
        }
    }
}
