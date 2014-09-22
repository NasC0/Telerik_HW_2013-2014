using System.Collections.Generic;
using System.Xml;

namespace ExtractAlbumAndAuthors
{
    public class ExtractAlbumAndAuthors
    {
        private const string ReadFileLocation = "../../../catalogue.xml";
        private const string WriteFileLocation = "../../../albums.xml";

        public static void Main()
        {
            var albumsAndAuthors = new List<KeyValuePair<string, string>>();

            using (var dataReader = XmlReader.Create(ReadFileLocation))
            {
                while (dataReader.Read())
                {
                    if (dataReader.NodeType == XmlNodeType.Element && dataReader.Name == "name")
                    {
                        string albumName = dataReader.ReadElementString();
                        dataReader.Read();
                        string authorName = dataReader.ReadElementString();

                        var pair = new KeyValuePair<string, string>(albumName, authorName);
                        albumsAndAuthors.Add(pair);
                    }
                }
            }

            using (var dataWriter = XmlWriter.Create(WriteFileLocation, new XmlWriterSettings()
            {
                Indent = true, 
                IndentChars = "\t"
                
            }))
            {
                dataWriter.WriteStartDocument();
                dataWriter.WriteStartElement("albums");

                foreach (var pair in albumsAndAuthors)
                {
                    dataWriter.WriteStartElement("album");
                    dataWriter.WriteStartElement("name", pair.Key);
                    dataWriter.WriteEndElement();
                    dataWriter.WriteStartElement("author", pair.Value);
                    dataWriter.WriteEndElement();
                    dataWriter.WriteEndElement();
                }

                dataWriter.WriteEndElement();
                dataWriter.WriteEndDocument();
            }
        }
    }
}
