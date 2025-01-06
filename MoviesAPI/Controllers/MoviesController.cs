using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesServices MoviesServices { get; set; }
        public MoviesController(MoviesServices moviesServices) 
        {
            MoviesServices = moviesServices;
                }
        [HttpPost]
        public IActionResult addMovie([FromBody] MovieVM movie)
        {
            MoviesServices.AddMovie(movie);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = MoviesServices.GetAllMovies();
            return Ok(allMovies);
        }
        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = MoviesServices.GetMovieById(id);
            return Ok(movie);
        }
        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id,
[FromBody] MovieVM movieVM)
        {
            var updatedMovie = MoviesServices.UpdateMovieById(id, movieVM);
            return Ok(updatedMovie);
        }
        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MoviesServices.DeleteMovie(id);
            return Ok();
        }

    }
}
