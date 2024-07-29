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
    public class RemovePostInteractionCommandHandler : IRequestHandler<RemovePostInteractionCommand, OperationResult<PostInteraction>>
    {
        private readonly DataContext _ctx;

        public RemovePostInteractionCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<PostInteraction>> Handle(RemovePostInteractionCommand request,
            CancellationToken cancellationToken)
        {
            var result = new OperationResult<PostInteraction>();
            //try
            //{
            //    var post = await _ctx.Posts
            //        .Include(p => p.Interactions)
            //        .FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken);

            //    if (post is null)
            //    {
            //        result.AddError(ErrorCode.NotFound,
            //            string.Format(PostsErrorMessages.PostNotFound, request.PostId));
            //        return result;
            //    }

            //    var interaction = post.Interactions.FirstOrDefault(i
            //        => i.InteractionId == request.InteractionId);

            //    if (interaction == null)
            //    {
            //        result.AddError(ErrorCode.NotFound, PostsErrorMessages.PostInteractionNotFound);
            //        return result;
            //    }

            //    if (interaction.UserProfileId != request.UserProfileId)
            //    {
            //        result.AddError(ErrorCode.InteractionRemovalNotAuthorized,
            //            PostsErrorMessages.InteractionRemovalNotAuthorized);
            //        return result;
            //    }

            //    post.RemoveInteraction(interaction);
            //    _ctx.Posts.Update(post);
            //    await _ctx.SaveChangesAsync(cancellationToken);

            //    result.Payload = interaction;
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
