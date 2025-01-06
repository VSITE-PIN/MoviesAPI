using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;
  


namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        public DirectorsServices DirectorsServices { get; set; }
        public DirectorsController(DirectorsServices directorsServices)
        {
            DirectorsServices = directorsServices;
        }
        [HttpPost]
        public IActionResult AddDirector([FromBody] DirectorVM director)
        {
            DirectorsServices.AddDirector(director);
            return Ok();
        }
    }
}
