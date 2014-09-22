using System;
using System.Linq;
using System.Xml.Linq;

namespace ExtractAlbumsAndAuthorsLinq
{
    public class ExtractAlbumsAndAuthorsLinq
    {
        private const string ReadFileLocation = "../../../catalogue.xml";
        private const string WriteFileLocation = "../../../albums-linq.xml";

        public static void Main()
        {
            XDocument musicCatalogue = XDocument.Load(ReadFileLocation);
            var authorsAndAlbums = musicCatalogue.Descendants().Where(x => x.Name == "album").Select(pair => new
            {
                Name = pair.Descendants("name").FirstOrDefault().Value,
                Author = pair.Descendants("artist").FirstOrDefault().Value
            });

            XElement albums = new XElement("albums");
            foreach (var pair in authorsAndAlbums)
            {
                XElement currentAlbum = new XElement("album",
                    new XElement("name", pair.Name),
                    new XElement("artist", pair.Author));

                albums.Add(currentAlbum);
            }

            var albumsDocument = new XDocument(albums);
            albumsDocument.Save(WriteFileLocation);
        }
    }
}
