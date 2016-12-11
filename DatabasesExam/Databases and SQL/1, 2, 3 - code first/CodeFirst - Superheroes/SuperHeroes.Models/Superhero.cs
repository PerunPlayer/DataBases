using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroes.Models
{
    public class Superhero
    {
        public Superhero()
        {
        }

        public Superhero(string name, string secretIdentity, string cityThatProtects, AligmentType aligment, 
                         string story, ICollection<Fraction> fractions, ICollection<Power> powers)
        {
            this.Name = name;
            this.SecretIdentity = secretIdentity;
            this.Aligment = aligment;
            this.Story = story;
            this.Fractions = fractions;
            this.Powers = powers;
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string SecretIdentity { get; set; }

        [Required]
        public ProtectedCity CityThatProtects { get; set; }

        [Required]
        public AligmentType Aligment { get; set; }

        [Required]
        public string Story { get; set; }

        [Required]
        public ICollection<Fraction> Fractions { get; set; }

        [Required]
        public ICollection<Power> Powers { get; set; }
    }
}
