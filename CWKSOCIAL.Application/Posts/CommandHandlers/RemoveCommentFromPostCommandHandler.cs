using CWKSOCIAL.Application.Enums;
using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Application.Posts.Commands;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Application.Posts.CommandHandlers
{
    public class RemoveCommentFromPostCommandHandler
    : IRequestHandler<RemoveCommentFromPostCommand, OperationResult<PostComment>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<PostComment> _result;

        public RemoveCommentFromPostCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
            _result = new OperationResult<PostComment>();
        }

        public async Task<OperationResult<PostComment>> Handle(RemoveCommentFromPostCommand request,
            CancellationToken cancellationToken)
        {
            //var post = await _ctx.Posts
            //    .Include(p => p.Comments)
            //    .FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken);

            //if (post == null)
            //{
            //    _result.AddError(ErrorCode.NotFound, PostsErrorMessages.PostNotFound);
            //    return _result;
            //}

            //var comment = post.Comments
            //    .FirstOrDefault(c => c.CommentId == request.CommentId);
            //if (comment == null)
            //{
            //    _result.AddError(ErrorCode.NotFound, PostsErrorMessages.PostCommentNotFound);
            //    return _result;
            //}

            //if (comment.UserProfileId != request.UserProfileId)
            //{
            //    _result.AddError(ErrorCode.CommentRemovalNotAuthorized,
            //        PostsErrorMessages.CommentRemovalNotAuthorized);
            //    return _result;
            //}

            //post.RemoveComment(comment);
            //_ctx.Posts.Update(post);
            //await _ctx.SaveChangesAsync(cancellationToken);

            //_result.Payload = comment;
            //return _result;

            return null;
        }
    }
}
