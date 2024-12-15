using MoviesAPI.Data;
using MoviesAPI.Model;
using static MoviesAPI.Data.Movie;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Year = movie.Year,
                IsSeen = movie.IsSeen,
                Genre = movie.Genre,
                Author = movie.Author,
                CoverPictureURL = movie.CoverPictureURL,
                DateAdded = DateTime.Now,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }
        public Movie UpdateMovieById(int id, MovieVM movieVM)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Name = movieVM.Name;
                movieVM.Year = movieVM.Year;
                movie.IsSeen = movieVM.IsSeen;
                movie.Genre = movieVM.Genre;
                movie.Author = movieVM.Author;
                movie.CoverPictureURL = movieVM.CoverPictureURL;
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

