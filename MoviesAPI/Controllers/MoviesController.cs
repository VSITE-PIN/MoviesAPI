using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Model;
using MoviesAPI.Services;
using static MoviesAPI.Data.Movie;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private object? allMovies;

        public MoviesService MoviesService { get; set; }
        public MoviesController(MoviesService moviesService)
        {
            MoviesService = moviesService;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            MoviesService.AddBook(movie);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allBooks = MoviesService.GetAllMovies();
            return Ok(allMovies);
        }


        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = MoviesService.GetMovieById(id);
            return Ok(movie);
        }
        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id,
        [FromBody] MovieVM movieVM)
        {
            var updatedMovie = MoviesService.UpdateMovieById(id, movieVM);
            return Ok(updatedMovie);
        }
        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MoviesService.DeleteMovie(id);
            return Ok();
        }
    }

}
