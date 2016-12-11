using System.Data.Entity.Migrations;

namespace SuperheroesUniverse.Importer.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SuperheroesDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SuperheroesDBContext context)
        {
        }
    }
}
