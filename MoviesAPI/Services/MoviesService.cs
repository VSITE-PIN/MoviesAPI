using Microsoft.EntityFrameworkCore;
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

		public async Task<List<Movie>> GetAllAsync()
		{
			return await _context.Movies.ToListAsync();
		}

		public async Task<Movie?> GetByIdAsync(int id)
		{
			return await _context.Movies.FindAsync(id);
		}

		public async Task<Movie> AddAsync(MovieVM movie)
		{
			if (string.IsNullOrWhiteSpace(movie.Name))
			{
				throw new ArgumentException("Movie name cannot be empty");
			}

			var newMovie = new Movie()
			{
				Name = movie.Name,
				Year = movie.Year,
				Genre = movie.Genre,
			};

			await _context.Movies.AddAsync(newMovie);
			await _context.SaveChangesAsync();

			return newMovie;
		}

		public async Task UpdateAsync(int id, MovieVM movie)
		{
			var existingMovie = await GetByIdAsync(id);

			if (existingMovie == null)
			{
				throw new KeyNotFoundException("Movie not found");
			}

			existingMovie.Name = movie.Name;
			existingMovie.Year = movie.Year;
			existingMovie.Genre = movie.Genre;

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var movie = await GetByIdAsync(id);
			if (movie == null)
			{
				throw new KeyNotFoundException("Movie not found");
			}

			_context.Movies.Remove(movie);
			await _context.SaveChangesAsync();
		}

		internal void AddAsync(Movie movie)
		{
			throw new NotImplementedException();
		}

		internal void UpdateAsync(int id)
		{
			throw new NotImplementedException();
		}

	}
}
