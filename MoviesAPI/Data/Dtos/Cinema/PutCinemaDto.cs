using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Cinema
{
    public class PutCinemaDto
    {
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
    }
}
