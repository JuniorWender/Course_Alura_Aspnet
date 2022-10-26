namespace MoviesAPI.Data.Dtos.Section
{
    public class CreateSectionDto
    {
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public DateTime MovieHour { get; set; }
    }
}
