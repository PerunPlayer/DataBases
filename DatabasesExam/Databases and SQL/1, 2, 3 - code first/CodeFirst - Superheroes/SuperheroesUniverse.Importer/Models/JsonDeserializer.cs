using Newtonsoft.Json;
using SuperheroesUniverse.Importer.Contracts;
using System.Collections.Generic;
using System.IO;

namespace SuperheroesUniverse.Importer.Models
{
    public class JsonDeserializer<T> : IDeserializer<T>
    {
        public IReadOnlyCollection<T> DeserializeToCollection(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            var deserializedData = JsonConvert.DeserializeObject<IReadOnlyCollection<T>>(fileContent);
            return deserializedData;
        }
    }
}
