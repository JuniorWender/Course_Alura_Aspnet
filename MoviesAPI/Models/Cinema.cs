using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }

        public int LocationFk { get; set; }

        public int ManegerFK { get; set; }
    }
}