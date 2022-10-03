﻿using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using System.IO;
using MoviesAPI.Migrations.Dtos;
using MoviesAPI.Models;
using AutoMapper;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost] // Used for add a new data on RESTful application
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges(); // Confirme the changes on db
            return CreatedAtAction(nameof(GetMovie), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie != null)
            { 
               ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);

               return Ok(movieDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, [FromBody] PutMovieDto movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieDto, movie);
            _context.SaveChanges();
            return NoContent(); // Good Practice when you update a content is not return the content, but retun a 200 familly status code
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);

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
