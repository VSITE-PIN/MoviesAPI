using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.VM;
using System.Linq;

namespace MoviesAPI.Service
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
				Name = movie.Name,
				Year = movie.Year,
				Genre = movie.Genre,
			};
			_context.Movie.Add(newMovie);
			_context.SaveChanges();
		}
		public List<Movie> GetMovies()
		{
			return _context.Movie.ToList();
		}
		public Movie GetMovieByID(int Id)
		{
			return _context.Movie.FirstOrDefault(x => x.Id == Id);
		}
		public Movie EditMovie(int id, MovieVM movieVM)
		{
			Movie movie = _context.Movie.FirstOrDefault(x => x.Id == id);
			if (movie != null) ;
			{

				movie.Name = movieVM.Name;
				movie.Year = movieVM.Year;
				movie.Genre = movieVM.Genre;
				_context.SaveChanges();

			}
			return movie;

		}
		public void DeleteMovie(int id)
		{
			Movie movie = _context.Movie.FirstOrDefault(x => x.Id == id);
			_context.Movie.Remove(movie);
			_context.SaveChanges();

		}

	}
}
