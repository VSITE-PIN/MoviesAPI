using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;

namespace MoviesAPI.Service
{
	public class MovieService
	{

		private AppDbContext _context;
		public MovieService(AppDbContext context)
		{
			_context = context;
		}
		public void AddMovie(Movie movie)
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
	}
}
