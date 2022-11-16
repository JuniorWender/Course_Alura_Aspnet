using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Cinema;
using MoviesAPI.Models;
using MoviesAPI.Services;
using System;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }


        [HttpPost]
        public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.AddCinema(cinemaDto);
            return CreatedAtAction(nameof(GetCinema), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult GetAllCinemas([FromQuery] string movieName)
        {
            List<ReadCinemaDto> readDto = _cinemaService.GetAllCinemas(movieName);

            if (readDto != null) return Ok(readDto);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutCinema(int id, [FromBody] PutCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
