using CWKSOCIAL.Application.Enums;
using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Application.UserProfiles.Commands;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using CWKSOCIAL.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CWKSOCIAL.Application.UserProfiles.CommandHandlers
{
    internal class UpdateUserProfileBasicInfoHandler : IRequestHandler<UpdateUserProfileBasicInfoCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;

        public UpdateUserProfileBasicInfoHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileBasicInfoCommand request,
            CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
                var userProfile = await _ctx.UserProfiles
                .FirstOrDefaultAsync(up => up.Id == request.UserProfileId);

                if (userProfile == null)
                {
                    result.IsError = true;
                    var error = new Error { Code = ErrorCode.NotFound, Message = $"No UserProfile found with ID {request.UserProfileId}" };
                    result.Errors.Add(error);
                    return result;
                }

                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                        request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);

                userProfile.UpdateBasicInfo(basicInfo);

                _ctx.UserProfiles.Update(userProfile);
                await _ctx.SaveChangesAsync(cancellationToken);

                result.Payload = userProfile;
                return result;
            }
            catch (UserProfileNotValidException ex)
            {
                result.IsError = true;
                foreach (var e in ex.ValidationErrors)
                {
                    var error = new Error { Code = Enums.ErrorCode.ValidationError, Message = $"{ex.Message}" };
                    result.Errors.Add(error);
                };

                return result;
            }

            catch (Exception e)
            {
                var error = new Error { Code = Enums.ErrorCode.UnknownError, Message = e.Message };
                return result;
            }
        }
    }
}
