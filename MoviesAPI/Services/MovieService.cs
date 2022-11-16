using AutoMapper;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Models;

namespace MoviesAPI.Services
{
    public class MovieService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadMovieDto AddMovie(CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges(); // Confirme the changes on db

            return _mapper.Map<ReadMovieDto>(movie);
        }

        internal List<ReadMovieDto> GetAllMovies(int? ageClassification)
        {
            List<Movie> movie;

            if (ageClassification == null)
            {
                movie = _context.Movies.ToList();
            }
            else
            {
                movie = _context.Movies.Where(movie => movie.AgeRating <= ageClassification).ToList();

            }

            if (movie != null)
            {
                List<ReadMovieDto> readDto = _mapper.Map<List<ReadMovieDto>>(movie);

                return readDto;
            }

            return null;
        }

        public ReadMovieDto GetMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie != null)
            {
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);

                return movieDto;
            }

            return null;
        }

        public ReadMovieDto PutMovie(ReadMovieDto movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == movieDto.Id);

            if (movie != null)
            {
                _mapper.Map(movieDto, movie);
                _context.SaveChanges();

                ReadMovieDto readDto = _mapper.Map<ReadMovieDto>(movie);

                return readDto;
            }

            return null;

        }

        public ReadMovieDto DeleteMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();

                ReadMovieDto readDto = _mapper.Map<ReadMovieDto>(movie);

                return readDto;
            }

            return null;
        }
    }
}
