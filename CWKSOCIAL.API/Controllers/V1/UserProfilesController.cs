using AutoMapper;
using CWKSOCIAL.API.Contracts.UserProfile.Requests;
using CWKSOCIAL.API.Contracts.UserProfile.Responses;
using CWKSOCIAL.Application.UserProfiles.Commands;
using CWKSOCIAL.Application.UserProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CWKSOCIAL.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfilesController : Controller
    {
        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles(CancellationToken cancellationToken)
        {
            var query = new GetAllUserProfiles();
            var response = await _mediator.Send(query, cancellationToken);
            var profiles = _mapper.Map<List<UserProfileResponse>>(response);
            return Ok(profiles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdateCommand profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            command.UserProfileId = Guid.NewGuid();
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = response.Id }, userProfile);
        }

        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpGet]
        //[ValidateGuid("id")]
        public async Task<IActionResult> GetUserProfileById(string id, CancellationToken cancellationToken)
        {
            var query = new GetUserProfileById { Id = Guid.Parse(id) };
            var response = await _mediator.Send(query, cancellationToken);
            var userProfile = _mapper.Map<UserProfileResponse>(response);
            return Ok(userProfile);
        }

        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        //[ValidateModel]
        //[ValidateGuid("id")]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdateCommand updatedProfile,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInfoCommand>(updatedProfile);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(string id, UserProfileCreateUpdateCommand updatedProfile,
            CancellationToken cancellationToken)
        {
            var command = new DeleteUserProfileCommand() { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
    }
}
