using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace ExtractArtistXPath
{
    public class Startup
    {
        public static void Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            var catalogue = doc.DocumentElement;

            foreach (var pair in GetUniqueArtists(doc))
            {
                Console.WriteLine("{0} - {1} album(s)", pair.Key, pair.Value);
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed with XPath: {0}", stopwatch.Elapsed);
        }

        private static Dictionary<string, int> GetUniqueArtists(XmlDocument catalogue)
        {
            var artistsAndAlbums = new Dictionary<string, int>();
            var artists = catalogue.SelectNodes("/catalogue/album/artist");

            foreach (XmlNode artist in artists)
            {
                var artistName = artist.InnerText;

                if (artistsAndAlbums.ContainsKey(artistName))
                {
                    artistsAndAlbums[artistName] += 1;
                }
                else
                {
                    artistsAndAlbums.Add(artistName, 1);
                }
            }

            return artistsAndAlbums;
        }
    }
}
