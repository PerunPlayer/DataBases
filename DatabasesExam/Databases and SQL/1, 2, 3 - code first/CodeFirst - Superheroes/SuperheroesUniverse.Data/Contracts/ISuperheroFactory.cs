using SuperHeroes.Models;
using System.Collections.Generic;

namespace SuperheroesUniverse.Data.Contracts
{
    public interface ISuperheroFactory
    {
        Power CreatePower(string name);

        Fraction CreateFraction(string name);

        Planet CreatePlanet(string name);

        Superhero CreateSuperharo(string name, string secretIdentity, string cityThatProtects, AligmentType aligment,
                         string story, ICollection<Fraction> fractions, ICollection<Power> powers);
    }
}
