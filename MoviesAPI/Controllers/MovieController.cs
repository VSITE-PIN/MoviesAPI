using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MovieController : ControllerBase
	{
		private readonly MovieService _movieService;

		public MovieController(MovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var movies = await _movieService.GetAllAsync();

			return Ok(movies);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById(int id)
		{
			var movie = await _movieService.GetByIdAsync(id);

			if (movie == null)
			{
				return NotFound("Movie not found");
			}

			return Ok(movie);
		}

		[HttpPost]
		public async Task<IActionResult> Add(MovieVM movie)
		{
			var newMovie = await _movieService.AddAsync(movie);
			return CreatedAtAction(nameof(GetById), new { id = newMovie.Id }, movie);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update(int id, MovieVM movie)
		{

			try
			{
				await _movieService.UpdateAsync(id, movie);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}

			return Ok("Successfully updated the movie.");
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _movieService.DeleteAsync(id);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}

			return Ok("Successfully deleted the movie.");
		}
	}
}
