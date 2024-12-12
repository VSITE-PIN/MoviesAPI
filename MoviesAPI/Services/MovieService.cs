using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class MovieService
    {
        private AppDbContext _context;
        public MovieService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                IsViewed = movie.IsViewed,
                DateViewed = movie.IsViewed ? movie.DateViewed : null,
                Rate = movie.IsViewed ? movie.Rate : null,
                Genre = movie.Genre,
                Author = movie.Author,
                CoverPictureURL = movie.CoverPictureURL,
                DateAdded = DateTime.Now,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }
        public List<Movie> GetAllBooks()
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
                movie.Title = movieVM.Title;
                movieVM.Description = movieVM.Description;
                movie.IsViewed = movieVM.IsViewed;
                movie.DateViewed = movieVM.IsViewed ? movieVM.DateViewed : null;
                movie.Rate = movieVM.IsViewed ? movieVM.Rate : null;
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
