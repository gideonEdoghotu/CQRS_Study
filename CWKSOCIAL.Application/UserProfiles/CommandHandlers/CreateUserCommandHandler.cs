using CWKSOCIAL.Application.UserProfiles.Commands;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace CWKSOCIAL.Application.UserProfiles.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        public CreateUserCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
            var userProfile = UserProfile.CreateUserProfile(request.UserProfileId.ToString(), basicInfo);
            _ctx.UserProfiles.Add(userProfile);
            await _ctx.SaveChangesAsync();
            return userProfile;
        }

        private readonly DataContext _ctx;
    }
}
