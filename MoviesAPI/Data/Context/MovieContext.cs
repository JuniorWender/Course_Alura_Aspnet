using MoviesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<Location>()
                .HasOne(location => location.Cinema)
                .WithOne(Cinema => Cinema.Location)
                .HasForeignKey<Cinema>(cinema => cinema.LocationId);

            builder.Entity<Cinema>()
                .HasOne(cinema => cinema.Manager)
                .WithMany(manager => manager.Cinemas)
                .HasForeignKey(cinema => cinema.ManagerId);
        }
        public DbSet<Movie> Movies {get; set;}

        public DbSet<Cinema> Cinemas {get; set;}

        public DbSet<Location> Locations {get; set;}
        
        public DbSet<Manager> Managers {get; set;}
    }
}
