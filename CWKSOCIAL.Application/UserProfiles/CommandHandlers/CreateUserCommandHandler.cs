using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Application.UserProfiles.Commands;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace CWKSOCIAL.Application.UserProfiles.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
    {
        public CreateUserCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
            var userProfile = UserProfile.CreateUserProfile(request.UserProfileId.ToString(), basicInfo);
            _ctx.UserProfiles.Add(userProfile);
            await _ctx.SaveChangesAsync();

            result.Payload = userProfile;
            return result;
        }

        private readonly DataContext _ctx;
    }
}
