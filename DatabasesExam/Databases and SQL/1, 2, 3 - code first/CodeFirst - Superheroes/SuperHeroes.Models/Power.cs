using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroes.Models
{
    public class Power
    {
        public Power(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(35)]
        public string Name { get; set; }
    }
}