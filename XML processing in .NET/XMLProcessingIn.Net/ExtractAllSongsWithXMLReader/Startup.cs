using System;
using System.Xml;

namespace ExtractAllSongsWithXMLReader
{
    public class Startup
    {
        public static void Main()
        {
            var path = "../../../catalogue.xml";

            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                    {
                        Console.WriteLine($"{reader.ReadElementContentAsString()}");
                    }
                }
            }
        }
    }
}
