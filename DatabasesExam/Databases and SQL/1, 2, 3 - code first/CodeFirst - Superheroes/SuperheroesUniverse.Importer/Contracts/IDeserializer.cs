using System.Collections.Generic;

namespace SuperheroesUniverse.Importer.Contracts
{
    public interface IDeserializer<T>
    {
        IReadOnlyCollection<T> DeserializeToCollection(string filePath);
    }
}
