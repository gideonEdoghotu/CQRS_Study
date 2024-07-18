﻿using CWKSOCIAL.Application.Models;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace CWKSOCIAL.Application.UserProfiles.Commands
{
    public class UpdateUserProfileBasicInfoCommand : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentCity { get; set; }
    }
}
