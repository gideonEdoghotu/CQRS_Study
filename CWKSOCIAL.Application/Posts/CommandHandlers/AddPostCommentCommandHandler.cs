using CWKSOCIAL.Application.Enums;
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
    public class AddPostCommentCommandHandler : IRequestHandler<AddPostCommentCommand, OperationResult<PostComment>>
    {
        private readonly DataContext _ctx;

        public AddPostCommentCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<PostComment>> Handle(AddPostCommentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PostComment>();

            //try
            //{
            //    var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.PostId == request.PostId,
            //        cancellationToken: cancellationToken);
            //    if (post is null)
            //    {
            //        result.AddError(ErrorCode.NotFound,
            //            string.Format(PostsErrorMessages.PostNotFound, request.PostId));
            //        return result;
            //    }

            //    var comment = PostComment.CreatePostComment(request.PostId, request.CommentText, request.UserProfileId);

            //    post.AddPostComment(comment);

            //    _ctx.Posts.Update(post);
            //    await _ctx.SaveChangesAsync(cancellationToken);

            //    result.Payload = comment;

            //}

            //catch (PostCommentNotValidException e)
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
