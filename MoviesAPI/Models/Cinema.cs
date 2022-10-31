using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public virtual Location Location { get; set; }
        public int LocationId { get; set; }
        public virtual Manager Manager { get; set; }
        public int ManagerId { get; set; }

        [JsonIgnore]
        public virtual List<Section> Sections { get; set; }
    }
}