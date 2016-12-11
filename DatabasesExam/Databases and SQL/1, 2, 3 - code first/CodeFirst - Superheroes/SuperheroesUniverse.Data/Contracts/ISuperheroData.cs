using SuperHeroes.Models;
using SuperheroesUniverse.Data.Repository;

namespace SuperheroesUniverse.Data.Contracts
{
    public interface ISuperheroData
    {
        IRepository<Power> Powers { get; }

        IRepository<Fraction> Fractions { get; }

        IRepository<Planet> Planets { get; }

        IRepository<Superhero> Superhero { get; }

        void SaveChanges();
    }
}
