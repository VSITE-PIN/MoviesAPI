using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly MoviesService _service;

    public MovieController(MoviesService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllMovies()
    {
        var movies = _service.GetAllMovies();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _service.GetMovieById(id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        _service.AddMovie(movie);
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
    {
        if (id != movie.Id) return BadRequest();
        _service.UpdateMovie(movie);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        _service.DeleteMovie(id);
        return NoContent();
    }
}
