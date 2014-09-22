using System;
using System.IO;
using System.Xml.Linq;

namespace CreatePersonXml
{
    public class CreatePersonXml
    {
        private const string ReadFileLocation = "../../../people.txt";
        private const string WriteFileLocation = "../../../people.xml";

        public static void Main()
        {
            using (StreamReader dataReader = new StreamReader(ReadFileLocation))
            {
                XElement people = new XElement("people");
                string line = dataReader.ReadLine();

                while (line != null)
                {
                    string name = string.Empty;
                    string address = string.Empty;;
                    string phoneNumber = string.Empty;
                    for (int i = 0; i < 3; i++)
                    {
                        if (line == null)
                        {
                            throw new ArgumentException("Unexpected end of file");
                        }

                        if (i == 0)
                        {
                            name = line;
                        }
                        else if (i == 1)
                        {
                            address = line;
                        }
                        else
                        {
                            phoneNumber = line;
                        }

                        line = dataReader.ReadLine();
                    }

                    var person = new XElement("person",
                        new XElement("name", name),
                        new XElement("address", address),
                        new XElement("phoneNumber", phoneNumber));

                    people.Add(person);
                }

                people.Save(WriteFileLocation);
            }
        }
    }
}
