using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Application.Posts.Queries;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Application.Posts.QueriesHandlers
{
    public class GetPostCommentsHandler : IRequestHandler<GetPostComments, OperationResult<List<PostComment>>>
    {
        private readonly DataContext _ctx;

        public GetPostCommentsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<List<PostComment>>> Handle(GetPostComments request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<PostComment>>();
            //try
            //{
            //    var post = await _ctx.Posts
            //        .Include(p => p.Comments)
            //        .FirstOrDefaultAsync(p => p.PostId == request.PostId);

            //    result.Payload = post.Comments.ToList();
            //}
            //catch (Exception e)
            //{
            //    result.AddUnknownError(e.Message);
            //}

            return result;
        }
    }
}
