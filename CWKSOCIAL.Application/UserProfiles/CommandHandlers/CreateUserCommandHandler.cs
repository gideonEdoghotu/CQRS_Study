using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Application.UserProfiles.Commands;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using CWKSOCIAL.Domain.Exceptions;
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
            try
            {
                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
                var userProfile = UserProfile.CreateUserProfile(request.UserProfileId.ToString(), basicInfo);
                _ctx.UserProfiles.Add(userProfile);
                await _ctx.SaveChangesAsync();

                result.Payload = userProfile;
                //return result;
            }
            catch (UserProfileNotValidException ex)
            {
                result.IsError = true;
                foreach (var e in ex.ValidationErrors)
                {
                    var error = new Error { Code = Enums.ErrorCode.ValidationError, Message = $"{ex.Message}" };
                    result.Errors.Add(error);
                };
            }

            catch (Exception e)
            {
                var error = new Error { Code = Enums.ErrorCode.UnknownError, Message = e.Message };
                result.IsError = true;
                result.Errors.Add(error);
            }

            return result;
        }

        private readonly DataContext _ctx;
    }
}
