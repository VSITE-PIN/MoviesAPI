using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class MoviesService
    {

        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context)
        {
     
            _context = context;
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }
        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
        }
        public bool UpdateMovie(int id, Movie updatedMovie)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return false;

            movie.Name = updatedMovie.Name;
            movie.Genre = updatedMovie.Genre;
            movie.Year = updatedMovie.Year;

            return true;
        }

        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            return true;
        }



    }
}
