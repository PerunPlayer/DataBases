using System;
using System.IO;
using System.Xml;

namespace DeleteAlbumsFromXML
{
    public class Startup
    {
        const double MaximumPrice = 20.0;

        public static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            var catalogue = doc.DocumentElement;

            DeleteAlbumsWithPrice(catalogue, MaximumPrice);
            doc.Save("../../updatedCatalogue.xml");

            var currentDirectory = Directory.GetCurrentDirectory();
            var savedDirectory = currentDirectory.Substring(0, currentDirectory.IndexOf("bin\\Debug"));
            Console.WriteLine("new catalogue saved as " + savedDirectory + "updatedCatalogue.xml");
        }

        private static void DeleteAlbumsWithPrice(XmlElement catalogue, double MaximumPrice)
        {
            var childs = catalogue.ChildNodes;

            for (int i = childs.Count - 1; i >= 0; i--)
            {
                var album = childs[i];

                var xmlPrice = album["price"].InnerText;
                var price = double.Parse(xmlPrice);

                if (price > MaximumPrice)
                {
                    catalogue.RemoveChild(album);
                }
            }
        }
    }
}
