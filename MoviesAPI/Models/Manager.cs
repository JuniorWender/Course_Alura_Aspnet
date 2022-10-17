using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Manager
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
