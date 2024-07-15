using CWKSOCIAL.Application.UserProfiles.Queries;
using CWKSOCIAL.Dal;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Application.UserProfiles.QueriesHandlers
{
    internal class GetAllUserProfilesHandler
        : IRequestHandler<GetAllUserProfiles, IEnumerable<UserProfile>>
    {
        private readonly DataContext _ctx;
        public GetAllUserProfilesHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfiles request,
            CancellationToken cancellationToken)
        {
            var profiles = await _ctx.UserProfiles.ToListAsync();
            return profiles;
            //var result = new IEnumerable<UserProfile>();
            //result.Payload = await _ctx.UserProfiles.ToListAsync(cancellationToken: cancellationToken);
            //return result;
        }
    }
}
