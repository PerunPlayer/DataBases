using System;
using System.Data.Entity;
using SuperheroesUniverse.Data.Repository;

namespace SuperheroesUniverse.Importer.Migrations
{
    public class SuperheroesDBContext : DbContext, ISuperheroDBContext
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperheroesDBContext, Configuration>());
            (new SuperheroesDBContext()).Database.Initialize(true);
        }

        IDbSet<T> ISuperheroDBContext.Set<T>()
        {
            throw new NotImplementedException();
        }
    }
}