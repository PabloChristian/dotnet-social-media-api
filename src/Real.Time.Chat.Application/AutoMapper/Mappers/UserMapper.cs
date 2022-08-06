using AutoMapper;
using Posterr.Domain.Commands;
using Posterr.Domain.Entity;
using Posterr.Shared.Kernel.Entity;

namespace Posterr.Application.AutoMapper.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserAddCommand, User>();
            CreateMap<User, UserDto>();
        }
    }
}
