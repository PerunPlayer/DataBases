using System.Collections.Generic;
using SuperHeroes.Models;

namespace SuperheroesUniverse.Importer.Models
{
    public class SuperheroJson
    {
        public string Name { get; set; }

        public string SecretIdentity { get; set; }

        public ProtectedCity CityThatProtects { get; set; }

        public AligmentType Aligment { get; set; }
        
        public string Story { get; set; }
        
        public ICollection<Fraction> Fractions { get; set; }
        
        public ICollection<Power> Powers { get; set; }
    }
}
