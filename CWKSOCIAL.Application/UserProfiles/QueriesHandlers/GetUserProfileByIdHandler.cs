using CWKSOCIAL.Application.UserProfiles.Queries;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CWKSOCIAL.Application.UserProfiles.QueriesHandlers
{
    internal class GetUserProfileByIdHandler
        : IRequestHandler<GetUserProfileById, UserProfile>
    {
        private readonly DataContext _ctx;

        public GetUserProfileByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UserProfile> Handle(GetUserProfileById request,
            CancellationToken cancellationToken)
        {
            return await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.Id == request.Id, cancellationToken);
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
