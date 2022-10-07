using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Location
{
    public class PutLocationDto
    {
        public string Street { get; set; }
        public string district { get; set; }
        public int Number { get; set; }
    }
}
