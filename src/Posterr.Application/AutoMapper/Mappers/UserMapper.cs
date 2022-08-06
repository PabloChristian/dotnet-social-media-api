using AutoMapper;
using Posterr.Application.Users.Queries;
using Posterr.Domain.Entity;

namespace Posterr.Application.AutoMapper.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>();
        }
    }
}
