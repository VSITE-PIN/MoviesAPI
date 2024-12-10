using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesService _moviesService;

        // Dependency Injection MoviesService
        public MovieController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _moviesService.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            var movie = await _moviesService.GetMovieByIdAsync(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            var newMovie = await _moviesService.InsertMovieAsync(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> UpdateMovie(int id, [FromBody] Movie movie)
        {
            var updatedMovie = await _moviesService.UpdateMovieAsync(id, movie);
            if (updatedMovie == null)
                return NotFound();

            return Ok(updatedMovie);
        }

        // Ispravljena metoda za brisanje filma
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var result = await _moviesService.DeleteMovieAsync(id);

            if (!result)
                return NotFound();  // Ako film nije pronađen, vrati HTTP 404 Not Found

            return NoContent();  // Ako je uspješno obrisano, vrati HTTP 204 No Content
        }

    }
}
