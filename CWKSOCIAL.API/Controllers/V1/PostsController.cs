using Microsoft.AspNetCore.Mvc;

namespace CWKSOCIAL.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class PostsController : Controller
    {
        //[MapToApiVersion("2.0")]
        [HttpGet]
        [Route(ApiRoutes.Posts.IdRoute)]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}
