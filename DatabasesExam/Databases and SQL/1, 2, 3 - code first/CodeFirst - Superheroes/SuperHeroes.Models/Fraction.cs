using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroes.Models
{
    public class Fraction
    {
        public Fraction(string name, AligmentType aligment, ICollection<Planet> planets, ICollection<Superhero> members)
        {
            this.Name = name;
            this.Aligment = aligment;
            this.ProtectedPlanets = planets;
            this.Members = members;
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public AligmentType Aligment { get; set; }

        public ICollection<Planet> ProtectedPlanets { get; set; }

        public ICollection<Superhero> Members { get; set; }
    }
}