using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class MoviesServices
    {
        private AppDbContext _context;
        public MoviesServices(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Year = movie.Year,
                Genre = movie.Genre,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            foreach (var id in movie.DirectorIds)
            {
                var moviedirector = new MovieDirector()
                {
                    MovieId = newMovie.Id,
                    DirectorId = id
                };
                _context.MovieDirectors.Add(moviedirector);
            }
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
                movie.Year = movieVM.Year;
                movie.Genre = movieVM.Genre;
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
