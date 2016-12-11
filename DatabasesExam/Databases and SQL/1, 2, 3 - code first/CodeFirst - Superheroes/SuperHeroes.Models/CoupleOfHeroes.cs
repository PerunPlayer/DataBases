using SuperHeroes.Models.Enums;
using System.Collections.Generic;

namespace SuperHeroes.Models
{
    public class CoupleOfHeroes
    {
        private ICollection<Superhero> couple;

        public CoupleOfHeroes(ICollection<Superhero> couple, RelationshipType relationship)
        {
            this.Relationship = relationship;
        }

        public RelationshipType Relationship { get; set; }

        public ICollection<Superhero> Couple { get; set; }
    }
}
