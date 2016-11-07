using System;
using System.IO;
using System.Xml.Linq;

namespace CreateXMLFromTxt
{
    public class Startup
    {
        const string person = "../../Person.txt";

        public static void Main()
        {
            StreamReader reader = new StreamReader(person);

            var xmlDoc = new XDocument();
            var rootElement = new XElement("person");

            var line = reader.ReadLine();

            while (line != null)
            {
                var person = new XElement("person");
                person.Add(new XElement("name", line));
                line = reader.ReadLine();

                person.Add(new XElement("address", line));
                line = reader.ReadLine();

                person.Add(new XElement("phone", line));
                line = reader.ReadLine();

                rootElement.Add(person);
            }

            xmlDoc.Add(rootElement);
            Console.WriteLine(xmlDoc);

            xmlDoc.Save("../../person2.xml");
        }
    }
}
