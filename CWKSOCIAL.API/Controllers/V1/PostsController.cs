using CWKSOCIAL.Domain.Aggregates.PostAggregate;
using Microsoft.AspNetCore.Mvc;

namespace CWKSOCIAL.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        //[MapToApiVersion("2.0")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var post = new Post { Id = id, Text = "Hello world" };
            return Ok(post);
        }
    }
}
