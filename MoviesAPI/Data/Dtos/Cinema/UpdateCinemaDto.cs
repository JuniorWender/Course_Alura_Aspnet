using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
    }
}
