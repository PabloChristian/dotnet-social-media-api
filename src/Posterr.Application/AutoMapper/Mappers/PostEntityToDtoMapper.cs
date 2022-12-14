using AutoMapper;
using Posterr.Domain.ViewModel.Posts;

namespace Posterr.Application.AutoMapper.Mappers
{
    public class PostEntityToDtoMapper : Profile
    {
        public PostEntityToDtoMapper()
        {
            CreateMap<Domain.Entity.Post, PostViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.PostMessage, opt => opt.MapFrom(s => s.PostMessage))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.UserScreenName, opt => opt.MapFrom(s => s.User != null ? s.User.UserScreenName : string.Empty))
                .ForMember(d => d.UserProfileImageUrl, opt => opt.MapFrom(s => s.User != null ? s.User.ProfileImageUrl : string.Empty))
                .ForMember(d => d.RepostId, opt => opt.MapFrom(s => s.RepostId))
                .ForMember(d => d.RepostPost, opt => opt.MapFrom(s => s.Repost != null ? s.Repost.PostMessage : string.Empty))
                .ForMember(d => d.RepostUserName, opt => opt.MapFrom(s => s.Repost.UserName))
                .ForMember(d => d.RepostUserScreenName, opt => opt.MapFrom(s => s.Repost != null ? s.Repost.User.UserScreenName : string.Empty))
                .ForMember(d => d.RepostUserProfileImageUrl, opt => opt.MapFrom(s => s.Repost != null ? s.Repost.User.ProfileImageUrl : string.Empty))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created));
        }
    }
}
