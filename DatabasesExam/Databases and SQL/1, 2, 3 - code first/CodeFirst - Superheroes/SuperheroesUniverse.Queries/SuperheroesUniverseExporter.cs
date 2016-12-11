using System;
using System.IO;
using System.Xml;

using SuperheroesUniverse.Queries.Contracts;

using Newtonsoft.Json;

namespace SuperheroesUniverse.Queries
{
    public class SuperheroesUniverseExporter : ISuperheroesUniverseExporter
    {
        private const string JsonPath = "../../json";

        public string ExportAllSuperheroes()
        {
            var jsonFile = Directory.GetFiles(JsonPath).ToString();

            XmlDocument doc = new XmlDocument();

            doc = JsonConvert.DeserializeXmlNode(jsonFile);

            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                doc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }

        public string ExportFractionDetails(object fractionId)
        {
            throw new NotImplementedException();
        }

        public string ExportFractions()
        {
            throw new NotImplementedException();
        }

        public string ExportSuperheroDetails(object superheroId)
        {
            throw new NotImplementedException();
        }

        public string ExportSuperheroesByCity(string cityName)
        {
            throw new NotImplementedException();
        }

        public string ExportSupperheroesWithPower(string power)
        {
            throw new NotImplementedException();
        }
    }
}
