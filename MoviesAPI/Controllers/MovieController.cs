using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();

        [HttpPost] // Used for add a new data on RESTful application
        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
            Console.WriteLine(movie.Title);
        }
    }
}
