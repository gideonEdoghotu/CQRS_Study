using CWKSOCIAL.Application.Enums;
using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Application.Posts.Queries;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.PostAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Application.Posts.QueriesHandlers
{
    public class GetPostByIdHandler : IRequestHandler<GetPostById, OperationResult<Post>>
    {
        public GetPostByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Post>> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Post>();
            var post = await _ctx.Posts
                .FirstOrDefaultAsync(p => p.Id == request.PostId);

            if (post is null)
            {
                //result.AddError(ErrorCode.NotFound,
                //    string.Format(PostsErrorMessages.PostNotFound, request.PostId));
                result.IsError = true;
                var error = new Error { Code = ErrorCode.NotFound, Message =  $"Np Post found with ID  {request.PostId}" };
                result.Errors.Add(error);
                return result;
            }

            result.Payload = post;
            return result;
        }

        private readonly DataContext _ctx;
    }
}
