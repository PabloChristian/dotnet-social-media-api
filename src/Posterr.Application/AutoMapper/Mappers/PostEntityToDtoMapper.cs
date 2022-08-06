using AutoMapper;
using Posterr.Application.Posteets.Queries;

namespace Posterr.Application.AutoMapper.Mappers
{
    public class PostEntityToDtoMapper : Profile
    {
        public PostEntityToDtoMapper()
        {
            CreateMap<Domain.Entity.Post, PostDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Post, opt => opt.MapFrom(s => s.PostMessage))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.UserScreeName, opt => opt.MapFrom(s => s.User != null ? s.User.UserScreeName : string.Empty))
                .ForMember(d => d.UserProfileImageUrl, opt => opt.MapFrom(s => s.User != null ? s.User.ProfileImageUrl : string.Empty))
                .ForMember(d => d.RepostId, opt => opt.MapFrom(s => s.RepostId))
                .ForMember(d => d.RepostPost, opt => opt.MapFrom(s => s.Repost != null ? s.Repost.PostMessage : string.Empty))
                .ForMember(d => d.RepostUserName, opt => opt.MapFrom(s => s.Repost.UserName))
                .ForMember(d => d.RepostUserScreenName, opt => opt.MapFrom(s => s.Repost != null ? s.Repost.User.UserScreeName : string.Empty))
                .ForMember(d => d.RepostUserProfileImageUrl, opt => opt.MapFrom(s => s.Repost != null ? s.Repost.User.ProfileImageUrl : string.Empty))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created));
        }
    }
}
