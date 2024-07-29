using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace CWKSOCIAL.Application.UserProfiles.Queries
{
    public class GetAllUserProfiles : IRequest<OperationResult<IEnumerable<UserProfile>>>
    {
    }
}
