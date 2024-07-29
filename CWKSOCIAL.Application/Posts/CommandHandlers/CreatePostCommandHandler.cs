using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Application.Posts.Commands;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.PostAggregate;
using CWKSOCIAL.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Application.Posts.CommandHandlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, OperationResult<Post>>
    {
        private readonly DataContext _ctx;

        public CreatePostCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<Post>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Post>();
            //try
            //{
            //    var post = Post.CreatePost(request.UserProfileId, request.TextContent);
            //    _ctx.Posts.Add(post);
            //    await _ctx.SaveChangesAsync(cancellationToken);

            //    result.Payload = post;
            //}
            //catch (PostNotValidException e)
            //{
            //    e.ValidationErrors.ForEach(er => result.AddError(ErrorCode.ValidationError, er));
            //}

            //catch (Exception e)
            //{
            //    result.AddUnknownError(e.Message);
            //}

            return result;
        }
    }
}
