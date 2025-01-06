using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :
   base(options)
    { }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MovieDirector>()
        .HasOne(m => m.Movie)
        .WithMany(md => md.MovieDirectors)
        .HasForeignKey(mi => mi.MovieId);
        modelBuilder.Entity<MovieDirector>()
        .HasOne(m => m.Director)
        .WithMany(md => md.MovieDirectors)
        .HasForeignKey(mi => mi.DirectorId);
    }

}

