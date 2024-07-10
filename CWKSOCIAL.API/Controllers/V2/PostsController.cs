using CWKSOCIAL.Domain.PostModel;
using Microsoft.AspNetCore.Mvc;
using ApiVersion = Microsoft.AspNetCore.Mvc.ApiVersion;

namespace CWKSOCIAL.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var post = new Post { Id = id, Text = "Hello universe" };
            return Ok(post);
        }
    }
}
