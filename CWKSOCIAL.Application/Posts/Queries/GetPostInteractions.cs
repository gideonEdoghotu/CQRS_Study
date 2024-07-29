using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Application.Posts.Queries
{
    public class GetPostInteractions : IRequest<OperationResult<List<PostInteraction>>>
    {
        public Guid PostId { get; set; }
    }
}
