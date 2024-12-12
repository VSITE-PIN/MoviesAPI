using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.ViewModel;
using System.Diagnostics.Metrics;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesService _moviesService { get; set; }
        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allBooks = _moviesService.GetAllMovies();
            return Ok(allBooks);
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            _moviesService.AddMovie(movie);
            return Ok();    
        }

        [HttpGet("id")]
        public IActionResult GetBookById([FromQuery] int id)
        {
            var book = _moviesService.GetMovieById(id);
            return Ok(book);
        }
        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id,
        [FromBody] MovieVM movieVM)
        {
            var updatedMovie = _moviesService.UpdateMovieById(id, movieVM);
            return Ok(updatedMovie);
        }
        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            _moviesService.DeleteMovie(id);
            return Ok();
        }
    }
}
