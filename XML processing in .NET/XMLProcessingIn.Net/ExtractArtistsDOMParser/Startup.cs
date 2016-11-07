using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace ExtractArtistsDOMParser
{
    public class Startup
    {
        public static void Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            XmlElement catalogue = doc.DocumentElement;

            foreach (var pair in GetUniqueArtists(catalogue))
            {
                Console.WriteLine("{0} - {1} album(s)", pair.Key, pair.Value);
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed with DOM Parser: {0}", stopwatch.Elapsed);
        }

        private static Dictionary<string, int> GetUniqueArtists(XmlElement catalogue)
        {
            var artistsAndAlbums = new Dictionary<string, int>();
            var artists = catalogue.GetElementsByTagName("artist");

            foreach (XmlElement artist in artists)
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
