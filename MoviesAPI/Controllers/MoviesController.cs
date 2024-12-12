using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    public class MoviesController : ControllerBase
    {
        public MovieService MovieService { get; set; }
        public MoviesController(MovieService moviesService)
        {
            MovieService = moviesService;
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            MovieService.AddMovie(movie);
            return Ok();
        }
    }
}

