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

        // Injektiranje MoviesService u konstruktoru
        public MovieController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        // Dohvaćanje svih filmova
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _moviesService.GetAllMovies();
            return Ok(movies); // Vraćanje svih filmova
        }

        // Dohvaćanje jednog filma prema ID-u
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _moviesService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound(); // Ako film nije pronađen, vraćamo 404
            }
            return Ok(movie); // Vraćanje filma s danim ID-em
        }

        // Ažuriranje postojećeg filma
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            // Ažuriramo film koristeći MoviesService
            var isUpdated = _moviesService.UpdateMovie(id, updatedMovie);
            if (!isUpdated)
            {
                return NotFound(); // Ako film nije pronađen za ažuriranje
            }
            return NoContent(); // Vraćanje statusa 204 (No Content) nakon uspješnog ažuriranja
        }

        // Brisanje filma prema ID-u
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var isDeleted = _moviesService.DeleteMovie(id);
            if (!isDeleted)
            {
                return NotFound(); // Ako film nije pronađen za brisanje
            }
            return NoContent(); // Vraćanje statusa 204 (No Content) nakon uspješnog brisanja
        }

        // Dodavanje novog filma
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie newMovie)
        {
            _moviesService.AddMovie(newMovie);
            return CreatedAtAction(nameof(GetMovie), new { id = newMovie.Id }, newMovie); // Vraća status 201 (Created) i novog filma
        }
    }
}
