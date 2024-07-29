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
    public class AddInteractionCommandHandler : IRequestHandler<AddInteractionCommand, OperationResult<PostInteraction>>
    {
        private readonly DataContext _ctx;

        public AddInteractionCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<PostInteraction>> Handle(AddInteractionCommand request,
            CancellationToken cancellationToken)
        {
            var result = new OperationResult<PostInteraction>();
            //try
            //{
            //    var post = await _ctx.Posts.Include(p => p.Interactions)
            //        .FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken);

            //    if (post == null)
            //    {
            //        result.AddError(ErrorCode.NotFound, PostsErrorMessages.PostNotFound);
            //        return result;
            //    }

            //    var interaction = PostInteraction.CreatePostInteraction(request.PostId, request.UserProfileId,
            //        request.Type);

            //    post.AddInteraction(interaction);

            //    _ctx.Posts.Update(post);
            //    await _ctx.SaveChangesAsync(cancellationToken);

            //    result.Payload = interaction;

            //}
            //catch (Exception e)
            //{
            //    result.AddUnknownError(e.Message);
            //}

            return result;
        }
    }
}
