using SuperheroesUniverse.Importer.Contracts;
using SuperheroesUniverse.Importer.Models;
using SuperheroesUniverse.Data.Contracts;
using SuperHeroes.Models;

namespace SuperheroesUniverse.Importer
{
    public class JsonImporter : IImporter
    {
        private ISuperheroData db;
        private ISuperheroFactory factory;

        public JsonImporter(ISuperheroData db, ISuperheroFactory factory)
        {
            this.db = db;
            this.factory = factory;
        }

        public void ImportHeroes(string inputFilePath, IDeserializer<SuperheroJson> jsonDeserializer)
        {

        }

        private Planet GetPlanet(string name)
        {
        }
    }
}