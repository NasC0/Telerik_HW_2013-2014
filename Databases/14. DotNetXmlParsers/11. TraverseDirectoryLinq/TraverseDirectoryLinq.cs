using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TraverseDirectoryLinq
{
    public class TraverseDirectoryLinq
    {
        private const string FolderLocation = "C:\\Program Files";
        private const string OutputLocation = "../../../output-linq.xml";

        public static void BuildXml(string folderLocation, string outputLocation)
        {
            var outputDocument = new XDocument();
            var rootElement = new XElement("traversed");
            var traversedNode = TraverseDirectory(folderLocation);

            rootElement.Add(traversedNode);
            outputDocument.Add(rootElement);
            outputDocument.Save(outputLocation);
        }

        private static XElement TraverseDirectory(string folderLocation)
        {
            var dirElement = new XElement("dir");
            dirElement.Add(new XAttribute("path", folderLocation));

            var files = Directory.GetFiles(folderLocation);
            var filesElement = new XElement("files");

            try
            {
                foreach (var file in files)
                {
                    filesElement.Add(new XElement("file", Path.GetFileName(file)));
                }

                dirElement.Add(filesElement);

                var directories = Directory.GetDirectories(folderLocation, "*", SearchOption.TopDirectoryOnly);

                foreach (var directory in directories)
                {
                    var currentDir = TraverseDirectory(directory);
                    dirElement.Add(currentDir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                
            }

            return dirElement;
        }

        public static void Main()
        {
            BuildXml(FolderLocation, OutputLocation);
        }
    }
}
