using Ninject.Extensions.Factory;
using Ninject.Modules;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Contracts;
using SuperheroesUniverse.Data.Repositories;
using SuperheroesUniverse.Data.Repository;
using SuperheroesUniverse.Importer.Contracts;
using SuperheroesUniverse.Importer.Migrations;
using SuperheroesUniverse.Importer.Models;

namespace SuperheroesUniverse.Importer.Config
{
    public class SuperheroModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<ISuperheroData>().To<SuperheroData>();
            this.Kernel.Bind<ISuperheroDBContext>().To<SuperheroesDBContext>();
            this.Kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            this.Kernel.Bind(typeof(IDeserializer<>)).To(typeof(JsonDeserializer<>));
            this.Kernel.Bind<IImporter>().To<JsonImporter>();

            Bind<ISuperheroFactory>().ToFactory();
        }
    }
}
