using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.Viewmodel;
using MoviesAPI.Data;


namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesService MoviesService { get; set; }
        public MoviesController(MoviesService moviesService)
        {
            MoviesService = moviesService;
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            MoviesService.AddMovie(movie);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = MoviesService.GetAllMovies();
            return Ok(allMovies);
        }
        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = MoviesService.GetById(id);
            return Ok(movie);
        }
        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id,
[FromBody] MovieVM movieVM)
        {
            var updatedMovie = MoviesService.UpdateById(id, movieVM);
            return Ok(updatedMovie);
        }
        [HttpDelete("id")]
        public IActionResult DeleteBook([FromQuery] int id)
        {
            MoviesService.DeleteMovie(id);
            return Ok();
        }
    }
}
