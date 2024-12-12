using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Service;

namespace MoviesAPI.Controllers
{

	public IActionResult GetAllMovies();{
		var allMovies = MovieService.GetAllMovies();
	return Ok(allMovies); }




	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		public MovieService MovieService { get; set; }
	
		public MoviesController(MovieService movieService)
		{
			MovieService = movieService;

		public Movie GetMovie() { return Movie; }

		[HttpPost]
			public IActionResult AddMovie([FromBody] MovieVM book, Movie movie)
			{
				MovieService.AddMovie(movie);
				return Ok();
			}
		} }
	}

