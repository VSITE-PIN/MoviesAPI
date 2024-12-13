using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM book)
        {
            var newMovie = new Movie()
            {
                Name = Movie.Name,
                Id = Movie.Id,
                Year = Movie.Year,
                Genre = Movie.Genre,
                
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }


        public List<Movie> GetAllMovies()
        {
            return _context.Movie.ToList();
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movie.FirstOrDefault(x => x.Id == id);
        }
        public Movie UpdateMovieById(int id, MovieVM bookVM)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Name = MovieVM.Name;
                movie.Id = MovieVM.Id;
              
                movie.Genre = MovieVM.Genre;
                movie.Year = MovieVM.Year;
            }
            return movie;
        }
        public void DeleteMovie(int id)
        {
            var book = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }


    }
}
