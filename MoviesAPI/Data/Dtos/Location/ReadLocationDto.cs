using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Location
{
    public class ReadLocationDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Street { get; set; }
        public string district { get; set; }
        public int Number { get; set; }
    }
}
