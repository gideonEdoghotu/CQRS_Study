using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Application.Posts.Commands
{
    public class CreatePostCommand : IRequest<OperationResult<Post>>
    {
        public Guid UserProfileId { get; set; }
        public string TextContent { get; set; }
    }
}
