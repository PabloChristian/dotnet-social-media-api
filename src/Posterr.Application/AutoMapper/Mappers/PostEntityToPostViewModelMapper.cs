using AutoMapper;
using Posterr.Domain.ViewModel.Posts;

namespace Posterr.Application.AutoMapper.Mappers
{
    public class PostEntityToPostViewModelMapper : Profile
    {
        public PostEntityToPostViewModelMapper()
        {
            CreateMap<Domain.Entity.Post, PostViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.PostMessage, opt => opt.MapFrom(s => s.PostMessage))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
                .ForMember(d => d.RepostId, opt => opt.MapFrom(s => s.RepostId))
                .ForMember(d => d.RepostPost, opt => opt.MapFrom(s => s.Repost != null ? s.Repost.PostMessage : string.Empty))
                .ForMember(d => d.RepostUserName, opt => opt.MapFrom(s => s.Repost.UserName))
                .ForMember(d => d.RepostUserScreenName, opt => opt.MapFrom(s => s.Repost != null ? s.Repost.User.UserScreenName : string.Empty))
                .ForMember(d => d.RepostUserProfileImageUrl, opt => opt.MapFrom(s => s.Repost != null ? s.Repost.User.ProfileImageUrl : string.Empty));
        }
    }
}
