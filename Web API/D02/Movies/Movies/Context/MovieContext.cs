using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Movies.Models;

namespace Movies.Context
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}
