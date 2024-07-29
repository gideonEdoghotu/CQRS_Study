using AutoMapper;
using CWKSOCIAL.API.Contracts.UserProfile.Requests;
using CWKSOCIAL.API.Contracts.UserProfile.Responses;
using CWKSOCIAL.API.Filters;
using CWKSOCIAL.Application.UserProfiles.Commands;
using CWKSOCIAL.Application.UserProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CWKSOCIAL.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfilesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProfiles(CancellationToken cancellationToken)
        {
            var query = new GetAllUserProfiles();
            var response = await _mediator.Send(query, cancellationToken);
            var profiles = _mapper.Map<List<UserProfileResponse>>(response.Payload);
            return Ok(profiles);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdateCommand profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            command.UserProfileId = Guid.NewGuid();
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = userProfile.UserProfileId }, userProfile);
        }

        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpGet]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetUserProfileById(string id, CancellationToken cancellationToken)
        {
            var query = new GetUserProfileById { Id = Guid.Parse(id) };
            var response = await _mediator.Send(query, cancellationToken);

            if (response.IsError)
                return HandleErrorResponse(response.Errors);

            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);
            return Ok(userProfile);
        }

        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [ValidateModel]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdateCommand updatedProfile,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInfoCommand>(updatedProfile);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command, cancellationToken);

            return response.IsError ? HandleErrorResponse(response.Errors) : NoContent();
            //if (response.IsError)
            //    return HandleErrorResponse(response.Errors);

            //return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> DeleteUserProfile(string id, UserProfileCreateUpdateCommand updatedProfile,
            CancellationToken cancellationToken)
        {
            var command = new DeleteUserProfileCommand() { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command);
            return response.IsError ? HandleErrorResponse(response.Errors) : NoContent();
        }
    }
}
