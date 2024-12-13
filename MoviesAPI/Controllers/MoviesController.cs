using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public class BooksController : ControllerBase
        {
            public MoviesService MoviesService { get; set; }
            public BooksController(MoviesService booksService)
            {
                MoviesService = booksService;
            }
            [HttpPost]
            public IActionResult AddBook([FromBody] MovieVM book)
            {
                MoviesService.AddMovie(movie);
                return Ok();
            }
        }

    }
}
