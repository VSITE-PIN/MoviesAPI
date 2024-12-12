using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class MovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public Movie? GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void UpdateMovie(Movie movie)
        {
            var existingMovie = GetMovieById(movie.Id);
            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {movie.Id} not found.");
            }

            existingMovie.Name = movie.Name;
            existingMovie.Genre = movie.Genre;
            existingMovie.Year = movie.Year;

            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = GetMovieById(id);
            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {id} not found.");
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}




/*
   dohvaćanje svih filmova
➢ dohvaćanje jednog filma preko ID-a
➢ ažuriranje filma
➢ brisanje filma
➢ dodavanje filma
  */