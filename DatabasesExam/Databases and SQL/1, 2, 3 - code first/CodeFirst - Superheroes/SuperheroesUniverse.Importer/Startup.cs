using SuperheroesUniverse.Importer.Migrations;

namespace SuperheroesUniverse.Importer
{
    public class Startup
    {
        public static void Main()
        {
            SuperheroesDBContext.Initialize();
            ImportStarter.Start();
        }
    }
}
