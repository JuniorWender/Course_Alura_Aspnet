using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using MoviesAPI.Data;
using System.IO;
using MoviesAPI.Migrations.Dtos;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost] // Used for add a new data on RESTful application
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = new Movie
            {
                Title = movieDto.Title,
                Director = movieDto.Director,
                Category = movieDto.Category,
                Duration = movieDto.Duration
            };

            _context.Movies.Add(movie);
            _context.SaveChanges(); // Confirme the changes on db
            return CreatedAtAction(nameof(GetMovie), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<CreateMovieDto> GetAllMovies()
        {
            return _context.Movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            CreateMovieDto movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, [FromBody] CreateMovieDto NewMovie)
        {
            CreateMovieDto movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            movie.Title = NewMovie.Title;
            movie.Category = NewMovie.Category;
            movie.Director = NewMovie.Director;
            movie.Duration = NewMovie.Duration;
            _context.SaveChanges();
            return NoContent(); // Good Practice when you update a content is not return the content, but retun a 200 familly status code
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            CreateMovieDto movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
