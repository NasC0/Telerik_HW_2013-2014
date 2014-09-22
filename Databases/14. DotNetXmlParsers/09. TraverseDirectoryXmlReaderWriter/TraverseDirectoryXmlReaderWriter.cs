using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace TraverseDirectoryXmlReaderWriter
{
    public class TraverseDirectoryXmlReaderWriter
    {
        private const string FolderLocation = "C:\\Program Files";
        private const string OutputLocation = "../../../output.xml";

        public static void TraverseAndWrite(string folderLocation, string outputLocation)
        {
            var writerSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
                Encoding = Encoding.UTF8,
                CheckCharacters = false,
                DoNotEscapeUriAttributes = false
            };

            using (var dataWriter = XmlWriter.Create(OutputLocation, writerSettings))
            {
                dataWriter.WriteStartDocument();
                dataWriter.WriteStartElement("traversed");

                try
                {
                    var files = Directory.GetFiles(folderLocation);
                    dataWriter.WriteStartElement("files");

                    foreach (var file in files)
                    {
                        dataWriter.WriteStartElement("file");
                        dataWriter.WriteEndElement();
                    }

                    dataWriter.WriteEndElement();

                    var directories = Directory.GetDirectories(folderLocation);
                    foreach (var directory in directories)
                    {
                        dataWriter.WriteStartElement("dir");
                        TraverseRecursively(directory, dataWriter);
                        dataWriter.WriteEndElement();
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                }

                dataWriter.WriteEndElement();
                dataWriter.WriteEndDocument();
            }
        }

        private static void TraverseRecursively(string folderLocation, XmlWriter dataWriter)
        {
            var files = Directory.GetFiles(folderLocation);
            dataWriter.WriteStartElement("files");

            foreach (var file in files)
            {
                string xml = new XElement("file", Path.GetFileName(file)).ToString();
                XmlReader reader = XmlReader.Create(new StringReader(xml));
                dataWriter.WriteNode(reader, true);
            }

            dataWriter.WriteEndElement();
            var directories = Directory.GetDirectories(folderLocation, "*", SearchOption.TopDirectoryOnly);

            foreach (var directory in directories)
            {
                dataWriter.WriteStartElement("dir");
                TraverseRecursively(directory, dataWriter);
                dataWriter.WriteEndElement();
            }
        }

        public static void Main()
        {
            TraverseAndWrite(FolderLocation, OutputLocation);
        }
    }
}
