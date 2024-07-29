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
    public class UpdatePostTextCommandHandler : IRequestHandler<UpdatePostTextCommand, OperationResult<Post>>
    {
        private readonly DataContext _ctx;

        public UpdatePostTextCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<Post>> Handle(UpdatePostTextCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Post>();

            //try
            //{
            //    var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken: cancellationToken);

            //    if (post is null)
            //    {
            //        result.AddError(ErrorCode.NotFound,
            //            string.Format(PostsErrorMessages.PostNotFound, request.PostId));
            //        return result;
            //    }

            //    if (post.UserProfileId != request.UserProfileId)
            //    {
            //        result.AddError(ErrorCode.PostUpdateNotPossible, PostsErrorMessages.PostUpdateNotPossible);
            //        return result;
            //    }

            //    post.UpdatePostText(request.NewText);

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

            //return result;

            return null;
        }
    }
}
