using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();
        private static int id = 1;

        [HttpPost] // Used for add a new data on RESTful application
        public void AddMovie([FromBody]Movie movie)
        {
            movie.Id = id++;
            movies.Add(movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetAllMovies()
        {
            return movies;
        }

        // public GetMovie()
    }
}
