using System;
using System.Linq;
using System.Xml.Linq;

namespace ExtractOldAlbum_sPricesWithLINQ
{
    public class Startup
    {
        public static void Main()
        {
            var document = XDocument.Load("../../../catalogue.xml");

            document.Descendants("album")
                    .Where(x => int.Parse(x.Element("year").Value) < 2011)
                    .Select(x => x.Element("price").Value)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x));
        }
    }
}
