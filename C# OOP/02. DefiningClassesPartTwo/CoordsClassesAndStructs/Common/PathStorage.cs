/* Task 4. Create a static class PathStorage with static methods to save and load paths from a text file. 
 * Use a file format of your choice. */

namespace CoordsClassesAndStructs.Common
{
    using System;
    using System.IO;
    using System.Xml;
    public static class PathStorage
    {
        public static void SavePath(Path path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("../../path.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Points");

                foreach (var point in path.PathList)
                {
                    writer.WriteStartElement("Point");

                    writer.WriteElementString("X", point.X.ToString());
                    writer.WriteElementString("Y", point.Y.ToString());
                    writer.WriteElementString("Z", point.Z.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public static Path LoadPath()
        {
            Path loadedPath = new Path();
            try
            {
                using (XmlReader reader = XmlReader.Create("../../path.xml"))
                {
                    Point3D currentPoint = new Point3D();
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "Point":
                                    loadedPath.AddPoint(currentPoint);
                                    currentPoint = new Point3D();
                                    break;
                                case "X":
                                    reader.Read();
                                    currentPoint.X = int.Parse(reader.Value);
                                    break;
                                case "Y":
                                    reader.Read();
                                    currentPoint.Y = int.Parse(reader.Value);
                                    break;
                                case "Z":
                                    reader.Read();
                                    currentPoint.Z = int.Parse(reader.Value);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    loadedPath.AddPoint(currentPoint);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find file \"path.txt\"");
            }
            loadedPath.PathList.RemoveAt(0);
            return loadedPath;
        }
    }
}
