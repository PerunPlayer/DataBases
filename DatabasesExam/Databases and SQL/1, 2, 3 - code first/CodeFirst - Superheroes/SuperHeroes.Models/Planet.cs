using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroes.Models
{
    public class Planet
    {
        public Planet(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}