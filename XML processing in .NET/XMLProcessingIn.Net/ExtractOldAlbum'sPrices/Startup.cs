using System;
using System.Xml;

namespace ExtractOldAlbum_sPrices
{
    public class Startup
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            var query = "/catalogue/album[year<2011]/price";

            var albumNames = doc.SelectNodes(query);

            foreach (XmlNode name in albumNames)
            {
                Console.WriteLine(name.InnerText);
            }
        }
    }
}
