﻿using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Application.Posts.Commands
{
    public class RemovePostInteractionCommand : IRequest<OperationResult<PostInteraction>>
    {
        public Guid PostId { get; set; }
        public Guid InteractionId { get; set; }
        public Guid UserProfileId { get; set; }
    }
}