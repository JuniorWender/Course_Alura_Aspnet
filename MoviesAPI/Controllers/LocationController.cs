using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using System.IO;
using MoviesAPI.Models;
using AutoMapper;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Data.Dtos.Location;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LocationController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public LocationController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost] // Used for add a new data on RESTful application
        public IActionResult AddLocation([FromBody] CreateLocationDto locationDto)
        {
            Movie movie = _mapper.Map<Movie>(locationDto);

            _context.Movies.Add(movie);
            _context.SaveChanges(); // Confirme the changes on db
            return CreatedAtAction(nameof(GetLocation), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<Location> GetAllLocation()
        {
            return _context.Locations;
        }

        [HttpGet("{id}")]
        public IActionResult GetLocation(int id)
        {
            Location location = _context.Locations.FirstOrDefault(x => x.Id == id);

            if (location != null)
            {
                ReadLocationDto locationDto = _mapper.Map<ReadLocationDto>(location);

               return Ok(locationDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutLocation(int id, [FromBody] PutLocationDto locationDto)
        {
            Location location = _context.Locations.FirstOrDefault(x => x.Id == id);

            if (location == null)
            {
                return NotFound();
            }
            _mapper.Map(locationDto, location);
            _context.SaveChanges();
            return NoContent(); // Good Practice when you update a content is not return the content, but retun a 200 familly status code
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(int id)
        {
            Location location = _context.Locations.FirstOrDefault(x => x.Id == id);

            if (location == null)
            {
                return NotFound();
            }
            _context.Locations.Remove(location);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
