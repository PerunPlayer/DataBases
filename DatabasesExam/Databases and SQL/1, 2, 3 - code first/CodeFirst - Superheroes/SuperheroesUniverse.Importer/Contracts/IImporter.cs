using SuperheroesUniverse.Importer.Models;

namespace SuperheroesUniverse.Importer.Contracts
{
    public interface IImporter
    {
        void ImportHeroes(string inputFilePath, IDeserializer<SuperheroJson> jsonDeserializer);
    }
}
