using MoviesAPI.Data;
using MoviesAPI.Viewmodel;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Genre = movie.Genre,
                Id = movie.Id,
                Year = movie.Year,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public Movie GetById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
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
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

    }
}
