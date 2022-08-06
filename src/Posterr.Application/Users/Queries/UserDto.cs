using AutoMapper;
using Posterr.Application.Common.Mappings;
using Posterr.Domain.Entities;
using System.Linq;

namespace Posterr.Application.Users.Queries
{
    public class UserDto : IMapFrom<User>
    {
        public string UserName { get; set; }
        public string UserScreeName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Joined { get; set; }
        public int PosteetsCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.UserScreeName, opt => opt.MapFrom(s => s.UserScreeName))
                .ForMember(d => d.ProfileImageUrl, opt => opt.MapFrom(s => s.ProfileImageUrl))
                .ForMember(d => d.Joined, opt => opt.MapFrom(s => s.Joined.ToString("MMMM dd, yyyy")))
                .ForMember(d => d.PosteetsCount, opt => opt.MapFrom(s => s.Posteets.Any() ? s.Posteets.Count : 0));
        }
    }
}
