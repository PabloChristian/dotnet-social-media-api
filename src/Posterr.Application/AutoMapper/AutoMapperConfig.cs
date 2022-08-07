using AutoMapper;
using Posterr.Application.AutoMapper.Mappers;

namespace Posterr.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PostEntityToDtoMapper());
                cfg.AddProfile(new PostEntityToViewModelMapper());
            });
        }
    }
}
