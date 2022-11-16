using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace MoviesAPI.Models
{
    public class Section
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Movie Movie { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get;set; }
        public DateTime MovieHour { get; set; }

    }
}
