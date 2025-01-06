using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublishersService PublishersService { get; set; }
        public PublishersController(PublishersService publishersService)
        {
            PublishersService = publishersService;
        }
        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            PublishersService.AddPublisher(publisher);
            return Ok();
        }
    }

}
