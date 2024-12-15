using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Service;
using MoviesAPI.VM;

namespace MoviesAPI.Controllers
{

	//public IActionResult AddMovie();
	//	var allMovies = MovieService.GetAllMovies();
	//return Ok(allMovies); 




	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		public MovieService MovieService { get; set; }

		public MoviesController(MovieService movieService)
		{
			MovieService = movieService;


		}
		//public Movie GetMovie() { return MovieService.getMovieByID(); }

		[HttpPost]
		public IActionResult AddMovie([FromBody] MovieVM movie)
		{
			MovieService.AddMovie(movie);
			return Ok();

		}
		[HttpGet]

		public IActionResult GetAllMovies()
		{
			List<Movie> allmovies = MovieService.GetMovies();
			return Ok(allmovies);
		}
		[HttpGet("Id")]
		public IActionResult GetMovieByID([FromQuery] int id)
		{
			Movie movie = MovieService.GetMovieByID(id);
			return Ok(movie);
		}
		[HttpPut("Id")]
		public IActionResult EditMovieByID([FromQuery] int id, [FromBody] MovieVM movieVM)
		{
			Movie movie = MovieService.EditMovie(id, movieVM);
			return Ok(movie);
		}

		[HttpDelete("Id")]
		public IActionResult RemoveMovie([FromQuery] int id)
		{
			MovieService.DeleteMovie(id);
			return Ok();
		}
	}
}

