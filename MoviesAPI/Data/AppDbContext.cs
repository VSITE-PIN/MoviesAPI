using Microsoft.EntityFrameworkCore;
using static MoviesAPI.Data.Movie;

namespace MoviesAPI.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
        { }
        public DbSet<Movie> Movies { get; set; }
        public object Movie { get; internal set; }
    }
}
