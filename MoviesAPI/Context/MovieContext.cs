﻿using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opt) : base(opt) { }

        public DbSet<CreateMovieDto> Movies {get; set;}
    }
}
