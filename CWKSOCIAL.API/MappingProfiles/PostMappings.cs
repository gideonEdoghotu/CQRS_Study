using AutoMapper;
using CWKSOCIAL.API.Contracts.Posts.Responses;
using CWKSOCIAL.Domain.Aggregates.PostAggregate;

namespace CWKSOCIAL.API.MappingProfiles
{
    public class PostMappings : Profile
    {
        public PostMappings()
        {
            CreateMap<Post, PostResponse>();
            CreateMap<PostComment, PostCommentResponse>();
            //CreateMap<PostInteraction, PostInteraction>()
            //    .ForMember(dest
            //        => dest.Type, opt
            //        => opt.MapFrom(src
            //        => src.InteractionType.ToString()))
            //    .ForMember(dest => dest.Author, opt
            //    => opt.MapFrom(src => src.UserProfile));
        }
    }
}
