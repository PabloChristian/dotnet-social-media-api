using AutoMapper;
using Posterr.Domain.Commands.Message;
using Posterr.Domain.Entity;
using System;

namespace Posterr.Application.AutoMapper.Mappers
{
    public class MessageMapper : Profile
    {
        public MessageMapper()
        {
            CreateMap<MessageAddCommand, Post>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
