using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroes.Models
{
    public class Country
    {
        public Country(string name, Planet planet)
        {
            this.Name = name;
            this.Planet = planet;
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public Planet Planet { get; set; }
    }
}