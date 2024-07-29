using AutoMapper;
using CWKSOCIAL.API.Contracts.Posts.Responses;
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
            //CreateMap<UserProfile, InteractionUser>()
            //    .ForMember(dest => dest.FullName, opt
            //    => opt.MapFrom(src
            //    => src.BasicInfo.FirstName + " " + src.BasicInfo.LastName))
            //    .ForMember(dest => dest.City, opt
            //    => opt.MapFrom(src => src.BasicInfo.CurrentCity));
            CreateMap<BasicInfo, BasicInformationResponse>();
        }
    }
}
