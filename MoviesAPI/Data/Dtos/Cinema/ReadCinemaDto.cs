using System.ComponentModel.DataAnnotations;
using MoviesAPI.Models;

namespace MoviesAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
    }
}
