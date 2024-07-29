using CWKSOCIAL.Application.Enums;
using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Application.UserProfiles.Queries;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CWKSOCIAL.Application.UserProfiles.QueriesHandlers
{
    internal class GetUserProfileByIdHandler
        : IRequestHandler<GetUserProfileById, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;

        public GetUserProfileByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<UserProfile>> Handle(GetUserProfileById request,
            CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();
            var profile = await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.Id == request.Id, cancellationToken);

            if (profile == null)
            {
                result.IsError = true;
                var error = new Error { Code = ErrorCode.NotFound, Message = $"No UserProfile found with ID {request.Id}"};
                result.Errors.Add(error);
                return result;
            }

            result.Payload = profile;
            return result;

            //var result = new OperationResult<UserProfileDto>();

            //var profile = await _ctx.UserProfiles
            //    .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId,
            //        cancellationToken: cancellationToken);

            //if (profile is null)
            //{
            //    result.AddError(ErrorCode.NotFound,
            //        string.Format(UserProfilesErrorMessages.UserProfileNotFound, request.UserProfileId));
            //    return result;
            //}

            //var friendRequests = await _ctx.FriendRequests
            //    .Where(fr => fr.ReceiverUserProfileId == request.UserProfileId)
            //    .ToListAsync();

            //var friendships = await _ctx.Friendships
            //    .Where(f => f.FirstFriendUserProfileId == request.UserProfileId
            //                || f.SecondFriendUserProfileId == request.UserProfileId)
            //    .ToListAsync();

            //result.Payload = UserProfileDto.FromUserProfile(profile, friendRequests, friendships);
            //return result;
        }
    }
}
