using CWKSOCIAL.API.Contracts.Posts.Requests;
using CWKSOCIAL.API.Contracts.Posts.Responses;
using CWKSOCIAL.API.Filters;
using CWKSOCIAL.Application.Posts.CommandHandlers;
using CWKSOCIAL.Application.Posts.Commands;
using CWKSOCIAL.Application.Posts.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CWKSOCIAL.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class PostsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllPosts(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllPosts(), cancellationToken);
            var mapped = _mapper.Map<List<PostResponse>>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(mapped);
        }

        [HttpGet]
        [Route(ApiRoutes.Posts.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var postId = Guid.Parse(id);
            var query = new GetPostById() { PostId = postId };
            var result = await _mediator.Send(query, cancellationToken);
            var mapped = _mapper.Map<PostResponse>(result.Payload);

            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(mapped);
        }

        //[HttpPost]
        //[ValidateModel]
        //public async Task<IActionResult> CreatePost([FromBody] PostCreateRequest newPost, CancellationToken cancellationToken)
        //{
        //    var userProfileId = HttpContext.GetUserProfileIdClaimValue();

        //    var command = new CreatePostCommand()
        //    {
        //        UserProfileId = userProfileId,
        //        TextContent = newPost.TextContent
        //    };

        //    var result = await _mediator.Send(command, cancellationToken);
        //    var mapped = _mapper.Map<PostResponse>(result.Payload);

        //    return result.IsError ? HandleErrorResponse(result.Errors)
        //        : CreatedAtAction(nameof(GetById), new { id = result.Payload.UserProfileId }, mapped);
        //}
    }
}
