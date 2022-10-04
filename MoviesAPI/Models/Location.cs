using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Location
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Street { get; set; }
        public string district { get; set; }
        public int Number { get; set; }
    }
}
