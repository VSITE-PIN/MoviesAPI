using MoviesAPI.Data;
using MoviesAPI.ViewModel;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
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
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }
        public void DeleteMovie(int id)
        {
            var Movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(Movie);
            _context.SaveChanges();
        }
        public Movie UpdateById(int id, MovieVM movieVM)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Name = movieVM.Name;
                movieVM.Id = movie.Id;
                movie.Genre = movieVM.Genre;
                movie.Year = movieVM.Year;
                _context.SaveChanges();
            }
            return movie;
        }
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Id = movie.Id,
                Year = movie.Year,
                Genre = movie.Genre,
    
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }
    }
}
