using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MoviesAPI.ViewModel.MovieVM;
using MoviesAPI.Services;
using MoviesAPI.Data;
using MoviesAPI.ViewModel;

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
            var Movie = MoviesService.GetMovieById(id);
            return Ok(Movie);
        }
        [HttpPut("id")]
        public IActionResult UpdateById([FromQuery] int id,
        [FromBody] MovieVM movieVM)
        {
            var updatedMovie = MoviesService.UpdateById(id, movieVM);
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
