using System.IO;

using SuperheroesUniverse.Importer.Config;
using SuperheroesUniverse.Importer.Contracts;
using SuperheroesUniverse.Importer.Models;

using Ninject;

namespace SuperheroesUniverse.Importer
{
    public class ImportStarter
    {
        private const string JsonPath = "../../json";

        public static void Start()
        {
            var kernel = new StandardKernel();
            kernel.Load(new SuperheroModule());

            var importer = kernel.Get<IImporter>();
            var deserializer = kernel.Get<IDeserializer<SuperheroJson>>();
            var jsonFile = Directory.GetFiles(JsonPath);

            foreach (var filePath in jsonFile)
            {
                importer.ImportHeroes(filePath, deserializer);
            }
        }
    }
}
