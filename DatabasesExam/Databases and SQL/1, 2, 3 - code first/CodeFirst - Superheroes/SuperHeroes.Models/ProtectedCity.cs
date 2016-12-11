using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroes.Models
{
    public class ProtectedCity
    {
        public ProtectedCity(Country country, string name)
        {
            this.Country = country;
            this.Name = name;
        }

        public int Id { get; set; }

        public Country Country { get; set; }

        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}