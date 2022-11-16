using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Cinema;
using MoviesAPI.Models;

namespace MoviesAPI.Services
{
    public class CinemaService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public CinemaService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AddCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> GetAllCinemas(string movieName)
        {
            List<Cinema> cinema = _context.Cinemas.ToList();

            if(cinema == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(movieName))
            {
               /* IEnumerable<Cinema> query = from cinemas in cinema
                                            where cinema.section.Any(section => section.Movie.Title == movieName)
                                            select cinema; */


               /* cinema = query.ToList();*/
            }
            return _mapper.Map<List<ReadCinemaDto>>(cinema);
        }
    }
}
