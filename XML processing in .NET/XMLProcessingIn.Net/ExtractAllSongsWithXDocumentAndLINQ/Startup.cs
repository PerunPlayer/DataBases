using System;
using System.Linq;
using System.Xml.Linq;

namespace ExtractAllSongsWithXDocumentAndLINQ
{
    public class Startup
    {
        public static void Main()
        {
            XDocument doc = XDocument.Load("../../../catalogue.xml");

            var songs = from song in doc.Descendants("song")
                        select song.Element("title").Value;

            foreach (var song in songs)
            {
                Console.WriteLine($"{song}");
            }
        }
    }
}
