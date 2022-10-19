using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title field is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Title Director is required")]
        public string Director { get; set; }

        [StringLength(30, ErrorMessage = "Category length invalid")]
        public string Category { get; set; }

        [Range(1, 600,ErrorMessage = "The Duration Range invalid")]
        public int Duration { get; set; }

        public virtual List<Cinema> Cinemas { get; set; }
    }
}