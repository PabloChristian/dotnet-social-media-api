using AutoMapper;
using Posterr.Application.Common.Mappings;
using Posterr.Domain.Entities;
using System;

namespace Posterr.Application.Posteets.Queries
{
    public class PostDto : IMapFrom<Posteet>
    {
        public int PosteetId { get; set; }
        public string Post { get; set; }
        public string UserName { get; set; }
        public string UserScreeName { get; set; }
        public string UserProfileImageUrl { get; set; }
        public int? ReposteetId { get; set; }
        public string ReposteetPost { get; set; }
        public string ReposteetUserName { get; set; }
        public string ReposteetUserScreeName { get; set; }
        public string ReposteetUserProfileImageUrl { get; set; }
        public DateTime Created { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostDto>()
                .ForMember(d => d.PosteetId, opt => opt.MapFrom(s => s.PosteetId))
                .ForMember(d => d.Post, opt => opt.MapFrom(s => s.Post))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.UserScreeName, opt => opt.MapFrom(s => s.User != null ? s.User.UserScreeName : string.Empty))
                .ForMember(d => d.UserProfileImageUrl, opt => opt.MapFrom(s => s.User != null ? s.User.ProfileImageUrl : string.Empty))
                .ForMember(d => d.ReposteetId, opt => opt.MapFrom(s => s.ReposteetId))
                .ForMember(d => d.ReposteetPost, opt => opt.MapFrom(s => s.Reposteet != null ? s.Reposteet.Post : string.Empty))
                .ForMember(d => d.ReposteetUserName, opt => opt.MapFrom(s => s.Reposteet != null ? s.Reposteet.UserName : string.Empty))
                .ForMember(d => d.ReposteetUserScreeName, opt => opt.MapFrom(s => s.Reposteet != null ? s.Reposteet.User.UserScreeName : string.Empty))
                .ForMember(d => d.ReposteetUserProfileImageUrl, opt => opt.MapFrom(s => s.Reposteet != null ? s.Reposteet.User.ProfileImageUrl : string.Empty))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created));
        }
    }
}
