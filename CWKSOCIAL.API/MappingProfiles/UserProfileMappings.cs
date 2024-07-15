using AutoMapper;
using CWKSOCIAL.API.Contracts.UserProfile.Requests;
using CWKSOCIAL.API.Contracts.UserProfile.Responses;
using CWKSOCIAL.Application.UserProfiles.Commands;
using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;

namespace CWKSOCIAL.API.MappingProfiles
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings()
        {
            CreateMap<UserProfileCreateUpdateCommand, CreateUserCommand>();
            CreateMap<UserProfileCreateUpdateCommand, UpdateUserProfileBasicInfoCommand>();
            CreateMap<UserProfile, UserProfileResponse>()
                .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.Id));
            CreateMap<BasicInfo, BasicInformationResponse>();
        }
    }
}
