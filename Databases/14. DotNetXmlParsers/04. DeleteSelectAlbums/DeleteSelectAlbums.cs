using System.Collections.Generic;
using System.Xml;

namespace DeleteSelectAlbums
{
    public class DeleteSelectAlbums
    {
        private const string FileLocation = "../../../catalogue.xml";
        private const string NewFileLocation = "../../../new-catalogue.xml";

        public static void Main()
        {
            XmlDocument musicCatalogue = new XmlDocument();
            musicCatalogue.Load(FileLocation);
            XmlNode rootNode = musicCatalogue.DocumentElement;

            List<XmlElement> nodesToDelete = new List<XmlElement>();
            foreach (XmlElement album in rootNode.ChildNodes)
            {
                var albumPrice = decimal.Parse(album["price"].InnerText);
                if (albumPrice > 20m)
                {
                    nodesToDelete.Add(album);
                }
            }

            foreach (var node in nodesToDelete)
            {
                rootNode.RemoveChild(node);
            }

            musicCatalogue.Save(NewFileLocation);
        }
    }
}
