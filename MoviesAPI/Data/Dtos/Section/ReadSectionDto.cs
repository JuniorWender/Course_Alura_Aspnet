using MoviesAPI.Models;

namespace MoviesAPI.Data.Dtos.Section
{
    public class ReadSectionDto
    {
        public int Id { get; set; }
        public Object Cinema { get; set; }
        public Object Movie { get; set; }
    }
}
