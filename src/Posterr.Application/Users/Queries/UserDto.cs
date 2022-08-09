using AutoMapper;
using Posterr.Application.AutoMapper;
using Posterr.Domain.Entity;

namespace Posterr.Application.Users.Queries
{
    public class UserDto : IMapFrom<User>
    {
        public string UserName { get; set; }
        public string UserScreeName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Joined { get; set; }
        public int PostsCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.UserScreeName, opt => opt.MapFrom(s => s.UserScreenName))
                .ForMember(d => d.ProfileImageUrl, opt => opt.MapFrom(s => s.ProfileImageUrl))
                .ForMember(d => d.Joined, opt => opt.MapFrom(s => Convert.ToDateTime(s.Created).ToString("MMMM dd, yyyy")))
                .ForMember(d => d.PostsCount, opt => opt.MapFrom(s => s.PostMessage.Any() ? s.PostMessage.Count : 0));
        }
    }
}
