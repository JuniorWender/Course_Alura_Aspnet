using MoviesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opt) : base(opt) { }

        public DbSet<Movie> Movies {get; set;}

        public DbSet<Cinema> Cinemas {get; set;}

        public DbSet<Location> Locations {get; set;}
    }
}
