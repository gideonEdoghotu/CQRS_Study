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
    public class GetAllPostsHandler : IRequestHandler<GetAllPosts, OperationResult<List<Post>>>
    {
        private readonly DataContext _ctx;
        public GetAllPostsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<List<Post>>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Post>>();
            try
            {
                var posts = await _ctx.Posts.ToListAsync();
                result.Payload = posts;
                return result;
            }
            catch (Exception e)
            {
                var error = new Error { Code = Enums.ErrorCode.UnknownError, Message = e.Message };
                result.IsError = true;
                result.Errors.Add(error);
                //return result;
            }

            return result;
        }
    }
}
