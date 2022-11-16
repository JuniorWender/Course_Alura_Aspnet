using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using System.IO;
using MoviesAPI.Models;
using AutoMapper;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Services;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {

        private MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost] // Used for add a new data on RESTful application
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            ReadMovieDto readDto = _movieService.AddMovie(movieDto);

            return CreatedAtAction(nameof(GetMovie), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult GetAllMovies([FromQuery] int? ageClassification = null)
        {
            List<ReadMovieDto> readDto = _movieService.GetAllMovies(ageClassification);

            if (readDto != null) return Ok(readDto);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            ReadMovieDto readDto = _movieService.GetMovie(id);

            if (readDto != null) return Ok(readDto);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie([FromBody] ReadMovieDto movieDto)
        {
            ReadMovieDto readDto = _movieService.PutMovie(movieDto);

            if (readDto != null) return NoContent(); // Good Practice when you update a content is not return the content, but return a 200 familly status code

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            ReadMovieDto readDto = _movieService.DeleteMovie(id);

            if (readDto != null) return NoContent();

            return NotFound();
        }
    }
}
